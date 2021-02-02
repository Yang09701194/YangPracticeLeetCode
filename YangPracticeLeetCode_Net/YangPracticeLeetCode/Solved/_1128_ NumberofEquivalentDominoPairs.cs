using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1128__NumberofEquivalentDominoPairs
	{

		public static void Test()
		{
			Solution s = new Solution();
			int[][] arr1 = new[]
			{
				new [] {1,2},
				new [] {2,1},
				new [] {3,4},
				new [] {5,6},
			};
			Console.WriteLine(s.NumEquivDominoPairs(arr1));

		}

		public class Solution
		{
			public int NumEquivDominoPairs(int[][] dominoes)
			{
				//陣列排序  每個元素兩個值也都轉成由小排到大
				List<Item> items = dominoes.Select(v => new Item(v[0], v[1])).ToList().OrderBy(v=>v.Vs).ToList();

				int equalCou = 0;
				int sequenceEqual = 0;
				for (int i = 0; i < items.Count - 1; i++)
				{
					if (items[i].Vs == items[i + 1].Vs && items[i].VL == items[i + 1].VL)
					{
						sequenceEqual++;
					}
					else if(i == items.Count - 2)
					{
						equalCou += (sequenceEqual * (sequenceEqual + 1) )/ 2;
					}
					else
					{
						if(sequenceEqual > 0)
							equalCou += (sequenceEqual * (sequenceEqual + 1)) / 2;
						sequenceEqual = 0;
					}
				}

				return equalCou;


				//最直觀的做法  全部兩兩比一遍  n(n-1)/2  會time exceed
				//int equalCou = 0;
				//for (int i = 0; i < dominoes.Length - 1; i++)
				//{
				//	for (int j = i + 1; j < dominoes.Length; j++)
				//	{
				//		if (dominoes[i].Sum() == dominoes[j].Sum())
				//		{
				//			if (dominoes[i][0] == dominoes[j][0]
				//			    || dominoes[i][0] == dominoes[j][1])
				//				equalCou++;
				//		}
				//	}
				//}
				//return equalCou;
			}

			public class Item
			{
				public Item(int v1, int v2)
				{
					Vs = v1 <= v2 ? v1 : v2;
					VL = v1 <= v2 ? v2 : v1;
				}
				public int Vs;
				public int VL;
			}

		}

	}
}
