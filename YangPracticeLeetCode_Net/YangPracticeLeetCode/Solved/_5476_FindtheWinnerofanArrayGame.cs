using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5476_FindtheWinnerofanArrayGame
	{


		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.GetWinner(new int[] { 3, 2, 1 }, 10));
			Console.WriteLine(s.GetWinner(new int[] { 1, 9, 8, 2, 3, 7, 6, 4, 5 }, 7));
			Console.WriteLine(s.GetWinner(new int[] { 1, 11, 22, 33, 44, 55, 66, 77, 88, 99 }, 1000000000));
			
		}


		public class Solution
		{
			public int GetWinner(int[] arr, int k)
			{
				int realK = k > arr.Length ? arr.Length : k;
				int first = arr[0];
				int accFirst = 0;

				List<int> la = arr.ToList();
				while (la.Count > 1 && accFirst < realK)
				{
					bool isFirstWin = la[0] > la[1];
					if (isFirstWin)
					{
						//la.Add(la[1]);
						la.RemoveAt(1);
						accFirst++;
					}
					else
					{
						accFirst = 1;
						first = la[1];
						//la.Add(la[0]);
						la.RemoveAt(0);
					}
				}

				return first;
			}
		}


	}
}
