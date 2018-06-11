using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VaccineCalendar.Services.DalcFile;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(VaccineCalendar.Droid.DalcFile.FileImplementation))]
namespace VaccineCalendar.Droid.DalcFile
{
    public class FileImplementation : IFile
    {
        public void ClearFile(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.Delete(filePath);

        }

        public bool FileExists(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.Exists(filePath);
        }

        public string LoadText(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllText(filePath);
        }

        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.Delete(filePath);
            File.WriteAllText(filePath, text);

        }
    }
}