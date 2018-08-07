using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VaccineCalendar.Services.DalcFile;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(VaccineCalendar.iOS.DalcFile.FileImplementation))]
namespace VaccineCalendar.iOS.DalcFile
{
    public class FileImplementation : IFile
    {
        public void ClearFile(string filename)
        {
            File.Delete(GetLocalFilePath(filename));
        }

        public bool FileExists(string filename)
        {
            return File.Exists(GetLocalFilePath(filename));
        }

        public string LoadText(string filename)
        {
            return File.ReadAllText(GetLocalFilePath(filename));
        }

        public void SaveText(string filename, string text)
        {
            File.WriteAllText(GetLocalFilePath(filename), text);
        }

        private string GetLocalFilePath(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return filePath;
        }
    }
}