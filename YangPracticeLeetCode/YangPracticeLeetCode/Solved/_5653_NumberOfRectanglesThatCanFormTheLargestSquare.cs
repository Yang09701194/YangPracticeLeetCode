using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5653_NumberOfRectanglesThatCanFormTheLargestSquare
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());
	
			Console.WriteLine(s.CountGoodRectangles(new int[][]
			{
				new []{5,8},
				new []{3,9},
				new []{5,12},
				new []{16,5},
				//new []{,},
				//new []{,},
			}));

		}

		class Solution
		{
			public int CountGoodRectangles(int[][] rectangles)
			{
				List<int> minWidths = new List<int>();
				foreach (int[] rectangle in rectangles)
				{
					minWidths.Add(Math.Min(rectangle[0], rectangle[1]));
				}

				minWidths.Sort();
				return minWidths.Count(w => w == minWidths.Last());
			}
		}


	}
}
