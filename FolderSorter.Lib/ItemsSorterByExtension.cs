using System;
using System.Collections.Generic;
using System.IO;

namespace FolderSorter.Lib
{
    public class ItemsSorterByExtension : IItemsSorter
    {
        string _path;
        IEnumerable<Item> _items;
        public ItemsSorterByExtension(string path, IEnumerable<Item> items)
        {
            _path = path;
            _items = items;
        }

        public void Sort()
        {
            foreach (var currentItem in _items)
            {
                string currentItemPath = currentItem.Path;

                string folderName = currentItem.Extension.Replace(".", "");   //remove dot(.) and spaces in the type
                string sortDirPath = Path.Combine(_path, folderName);        //sort folders
                string finalFilePath = Path.Combine(sortDirPath, currentItem.Name);

                Directory.CreateDirectory(sortDirPath);                     //create folder if it doesn't exist even if it does exist it won't throw an error

                Console.WriteLine(currentItemPath + " ; " + finalFilePath);

                if (!File.Exists(finalFilePath))                             //check if file already exists in the destination folder
                {
                    File.Move(currentItemPath, finalFilePath);              //move file to the destination folder
                }
            }
        }
    }
}
