using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _824_GoatLatin
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.ToGoatLatin("I speak Goat Latin"));
			Console.WriteLine(s.ToGoatLatin("a"));
			Console.WriteLine(s.ToGoatLatin("The quick brown fox jumped over the lazy dog"));

		}


		public class Solution
		{
			public string ToGoatLatin(string S)
			{
				char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
				string[] strs = S.Split(' ');
				string _a = "a";
				for (int i = 0; i < strs.Length; i++)
				{
					string s = "";
					if (!vowels.Contains(strs[i][0]))
					{
						char first = strs[i][0];
						string remFirst = strs[i].Substring(1, strs[i].Length -1);
						s = remFirst + first ;
					}
					else
					{
						s = strs[i];
					}
					strs[i] = s + "ma" + _a;
					_a += "a";

				}
				return String.Join(" ", strs);
			}
		}


	}
}
