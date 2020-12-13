using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5625_CountofMatchesinTournament
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.NumberOfMatches(14));

		}


		public class Solution
		{
			public int NumberOfMatches(int n)
			{
				int matches = 0;
				while (n > 1)
				{
					int remainder = 0;
					if (n % 2 > 0)
						remainder = 1;
					n = n / 2;
					matches += n;
					n += remainder;

				}

				return matches;
			}
		}



	}
}
