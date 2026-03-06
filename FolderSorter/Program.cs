using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderSorter.Lib;
using System.Windows.Forms;
using System.IO;

namespace FolderSorter
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            if (args.Length < 1)
                path = AskAndGetUsersPath();

            ReadFolder readFolder = new ReadFolder(path);

            readFolder.GetAllItems();

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
