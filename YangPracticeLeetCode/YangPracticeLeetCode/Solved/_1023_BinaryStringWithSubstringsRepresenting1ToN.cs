using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
    class _1023_BinaryStringWithSubstringsRepresenting1ToN
    {

        public static void Test()
        {
            Solution s = new Solution();

            Console.WriteLine(s.QueryString("0110", 3));
            Console.WriteLine(s.QueryString("0110", 4));
        }

        public class Solution
        {
            public bool QueryString(string S, int N)
            {
                for (int i = 1; i <= N; i++)
                {
                    string binaryStr = Convert.ToString(i, 2);
                    if (!S.Contains(binaryStr))
                        return false;
                }
                return true;
            }
        }

    }
}
