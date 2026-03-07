using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    //used only for debugging, to generate random files with random sizes, types and created dates
    public class ClutterGenerator
    {
        private string[] _fileTypes = { ".txt", ".jpg", ".pdf", ".docx", ".xlsx", ".mp3", ".mp4" };

        public void GenerateClutter(string path, int numberOfItems)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfItems; i++)
            {
                string itemName = $"Item_{i}{_fileTypes[ random.Next(0, _fileTypes.Length) ]}";
                string itemPath = System.IO.Path.Combine(path, itemName);

                // Create a file with random size
                long fileSize = random.Next(1, 1000000); // Size between 1 byte and 1 MB
                using (var fileStream = System.IO.File.Create(itemPath))
                {
                    fileStream.SetLength(fileSize);
                }

                // Set a random created date
                DateTime createdDate = DateTime.Now.AddDays(-random.Next(365)); // Created within the last year
                System.IO.File.SetCreationTime(itemPath, createdDate);
            }
        }
    }
}
