using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
    class _1020_PartitionArrayIntoThreePartsWithEqualSum
    {

        public static void Test()
        {
            Solution s = new Solution();

            int[] i1 = new[] { 0, 2, 1, -6, 6, -7, 9, 1, 2, 0, 1 };
            Console.WriteLine(s.CanThreePartsEqualSum(i1));
            int[] i2 = new[] { 0, 2, 1, -6, 6, 7, 9, -1, 2, 0, 1 };
            Console.WriteLine(s.CanThreePartsEqualSum(i2));

        }

        public class Solution
        {
            public bool CanThreePartsEqualSum(int[] A)
            {
                long sum = A.Sum();
                if (sum % 3 != 0)
                    return false;
                long partitionSum = sum/3;
                long currentSum = 0, matchCount = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    currentSum += A[i];
                    if (currentSum == partitionSum)
                    {
                        matchCount += 1;
                        currentSum = 0;
                    }
                }
                return matchCount == 3;
            }
        }

    }
}
