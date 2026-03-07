using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    public class FolderReader
    {

        string _folderPath;

        public string FolderPath
        {
            set
            {
                if (Directory.Exists(value))
                {
                    _folderPath = value;
                }
                else
                {
                    _folderPath = null;
                }
            }
        }

        List<Item> AllItems = new List<Item>();

        public FolderReader(string folderPath)
        {
            FolderPath = folderPath;
        }

        public void AddItemsToList()
        {
            string[] files = Directory.GetFiles(_folderPath);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);

                if (fileName == " " || fileName == "desktop.ini" || fileName == "")
                    continue;

                AllItems.Add(new Item(Path.GetFileName(file), new FileInfo(file).Length, Path.GetExtension(file), File.GetCreationTime(file).ToString(), Path.GetFullPath(file).ToString()));
            }
        }

        public List<Item> GetAllItems()
        {
            return AllItems;
        }
    }
}
