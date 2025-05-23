﻿using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Support.Local.Helpers
{
    public class FileService(DirectoryManager directoryManager)
    {
        private readonly DirectoryManager _directoryManager = directoryManager;

        public List<FolderInfo> GenerateRootNodes()
        {
            List<FolderInfo> roots = [
                CreateFolderInfo(1, "Download", IconType.ArrowDownBox, _directoryManager.DownloadDirectory),
                CreateFolderInfo(1, "Documents", IconType.TextBox, _directoryManager.DocumentsDirectory),
                CreateFolderInfo(1, "Pictures", IconType.Image, _directoryManager.PicturesDirectory),
            ];

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (!drive.IsReady) continue;

                var name = $"{drive.VolumeLabel} ({drive.Name.TrimEnd('\\')})";
                roots.Add(CreateFolderInfo(1, name, IconType.MicrosoftWindows, drive.Name));
            }

            return roots;
        }

        private static FolderInfo CreateFolderInfo(int depth, string name, IconType iconType, string fullPath)
        {
            return new FolderInfo
            {
                Depth = depth,
                Name = name,
                IconType = iconType,
                FullPath = fullPath,
                Children = [],
            };
        }

        public void RefreshSubdirectories(FolderInfo parent)
        {
            List<FolderInfo> newChildren = FetchSubdirectories(parent);
            
            var oldChildrenDict = parent.Children.ToDictionary(c => c.FullPath);
            var newChildrenDict = newChildren.ToDictionary(c => c.FullPath);

            var added = newChildren.Where(c => !oldChildrenDict.ContainsKey(c.FullPath)).ToList();
            var removed = parent.Children.Where(c => !newChildrenDict.ContainsKey(c.FullPath)).ToList();

            parent.Children.AddRange(added);
            foreach (var child in removed)
            {
                parent.Children.Remove(child);
            }
        }

        private List<FolderInfo> FetchSubdirectories(FolderInfo parent)
        {
            List<FolderInfo> children = [];
            try
            {
                var subDirs = Directory.GetDirectories(parent.FullPath);
                foreach (var dir in subDirs)
                {
                    children.Add(new FolderInfo
                    {
                        Depth = parent.Depth + 1,
                        Name = Path.GetFileName(dir),
                        IconType = IconType.Folder,
                        FullPath = dir,
                        Children = [],
                    });
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return children;
        }
    }
}
