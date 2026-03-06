using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    public class SortItemsBySize : Item
    {
        long _size;

        public long SetSize
        {
            set
            {

            }
        }

        public SortItemsBySize(string name, long size, string type, string createdDate) : base(name, size, type, createdDate)
        {


        }
    }
}
