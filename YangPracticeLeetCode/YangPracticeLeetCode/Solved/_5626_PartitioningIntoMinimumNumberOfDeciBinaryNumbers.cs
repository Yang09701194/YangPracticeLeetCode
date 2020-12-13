using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5626_PartitioningIntoMinimumNumberOfDeciBinaryNumbers
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.MinPartitions("27346209830709182346"));

		}



		public class Solution
		{
			public int MinPartitions(string n)
			{
				int max = n.Max(c => c - '0');
				return max;
			}
		}



	}
}
