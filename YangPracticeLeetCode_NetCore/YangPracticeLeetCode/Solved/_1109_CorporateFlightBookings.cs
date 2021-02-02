using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Helper;

namespace YangPracticeLeetCode.Solved
{
	class _1109_CorporateFlightBookings
	{

		public static void Test()
		{
			Solution s = new Solution();

			int[][] flightSeats = new int[][]
			{
				new int[] {1,2,10},
				new int[] {2,3,20},
				new int[] {2,5,25} 
			};
			var t = TimerY.New();
			s.CorpFlightBookings(flightSeats, 5).PrintList();
			t.TimingMs();
			//10, 55, 45, 25, 25

			int[][] flightSeats2 = new int[][]
			{
				new int[] {2,2,35},
				new int[] {1,2,10},
			};

			var t2 = TimerY.New();
			s.CorpFlightBookings(flightSeats2, 2).PrintList();
			t2.TimingMs();
			//10, 45

		}

		public class Solution
		{
			/// <summary>
			/// 這題沒想出來 太困難  靠解答
			/// https://leetcode.com/problems/corporate-flight-bookings/discuss/328871/C%2B%2BJava-with-picture-O(n)
			/// </summary>
			/// <param name="bookings"></param>
			/// <param name="n"></param>
			/// <returns></returns>
			public int[] CorpFlightBookings(int[][] bookings, int n)
			{
				int[] totalBookFlights = new int[n];

				foreach (var book in bookings)
				{
					totalBookFlights[book[0] - 1] += book[2];
					if (book[1] < n) totalBookFlights[book[1]] -= book[2];
				}

				for (int i = 1; i < totalBookFlights.Length; i++)
					totalBookFlights[i] += totalBookFlights[i - 1]; 

				//// correct solution but time exceed
				//for (int i = 0; i < bookings.Length; i++)
				//{
				//	for (int j = bookings[i][0]; j <= bookings[i][1]; j++)
				//	{
				//		totalBookFlights[j - 1] += bookings[i][2];
				//	}
				//}

				return totalBookFlights;
			}

		}



	}




}
