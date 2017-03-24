using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            for (int j = 0; j <= 10; j++)
            {
                var ta = MyTest.GetRandomList(100, 5, 10, 2, ran);
                for (int i = 0; i < ta.Length; i++)
                {
                    Console.Write(ta[i]+" ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
