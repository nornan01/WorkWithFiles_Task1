using System;
using System.IO;
namespace WorkWithFiles_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\ASUS\\Desktop\\c# learning";
            TimeSpan maxTime = TimeSpan.FromMinutes(30);
        

            if (Directory.Exists(path))
            {
                CleanOldFilesFolders(path, maxTime);
                Console.WriteLine("Directory cleaned");
            }
            else
            {
                Console.WriteLine("Directory not found");
            }
        }

        private static void CleanOldFilesFolders(string path, TimeSpan maxTime)
        {

            DirectoryInfo dir = new DirectoryInfo(path);
            DateTime threshold = DateTime.Now - maxTime;
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.LastAccessTime < threshold)
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Mistake deleting file {file.FullName}: {ex.Message}");
                    }
                }
            }
            foreach(DirectoryInfo directory in dir.GetDirectories())
            {
                if (directory.LastAccessTime < threshold)
                {
                    try
                    {
                        directory.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Mistake deleting file {directory.FullName}: {ex.Message}");
                    }
                }
            }
        }
    }
}
