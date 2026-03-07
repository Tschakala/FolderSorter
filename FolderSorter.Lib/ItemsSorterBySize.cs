using System;
using System.Collections.Generic;
using System.IO;

namespace FolderSorter.Lib
{
    public class ItemsSorterBySize : IItemsSorter
    {
        string _path;
        IEnumerable<Item> _items;

        public ItemsSorterBySize(string path, IEnumerable<Item> items)
        {
            _path = path;
            _items = items;
        }

        static string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };

            double len = bytes;
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        private long GetLargestFileSize()
        {
            long largestSize = 0;
            foreach (var item in _items)
            {
                if (item.GetSize > largestSize)
                {
                    largestSize = item.GetSize;
                }
            }
            return largestSize;
        }

        private string GetSizeGroup(long size, long step)
        {
            double groupIndexPrecise = (double)size / step;

            int groupIndex = (int)Math.Round(groupIndexPrecise, 0, MidpointRounding.AwayFromZero);

            Console.WriteLine("rounded value: " + Math.Round(groupIndexPrecise, 0, MidpointRounding.AwayFromZero));

            if (groupIndex < 1)
                groupIndex = 1;

            if (groupIndex > 3)
                groupIndex = 3;

            Console.WriteLine("group index: " + groupIndex);

            switch (groupIndex)
            {
                case 1:
                    return "Small";
                case 2:
                    return "Medium";
                case 3:
                    return "Large";
            }

            return "Unknown";
        }

        public void Sort()
        {
            long fileSizeStep = GetLargestFileSize() / 3; //Size of each group

            Console.WriteLine("step: " + fileSizeStep);

            foreach (Item item in _items)
            {
                string sizeGroup = GetSizeGroup(item.GetSize, fileSizeStep);

                string currentItemPath = item.GetPath;
                string sortDirPath = Path.Combine(_path, sizeGroup);        //sort folders
                string finalName = (FormatBytes(item.GetSize) + "  " + item.GetName + item.GetExtension);
                string finalItemPath = Path.Combine(sortDirPath, finalName); //final path of the item

                Directory.CreateDirectory(sortDirPath);

                Console.WriteLine(FormatBytes(item.GetSize) + " ; " + sizeGroup);

                if (!File.Exists(finalItemPath))
                {
                    File.Move(currentItemPath, finalItemPath);
                }
            }
        }
    }
}
