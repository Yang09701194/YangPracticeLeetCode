using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAlgo.DS;
using DSAlgo.ALGO;

namespace YangPracticeLeetCode.Solved
{
	class _329_LongestIncreasingPathinaMatrix
	{

		public static void Test()
		{
			Solution s = new Solution();

			///Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.LongestIncreasingPath(
				new int[][]
				{
					new []{9,9,4},
					new []{6,6,8},
					new []{2,1,1},
				}));

			Console.WriteLine(s.LongestIncreasingPath(
				new int[][]
				{
					new []{3,4,5},
					new []{3,2,6},
					new []{2,2,1},
				}));

		}	





		/// <summary>
		///
		/// 先想到  遞增path  可以說 < 的關係  用箭頭表示  小 -> 大
		/// 鄰近方向相同的可以相連   就變成  directed graph
		/// 又要找path  可能可以用  dfs  或  bfs
		/// 所謂的 path 長度 可以說就是 path finding的時候 出現過的最長長度
		/// 而且 DFS  會自動避開已拜訪過的點
		///
		/// 有畫一張圖 在 evernote     如果是 nxn 個數  邊數鄰近兩點連成一線  由圖可看出  邊數會是
		/// 4x4  4-1 *  4+4 
		/// nxn  (n-1)* 2n =  2n^2 - 2n
		///
		/// 5x3  5-1 * 3 + 3-1* 5
		/// mxn  (m-1)* n + (n-1)*m = mn - n + mn - m = 2mn-m-n
		/// 
		/// 所有邊  可說是   水平由左往右的   由上列往下列    垂直的  左行往右行
		/// 所以 for i 固定  j = 1~n     j固定  i = 1~n   所有邊構建 Graph with adjacency list
		///
		/// 然後 DFS 我有改編  可以記錄過到訪的點 的路徑的最大程度
		/// 
		/// </summary>
		public class Solution
		{
			public int LongestIncreasingPath(int[][] matrix)
			{
				Func<int, int, int, int> getIdx = (row, col, rowLen) => { return rowLen * row + col; };

				//建立 graph   directed graph 的 edge方向  小->大   mxn個點  會有

				List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
				
				//  matrix  m x n   int[列][行]

				// 0 1 2    i=0 j= 0 + 1~3
				// 3 4 5    i=1 j= 3 + 1~3
				// 6 7 8    i=2 j= 6 + 1~3
				// 點的編號  把二維轉成  一維邊號  如上 3x3  編號 1~9  

				int rowLength = matrix.Length;
				int colLength = matrix[0].Length;

				//  水平邊
				for (int i = 0; i < rowLength; i++) //固定列
				{
					for (int j = 0; j < colLength - 1; j++) //行
					{
						int left = getIdx(i, j, rowLength);
						int right = getIdx(i, j + 1, rowLength);

						if (matrix[i][j] < matrix[i][j + 1])
							edges.Add(Tuple.Create(left, right));
						else if(matrix[i][j] > matrix[i][j + 1])
							edges.Add(Tuple.Create(right, left));
					}
				}
				//  垂直邊
				for (int i = 0; i < matrix.Length; i++) //固定行
				{
					for (int j = 0; j < matrix[0].Length - 1; j++) //列
					{
						int left = getIdx(j, i, rowLength);
						int right = getIdx(j+1, i, rowLength);

						if (matrix[j][i] < matrix[j+1][i])
							edges.Add(Tuple.Create(left, right));
						else if(matrix[j][i] > matrix[j+1][i])
							edges.Add(Tuple.Create(right, left));
					}
				}

				List<int> vertexes = new List<int>();
				for (int i = 0; i < rowLength * colLength - 1; i++)
				{
					vertexes.Add(i);
				}

				//graph
				Graph<int> graph = new Graph<int>(vertexes, edges, GraphOption.Diirected);

				DFS_Algo dfs = new DFS_Algo();
				//DFS_Algo.IsMarkGrayDark = false;
				dfs.DFS(0, graph);

				int maxDfsPath = dfs.GetMaxDfsPathLen();

				return maxDfsPath;
			}
		}
	}
}
