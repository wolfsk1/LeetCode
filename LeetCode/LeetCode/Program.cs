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
            var isR = lcc.ReverseList(ListNode.CreateNodeList(new int[]{1,2,3,4,5}));
            //LeetCodeChina.MoveZeroes(new int[8]{1,0,2,0,3,4,5,6});
        }
    }
}
