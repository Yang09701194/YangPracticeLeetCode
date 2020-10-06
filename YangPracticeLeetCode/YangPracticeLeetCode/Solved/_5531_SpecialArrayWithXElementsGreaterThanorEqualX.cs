using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5531_SpecialArrayWithXElementsGreaterThanorEqualX
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));
			Console.WriteLine(s.SpecialArray(new int[] { 0, 0 }));
			Console.WriteLine(s.SpecialArray(new int[] { 0, 4, 3, 0, 4 }));
			Console.WriteLine(s.SpecialArray(new int[] { 3, 6, 7, 7, 0 }));
			Console.WriteLine(s.SpecialArray(new int[] { 3, 9, 7, 8, 3, 8, 6, 6 }));
			Console.WriteLine(s.SpecialArray(new int[] { 3, 6, 7, 7, 0 }));
			Console.WriteLine(s.SpecialArray(new int[] { 1, 3, 9, 5, 11, 2, 11, 0, 4, 2 }));

		}

		public class Solution
		{
			public int SpecialArray(int[] nums)
			{

				var not0Ele = nums.Where(n => n > 0).OrderBy(n => n).ToList();
				int not0EleCou = not0Ele.Count();
				int sum = nums.Sum();
				if (sum == 0)
					return -1;

				int start = not0EleCou < not0Ele[0] ? not0EleCou : not0Ele[0];
				int sq = (int) Math.Pow(sum, 0.5);
				int end = sq > not0EleCou ? not0EleCou : sq;

				int eIndex = 0;
				for (int i = start; i <= end; i++)
				{
					while (i > not0Ele[eIndex])
					{
						sum -= not0Ele[eIndex++];
						not0EleCou -= 1;
					}


					if ((i * i <= sum )
					    && 
						(i == not0EleCou))
						return not0EleCou;
					
				}

				return -1;

			}
		}


	}
}
