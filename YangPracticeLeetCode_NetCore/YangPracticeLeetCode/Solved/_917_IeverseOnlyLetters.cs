using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
    public class _917_IeverseOnlyLetters
    {
        public static void Test()
        {
            Solution s = new Solution();

            string s1 = "ab-cd";
            string s2 = "a-bC-dEf-ghIj";
            string s3 = "Test1ng-Leet=code-Q!";



            Console.WriteLine(s1);
            Console.WriteLine(s.ReverseOnlyLetters(s1));
            Console.WriteLine("dc-ba");

            Console.WriteLine(s2);
            Console.WriteLine(s.ReverseOnlyLetters(s2));
            Console.WriteLine("j-Ih-gfE-dCba");

            Console.WriteLine(s3);
            Console.WriteLine(s.ReverseOnlyLetters(s3));
            Console.WriteLine("Qedo1ct-eeLg=ntse-T!");



        }


        public class Solution
        {
            public string ReverseOnlyLetters(string S)
            {
                char[] chars = S.ToCharArray();
                byte[] bytes = Encoding.ASCII.GetBytes(S);

                //ASCII  a-z 的DECimal 97-122
                //ASCII  A-Z 的DECimal 65-90
                List<int> not_azAZ_pos = new List<int>();
                for (int i = 0; i < bytes.Length; i++)
                {
                    int now = bytes[i];
                    if (
                        ! ((97 <= now && now <= 122) || (65 <= now && now <= 90)))
                        not_azAZ_pos.Add(i);
                }

                string azAz = "";
                for (int i = 0; i < chars.Length; i++)
                    if (!not_azAZ_pos.Contains(i))
                        azAz += chars[i];
                int azAztailPos = azAz.Length - 1;

                string result = "";
                for (int i = 0, j = 0; i < chars.Length; i++)
                {
                    if (not_azAZ_pos.Contains(i))
                        result += chars[i];
                    else
                    {
                        result += azAz[azAztailPos - j];
                        j++;
                    }
                }
                return result;
            }
        }
    }
}
