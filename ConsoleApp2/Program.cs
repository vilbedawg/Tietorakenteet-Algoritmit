using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmit
{
    class Program
    {
        static void Main(string[] args)
        {
            _LinkedList list = new _LinkedList();
            
            for(int i = 1; i < 11; i++)
            {
                list.AddToEnd(i);
            }

            list.Print();
            Console.WriteLine();
            Console.WriteLine(list.Find(10));
        }
    }
}

