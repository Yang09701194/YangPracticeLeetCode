using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5464_WaterBottles
	{


		public static void Test()
		{
			Solution s = new Solution();

			int bt = 9, ex = 3;
			Console.WriteLine($"{bt} {ex} " + s.NumWaterBottles(bt, ex));
			bt = 15;
			ex = 4;
			Console.WriteLine($"{bt} {ex} " + s.NumWaterBottles(bt, ex));
			bt = 5;
			ex = 5;
			Console.WriteLine($"{bt} {ex} " + s.NumWaterBottles(bt, ex));
			bt = 2;
			ex = 3;
			Console.WriteLine($"{bt} {ex} " + s.NumWaterBottles(bt, ex));




		}



		public class Solution
		{
			public int NumWaterBottles(int numBottles, int numExchange)
			{
				int totalDrinkBottles = numBottles;
				return Drink(totalDrinkBottles, totalDrinkBottles, numExchange);
			}

			public int Drink(int totalDrinkBottles, int emptyBottles, int numExchange)
			{
				int exchangeRemainEmpty = emptyBottles % numExchange;
				int exchange = emptyBottles / numExchange;
				if (exchange == 0)
					return totalDrinkBottles;

				emptyBottles = exchangeRemainEmpty + exchange;
				totalDrinkBottles += exchange;

				return Drink(totalDrinkBottles, emptyBottles, numExchange);
			}

		}

	}
}
