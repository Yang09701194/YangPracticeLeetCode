using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	public class _989_AddToArrayFormOfInteger
	{
		public static void Test()
		{
			Solution s = new Solution();

			int[] A = new[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
			int K = 1;
			s.AddToArrayForm(A, K).PrintList();

			int[] A2 = new[] { 1,2,0,0 };
			int K2 = 34;
			s.AddToArrayForm(A2, K2).PrintList();

			int[] A3 = new[] { 1, 2, 6, 3, 0, 7, 1, 7, 1, 9, 7, 5, 6, 6, 4, 4, 0, 0, 6, 3 };
			int K3 = 516;
			s.AddToArrayForm(A3, K3).PrintList();

		}


		public class Solution
		{
			public IList<int> AddToArrayForm(int[] A, int K)
			{


				return null;
			}

			/// <summary>
			/// UInt64  也就是ulong 大約10 base最大20位數
			/// 
			///  
			/// </summary>
			/// <param name="A"></param>
			/// <param name="K"></param>
			/// <returns></returns>
			public IList<int> AddToArrayFormProcess(int[] A, int K)
			{

				List<int> L = A.ToList();
				L.Reverse();

				long sum = 0;
				for (int i = 0; i < L.Count; i++)
				{
					sum += L[i] * (long)Math.Pow(10, i);
				}

				sum += K;

				if (sum == 0)
					return new List<int>() { 0 };

				List<long> result = new List<long>();

				while (sum > 0)
				{
					result.Add(sum % 10);
					sum /= 10;
				}

				result.Reverse();
				return result.Select(i => (int)i).ToList();

			}


		}


	}
}
