using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5473_BulbSwitcherIV
	{

		public static void Test()
		{
			Solution s = new Solution();

			Console.WriteLine(s.MinFlips("10111"));
			Console.WriteLine(s.MinFlips("101"));
			Console.WriteLine(s.MinFlips("00000"));
			Console.WriteLine(s.MinFlips("001011101"));


		}


		public class Solution
		{
			public int MinFlips(string target)
			{

				int bitChange = 0;
				int currBit = '0';

				for (int i = 0; i < target.Length; i++)
				{
					if (target[i] != currBit)
					{
						currBit = target[i];
						bitChange++;
					}
				}

				return bitChange;
			}
		}

	}
}
