using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    public struct TestStruct
    {
        public string A; 
        public static implicit operator TestStruct(TestClass source)
        {
            if (source == null)
            {
                Console.WriteLine("Test");
            }
            return new TestStruct();
        }
        public static implicit operator TestStruct(TestS1 source)
        {
            return new TestStruct();
        }
    }

    public class TestClass
    {
    }
    public class TestClass1
    {
    }

    public struct TestS1
    {
        
    }

}
