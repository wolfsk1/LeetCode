using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;


namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            LeetCodeChina lcc = new LeetCodeChina();
            var isR = lcc.IsRectangleOverlap(new[] {0,0,1,1}, new[] {1,0,2,1});
            //LeetCodeChina.MoveZeroes(new int[8]{1,0,2,0,3,4,5,6});
        }
    }
}
