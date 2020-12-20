using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5630_MaximumErasureValue
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.MaximumUniqueSubarray(new[] { 4, 2, 4, 5, 6 }));
			Console.WriteLine(s.MaximumUniqueSubarray(new[] { 5, 2, 1, 2, 5, 2, 1, 2, 5 }));

		}

		public class Solution
		{
			public int MaximumUniqueSubarray(int[] nums)
			{
				if (nums.Length == 1)
					return nums[0];
				
				if (nums[0] == nums[1])
					return nums[0];

				var n = nums;
				HashSet<int> h = new HashSet<int>();
				h.Add(n[0]);
				h.Add(n[1]);

				int sum = n[0] + n[1];
				int max = sum;
				for (int i = 0, j =2; j < n.Length;j++)
				{
					if (h.Contains(n[j]))
					{
						while (n[i] != n[j])
						{
							sum -= n[i];
							h.Remove(n[i]);
							i++;
						}
						//remove & add ­è¦n¤£¥Îremove
						i++;
					}
					else
					{
						h.Add(n[j]);
						sum += n[j];
						max = Math.Max(max, sum);
					}
				}

				return max;
			}
		}


	}
}
