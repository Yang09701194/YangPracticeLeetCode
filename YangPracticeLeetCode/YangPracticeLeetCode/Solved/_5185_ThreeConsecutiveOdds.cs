using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5185_ThreeConsecutiveOdds
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.ThreeConsecutiveOdds(new int[] { 2, 6, 4, 1}));
			Console.WriteLine(s.ThreeConsecutiveOdds(new int[] { 1, 2, 34, 3, 4, 5, 7, 23, 12 }));
			//Console.WriteLine(s.ThreeConsecutiveOdds(new int[] { 1, 1, 2, 2, 3 }));

		}



		public class Solution
		{
			public bool ThreeConsecutiveOdds(int[] arr)
			{
				int consecutiveCou = 0;
				int[] odds = new int[] {1,3,5,7,9};
				foreach (int i in arr)
				{
					if (odds.Contains(i % 10))
					{
						consecutiveCou++;
						if (consecutiveCou == 3)
							return true;
					}
					else
					{
						consecutiveCou = 0;
					}
				}

				return false;
			}
		}

	}
}
