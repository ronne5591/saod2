using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            BigList<char> bigList = new BigList<char>();
            bigList.Add('a');
            bigList.Add('b');
            bigList.Add('c');
            
            bigList.WriteList();
            Console.WriteLine(bigList.IndexOf('g') + " " + bigList.Size());
            Console.WriteLine();
            bigList.WriteList();
            Console.WriteLine(bigList[1]);
            bigList[1] = 'o';
            bigList.WriteList();
            Console.WriteLine("----");
            foreach(char temp in bigList)
            {
                Console.WriteLine(temp);
            }
            Console.ReadKey();
        }
    }
}
