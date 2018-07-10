
using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MyTest
    {
        public int I;
        public static int[] GetRandomList(int totalValue, int userCount, int offset, int a, Random ran)
        {
            int[] result = new int[userCount];
            int orgin = totalValue/userCount - offset;
            orgin = orgin < 0 ? 0 : orgin;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = orgin;
            }
            int maxValue = orgin + offset*2;
            totalValue -= orgin*userCount;
            List<int> randomInts = new List<int>();
            int randomNum = 1;
            randomInts.Add(randomNum);
            totalValue -= randomNum;
            while (totalValue>0)
            {
                randomNum = (randomNum + a)%offset;
                if (randomNum > totalValue)
                {
                    randomNum = totalValue;
                }
                totalValue -= randomNum;
                randomInts.Add(randomNum);
            }
            int index = 0;
            
            while (index < randomInts.Count)
            {
                //int ri = index%(userCount);
                int ri = ran.Next(userCount);
                if (result[ri] + randomInts[index] > maxValue)
                {
                    randomInts.Add(randomInts[index]/2);
                    randomInts.Add(randomInts[index]/2 + randomInts[index]%2);
                }
                else
                {
                    result[ri] += randomInts[index];
                }
                index ++;
            }
            return result;
        }
    }
}
