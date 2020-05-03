using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5401_CheckIfAll1sAreatLeastLengthKPlacesAway
	{

		public static void Test()
		{
			Solution s = new Solution();

			Console.WriteLine(s.KLengthApart(new []{ 1, 0, 0, 1, 0, 1 }, 2));




		}

	public class Solution
		{
			public bool KLengthApart(int[] nums, int k)
			{

				int currPlace = 0;
				int min1sPlace = 100000;
				bool isFirst1 = true;
				foreach (int num in nums)
				{
					if (num == 1)
					{
						if (currPlace < min1sPlace && !isFirst1)
							min1sPlace = currPlace;
						currPlace = 0;
						isFirst1 = false;
					}
					else
					{
						currPlace++;
					}
				}

				return k <= min1sPlace;
			}
		}


	}
}
