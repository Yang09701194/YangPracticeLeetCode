using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Solved;

namespace YangPracticeLeetCode.Solved
{
    class _941_ValidMountainArray
    {

        public static void Test()
        {

            Solution s = new Solution();


            int[] a4 = new[] { 2 };
            a4.PrintList();
            Console.WriteLine(s.ValidMountainArray(a4) + " should be false");


            int[] a = new[] {2, 1};
            a.PrintList();
            Console.WriteLine(s.ValidMountainArray(a));

            int[] a2 = new[] {3, 5, 5};
            a2.PrintList();
            Console.WriteLine(s.ValidMountainArray(a2));

            int[] a3 = new[] {0, 3, 2, 1};
            a3.PrintList();
            Console.WriteLine(s.ValidMountainArray(a3));

        }

        public class Solution
        {
            public bool ValidMountainArray(int[] A)
            {
                if (A.Length == 0)
                    return false;
        
                int max = A[0];
                int maxPos = 0;
                for (int i = 1; i < A.Length; i++)
                {
                    if (A[i] > max)
                    {
                        max = A[i];
                        maxPos = i;
                    }
                }

                if (maxPos == 0 || maxPos == A.Length - 1)
                    return false;

                for (int i = 0; i < maxPos; i++)
                {
                    if (A[i] >= A[i + 1])
                        return false;
                }

                for (int i = maxPos; i < A.Length - 1; i++)
                {
                    if (A[i] <= A[i + 1])
                        return false;
                }

                return true;
            }
        }



    }
}
