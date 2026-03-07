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

            if (path == null)
                return;

            //used for debugging, don't include into final product
            //ClutterGenerator clutterGenerator = new ClutterGenerator();
            //clutterGenerator.GenerateClutter(path, 50);

            FolderReader readFolder = new FolderReader(path);
            readFolder.AddItemsToList();

            List<Item> items = new List<Item>();
            items = readFolder.GetAllItems();

            bool wantToSortByExtension = MessageBox.Show("Do you want to sort by extension?", "Sorting", MessageBoxButtons.YesNo) == DialogResult.Yes;
            bool wantToSortBySize = false;
            if (!wantToSortByExtension)
            {
                wantToSortBySize = MessageBox.Show("Do you want to sort by Size", "Sorting", MessageBoxButtons.YesNo) == DialogResult.Yes;
            }

            if (wantToSortByExtension)
            {
                ItemsSorterByExtension itemsSorterByExtension = new ItemsSorterByExtension(path, items);
                itemsSorterByExtension.Sort();
            }

            if (wantToSortBySize)
            {
                ItemsSorterBySize itemsSorterBySize = new ItemsSorterBySize(path, items);
                itemsSorterBySize.Sort();
            }




            //ItemsSorterBySize itemsSorterBySize = new ItemsSorterBySize(path, items);
            //itemsSorterBySize.Sort();
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
