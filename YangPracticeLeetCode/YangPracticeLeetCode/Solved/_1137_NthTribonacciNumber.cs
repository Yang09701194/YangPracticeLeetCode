using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1137_NthTribonacciNumber
	{


		public static void Test()
		{

			Solution s = new Solution();
			Console.WriteLine(s.Tribonacci(4));
			//s = new Solution();
			Console.WriteLine(s.Tribonacci(25));



			
		}


		public class Solution
		{
			private List<int> triVals = new List<int>() {0, 1, 1};

			public int Tribonacci(int n)
			{
				if (n <= triVals.Count - 1)
					return triVals[n];

				for (int i = triVals.Count; i <= n; i++)
				{
					triVals.Add(triVals[i-3] + triVals[i - 2] + triVals[i - 1]);
				}

				return triVals[n];
			}
		}


	}
}
