using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5535_MaximumNestingDepthoftheParentheses
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.MaxDepth("(1+(2*3)+((8)/4))+1"));
			//Console.WriteLine(s.MaxDepth(""));
			Console.WriteLine(s.MaxDepth("(1)+((2))+(((3)))"));
			Console.WriteLine(s.MaxDepth("1+(2*3)/(2-1)"));
			Console.WriteLine(s.MaxDepth("1"));

		}

		public class Solution
		{
			public int MaxDepth(string s)
			{
				int parDepth = 0, maxLeftParen = 0;

				for (int i = 0; i < s.Length; i++)
				{
					if (s[i] == '(')
					{
						parDepth++;
						if (parDepth > maxLeftParen)
							maxLeftParen = parDepth;
					}

					if (s[i] == ')')
						parDepth--;
				}

				return maxLeftParen;
			}
		}

	}
}
