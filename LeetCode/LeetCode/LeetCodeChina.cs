using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

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

        public static int[][] FlipAndInvertImage(int[][] A)
        {
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

        public bool JudgeCircle(string moves)
        {
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

            return x == y && x == 0;
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

        public int FindComplement(int num)
        {
            int result = 0;
            int i = 0;
            while (num != 0)
            {
                result += ((num & 1) ^ 1) << i;
                num >>= 1;
                i++;
            }

            return result;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] {i, j};
                    }
                }
            }

            return new int[] {0, 0};
        }

        // 7
        public static int Reverse(int x)
        {
            int symolNum = x < 0 ? -1 : 1;
            int result = 0;
            while (x != 0)
            {
                if (Int32.MaxValue / 10 < result || Int32.MinValue / 10 > result)
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
            int midLength = totalLength / 2 + 1;
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

            if (totalLength % 2 == 0)
            {
                return (newResult[newResult.Length - 2] + newResult[newResult.Length - 1]) / 2.0d;
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
            while (numsIndex < nums.Length - 1)
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
            for (; (k %= n) != 0; n -= k, start += k)
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

        public bool ContainsDuplicate(int[] nums)
        {
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

        public void Rotate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - j - 1, i];
                    matrix[n - j - 1, i] = matrix[n - i - 1, n - j - 1];
                    matrix[n - i - 1, n - j - 1] = matrix[j, n - i - 1];
                    matrix[j, n - i - 1] = temp;
                }
            }
        }

        public string ReverseString(string s)
        {
            var cs = s.ToCharArray();
            for (int i = 0; i < cs.Length / 2; i++)
            {
                char temp = cs[i];
                cs[i] = cs[cs.Length - i - 1];
                cs[cs.Length - i - 1] = temp;
            }

            return new string(cs);
        }

        public int FirstUniqChar(string s)
        {
            int[] judge = new int[26];
            for (int i = 0; i < judge.Length; i++)
            {
                judge[i] = -2;
            }

            var cs = s.ToCharArray();
            for (int i = 0; i < cs.Length; i++)
            {
                int curCharInt = cs[i] - 'a';
                if (judge[curCharInt] == -2)
                {
                    judge[curCharInt] = i;
                }
                else if (judge[curCharInt] >= 0)
                {
                    judge[curCharInt] = -1;
                }
            }

            int min = Int32.MaxValue;
            for (int i = 0; i < judge.Length; i++)
            {
                if (judge[i] >= 0)
                {
                    min = Math.Min(judge[i], min);
                }
            }

            return min == Int32.MaxValue ? -1 : min;
        }

        public bool IsAnagram(string s, string t)
        {
            int[] judge = new int[26];
            char[] cs = s.ToCharArray();
            for (int i = 0; i < cs.Length; i++)
            {
                int charInt = cs[i] - 'a';
                judge[charInt]++;
            }

            var ts = t.ToCharArray();
            for (int i = 0; i < ts.Length; i++)
            {
                int charInt = ts[i] - 'a';
                judge[charInt]--;
            }

            for (int i = 0; i < judge.Length; i++)
            {
                if (judge[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            var cs = s.ToCharArray();
            int l = FindNextCharWithIsPalindrome(cs, 0, true);
            int r = FindNextCharWithIsPalindrome(cs, s.Length - 1, false);
            while (l < r)
            {
                if (cs[l] != cs[r])
                {
                    return false;
                }

                l = FindNextCharWithIsPalindrome(cs, l + 1, true);
                r = FindNextCharWithIsPalindrome(cs, r - 1, false);
            }

            return true;
        }

        private int FindNextCharWithIsPalindrome(char[] array, int index, bool isToRight)
        {
            int additionalIndex = isToRight ? 1 : -1;
            while (index >= 0 && index < array.Length)
            {
                char curc = array[index];
                if ((curc >= 'a' && curc <= 'z') || (curc >= '0' && curc <= '9'))
                {
                    break;
                }
                else
                {
                    index += additionalIndex;
                }
            }

            return index;
        }

        public static int MyAtoi(string str)
        {
            var cstr = str.ToCharArray();
            List<int> resultInts = new List<int>();
            bool isAdditional = true;
            bool meetNoNull = false;
            for (int i = 0; i < cstr.Length; i++)
            {
                var c = cstr[i];
                if (c == ' ' && !meetNoNull) continue;
                if (meetNoNull)
                {
                    if (c < '0' || c > '9')
                        break;
                    else
                    {
                        resultInts.Add(c - '0');
                    }
                }
                else
                {
                    if (c == '+' || c == '-')
                    {
                        isAdditional = c == '+';
                    }
                    else if (c >= '0' && c <= '9')
                    {
                        resultInts.Add(c - '0');
                    }
                    else
                    {
                        break;
                    }

                    meetNoNull = true;
                }
            }

            if (resultInts.Count == 0) return 0;
            int additional = isAdditional ? 1 : -1;
            int result = resultInts[0] * additional;
            for (int i = 1; i < resultInts.Count; i++)
            {
                int curInt = resultInts[i];
                if (Int32.MaxValue / 10 < result)
                {
                    return Int32.MaxValue;
                }
                else if (Int32.MinValue / 10 > result)
                {
                    return Int32.MinValue;
                }
                else
                {
                    result *= 10;
                }

                if (isAdditional)
                {
                    if (Int32.MaxValue - curInt < result)
                    {
                        return Int32.MaxValue;
                    }
                    else
                    {
                        result += curInt;
                    }
                }
                else
                {
                    if (Int32.MinValue + curInt > result)
                    {
                        return Int32.MinValue;
                    }
                    else
                    {
                        result -= curInt;
                    }
                }

            }

            return result;
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> judge = new Dictionary<int, int>();
            List<int> result = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!judge.ContainsKey(nums1[i]))
                {
                    judge.Add(nums1[i], 1);
                }
                else
                {
                    judge[nums1[i]]++;
                }
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (judge.ContainsKey(nums2[i]))
                {
                    judge[nums2[i]]--;
                    result.Add(nums2[i]);
                    if (judge[nums2[i]] == 0)
                    {
                        judge.Remove(nums2[i]);
                    }
                }
            }

            return result.ToArray();
        }

        public static int[] PlusOne(int[] digits)
        {
            if (digits.Length == 0)
            {
                return digits;
            }

            digits[digits.Length - 1]++;
            bool needAdd = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (needAdd)
                {
                    digits[i]++;
                }

                needAdd = digits[i] >= 10;
                if (needAdd)
                {
                    digits[i] -= 10;
                }
                else
                {
                    break;
                }

            }

            int[] result;
            if (needAdd)
            {
                result = new int[digits.Length + 1];
                Array.Copy(digits, 0, result, 1, digits.Length);
                result[0] = 1;
            }
            else
            {
                result = digits;
            }

            return result;
        }

        public static void MoveZeroes(int[] nums)
        {
            int zeroStart = -1;
            int i = 0;
            while (i < nums.Length - 1)
            {

                if (nums[i] == 0)
                {
                    if (zeroStart == -1) zeroStart = i;
                    if (nums[i + 1] != 0)
                    {
                        nums[zeroStart] = nums[i + 1];
                        nums[i + 1] = 0;
                        zeroStart++;
                    }
                }

                i++;
            }
        }

        public bool IsValidSudoku(char[,] board)
        {
            HashSet<int>[] squadSet = new HashSet<int>[9];
            HashSet<int>[] colSet = new HashSet<int>[9];
            HashSet<int>[] lineSet = new HashSet<int>[9];
            for (int i = 0; i < 9; i++)
            {
                squadSet[i] = new HashSet<int>();
                colSet[i] = new HashSet<int>();
                lineSet[i] = new HashSet<int>();
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    char cur = board[i, j];
                    if (cur == '.') continue;
                    int curInt = cur - '0';
                    int sqadIndex = i / 3 * 3 + j / 3;
                    if (squadSet[sqadIndex].Contains(curInt))
                    {
                        return false;
                    }
                    else
                    {
                        squadSet[sqadIndex].Add(curInt);
                    }

                    int colIndex = j;
                    if (colSet[j].Contains(curInt))
                    {
                        return false;
                    }
                    else
                    {
                        colSet[j].Add(curInt);
                    }

                    int lineIndex = i;
                    if (lineSet[i].Contains(curInt))
                    {
                        return false;
                    }
                    else
                    {
                        lineSet[i].Add(curInt);
                    }
                }
            }

            return true;
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle == null || needle.Length == 0)
            {
                return 0;
            }
            var needleChar = needle.ToCharArray();
            var hayChar = haystack.ToCharArray();
            int[] next = new int[needle.Length];
            int judge = 1;
            next[0] = -1;
            while (judge < needle.Length - 1 )
            {
                char judgeChar = needleChar[judge];
                int nextIndex = judge;
                while (next[nextIndex] >= 0 && needleChar[next[nextIndex] ] != judgeChar)
                {
                    nextIndex = next[nextIndex];
                }
                judge++;
                next[judge] = next[nextIndex] + 1;
            }
            int hayIndex = 0;                      
            int needleIndex = 0;
            while (needleIndex < needleChar.Length && hayIndex < hayChar.Length)
            {
                if (hayChar[hayIndex] == needleChar[needleIndex])
                {
                    hayIndex++;
                    needleIndex++;
                }
                else if(needleIndex == 0)
                {
                    hayIndex++;
                }
                else
                {
                    needleIndex = next[needleIndex];
                }
            }

            if (needleIndex == needleChar.Length)
            {
                return hayIndex - needleIndex;
            }
            else
            {
                return -1;
            }

        }
        
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";
            Array.Sort(strs);
            int index = 0;
            char[] firstChar = strs[0].ToCharArray();
            char[] lastChar = strs[strs.Length - 1].ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < firstChar.Length; i++)
            {
                if (firstChar[i] == lastChar[i])
                {
                    sb.Append(firstChar[i]);
                }
                else
                {
                    break;
                }
            }

            return sb.ToString();
        }
        
        public string CountAndSay(int n) {
            List<List<char>> chars = new List<List<char>>();
            chars.Add(new List<char>());
            chars.Add(new List<char>(){'1'});
            for (int i = 1; i < n; i++)
            {
                int index = 0;
                var curChars = chars[i];
                var nextChars = new List<char>();
                while (index < curChars.Count)
                {
                    var curChar = curChars[index];
                    int numOfChar = 1;
                    while(index < curChars.Count - 1 && curChar == curChars[index + 1])
                    {
                        numOfChar++;
                        index++;
                    }

                    while (numOfChar > 0)
                    {
                        nextChars.Add((char)(numOfChar%10+'0'));
                        numOfChar /= 10;
                    }
                    nextChars.Add(curChar);
                    index++;
                }
                chars.Add(nextChars);
            }
            var resultBuild = new StringBuilder();
            for (int i = 0; i < chars[n].Count; i++)
            {
                resultBuild.Append(chars[n][i]);
            }
        
            return resultBuild.ToString();
        }

        private int[] _rectangleLocations;
        
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            EdgeForRectTangele[] es = new EdgeForRectTangele[4];
            var tree = new TreeNodeForSegmentWithRectangle[64];
            _rectangleLocations = new int[4]{rec1[0], rec1[2],  rec2[0], rec2[2]};
            Array.Copy(GetEdgeByRect(rec1), 0, es, 0, 2);
            Array.Copy(GetEdgeByRect(rec2), 0, es, 2, 2);
            Array.Sort(es, (data1, data2) => data1.Height - data2.Height);
            Array.Sort(_rectangleLocations);
            int k = 1;
            for (int i = 1; i < _rectangleLocations.Length; i++)
            {
                if (_rectangleLocations[i] != _rectangleLocations[i -  1])
                {
                    _rectangleLocations[k] = _rectangleLocations[i];
                    k++;
                }
            }
            Build(tree, 0, 0, k - 1);
            int totalArea = 0;
            for (int i = 0; i < es.Length - 1; i++)
            {
                int indexL = Array.IndexOf(_rectangleLocations, es[i].LocationL);
                int indexR = Array.IndexOf(_rectangleLocations, es[i].LocationR);
                Update(tree, 0, indexL, indexR, es[i].UpDown);
                totalArea += tree[0].Length * (es[i + 1].Height - es[i].Height);
            }
            Console.WriteLine(totalArea);
            int preArea = (rec1[2] - rec1[0]) * (rec1[3] - rec1[1]) + (rec2[2] - rec2[0]) * (rec2[3] - rec2[1]);
            return totalArea - preArea != 0;

        }
        
        private struct TreeNodeForSegmentWithRectangle
        {
            public int IndexL;
            public int IndexR;
            public int CompleteGet;
            public int Length;
        }

        private struct EdgeForRectTangele
        {
            public int Height;
            public int UpDown;
            public int LocationL;
            public int LocationR;
            
        }

        private EdgeForRectTangele[] GetEdgeByRect(int[] rec)
        {
            int[] xs = new int[] {rec[0], rec[2]};
            int[] ys = new int[] {rec[1], rec[3]};
            var result = new EdgeForRectTangele[2];
            for (int i = 0; i < ys.Length; i++)
            {
                var edge = new EdgeForRectTangele();
                edge.Height = ys[i];
                edge.UpDown = i == 0 ? 1 : -1;
                edge.LocationL = xs[0];
                edge.LocationR = xs[1];
                result[i] = edge;
            }

            return result;
        }

        private void Build(TreeNodeForSegmentWithRectangle[] treeStruct, int i, int l, int r)
        {
            
            var treeNode = new TreeNodeForSegmentWithRectangle();
            treeNode.IndexL = l;
            treeNode.IndexR = r;
            treeNode.CompleteGet = 0;
            treeNode.Length = 0;
            Console.WriteLine(i);
            treeStruct[i] = treeNode;
            if (l == r) return;
            Build(treeStruct, (i<<1)+1, l, (l+r)>>1);
            Build(treeStruct, (i<<1)+2, ((l+r)>>1), r);
        }

        private void Update(TreeNodeForSegmentWithRectangle[] treeStruct, int i, int l, int r, int upDown)
        {
            if (treeStruct[i].IndexL == l && treeStruct[i].IndexR == r)
            {
                treeStruct[i].CompleteGet += upDown;
                PushUp(treeStruct, i);
                return;
            }

            int mid = (treeStruct[i].IndexL + treeStruct[i].IndexR) / 2;
            if (r <= mid)
            {
                Update(treeStruct, i*2+1, l, r,upDown);
            }else if (l > mid)
            {
                Update(treeStruct, i*2+2, l, r, upDown);
            }
            else
            {
                Update(treeStruct, i*2+1, l, mid, upDown);
                Update(treeStruct, i*2+2, mid+1, r, upDown);
            }
        }

        private void PushUp(TreeNodeForSegmentWithRectangle[] treeStruct, int i)
        {
            if (treeStruct[i].CompleteGet != 0)
            {
                treeStruct[i].Length =
                    _rectangleLocations[treeStruct[i].IndexR] - _rectangleLocations[treeStruct[i].IndexL];
            }
            else if(treeStruct[i].IndexL == treeStruct[i].IndexR)
            {
                treeStruct[i].Length = 0;
            }
            else // 某一方是1而另一边是0的情况，部分覆盖线段
            {
                treeStruct[i].Length = treeStruct[i * 2 + 1].Length + treeStruct[i * 2 + 2].Length;
            }
        }
        
        public void DeleteNode(ListNode node)
        {
            var nextNode = node.next;
            node.val = nextNode.val;
            node.next = nextNode.next;
        }
        
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var nthNode = head;
            for (int i = 0; i < n; i++)
            {
                nthNode = nthNode.next;
            }

            if (nthNode == null)
            {
                return head.next;
            }
            var currentNode = head;
            while (nthNode.next != null)
            {
                currentNode = currentNode.next;
                nthNode = nthNode.next;
            }
            
            currentNode.next = currentNode.next.next;
            return head;
        }
        
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var currentNode = head;
            var nextNode = head.next;
            while (nextNode != null)
            {
                var tempNode = nextNode.next;
                nextNode.next = currentNode;
                currentNode = nextNode;
                nextNode = tempNode;
            }

            head.next = null;
            return currentNode;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode currentNode = null;
            while (l1!=null || l2!=null)
            {
                if (l1 == null)
                {
                    currentNode = l2;
                    l2 = l2.next;
                }else if (l2 == null)
                {
                    currentNode = l1;
                    l1 = l1.next;
                }
                else if(l1.val<=l2.val)
                {
                    currentNode = l1;
                    l1 = l1.next;
                }
                else
                {
                    currentNode = l2;
                    l2 = l2.next;
                }

                if (head == null)
                {
                    head = currentNode;
                }
                currentNode = currentNode.next;
            }

            return head;
        }
    }
}