using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _378_KthSmallestElementinaSortedMatrix
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//[[1,3,5],[6,7,12],[11,14,14]]
			//4
			Console.WriteLine(s.KthSmallest(new int[][]
				{
					new []{1,3,5},
					new [] {6,7,12},
					new []{11,14,14},
				},
				4
				//2
			));



			Console.WriteLine(s.KthSmallest(new int[][]
				{
					new []{-5},
					
				},
				//8
				1
			));


			Console.WriteLine(s.KthSmallest(new int[][]
			{
				new []{1,5,9},
				new []{10,11,13},
				new []{12,13,15},
			}, 
				8
				//2
				));

		}





		public class Solution
		{
			public int KthSmallest(int[][] matrix, int k)
			{
				int n = matrix.Length;
				int minIdx = k - 1;// 2 - 1
				int maxIdx = n * n - k; // 9 - 8
				List<int> vPoss = new List<int>();

				if (maxIdx <= n)
				{
					// eg 第八大  8~9 > 7~8   0 ,1
					for (int i = n - maxIdx - 1; i < n; i++)
					{
						for (int j = n - 1; j >= n - 1 - i; j--)
						{
							vPoss.Add(matrix[i][j]);
						}
					}

					vPoss = vPoss.OrderByDescending(v => v).ToList();
					return vPoss[maxIdx];
				}
				else if (minIdx < n)
				{
					for (int i = 0; i <= minIdx; i++)
					{
						for (int j = 0; j <= minIdx - i; j++)
						{
							vPoss.Add(matrix[i][j]);
						}
					}

					vPoss = vPoss.OrderBy(v => v).ToList();
					return vPoss[minIdx];
				}
				else
				{

					for (int i = 0; i < n; i++)
					{
						for (int j = 0; j < n; j++)
						{
							vPoss.Add(matrix[i][j]);
						}
					}

					vPoss = vPoss.OrderBy(v => v).ToList();
					return vPoss[k - 1];
				}
			}
		
		}




		/// <summary>
		/// 我是覺得  這好像是林教的 Counting Sort
		/// 都是矩陣 也有列行排序
		/// 直覺是 全部加  再Order nlogn
		/// 不過這種又多加一個條件   先排好序的    一定有機關
		/// 直接全排  大概TLE 跑不掉
		/// 想極端   小的就從左上找幾個  大的右上找幾個  不用全找
		/// 再想一下  例如第三小  有可能是  左上 左左 上上  
		/// 以此類推  我猜  先看是偏大還偏小  就從左上 或右下 或只有左 (因為同時考慮 右下,左,上)
		/// 若第k小  就全部可能 k*上  左+(k-1)*上  左左k-2上  也就是 斜角線
		/// 來試試
		///
		/// 不對 好像不夠全面  ex 3x3  123可用上面  但是 4 以上面來說 可能位置到4的反對角線
		/// 就要考慮全部了  就不ok
		/// 換個想法  以5x5  從主對角線往左上 每移一格
		///
		/// 不對 因為假設 4,4 是往左上一 但是不一定剛好前四小都在4~5的2x2 上面說的可能是三個上
		///
		/// 所以綜合版  既然三小 可能 上上  左左  或自己 左 上
		/// 那也就是一個list 第k小  就是去除自己  再丟k-1個元素到右邊  很像排列組合
		/// 因為要小 一定是往左 或往上 也有可能一左 一上
		/// 例如第5小左左上上  可能是  左 和 左左 還有上 和上上  也有可能是連續動作左左上上
		/// 或者 左  左上 左上上  左左
		/// 但是這樣想  又覺得沒有一個明確的公式出來
		///
		/// 又想到一個綜合版  其實每個點  都可以直接看出上面最多有幾個更大的
		/// 不對  從這邊可以看出  就算三小  上上也不一定  只是種可能
		/// 其實小於n的話  反對角線很ok 因為確實就是最長路徑  短路徑都會包含在範圍中
		///
		/// 大於n  < n^2
		/// 這樣的路徑    確實有可能踏入左上半部
		/// 
		/// 所以有可能真的 超過n 就要考慮全部
		/// 剛才還在怕才n 就直接全部  會不會容易TLE  先試試好了
		///
		/// >-------
		///
		/// 果然過關  推論都對
		/// 160 ms, faster than 51.80%
		/// 39.7 MB, less than 5.40% of C#
		/// </summary>
		public class Solution_V1
		{
			public int KthSmallest(int[][] matrix, int k)
			{
				int n = matrix.Length;
				int minIdx = k - 1;// 2 - 1
				int maxIdx = n * n - k; // 9 - 8
				List<vPos> vPoss = new List<vPos>();

				if (maxIdx <= n)
				{
					// eg 第八大  8~9 > 7~8   0 ,1
					for (int i = n-maxIdx-1; i < n; i++)
					{
						for (int j = n-1; j >= n -1 - i; j--)
						{
							vPoss.Add(new vPos {row = i, col = j, val = matrix[i][j]});
						}
					}

					vPoss = vPoss.OrderByDescending(v => v.val).ToList();
					return vPoss[maxIdx].val;
				}
				else if (minIdx < n)
				{
					for (int i = 0; i <= minIdx; i++)
					{
						for (int j = 0; j <= minIdx - i; j++)
						{
							vPoss.Add(new vPos {row = i, col = j, val = matrix[i][j]});
						}
					}

					vPoss = vPoss.OrderBy(v => v.val).ToList();
					return vPoss[minIdx].val;
				}
				else
				{

					for (int i = 0; i < n; i++)
					{
						for (int j = 0; j < n; j++)
						{
							vPoss.Add(new vPos {row = i, col = j, val = matrix[i][j]});
						}
					}

					vPoss = vPoss.OrderBy(v => v.val).ToList();
					return vPoss[k - 1].val;
				}
			}


			public class vPos
			{
				public int row;
				public int col;
				public int val;
			}
		}



	}

}

