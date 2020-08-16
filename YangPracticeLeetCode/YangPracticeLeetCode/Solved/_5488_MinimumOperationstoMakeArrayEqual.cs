using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5488_MinimumOperationstoMakeArrayEqual
	{

		//  3 ->  2   5 -> 2 + 4
		//            6 -> 1 + 3 + 5
		public class Solution
		{
			public int MinOperations(int n)
			{
				int mod = n % 2;
				int div2 = n / 2;
				int sum = 0;
				if (mod > 0)
				{
					for (int i = 1; i <= div2; i++)
					{
						sum += 2 * i;
					}
				}
				else
				{
					for (int i = 0; i < div2; i++)
					{
						sum += (2 * i) + 1;
					}
				}
				return sum;
			}
		}

	}
}
