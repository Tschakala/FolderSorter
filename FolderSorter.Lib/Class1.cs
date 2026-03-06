using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    public class Class1
    {
        string _name;

        public string GetName
        {
            set
            {
                string temp = value.ToLower();
                _name = temp;
            }
            get { return _name; }
        }

        public Class1(string name)
        {
            GetName = name;
        }
    }
}
