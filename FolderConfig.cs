using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascii_Art
{
    public static class FolderConfig
    {
        public static void SetupFolderConfig(ref string DESTINATION_PATH)
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string newFolderName = "Images";
            string newFolderDirectory = Path.Combine(appDirectory, newFolderName);
            DESTINATION_PATH = newFolderDirectory;
            try
            {
                if (!Directory.Exists(newFolderName))
                {
                    Directory.CreateDirectory(newFolderDirectory);
                    Console.WriteLine($"Folder created at: {newFolderDirectory}");
                }
                else
                {
                    Console.WriteLine($"Folder already exists at: {newFolderDirectory}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
