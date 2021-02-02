using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1139_Largest1BorderedSquare
	{

		public static void Test()
		{

			Solution s = new Solution();
			Console.WriteLine(
				s.Largest1BorderedSquare(
					new int[][]
					{
						new [] { 1,0 },
						new [] { 0,1 },
					}
				)
			);

			Console.WriteLine(
				s.Largest1BorderedSquare(
					new int[][]
				{
					new [] { 1,1,1 },
					new [] { 1,0,1 },
					new [] { 1,1,1 },
				}
				)
				);

			Console.WriteLine(
				s.Largest1BorderedSquare(
				new int[][]
				{
					new [] { 1,1,0,0 },
				 	}
				)
				);

		}

		public class Solution
		{


			public int Largest1BorderedSquare(int[][] A)
			{
				int m = A.Length , n = A[0].Length ;
				int[,] left = new int[m, n], top = new int[m, n];
				for (int i = 0; i < m; ++i)
				{
					for (int j = 0; j < n; ++j)
					{
						if (A[i][j] > 0)
						{
							left[i, j] = j > 0 ? left[i, j - 1] + 1 : 1;
							top[i, j] = i > 0 ? top[i - 1, j] + 1 : 1;
						}
					}
				}
				for (int l = Math.Min(m, n); l > 0; --l)
				for (int i = 0; i < m - l + 1; ++i)
				for (int j = 0; j < n - l + 1; ++j)
					if (top[i + l - 1, j] >= l &&
					    top[i + l - 1, j + l - 1] >= l &&
					    left[i, j + l - 1] >= l &&
					    left[i + l - 1, j + l - 1] >= l)
						return l * l;
				return 0;
			}



			///// <summary>
			///// 是可以計算  但是會time exceed  這是完全自己想出來的  原本想要用  Width First Search 或 DepthFirst Search 去找出所有的 連通的path 和cycle  但是想到 也有可能會是實心的  簡言之  可能性真的太多
			///// 所以後來想到用 點的方式  找左上 和右下 是x位移 = y位移的   轉成一組點
			///// 然後測試每一組點之間  是不是左右上下有用一連起來
			///// </summary>
			///// <param name="grid"></param>
			///// <returns></returns>
			//public int Largest1BorderedSquare(int[][] grid)
			//{
			//	List<int[]> point11s = new List<int[]>();
			//	List<List<int[]>> candididateSquarePairLs = new List<List<int[]>>();


			//	int result = 0;

			//	if (grid.Length  == 0)
			//		return result;

			//	for (int i = 0; i < grid.Length ; i++)
			//	{
			//		for (int j = 0; j < grid[i].Length ; j++)
			//		{
			//			if(grid[i][j] == 1)
			//				point11s.Add(new []{i, j});//row column
			//		}
			//	}

			//	if (point11s.Any())
			//		result = 1;

			//	for (int i = 0; i < point11s.Count - 1; i++)
			//	{
			//		for (int j = i+1; j < point11s.Count; j++)
			//		{
			//			if(IsEqual(point11s[i], point11s[j]))
			//				candididateSquarePairLs.Add(new List<int[]>() { point11s[i], point11s[j] });
			//		}
			//	}


			//	candididateSquarePairLs = candididateSquarePairLs.OrderByDescending(l => Math.Abs(l[0][0] - l[1][0])).ToList();

			//	foreach (var sq in candididateSquarePairLs)
			//	{
			//		bool notConnect = false;
			//		//測試是否連通
			//		//左直
			//		for (int i = sq[0][0]; i < sq[1][0]; i++)
			//		{
			//			if (grid[i][sq[0][1]] == 0)
			//			{
			//				notConnect = true;
			//				break;
			//			}
			//		}
			//		if(notConnect)
			//			continue;
			//		//右直
			//		for (int i = sq[0][0]; i < sq[1][0]; i++)
			//		{
			//			if (grid[i][sq[1][1]] == 0)
			//			{
			//				notConnect = true;
			//				break;
			//			}
			//		}
			//		if (notConnect)
			//			continue;
			//		//上橫
			//		for (int i = sq[0][1]; i < sq[1][1]; i++)
			//		{
			//			if (grid[sq[0][0]][i] == 0)
			//			{
			//				notConnect = true;
			//				break;
			//			}
			//		}
			//		if (notConnect)
			//			continue;
			//		//下橫
			//		for (int i = sq[0][1]; i < sq[1][1]; i++)
			//		{
			//			if (grid[sq[1][0]][i] == 0)
			//			{
			//				notConnect = true;
			//				break;
			//			}
			//		}
			//		if (notConnect)
			//			continue;

			//		int edgeLength  = Math.Abs(sq[0][0] - sq[1][0]) + 1;
			//		int pow2 = (int)Math.Pow(edgeLength , 2);
			//		if (pow2 > result)
			//		{
			//			result = pow2;
			//			break;
			//		}
			//	}


			//	return result;
			//}


			//private bool IsEqual(int[] pa, int[] pb)
			//{
			//	int diffRow = pa[0] - pb[0];
			//	int diffColumn = pa[1] - pb[1];
			//	if (diffRow != 0 && diffColumn == diffRow)
			//		return true;
			//	return false;
			//}

		}

	}
}
