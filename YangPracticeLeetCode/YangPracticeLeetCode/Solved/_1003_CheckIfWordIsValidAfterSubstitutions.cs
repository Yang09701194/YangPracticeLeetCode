using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1003_CheckIfWordIsValidAfterSubstitutions
	{
		public static void Test()
		{
			Solution s = new Solution();
			string s1 = "abcabcababcc";
			Console.WriteLine(s.IsValid(s1));


		}


		public class Solution
		{
			public bool IsValid(string S)
			{
				while (S != "")
				{
					if (S.Contains("abc"))
					{
						S = S.Replace("abc", "");
					}
					else
					{
						break;
					}
				}

				return S == "";
			}
		}

	}
}
