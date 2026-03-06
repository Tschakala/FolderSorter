using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    public class SortItemsByType : Item
    {
        string _type;



        public SortItemsByType(string name, long size, string type, string createdDate) : base(name, size, type, createdDate)
        {
            
        }
    }
}
