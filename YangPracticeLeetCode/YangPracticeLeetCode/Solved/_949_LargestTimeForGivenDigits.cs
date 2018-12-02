using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Helper;

namespace YangPracticeLeetCode.Solved
{
	class _949_LargestTimeForGivenDigits
	{

		public static void Test()
		{
			Solution s = new Solution();

			int[] a4 = new[] { 1,2,3,4 };
			a4.PrintList();
			Console.WriteLine(s.LargestTimeFromDigits(a4) + " is 23:41");

			int[] a = new[] { 5,5,5,5 };
			a.PrintList();
			Console.WriteLine(s.LargestTimeFromDigits(a) + " is \"\"");

			int[] a2 = new[] { 2,3,5,9 };
			a2.PrintList();
			Console.WriteLine(s.LargestTimeFromDigits(a2) + " is 23:59");

			int[] a6 = new[] { 0,0,0,0 };
			a6.PrintList();
			Console.WriteLine(s.LargestTimeFromDigits(a6) + " is \"\"");

		}


		public class Solution
		{
			public string LargestTimeFromDigits(int[] A)
			{
				string s = A.ToList().Select(a => a.ToString()).Aggregate((pre, next) => pre + next);

				List<string> pers = new List<string>();
				WordPermuatation("", s, pers);

				List<int> validTimes = new List<int>();
				foreach (var per in pers)
				{
					int iPer = Convert.ToInt32(per);
					// mm >= 60 || HH >23
					if(iPer%100 >=60 || iPer>2359)
						continue;
					validTimes.Add(iPer);
				}

				return validTimes.Any() ? validTimes.Max().ToString("0000").Insert(2,":")
					: "";
			}


			void WordPermuatation(string prefix, string word, List<string> result)
			{
				int n = word.Length;
				if (n == 0)
				{
					/*Console.WriteLine(prefix);*/
					result.Add(prefix);
				}
				else
				{
					for (int i = 0; i < n; i++)
					{
						WordPermuatation(prefix + word[i]
							, word.Substring(0, i) + word.Substring(i + 1, n - (i + 1))
							, result);
					}
				}
			}
		}


	}
}
