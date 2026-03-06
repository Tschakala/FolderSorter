using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    public class ReadFolder
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

        public ReadFolder(string folderPath)
        {
            FolderPath = folderPath;

            AddItemsToList();
        }

        public void AddItemsToList()
        {
            string[] files = Directory.GetFiles(_folderPath);

            foreach (string file in files)
            {
                AllItems.Add(new Item(Path.GetFileName(file), new FileInfo(file).Length, Path.GetExtension(file), File.GetCreationTime(file).ToString()));
            }
        }

        public List<Item> GetAllItems()
        {
            return AllItems;
        }
    }
}
