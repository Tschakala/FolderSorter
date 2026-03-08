using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderSorter.Lib;

namespace FolderSorter
{
    internal class Program
    {

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        [STAThread]
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            string directoryOfExecutable = AppDomain.CurrentDomain.BaseDirectory;
            ConfigManager configManager = new ConfigManager(directoryOfExecutable);
            configManager.Initialize();

            string path = Directory.GetCurrentDirectory();

            if(args.Contains("-showconsole"))
            {
                ShowWindow(handle, SW_SHOW);
            }

            if (args.Contains("-settings"))
            {
                ConfigEditorForm configEditorForm = new ConfigEditorForm(configManager.ConfigFilePath, configManager.configValues);
                configEditorForm.ShowDialog();
                return;
            }

            if (!args.Contains("-silent"))
            {
                path = AskAndGetUsersPath();
            }

            if (path == null)
                return;

            //used for debugging, don't include into final product
            ClutterGenerator clutterGenerator = new ClutterGenerator();
            clutterGenerator.GenerateClutter(path, 50);

            FolderReader readFolder = new FolderReader(path);
            readFolder.AddItemsToList();

            List<Item> items = new List<Item>();
            items = readFolder.GetAllItems();
            

            switch (configManager.configValues["sortby"])
            {
                case "extension":
                    ItemsSorterByExtension itemsSorterByExtension = new ItemsSorterByExtension(path, items);
                    itemsSorterByExtension.Sort();
                    break;
                case "size":
                    ItemsSorterBySize itemsSorterBySize = new ItemsSorterBySize(path, items);
                    itemsSorterBySize.Sort();
                    break;
                default:
                    MessageBox.Show("Invalid sorting method in config file. Please check the config file and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
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
