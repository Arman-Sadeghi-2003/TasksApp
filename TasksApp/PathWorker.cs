using System.ComponentModel.DataAnnotations;

namespace TasksApp
{
    public class PathWorker
    {
        string binFile = Path.Combine(FileSystem.AppDataDirectory, "Bin");
        public string DirectoryPath
        {
            get
            {
                if (!Directory.Exists(binFile))
                    Directory.CreateDirectory(binFile);
                return binFile;
            }
        }

        public string GetTastsFilePath => Path.Combine(DirectoryPath, "TasksObject.json"); 

        public bool IsTasksFileExists => File.Exists(GetTastsFilePath);
    }
}
