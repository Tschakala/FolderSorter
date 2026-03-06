using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolderSorter.Lib;

namespace FolderSorter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Class1 Hlib = new Class1("Hlib");

            Console.WriteLine(Hlib.GetName);
        }
    }
}
