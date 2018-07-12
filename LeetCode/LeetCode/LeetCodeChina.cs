using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LeetCodeChina
    {
        public int NumJewelsInStones(string J, string S)
        {
            var jca = J.ToCharArray();
            HashSet<char> judge = new HashSet<char>();
            for (int i = 0; i < jca.Length; i++)
            {
                judge.Add(jca[i]);
            }

            int result = 0;
            var sca = S.ToCharArray();
            foreach (var c in sca)
            {
                if (judge.Contains(c))
                {
                    result++;
                }
            }

            return result;
        }
        
        public static int[][] FlipAndInvertImage(int[][] A) {
            int[][] result = new int[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                int length = A[i].Length;
                result[i] = new int[length];
                for (int j = length - 1; j >= 0; j--)
                {
                    result[i][length - j - 1] = A[i][j] ^ 1;
                }
            }

            return result;

        }
        
        public bool JudgeCircle(string moves) {
            char[] moveChar = moves.ToCharArray();
            int x = 0;
            int y = 0;
            for (int i = 0; i < moveChar.Length; i++)
            {
                switch (moveChar[i])
                {
                    case 'U':
                        y++;
                        break;
                    case 'D':
                        y--;
                        break;
                    case 'L':
                        x--;
                        break;
                    case 'R':
                        x++;
                        break;
                }
            }
            return x == y && x==0;
        }
        public int HammingDistance(int x, int y)
        {
            int result = 0;
            int mid = x ^ y;
            while (mid != 0)
            {
                result++;
                mid &= mid - 1;
            }

            return result;
        }
        
        public static uint reverseBits(uint n)
        {
            uint result = 0;
            for (int i = 0; i < 32; i++)
            {
                result <<= 1;
                result |= n & 1;
                n >>= 1;
            }

            return result;
        }
        
        
        public bool HasAlternatingBits(int n)
        {
            int last = 0;
            while (n != 0)
            {
                last = n & 1;
                n >>= 1;
                if (last == (n & 1))
                {
                    return false;
                }
            }

            return true;
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int totalResult = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                totalResult >>= 1;
            }

            for (int i = 0; i < totalResult; i++)
            {
                var singleResult = new List<int>();
                int temp = i;
                int index = 0;
                while (temp != 0)
                {
                    bool isSelect = (temp & 1) == 1;
                    if (isSelect)
                    {
                        singleResult.Add(nums[index]);
                    }
                    index++;
                    temp >>= 1;
                }
                result.Add(singleResult);
            }

            return result;
        }
        
        public int FindComplement(int num) {
            int result = 0;
            int i = 0;
            while(num!=0){
                result+=((num&1)^1)<<i;
                num>>=1;
                i++;
            }
            return result;
        }
        public int[] TwoSum(int[] nums, int target) {
            for(int i = 0;i<nums.Length;i++){
                for(int j = i+1;j<nums.Length;j++){
                    if(nums[i]+nums[j] == target){
                        return new int[]{i,j};
                    }
                }
            }
            return new int[]{0,0};
        }
        // 7
        public static int Reverse(int x)
        {
            int symolNum = x<0?-1:1;
            int result = 0;
            while (x != 0)
            {
                if (Int32.MaxValue / 10 < result || Int32.MinValue/10>result)
                {
                    return 0;
                }
                else
                {
                    result *= 10;
                }
                int num = x % 10;
                if (symolNum > 0)
                {
                    if (Int32.MaxValue - result < num)
                    {
                        return 0;
                    }
                }
                else
                {
                    if (Int32.MinValue - result > num)
                    {
                        return 0;
                    }
                }
                result += num;
                x /= 10;
            }
            return result;

        }
        
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int[] xHeight = new int[grid.Length];
            int[] yHeight = new int[grid.Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    xHeight[i] = Math.Max(grid[i][j], xHeight[i]);
                    yHeight[j] = Math.Max(grid[i][j], yHeight[j]);
                }
            }

            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                        result += Math.Min(xHeight[i], yHeight[j]) - grid[i][j];
                }
            }

            return result;
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int totalLength = nums1.Length + nums2.Length;
            int midLength = totalLength/2 + 1;
            int[] newResult = new int[midLength];
            int n1Index = 0;
            int n2Index = 0;
            for (int i = 0; i < newResult.Length; i++)
            {
                if (n1Index >= nums1.Length)
                {
                    newResult[i] = nums2[n2Index];
                    n2Index++;
                    continue;
                }
                else if (n2Index >= nums2.Length)
                {
                    newResult[i] = nums1[n1Index];
                    n1Index++;
                    continue;
                }
                bool isN1Smaller = nums1[n1Index] <= nums2[n2Index];
                if (isN1Smaller)
                {
                    newResult[i] = nums1[n1Index];
                    n1Index++;
                }
                else
                {
                    newResult[i] = nums2[n2Index];
                    n2Index++;
                }
            }

            if (totalLength%2 == 0)
            {
                return (newResult[newResult.Length - 2] + newResult[newResult.Length - 1])/2.0d;
            }
            else
            {
                return (newResult[newResult.Length - 1]);
            }
        }

        public static
            int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int realNumIndex = 0;
            int numsIndex = 0;
            while (numsIndex < nums.Length-1)
            {
                if (nums[numsIndex] != nums[numsIndex + 1])
                {
                    nums[realNumIndex] = nums[numsIndex];
                    realNumIndex++;
                }
                numsIndex++;
            }

            nums[realNumIndex] = nums[numsIndex];
            return realNumIndex + 1;
        }
        
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }
            int result = 0;
            int minNum = prices[0];
            int lastNum = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < lastNum)
                {
                    result += lastNum - minNum;
                    minNum = prices[i];
                }
                lastNum = prices[i];
            }

            result += lastNum - minNum;
            return result;
        }
        
        public static void Rotate(int[] nums, int k)
        {
            if (nums.Length == 0)
            {
                return;
            }
            // 需要交换区域的长度
            int n = nums.Length;
            // 交换区域的初始位置
            int start = 0;
            // 每轮的交换
            for (;(k%=n)!=0;n-=k,start+=k)
            {
                for (int i = 0; i < k; i++)
                {
                    int orginIndex = i + start;
                    int targetIndex = n - k + i + start;
                    int temp = nums[orginIndex];
                    nums[orginIndex] = nums[targetIndex];
                    nums[targetIndex] = temp;
                }
            }
        }
        
        public bool ContainsDuplicate(int[] nums) {
            HashSet<int> judge = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (judge.Contains(nums[i]))
                {
                    return true;
                }
                else
                {
                    judge.Add(nums[i]);
                }
            }

            return false;
        }
        
        public int SingleNumber(int[] nums)
        {
            int judge = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                judge = nums[i] ^ judge;
            }

            return judge;
        }
    }
}