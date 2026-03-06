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
            bool WantToSortByType = false;
            bool WantToSortByName = false;
            bool WantToSortByCreatedDate = false;


            if (wantToSortBySize)
            {
                SortItemsBySize sorted = new SortItemsBySize(items);

                List<string> sizes = new List<string>();
                sizes = sorted.GetSizesS;

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
