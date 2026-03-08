using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    public class ConfigManager
    {
        private string _dir;
        private string _configFilePath;
        private const string _configFileName = "config.txt";
        private string[] defaultConfig = new string[] {
                    "SortBy=Extension",
                    "SilentMode=false"
                };

        public Dictionary<string, string> configValues = new Dictionary<string, string>();

        public string ConfigFilePath
        {
            get { return _configFilePath; }
        }


        public ConfigManager(string dir) 
        { 
            _dir = dir;
            _configFilePath = System.IO.Path.Combine(_dir, _configFileName);
        }

        public void Initialize()
        {
            CreateConfig(overwrite: false);
            ReadConfig();
        }

        public bool ConfigExists()
        {
            return System.IO.File.Exists(_configFilePath);
        }

        public void ReadConfig()
        {
            if (ConfigExists())
            {
                string[] configLines = System.IO.File.ReadAllLines(_configFilePath);
    
                foreach (string line in configLines)
                {
                    Console.WriteLine(line);

                    string[] parts = line.Split('=');

                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim().ToLower();
                        string value = parts[1].Trim().ToLower();
                        configValues[key] = value;
                    }
                }
            }
            else
            {
                Console.WriteLine("Config file not found at: " + _configFilePath);
            }
        }

        public void CreateConfig(bool overwrite) 
        {
            if(!ConfigExists() || overwrite)
            {
                System.IO.File.WriteAllLines(_configFilePath, defaultConfig);
                Console.WriteLine("Config file created at: " + _configFilePath);
            }
        }
    }
}
