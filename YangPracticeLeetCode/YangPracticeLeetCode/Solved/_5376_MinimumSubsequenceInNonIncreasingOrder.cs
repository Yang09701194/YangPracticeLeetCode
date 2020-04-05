using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5376_MinimumSubsequenceInNonIncreasingOrder
	{

		public static void Test()
		{

			Solution s = new Solution();
			var nums = new int[] {4, 3, 10, 9, 8};
			s.MinSubsequence(nums).PrintList();

			nums = new int[] { 4, 4, 7, 6, 7 };
			s.MinSubsequence(nums).PrintList();

			nums = new int[] { 6 };
			s.MinSubsequence(nums).PrintList();

		}


		public class Solution
		{
			public IList<int> MinSubsequence(int[] nums)
			{
				var ns = nums.ToList().OrderByDescending(t => t).Where(t => t != 0).ToList();

				int totalLsSum = ns.Sum();
				int subSum = 0;
				List<int> subSeq = new List<int>();
				for (int i = 0; i < ns.Count(); i++)
				{
					subSum += ns[i];
					totalLsSum -= ns[i];
					subSeq.Add(ns[i]);
					if (subSum > totalLsSum)
						break;
				}

				return subSeq;
			}
		}


	}
}
