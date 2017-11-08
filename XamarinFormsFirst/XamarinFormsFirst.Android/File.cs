using System;
using System.IO;
using Xamarin.Forms;
using XamarinFormsFirst.Data;
using XamarinFormsFirst.Droid;

[assembly: Dependency(typeof(FileImpl))]
namespace XamarinFormsFirst.Droid
{
    public class FileImpl : IFile
    {
        public FileImpl() 
         {
        }

        public string ClearFile(string filename)
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(docPath, filename);
            File.Delete(filename);
            return filename;
        }

        public bool FileExists(string filename)
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(docPath, filename);
            return File.Exists(filePath);
        }

        public string LoadText(string filename)
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(docPath, filename);
            return File.ReadAllText(filePath);

        }

        public void SaveText(string filename, string text)
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(docPath, filename);
            File.Delete(filePath);
            File.WriteAllText(filePath, text);
        }
    }
}
