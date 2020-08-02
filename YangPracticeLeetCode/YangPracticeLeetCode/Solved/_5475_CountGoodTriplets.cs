using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5475_CountGoodTriplets
	{


		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.CountGoodTriplets(new int[] { 1, 7, 4, 5, 2, 0 }, 2,5,6));
			Console.WriteLine(s.CountGoodTriplets(new int[] { 3, 0, 1, 1, 9, 7 }, 7,2,3));
			Console.WriteLine(s.CountGoodTriplets(new int[] { 1, 1, 2, 2, 3 }, 0,0,1));
			
		}


		public class Solution
		{
			public int CountGoodTriplets(int[] arr, int a, int b, int c)
			{
				int cou = 0;
				for (int i = 0; i <= arr.Length - 3; i++)
				{
					for (int j = i + 1; j <= arr.Length - 2; j++)
					{
						for (int k = j + 1; k <= arr.Length - 1; k++)
						{
							if (Math.Abs(arr[i] - arr[j]) <= a
							    && Math.Abs(arr[j] - arr[k]) <= b
							    && Math.Abs(arr[i] - arr[k]) <= c
							)
								cou++;
						}
					}
				}

				return cou;
			}
		}



	}
}
