using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
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
    }
}
