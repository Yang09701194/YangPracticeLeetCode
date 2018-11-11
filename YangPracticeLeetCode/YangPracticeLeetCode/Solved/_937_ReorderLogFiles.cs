using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
    public class _937_ReorderLogFiles
    {

        public static void Test()
        {
            Solution s = new Solution();

            string[] logs1 = new[] {"a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo"};
            var results = s.ReorderLogFiles(logs1);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

        }

        public class Solution
        {
            public string[] ReorderLogFiles(string[] logs)
            {

                List<string> Logs = logs.ToList();
                List<List<string>> Logss = Logs.Select(s => s.Split(' ').ToList()).ToList();

                Regex numberReg = new Regex("^[0-9]+");

                List<List<string>> numLogss = new List<List<string>>();
                List<List<string>> strLogss = new List<List<string>>();

                foreach (var _Logs in Logss)
                {
                    
                    if(numberReg.IsMatch(_Logs[1]))
                        numLogss.Add(_Logs);
                    else
                        strLogss.Add(_Logs);
                }


                strLogss = strLogss.OrderBy(llogs => Remove1stToStr(llogs)).ToList();

                List<string> result = new List<string>();

                foreach (List<string> lllogs in strLogss)
                    result.Add(lllogs.Aggregate(((pre, next)=>pre+" "+next)));
                foreach (List<string> lllogs in numLogss)
                    result.Add(lllogs.Aggregate(((pre, next)=>pre+" "+next)));

                return result.ToArray();
            }
              public static string Remove1stToStr(List<string> strs)
                {
                    List<string> temp = new List<string>();
                    for (int i = 1; i < strs.Count; i++)
                    {
                        temp.Add(strs[i]);
                    }
                    return temp.Aggregate(((pre, next) => pre + " " + next));
                }



        }

  

    }
}
