using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5637_DetermineifStringHalvesAreAlike
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

				Console.WriteLine(s.HalvesAreAlike("book"));
				Console.WriteLine(s.HalvesAreAlike("textbook"));

		}
		public class Solution
		{
			public bool HalvesAreAlike(string s)
			{

				var vowels = "aeiouAEIOU".ToCharArray();
				HashSet<char> hs = new HashSet<char>();
				foreach (char v in vowels)
				{
					hs.Add(v);
				}


				int splitPt = (s.Length / 2);// 4/2 = 2     
				string a = s.Substring(0, splitPt);
				string b = s.Substring(splitPt );

				int couA = 0, couB = 0;
				foreach (char c in a)
				{
					if (hs.Contains(c))
						couA++;
				}
				foreach (char c in b)
				{
					if (hs.Contains(c))
						couB++;
				}

				return couA == couB;
			}
		}


	}
}
