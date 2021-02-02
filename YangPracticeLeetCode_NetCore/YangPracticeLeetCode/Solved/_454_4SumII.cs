using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _454_4SumII
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.FourSumCount(
				new int[] { 1,2 },
				new int[] { -2,-1 },
				new int[] {  -1,2},
				new int[] { 0,2 }
				));

		}

		public class Solution
		{
			public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
			{

				Dictionary<int, int> sumCou = new Dictionary<int, int>();
				for (int i = 0; i < A.Length; i++)
				{
					for (int j = 0; j < B.Length; j++)
					{
						int sum = A[i] + B[j];
						if (sumCou.ContainsKey(sum))
							sumCou[sum]++;
						else
							sumCou[sum] = 1;
					}
				}

				int res = 0;
				for (int i = 0; i < C.Length; i++)
				{
					for (int j = 0; j < D.Length; j++)
					{
						int sum = -C[i] - D[j];
						if (sumCou.ContainsKey(sum))
							res += sumCou[sum];
					}
				}

				return res;

			}
		}

	}
}
