using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5536_MaximalNetworkRank
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.MaximalNetworkRank(5,
				new int[][]
				{
					new int[]{0,1},new int[]{0,3},new int[]{1,2},new int[]{1,3},new int[]{2,3},new int[]{2,4}
				}));

			Console.WriteLine(s.MaximalNetworkRank(5,
				new int[][]
				{
					new int[]{0,1},new int[]{1,2},new int[]{2,3},new int[]{2,4},new int[]{5,6},new int[]{5,7}
				}));



		}



		/// <summary>
		/// 這題自己想出來的   因為是 contest 題   數據還不多  所以達到 100 100     所以先沒看discuss
		/// 這題策略算單純   連接到一個點的線的數量  等於直接計算  所有邊的兩點出現的次數
		/// 基本上深度研究過 dfs bfs 之後  對於圖的題目很有幫助  以這題來說  有Adjacency List的概念  知道圖這麼複雜的東西  用adj List 也就是邊兩點的集合  就可以優雅的表示完整的圖  是一個滿高階  不知道會很難解  一理解後知道就會瞬間很有力的  好用工具
		/// 
		/// 所以計算點連的邊數之後    取最大的前兩個  比較特別的是  第二名可能有很多個點的邊數都相同
		/// 這時候就會差在有沒有兩點直接相連的邊要減一  所以就跟第二名同數量的全部組合  都計算一遍  取最大值的兩個點
		///
		/// 檢查兩點直接相連 用陣列遍歷很慢  所以用Chr的技巧  key_key  dic
		/// </summary>
		public class Solution
		{
			public int MaximalNetworkRank(int n, int[][] roads)
			{
				if (roads.Length == 0)
					return 0;

				Dictionary<string,string> roadStr = new Dictionary<string, string>();

				Dictionary<int,int> numCou = new Dictionary<int, int>();
				for (int i = 0; i < roads.Length; i++)
				{
				
					for (int j = 0; j <= 1; j++)
					{
						if (!numCou.ContainsKey(roads[i][j]))
							numCou[roads[i][j]] = 1;
						else
							numCou[roads[i][j]]++;
					}

					roadStr[$"{roads[i][0]}_{roads[i][1]}"] = "";

				}

				var orderCou = numCou.OrderByDescending(kv => kv.Value).ToList();


				int secondMaxCou = orderCou[1].Value;

				var gEqSec = orderCou.Where(c => c.Value >= secondMaxCou).ToList();

				List<List<KeyValuePair<int,int>>> pairs = new List<List<KeyValuePair<int, int>>>();
				for (int i = 0; i < gEqSec.Count; i++)
				{
					for (int j = i + 1; j < gEqSec.Count; j++)
					{
						pairs.Add(new List<KeyValuePair<int, int>>() {gEqSec[i], gEqSec[j]});
						
					}
				}

				int maxRes = 0;
				for (int i = 0; i < pairs.Count; i++)
				{
					int max1 = pairs[i][0].Key;
					int max2 = pairs[i][1].Key;
					int max1Cou = pairs[i][0].Value;
					int max2Cou = pairs[i][1].Value;

					int sum = max1Cou + max2Cou;
					if (roadStr.ContainsKey($"{max1}_{max2}") || roadStr.ContainsKey($"{max2}_{max1}"))
						sum -= 1;
					if (sum > maxRes)
						maxRes = sum;
				}
				
				return maxRes;
			}
		}


	}
}
