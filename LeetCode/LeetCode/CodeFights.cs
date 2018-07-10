﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode
{
    public class CodeFights
    {
        #region 已通过 Intro

        int AdjacentElementsProduct(int[] inputArray)
        {
            int max = -1001;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                int reult = inputArray[i] * inputArray[i + 1];
                max = Math.Max(reult, max);
            }
            return max;
        }

        int makeArrayConsecutive2(int[] statues)
        {
            int min = 21;
            int max = -1;
            for (int i = 0; i < statues.Length; i++)
            {
                min = Math.Min(min, statues[i]);
                max = Math.Max(max, statues[i]);
            }
            return (max - min) - statues.Length + 1;
        }

        public static bool AlmostIncreasingSequence(int[] sequence)
        {
            List<List<int>> subSeq = new List<List<int>>();
            subSeq.Add(new List<int>());
            int seqsCurrentIndex = 0;
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                subSeq[seqsCurrentIndex].Add(sequence[i]);
                if (sequence[i] >= sequence[i + 1])
                {
                    seqsCurrentIndex++;
                    if (seqsCurrentIndex >= 2)
                    {
                        return false;
                    }
                    subSeq.Add(new List<int>());
                }
            }
            subSeq[seqsCurrentIndex].Add(sequence[sequence.Length - 1]);
            if (seqsCurrentIndex == 0)
            {
                return true;
            }
            else
            {
                var firstSeq = subSeq[0];
                var lastSeq = subSeq[1];

                return (firstSeq.Count < 2 || lastSeq.Count < 2 || firstSeq[firstSeq.Count - 2] < lastSeq[0] ||
                        firstSeq[firstSeq.Count - 1] < lastSeq[1]);
            }
        }

        public static int MatrixElementsSum(int[][] matrix)
        {
            int colCount = matrix[0].Length;
            int rowCount = matrix.Length;
            int totalPrice = 0;
            for (int i = 0; i < colCount; i++)
            {
                int price = 0;
                for (int j = 0; j < rowCount; j++)
                {
                    if (matrix[j][i] == 0)
                    {
                        break;
                    }
                    else
                    {
                        price += matrix[j][i];
                    }
                }
                totalPrice += price;
            }
            return totalPrice;
        }

        public static string[] AllLongestStrings(string[] inputArray)
        {
            List<string> result = new List<string>();
            int maxLength = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i].Length > maxLength)
                {
                    maxLength = inputArray[i].Length;
                    result.Clear();
                    result.Add(inputArray[i]);
                }
                else if (inputArray[i].Length == maxLength)
                {
                    result.Add(inputArray[i]);
                }
            }
            return result.ToArray();
        }

        public static int CommonCharacterCount(string s1, string s2)
        {
            int[] countArray = new int[26];
            var s1Char = s1.ToCharArray();
            for (int i = 0; i < s1Char.Length; i++)
            {
                countArray[s1Char[i] - 'a']++;
            }
            int result = 0;
            var s2Char = s2.ToCharArray();
            for (int i = 0; i < s2Char.Length; i++)
            {
                int charIndex = s2Char[i] - 'a';
                if (countArray[charIndex] > 0)
                {
                    result++;
                    countArray[charIndex]--;
                }
            }
            return result;
        }

        public static bool IsLucky(int n)
        {
            List<int> nums = new List<int>();
            while (n > 0)
            {
                nums.Add(n % 10);
                n /= 10;
            }
            int halfLength = nums.Count / 2;
            int firstHalf = 0;
            int secondHalf = 0;
            for (int i = 0; i < halfLength; i++)
            {
                firstHalf += nums[i];
                secondHalf += nums[halfLength + i];
            }
            return firstHalf == secondHalf;
        }

        public static int[] SortByHeight(int[] a)
        {
            List<int> person = new List<int>();
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == -1)
                {
                    result[i] = -1;
                }
                else
                {
                    person.Add(a[i]);
                }
            }
            person.Sort();
            int indexOfPerson = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != -1)
                {
                    result[i] = person[indexOfPerson];
                    indexOfPerson++;
                }
            }
            return result;
        }

        public static string reverseParentheses(string s)
        {
            int index = 0;
            int leftIndex = -1;
            int bracketCount = 0;
            var cas = s.ToCharArray();
            StringBuilder sb = new StringBuilder();
            while (index < cas.Length)
            {
                if (cas[index] == '(')
                {
                    if (bracketCount == 0)
                    {
                        leftIndex = index;
                    }
                    bracketCount++;
                }
                else if (cas[index] == ')')
                {
                    bracketCount--;
                    if (bracketCount == 0)
                    {
                        var subString = s.Substring(leftIndex + 1, index - leftIndex - 1);
                        subString = reverseParentheses(subString);
                        var scas = subString.ToCharArray();
                        for (int i = scas.Length - 1; i >= 0; i--)
                        {
                            sb.Append(scas[i]);
                        }
                    }
                }
                else if (bracketCount == 0)
                {
                    sb.Append(cas[index]);
                }
                index++;
            }
            return sb.ToString();

        }

        string[] addBorder(string[] picture)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < picture[0].Length + 2; i++)
            {
                sb.Append('*');
            }
            string topBorder = sb.ToString();
            string[] result = new string[picture.Length + 2];
            result[0] = topBorder;
            result[result.Length - 1] = topBorder;
            for (int i = 0; i < picture.Length; i++)
            {
                result[i + 1] = "*" + picture[i] + "*";
            }
            return result;
        }

        bool areSimilar(int[] A, int[] B)
        {
            int[] table = new int[1001];
            int notEqual = 0;
            for (int i = 0; i < A.Length; i++)
            {
                table[A[i]]++;
            }
            for (int i = 0; i < B.Length; i++)
            {
                table[B[i]]--;
                if (A[i] != B[i])
                {
                    notEqual++;
                    if (notEqual > 2)
                    {
                        return false;
                    }
                }
                if (table[B[i]] < 0)
                {
                    return false;
                }
            }

            return (notEqual == 0) || (notEqual == 2);
        }
        public static int ArrayChange(int[] inputArray)
        {
            int result = 0;
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] <= inputArray[i - 1])
                {
                    int diff = inputArray[i - 1] - inputArray[i] + 1;
                    inputArray[i] += diff;
                    result += diff;
                }
            }
            return result;
        }

        public static bool PalindromeRearranging(string inputString)
        {
            int[] charCount = new int[26];
            char[] charArray = inputString.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                charCount[charArray[i] - 'a']++;
            }
            bool isCenterUse = false;
            for (int i = 0; i < charCount.Length; i++)
            {
                if (charCount[i] % 2 == 1)
                {
                    if (isCenterUse)
                    {
                        return false;
                    }
                    else
                    {
                        isCenterUse = true;
                    }
                }
            }
            return true;
        }

        public static bool areEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            int min = Math.Min(yourLeft, yourRight);
            int max = Math.Max(yourLeft, yourRight);
            return min == (Math.Min(friendsLeft, friendsRight)) && max == Math.Max(friendsLeft, friendsRight);
        }

        public static int arrayMaximalAdjacentDifference(int[] inputArray)
        {
            int maxDiff = 0;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                maxDiff = Math.Max(Math.Abs(inputArray[i] - inputArray[i + 1]), maxDiff);
            }
            return maxDiff;
        }

        public static bool isIPv4Address(string inputString)
        {
            string[] ipSingle = inputString.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (ipSingle.Length != 4)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < ipSingle.Length; i++)
                {
                    int ip = 0;
                    try
                    {
                        ip = int.Parse(ipSingle[i]);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    if (ip < 0 || ip > 255)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        int avoidObstacles(int[] inputArray)
        {
            for (int i = 2; i <= 40; i++)
            {
                bool isBreak = false;
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[j] % i == 0)
                    {
                        isBreak = true;
                        break;
                    }
                }
                if (!isBreak)
                {
                    return i;
                }
            }
            return 41;
        }

        int[][] boxBlur(int[][] image)
        {
            int[][] result = new int[image.Length - 2][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[image[0].Length - 2];
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = image[i][j] + image[i][j + 1] + image[i][j + 2] +
                                    image[i + 1][j] + image[i + 1][j + 1] + image[i + 1][j + 2] +
                                    image[i + 2][j] + image[i + 2][j + 1] + image[i + 2][j + 2];
                    result[i][j] /= 9;
                }
            }
            return result;
        }

        public static int[][] minesweeper(bool[][] matrix)
        {
            int[] xOffset = new[]
            {
                -1, 0, 1,
                -1, 1,
                -1, 0, 1
            };
            int[] yOffset = new[]
            {
                -1, -1, -1,
                0, 0,
                1, 1, 1
            };
            int[][] result = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    for (int offset = 0; offset < xOffset.Length; offset++)
                    {
                        int ax = j + xOffset[offset];
                        int ay = i + yOffset[offset];
                        if (minesweeperBoundCheck(ax, 0, matrix[i].Length - 1)
                            && minesweeperBoundCheck(ay, 0, matrix.Length - 1))
                        {
                            if (matrix[ay][ax])
                            {
                                result[i][j]++;
                            }
                        }
                    }
                }
            }
            return result;

        }

        static bool minesweeperBoundCheck(int num, int min, int max)
        {
            return num >= min && num <= max;
        }

        public static bool chessBoardCellColor(string cell1, string cell2)
        {
            char[] cell1Char = cell1.ToLower().ToCharArray();
            char[] cell2Char = cell2.ToLower().ToCharArray();
            int cell1Result = (cell1Char[0] + cell1Char[1]) % 2;
            int cell2Result = (cell2Char[0] + cell2Char[1]) % 2;
            return cell2Result == cell1Result;
        }

        int depositProfit(int deposit, int rate, int threshold)
        {
            float trueRate = (100 + rate) / 100f;
            float trueDeposit = deposit;
            int year = 0;
            while (trueDeposit < threshold)
            {
                trueDeposit *= trueRate;
                year++;
            }
            return year;
        }

        int absoluteValuesSumMinimization(int[] a)
        {
            int minSum = 0;
            int minSumNumber = 0;
            for (int i = 0; i < a.Length; i++)
            {
                minSum += Math.Abs(a[i]);
            }
            for (int i = 0; i < a.Length; i++)
            {
                int currentSum = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    currentSum += Math.Abs(a[j] - a[i]);
                    if (currentSum > minSum)
                    {
                        break;
                    }
                }
                if (currentSum <= minSum)
                {
                    if (currentSum == minSum)
                    {
                        minSumNumber = Math.Min(minSumNumber, a[i]);
                    }
                    else
                    {
                        minSum = currentSum;
                        minSumNumber = a[i];
                    }
                }
            }
            return minSumNumber;
        }
        bool stringsRearrangement(string[] inputArray)
        {
            List<string> ss = new List<string>(inputArray);
            string firstS = ss[0];
            string lastS = ss[0];
            ss.RemoveAt(0);
            bool isFind = true;
            while (ss.Count > 0 && isFind)
            {
                isFind = false;
                for (int i = 0; i < ss.Count; i++)
                {
                    bool firstDiff = CheckDiffer(firstS, ss[i]);
                    if (firstDiff)
                    {
                        isFind = true;
                        firstS = ss[i];
                        ss.RemoveAt(i);
                        break;
                    }
                    bool lastDiff = CheckDiffer(lastS, ss[i]);
                    if (lastDiff)
                    {
                        isFind = true;
                        lastS = ss[i];
                        ss.RemoveAt(i);
                        break;
                    }
                }
            }
            return isFind && ss.Count == 0;

        }

        bool CheckDiffer(string s1, string s2)
        {
            char[] s1c = s1.ToCharArray();
            char[] s2c = s2.ToCharArray();
            bool isDiff = false;
            for (int i = 0; i < s1c.Length; i++)
            {
                if (s1c[i] != s2c[i])
                {
                    if (isDiff)
                    {
                        return false;
                    }
                    else
                    {
                        isDiff = true;
                    }
                }
            }
            return isDiff;
        }

        char firstDigit(string inputString)
        {
            char[] ca = inputString.ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                if (ca[i] >= '0' && ca[i] <= '9')
                    return ca[i];
            }
            return '0';
        }
        int arrayMaxConsecutiveSum(int[] inputArray, int k)
        {
            int max = int.MinValue;
            for (int i = 0; i < inputArray.Length - k + 1; i++)
            {
                int result = 0;
                for (int j = i; j < i + k; j++)
                {
                    result += inputArray[j];
                }
                max = Math.Max(max, result);
            }
            return max;
        }

        public static string findEmailDomain(string address)
        {
            Match m = Regex.Match(address, "@[a-z0-9]+.[a-z0-9]+");
            if (m.Success)
            {
                return m.Value.Substring(1);
            }
            return string.Empty;
        }
        public static string buildPalindrome(string st)
        {
            char[] cas = st.ToCharArray();
            char[] revCas = new char[st.Length];
            for (int i = 0; i < cas.Length; i++)
            {
                revCas[cas.Length - i - 1] = cas[i];
            }
            int node = 0;
            while (node < revCas.Length)
            {
                if (revCas[0] == cas[node])
                {
                    int subNode = 0;
                    while ((subNode + node) < cas.Length && revCas[subNode] == cas[subNode + node])
                    {
                        subNode++;
                    }
                    if (subNode + node == cas.Length)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(cas);
                        for (int i = subNode; i < revCas.Length; i++)
                        {
                            sb.Append(revCas[i]);
                        }
                        return sb.ToString();
                    }
                }
                node++;
            }
            return string.Empty;
        }

        int chessKnight(string cell)
        {
            int size = 8;
            int[] offsetX = new[] { 1, 2, 2, 1, -1, -2, -2, -1 };
            int[] offsetY = new[] { 2, 1, -1, -2, -2, -1, 1, 2 };
            int ox = cell.ToCharArray()[0] - 'a';
            int oy = cell.ToCharArray()[1] - '1';
            int result = 0;
            for (int i = 0; i < offsetX.Length; i++)
            {
                int nx = ox + offsetX[i];
                int ny = oy + offsetY[i];
                if (nx >= 0 && nx < size && ny >= 0 && ny < size)
                {
                    result++;
                }
            }
            return result;
        }

        int deleteDigit(int n)
        {
            List<int> nums = new List<int>();
            while (n != 0)
            {
                nums.Add(n % 10);
                n /= 10;
            }
            int max = int.MinValue;
            for (int i = 0; i < nums.Count; i++)
            {
                int d = 1;
                int sum = 0;
                for (int j = 0; j < nums.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    sum += nums[j] * d;
                    d *= 10;
                }
                max = Math.Max(max, sum);
            }
            return max;
        }
        string longestWord(string text)
        {
            MatchCollection mc = Regex.Matches(text, "[a-zA-Z]*");
            string longestS = String.Empty;
            for (int i = 0; i < mc.Count; i++)
            {
                if (mc[i].Value.Length > longestS.Length)
                {
                    longestS = mc[i].Value;
                }
            }
            return longestS;
        }

        bool validTime(string time)
        {
            string[] sa = time.Split(':');
            int h = int.Parse(sa[0]);
            int m = int.Parse(sa[1]);
            return h >= 0 && h < 24 && m >= 0 && m < 60;
        }

        public static int sumUpNumbers(string inputString)
        {
            MatchCollection mc = Regex.Matches(inputString, "[0-9]+");
            int result = 0;
            for (int i = 0; i < mc.Count; i++)
            {
                if (mc[i].Success)
                {
                    result += int.Parse(mc[i].Value);
                }
            }
            return result;

        }

        int differentSquares(int[][] matrix)
        {
            bool[] flag = new bool[10000];
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    int hash = matrix[i][j] * 1000 + matrix[i][j + 1] * 100 + matrix[i + 1][j] * 10 + matrix[i + 1][j + 1];
                    flag[hash] = true;
                }
            }
            int result = flag.Count(b => b);
            return result;
        }

        int digitsProduct(int product)
        {
            if (product == 0)
            {
                return 10;
            }
            else if (product < 10)
            {
                return product;
            }
            List<int> nums = new List<int>();
            bool isHandler = false;
            while (product > 1)
            {
                isHandler = false;
                for (int i = 9; i > 1; i--)
                {
                    if (product % i == 0)
                    {
                        isHandler = true;
                        nums.Add(i);
                        product /= i;
                        break;
                    }
                }
                if (!isHandler)
                {
                    break;
                }
            }
            if (product > 1)
            {
                return -1;
            }
            else
            {
                nums.Sort();
                int result = 0;
                foreach (var num in nums)
                {
                    result = result * 10 + num;
                }
                return result;
            }
        }

        public static string[] fileNaming(string[] names)
        {
            Dictionary<string, int> files = new Dictionary<string, int>();
            string[] result = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                if (files.ContainsKey(names[i]))
                {
                    files[names[i]]++;
                    var newString = string.Format("{0}({1})", names[i], files[names[i]]);
                    while (files.ContainsKey(newString))
                    {
                        files[names[i]]++;
                        newString = string.Format("{0}({1})", names[i], files[names[i]]);
                    }
                    files.Add(newString, 0);
                    result[i] = newString;
                }
                else
                {
                    files.Add(names[i], 0);
                    result[i] = names[i];
                }
            }
            return result;
        }

        public static string messageFromBinaryCode(string code)
        {
            char[] aa = new char[code.Length / 8];
            char[] sca = code.ToCharArray();
            char[] result = new char[code.Length / 8];
            for (int i = 0; i < aa.Length; i++)
            {
                Int32 sum = 0;
                for (int j = 0; j < 8; j++)
                {
                    sum = sum * 2 + sca[i * 8 + j] - '0';
                }
                result[i] = (char)sum;
            }
            return new string(result);

        }
        public static int[][] spiralNumbers(int n)
        {
            int[] offsetX = new[] { 1, 0, -1, 0 };
            int[] offsetY = new[] { 0, 1, 0, -1 };
            int indexOfOffset = 0;
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }
            int x = 0, y = 0;
            result[0][0] = 1;
            int index = 2;
            while (index <= n * n)
            {
                int nx = x + offsetX[indexOfOffset];
                int ny = y + offsetY[indexOfOffset];
                if (nx >= 0 && nx < n && ny >= 0 && ny < n && result[ny][nx] == 0)
                {
                    result[ny][nx] = index;
                    index++;
                    x = nx;
                    y = ny;
                }
                else
                {
                    indexOfOffset++;
                    indexOfOffset %= 4;
                }
            }
            return result;
        }

        bool sudoku(int[][] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                int ox = i % 3 * 3;
                int oy = i / 3 * 3;
                bool[] flag = new bool[10];
                bool[] flagCol = new bool[10];
                bool[] flagRow = new bool[10];
                for (int j = 0; j < 9; j++)
                {
                    int flagNum = grid[oy + j / 3][ox + j % 3];
                    if (flag[flagNum])
                    {
                        return false;
                    }
                    else
                    {
                        flag[flagNum] = true;
                    }

                    int flagColNum = grid[j][i];
                    if (flagCol[flagColNum])
                    {
                        return false;
                    }
                    else
                    {
                        flagCol[flagColNum] = true;
                    }

                    int flagRowNum = grid[j][i];
                    if (flagRow[flagRowNum])
                    {
                        return false;
                    }
                    else
                    {
                        flagRow[flagRowNum] = true;
                    }
                }
            }
            return true;
        }
        #endregion



    }
}
