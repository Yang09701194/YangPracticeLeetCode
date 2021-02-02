using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1103_DistributeCandiestoPeople
	{
		public static void Test()
		{
			Solution s = new Solution();

			int candies1 = 7;
			int people1 = 4;
			s.DistributeCandies(candies1, people1).PrintList();

			int candies2 = 10;
			int people2 = 3;
			s.DistributeCandies(candies2, people2).PrintList();



		}

		public class Solution
		{
			public int[] DistributeCandies(int candies, int num_people)
			{
				int[] distrCandToPeo = new int[num_people];

				int formalAddCan = 1;
				while (candies > 0)
				{
					for (int i = 0; i < distrCandToPeo.Length; i++)
					{
						if (candies == 0)
							break;
						int addCand = candies >= formalAddCan ? formalAddCan : candies;
						distrCandToPeo[i] += addCand;
						candies -= addCand;
						formalAddCan += 1;
					}
				}

				return distrCandToPeo;
			}
		}

	}
}
