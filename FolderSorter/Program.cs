using FolderSorter.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSorter
{
    internal class Program
    {



        public static string FormatBytes(long bytes)
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


        static List<string> SortItemsBySize(List<Item> items)
        {
            List<long> sizes = new List<long>();

            for (int i = 0; i < items.Count; i++)
            {
                sizes.Add(items[i].GetSize);
            }

            sizes.Sort();

            List<string> sizesSortet = new List<string>();

            for (int i = 0; i < items.Count; i++)
            {
                sizesSortet.Add(FormatBytes(sizes[i]));
            }

            return sizesSortet;
        }


        [STAThread]
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            if (args.Length < 1)
            {
                path = AskAndGetUsersPath();
            }
                

            ReadFolder readFolder = new ReadFolder(path);

            List<Item> items = new List<Item>();

            items = readFolder.GetAllItems();


            bool wantToSortBySize = true;


            if (wantToSortBySize)
            {
                List<string> sizes = new List<string>();
                sizes = SortItemsBySize(items);

                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine(sizes[i]);
                }
            }


            Console.WriteLine(path);
        }
        
        static string AskAndGetUsersPath()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = folderBrowserDialog.SelectedPath;
                
                return filePath;
            }

            return null;
        }
    }
}
