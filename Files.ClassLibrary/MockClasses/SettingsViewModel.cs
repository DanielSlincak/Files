using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Files.ClassLibrary.MockClasses
{
    public class SettingsViewModel
    {
        public string DesktopPath { get; set; } = UserDataPaths.GetDefault().Desktop;
        public string DocumentsPath { get; set; } = UserDataPaths.GetDefault().Documents;
        public string DownloadsPath { get; set; } = UserDataPaths.GetDefault().Downloads;
        public string PicturesPath { get; set; } = UserDataPaths.GetDefault().Pictures;
        public string MusicPath { get; set; } = UserDataPaths.GetDefault().Music;
        public string VideosPath { get; set; } = UserDataPaths.GetDefault().Videos;
        public string RecycleBinPath { get; set; } = @"Shell:RecycleBinFolder";

    }
}
