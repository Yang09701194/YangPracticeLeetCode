using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Solved;

namespace YangPracticeLeetCode.Solved
{
    class _942_DIStringMatch
    {
        public static void Test()
        {
            Solution s = new Solution();

            string a4 = "IDID";
            Console.WriteLine(a4);
            s.DiStringMatch(a4).PrintList();

            string a = "III";
            Console.WriteLine(a);
            s.DiStringMatch(a).PrintList();

            string a2 = "DDI";
            Console.WriteLine(a2);
            s.DiStringMatch(a2).PrintList();

        }

        public class Solution
        {
            public int[] DiStringMatch(string S)
            {
                int strLength = S.Length;
                int[] result = new int[strLength + 1];

                int min = 0;
                int max = strLength;
                int pos = 0;
                // 有I的話  第一個I是0  接著加一遞增
                // 有D的話  第一個D是strLength  接著減一遞減
                foreach (char c in S)
                {
                    if (c == 'I')
                        result[pos] = min++;
                    else
                        result[pos] = max--;
                    pos++;
                }
                result[strLength] = max--;//由觀察可知最後一個數字  無論是用 max-- 或 min++都正確
                return result.ToArray();
            }
        }
    }
}
