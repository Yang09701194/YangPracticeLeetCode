using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Solved;

namespace YangPracticeLeetCode.Solved
{
	class _961_N_RepeatedElementInSize2NArray
	{
		public static void Test()
		{
			Solution s = new Solution();

			int[] a4 = new int[] { 1, 2, 3, 3 };
			int[] a5 = new int[] { 2, 1, 2, 5, 3, 2 };
			int[] a6 = new int[] { 5, 1, 5, 2, 5, 3, 5, 4 };

			a4.PrintList();
			Console.WriteLine(s.RepeatedNTimes(a4) + " is 3");

			a5.PrintList();
			Console.WriteLine(s.RepeatedNTimes(a5) + " is 2");

			a6.PrintList();
			Console.WriteLine(s.RepeatedNTimes(a6) + " is 5");
		}


		public class Solution
		{
			public int RepeatedNTimes(int[] A)
			{
				int resultCou = A.Length / 2;
				Dictionary<int,int> num_cou = new Dictionary<int, int>();
				for (int i = 0; i < A.Length; i++)
				{
					int key = A[i];
					if (!num_cou.ContainsKey(A[i]))
					{
						num_cou.Add(key, 0);
						num_cou[key] += 1;
					}
					else
						num_cou[key] += 1;

					if (num_cou[key] == resultCou)
						return key;
				}

				return -1;
			}
		}

	}
}
