
using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Solution
    {
        /// <summary>
        /// 461. Hamming Distance 
        /// </summary>
        public int HammingDistance(int x, int y)
        {
            int result = 0;
            while (x != 0 || y != 0)
            {
                int x1 = x%2;
                int y1 = y%2;
                x /= 2;
                y /= 2;
                if (x1 != y1)
                {
                    result ++;
                }
            }
            return result;
        }
        /// <summary>
        /// 500. Keyboard Row 
        /// </summary>
        public string[] FindWords(string[] words)
        {
            string reg = "(abcd|efgh)+";
            List<string> result = new List<string>();
            foreach (var word in words)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(word.ToLower(), reg))
                {
                    System.Console.WriteLine(word);
                    result.Add(word);
                }
            }
            return result.ToArray();
        }
        /// <summary>
        /// 476. Number Complement 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int FindComplement(int num)
        {
            int orginNum = num;
            int complementNum = 1;
            while (num != 0)
            {
                complementNum *= 2;
                num /= 2;
            }
            return complementNum - 1 - orginNum;
        }
        /// <summary>
        /// 496. Next Greater Element I 
        /// </summary>
        public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            Dictionary<int, int> resultTable = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                bool isSet = false;
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        resultTable.Add(nums[i], nums[j]);
                        isSet = true;
                        break;
                    }
                }
                if (!isSet)
                {
                    resultTable.Add(nums[i], -1);
                }
            }
            int[] result = new int[findNums.Length];
            for (int i = 0; i < findNums.Length; i++)
            {
                result[i] = resultTable[findNums[i]];
            }
            return result;
        }
        /// <summary>
        /// 412. Fizz Buzz 
        /// </summary>
        public IList<string> FizzBuzz(int n)
        {
            string div3 = "Fizz";
            string div5 = "Buzz";
            string div15 = "FizzBuzz";
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i%3 == 0)
                {
                    if (i%5 == 0)
                    {
                        result.Add(div15);
                    }
                    else
                    {
                        result.Add(div3);
                    }
                }else if (i%5 == 0)
                {
                    result.Add(div5);
                }
                else
                {
                    result.Add(i.ToString());
                }
            }
            return result;
        }
        /// <summary>
        /// 344. Reverse String 
        /// </summary>
        public string ReverseString(string s)
        {
            char[] orgin = s.ToCharArray();
            char[] result = new char[s.Length];
            for (int i = 0; i < orgin.Length; i++)
            {
                result[i] = orgin[orgin.Length - i - 1];
            }
            return new string(result);
        }
        /// <summary>
        /// 463. Island Perimeter 
        /// </summary>
        public int IslandPerimeter(int[,] grid)
        {
            int rows = grid.GetLength(0);
            int colums = grid.GetLength(1);
            int[,] newGrid = new int[rows+2,colums+2];
            int result = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    newGrid[i + 1, j + 1] = grid[i, j];
                }
            }
            for (int i = 1; i < rows+1; i++)
            {
                for (int j = 1; j < colums+1; j++)
                {
                    if (newGrid[i, j] == 1)
                    {
                        result = newGrid[i - 1, j] == 0 ? result + 1 : result;
                        result = newGrid[i + 1, j] == 0 ? result + 1 : result;
                        result = newGrid[i, j - 1] == 0 ? result + 1 : result;
                        result = newGrid[i, j + 1] == 0 ? result + 1 : result;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 485. Max Consecutive Ones 
        /// </summary>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = -1;
            int record = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (num == 1)
                {
                    record++;
                    if (i == nums.Length - 1)
                    {
                        max = Math.Max(record, max);
                    }
                }
                else
                {
                    max = Math.Max(record, max);
                    record = 0;
                }
            }
            return max;
        }
        /// <summary>
        /// 292. Nim Game 
        /// </summary>
        public bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }
        /// <summary>
        /// 448. Find All Numbers Disappeared in an Array 
        /// </summary>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[(nums[i] - 1 )% nums.Length] += nums.Length;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= nums.Length)
                {
                    result.Add(i + 1);
                }
            }
            return result;
        }
    }
}
