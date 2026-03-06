using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    public class SortItemsBySize
    {
        List<string> sizesS = new List<string>();
        List<Item> _items = new List<Item>();

        public List<string> GetSizesS
        {
            get { return sizesS; }
        }

        public SortItemsBySize(List<Item> items)
        {
            _items = items;
            sizesS = SortItems(_items);
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

        List<string> SortItems(List<Item> itemsSorted)
        {
            List<long> sizes = new List<long>();

            for (int i = 0; i < itemsSorted.Count; i++)
            {
                sizes.Add(itemsSorted[i].GetSize);
            }

            sizes.Sort();

            List<string> sizesSortet = new List<string>();

            for (int i = 0; i < itemsSorted.Count; i++)
            {
                sizesSortet.Add(FormatBytes(sizes[i]));
            }

            return sizesSortet;
        }

    }
}
