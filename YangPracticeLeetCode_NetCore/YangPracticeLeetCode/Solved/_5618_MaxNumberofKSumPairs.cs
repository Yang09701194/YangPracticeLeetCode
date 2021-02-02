using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5618_MaxNumberofKSumPairs
	{

		public static void Test()
		{
			Solution_V1 s = new Solution_V1();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.MaxOperations(new int[] { 1, 2, 3, 4 },5));
			Console.WriteLine(s.MaxOperations(new int[] { 3, 1, 3, 4, 3 },6));

		}

		/// <summary>
		/// 208ms  ㄎㄎ
		/// </summary>
		public class Solution
		{
			public int MaxOperations(int[] nums, int k)
			{
				List<int> nls = nums.ToList();
				nls.Sort();

				int total = 0;

				//  雙指標  相向而行
				//  3    9-3 = 6
				for (int i = 0, j = nls.Count - 1;  j > i; )
				{
					int left = nls[i];
					int right = nls[j];
					int diff = k - left;
					if (right > diff)
					{
						j--;
					}
					else if (right == diff)
					{
						total++;
						i++;
						j--;
					}
					else// right < diff
					{
						i++;
					}
				}


				return total;
			}
		}




		/// <summary>
		///  contest 100% 670ms~700ms
		/// </summary>
		public class Solution_V1
		{
			public int MaxOperations(int[] nums, int k)
			{
				List<int> nls = nums.ToList();
				nls.Sort();

				int total = 0;
				while (nls.Count >= 2)
				{
					//  3    9-3 = 6
					int first = nls[0];
					int diff = k - first;

					for (int i = nls.Count - 1; i > 0; i--)
					{
						if (nls[i] > diff)
						{
							nls.RemoveAt(i);
						}
						else if (nls[i] == diff)
						{
							total++;
							nls.RemoveAt(i);
							nls.RemoveAt(0);
							break;
						}
						else//nls[i] < diff
						{
							nls.RemoveAt(0);
							break;
						}
					}
				}

				return total;
			}
		}


	}
}
