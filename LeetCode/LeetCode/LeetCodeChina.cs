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
        public int Reverse(int x) {
        
        }
    }
}