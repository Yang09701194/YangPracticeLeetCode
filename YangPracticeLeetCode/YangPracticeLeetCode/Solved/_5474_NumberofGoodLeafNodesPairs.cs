using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5474_NumberofGoodLeafNodesPairs
	{


		public static void Test()
		{
			Solution s = new Solution();
			Solution.Go();
			//Console.WriteLine(s.NumPoints());


		}



		public class Solution
		{
			//public int CountPairs(TreeNode root, int distance)
			//{



			//}

			static int[,] graph = new int[6, 6] { { 10000, 10000, 10, 10000, 30, 100 }, { 10000, 10000, 5, 10000, 10000, 10000 }, { 10000, 10000, 10000, 50, 10000, 10000 }, { 10000, 10000, 10000, 10000, 10000, 10 }, { 10000, 10000, 10000, 20, 10000, 60 }, { 10000, 10000, 10000, 10000, 10000, 10000 } };
			static int[] S = new int[6] { 0, 0, 0, 0, 0, 0 };//最短路徑的頂點集合
			static string[] mid = new string[6] { "", "", "", "", "", "" };//點的路線
			public static int IsContain(int m)//判斷元素是否在mst中
			{
				int index = -1;
				for (int i = 1; i < 6; i++)
				{
					if (S[i] == m)
					{
						index = i;
					}
				}
				return index;
			}
			/// <summary>
			/// Dijkstrah實現最短路演算法
			/// </summary>
			static void ShortestPathByDijkstra()
			{
				int min;
				int next;

				for (int f = 5; f > 0; f--)
				{
					//置為初始值

					min = 1000;
					next = 0;//第一行最小的元素所在的列 next點
							 //找出第一行最小的列值
					for (int j = 1; j < 6; j++)//迴圈第0行的列
					{
						if ((IsContain(j) == -1) && (graph[0, j] < min))//不在S中,找出第一行最小的元素所在的列
						{
							min = graph[0, j];
							next = j;
						}
					}
					//將下一個點加入S
					S[next] = next;
					//輸出最短距離和路徑
					if (min == 1000)
					{
						Console.WriteLine("V0到V{0}的最短路徑為：無", next);
					}
					else
					{
						Console.WriteLine("V0到V{0}的最短路徑為：{1},路徑為：V0{2}->V{0}", next, min, mid[next]);
					}
					// 重新初始0行所有列值
					for (int j = 1; j < 6; j++)//迴圈第0行的列
					{
						if (IsContain(j) == -1)//初始化除包含在S中的
						{
							if ((graph[next, j] + min) < graph[0, j])//如果小於原來的值就替換
							{
								graph[0, j] = graph[next, j] + min;
								mid[j] = mid[next] + "->V" + next;//記錄過程點
							}
						}
					}

				}

			}


			public static void Go()
			{
				ShortestPathByDijkstra();

			}

		}


	}
}
