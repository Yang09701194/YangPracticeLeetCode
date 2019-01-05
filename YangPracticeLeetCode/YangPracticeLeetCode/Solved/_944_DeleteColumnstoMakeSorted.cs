using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Solved;

namespace YangPracticeLeetCode.Solved
{
    class _944_DeleteColumnstoMakeSorted
    {
        public static void Test()
        {
            Solution s = new Solution();
            
            string[] a4 = new[] { "cba", "daf", "ghi" };
            a4.PrintList();
            Console.WriteLine(s.MinDeletionSize(a4) + " is 1");
            
            string[] a = new[] { "a", "b" };
            a.PrintList();
            Console.WriteLine(s.MinDeletionSize(a) + " is 0");

            string[] a2 = new[] { "zyx", "wvu", "tsr"};
            a2.PrintList();
            Console.WriteLine(s.MinDeletionSize(a2) + " is 3");

        }


        public class Solution
        {
            public int MinDeletionSize(string[] A)
            {
                int removeCou = 0;
                for (int j = 0; j < A[0].Length; j++) // 第j個字
                {
                    for (int i = 0; i < A.Length -1; i++) // 遍歷所有字串
                    {
                        if (A[i][j] > A[i + 1][j])
                        {
                            removeCou++;
                            break;
                        }
                    }
                }
                return removeCou;
            }
        }

    }
}
