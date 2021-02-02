using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5617_GoalParserInterpretation
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.Interpret("(al)G(al)()()G"));

		}

		public class Solution
		{
			public string Interpret(string command)
			{
				command = command.Replace("()", "o").Replace("(al)", "al");
				return command;
			}
		}

	}
}
