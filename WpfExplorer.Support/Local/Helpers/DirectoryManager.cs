using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExplorer.Support.Local.Helpers
{
    public class DirectoryManager
    {
        public string DownloadDirectory { get; set; }
        public string DocumentDirectory { get; set; }
        public string PicturesDirectory { get; set; }

        public DirectoryManager()
        {
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            DownloadDirectory = Path.Combine(userPath, "Downloads");
            DocumentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            PicturesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }
    }
}
