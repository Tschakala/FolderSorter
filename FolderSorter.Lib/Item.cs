using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FolderSorter.Lib
{
    public class Item
    {
        string _name;
        long _size;
        string _type;
        string _createdDate;

        public string GetName
        {
            get { return _name; }
        }

        public long GetSize
        {
            get { return _size; }
        }

        public string GetType
        {
            get { return _type; }
        }

        public string GetCreatedDate
        {
            get { return _createdDate; }
        }

        public Item(string name, long size, string type, string createdDate)
        {
            _name = name;
            _size = size;
            _type = type;
            _createdDate = createdDate;
        }
    }
}
