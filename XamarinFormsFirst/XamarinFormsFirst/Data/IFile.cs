using System;
namespace XamarinFormsFirst.Data
{
    public interface IFile
    {
        string ClearFile(string filename);
        bool FileExists(string filename);
        string LoadText(string filename);
        void SaveText(string filename, string text);
    }
}
