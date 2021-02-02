using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5613_RichestCustomerWealth
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.MaximumWealth(new int[][] { new int[] {7,3},new int[] {3,5},   }));

		}
		public class Solution
		{
			public int MaximumWealth(int[][] accounts)
			{
				int max = 0;
				foreach (int[] acc in accounts)
				{
					int sum = acc.Sum();
					if (sum > max)
						max = sum; 
				}

				return max;
			}
		}


	}
}
