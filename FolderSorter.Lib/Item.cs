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
        string _extension;      //file type
        string _createdDate;
        string _path;

        public string GetName
        {
            get { return _name; }
        }

        public long GetSize
        {
            get { return _size; }
        }

        public string GetExtension
        {
            get { return _extension; }
        }

        public string GetCreatedDate
        {
            get { return _createdDate; }
        }

        public string GetPath
        {
            get { return _path; }
        }

        public Item(string name, long size, string extension, string createdDate, string path)
        {
            _name = name;
            _size = size;
            _extension = extension;
            _createdDate = createdDate;
            _path = path;
        }
    }
}
