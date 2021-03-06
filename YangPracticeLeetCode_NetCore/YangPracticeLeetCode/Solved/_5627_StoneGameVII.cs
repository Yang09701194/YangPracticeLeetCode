using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5627_StoneGameVII
	{

		/// <summary>
		/// 	Approach 1 實測結果 應該是2^n  他可能寫錯了  已提交詢問
		/// </summary>


		public static void Test()
		{
			Solution_App4 s = new Solution_App4();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.StoneGameVII(new int[] { 5, 3, 1, 4, 2 }));

			Console.WriteLine(s.StoneGameVII(new int[] { 7, 90, 5, 1, 100, 10, 10, 2 }));
			//Console.WriteLine(s.StoneGameVII(new int[] { 3, 5 }));


			///Solution_V2   數據有記錄在summary
			//for (int i = 2; i < 32; i++)
			//{
			//	var now = DateTime.Now;
			//	int[] n = new int[i];
			//	for (int j = 0; j < i; j++)
			//	{
			//		n[j] = j;
			//	}
			//	Solution_V2 ss = new Solution_V2();  //實測  Approach 1  : 2^n
			//	ss.StoneGameVII(n);
			//	Console.WriteLine(i + " " + DateTime.Now.Subtract(now).TotalMilliseconds);
			//}

			////Solution_V2_Cache_DP2   這個神  上面的32長度  已經要幾十秒   這個32還在 0 毫 秒
			////320只要10ms
			//int[] t1 = new int[] {400, 800, 1200, 1600, 2000, 2400, 2800, 3200};
			//for (int i = 0; i < t1.Length; i++)
			//{
			//	var now = DateTime.Now;
			//	int[] n = new int[t1[i]];
			//	for (int j = 0; j < t1[i]; j++)
			//	{
			//		n[j] = j;
			//	}
			//	Solution_V2_Cache_DP2 ss = new Solution_V2_Cache_DP2();
			//	ss.StoneGameVII(n);
			//	Console.WriteLine(t1[i] + " " + DateTime.Now.Subtract(now).TotalMilliseconds);
			//}
			



			//Console.WriteLine(s.StoneGameVII(new int[] { 454, 989, 739, 904, 646, 100, 639, 449, 891, 46, 32, 483, 99, 311, 270, 224, 151, 188, 667, 513, 880, 758, 720, 861, 460, 270, 461, 164, 46, 755, 409, 921, 913, 623, 959, 33, 671, 536, 716, 907, 377, 481, 871, 757, 644, 402, 795, 904, 852, 591, 122, 564, 109, 661, 160, 530, 73, 835, 195, 622, 724, 443, 620, 531, 771, 152, 423, 450, 944, 391, 757, 673, 886, 924, 161, 413, 899, 167, 356, 250, 548, 581, 403, 708, 685, 723, 363, 362, 980, 395, 593, 926, 323, 126, 939, 150, 176, 316, 776, 136, 757, 495, 613, 252, 605, 203, 743, 50, 363, 867, 467, 570, 269, 373, 919, 149, 75, 342, 658, 870, 723, 245, 587, 963, 172, 500, 361, 589, 812, 647, 515, 827, 334, 740, 416, 436, 1000, 382, 65, 179, 233, 896, 910, 316, 419, 860, 48, 523, 562, 31, 520, 247, 152, 703, 326, 182, 883, 199, 18, 278, 468, 191, 885, 32, 950, 510, 668, 47, 87, 485, 194, 803, 58, 77, 717, 245, 711, 836, 633, 442, 874, 767, 27, 433, 815, 611, 580, 135, 834, 686, 551, 471, 27, 146, 99, 488, 484, 586, 25, 372, 931, 734, 856, 231, 346, 925, 345, 692, 930, 295, 978, 786, 98, 720, 868, 952, 417, 364, 937, 502, 340, 803, 266, 612, 611, 191, 165, 516, 506, 489, 917, 651, 135, 333, 564, 937, 787, 917, 619, 702, 622, 143, 238, 253, 901, 401, 594, 861, 439, 439, 823, 986, 928, 329, 187, 339, 772, 551, 128, 845, 112, 418, 862, 127, 929, 905, 528, 841, 85, 313, 111, 645, 169, 557, 683, 796, 677, 706, 758, 367, 773, 217, 400, 141, 140, 706, 144, 148, 817, 855, 82, 400, 193, 10, 586, 448, 752, 901, 164, 761, 257, 909, 611, 288, 963, 713, 272, 81, 409, 249, 189, 531, 359, 339, 173, 374, 854, 20, 180, 501, 359, 732, 197, 529, 422, 485, 135, 243, 672, 448, 7, 109, 141, 180, 222, 910, 203, 445, 710, 509, 900, 980, 443, 172, 253, 272, 881, 519, 946, 852, 463, 570, 478, 260, 894, 930, 276, 870, 493, 69, 2, 439, 61, 93, 510, 9, 442, 652, 94, 569, 666, 604, 967, 209, 641, 274, 784, 215, 557, 621, 665, 962, 812, 304, 874, 115, 62, 785, 917, 116, 646, 57, 551, 389, 569, 749, 102, 561, 556, 4, 583, 832, 480, 104, 345, 31, 907, 1000, 234, 129, 487, 483, 432, 491, 239, 550, 381, 641, 565, 939, 18, 541, 484, 828, 7, 904, 757, 283, 808, 46, 764, 784, 115, 674, 170, 402, 952, 413, 616, 454, 623, 212, 864, 459, 729, 680, 134, 600, 834, 922, 674, 266, 21, 772, 622, 172, 169, 611, 527, 25, 78, 178, 919, 505, 796, 445, 476, 944, 710, 733, 484, 866, 175, 121, 778, 47, 269, 981, 755, 569, 586, 403, 364, 831, 602, 547, 294, 51, 681, 302, 319, 370, 573, 184, 691, 953, 236, 248, 364, 636, 846, 763, 503, 29, 623, 744, 141, 410, 79, 309, 227, 127, 268, 861, 165, 644, 451, 127, 491, 223, 880, 236, 251, 978, 622, 702, 63, 349, 448, 579, 637, 672, 416, 302, 222, 544, 412, 821, 787, 17, 37, 906, 186, 599, 767, 233, 78, 191, 535, 909, 551, 727, 992, 297, 137, 838, 881, 58, 860, 36, 726, 953, 245, 330, 261, 261, 118, 427, 632, 599, 431, 162, 409, 718, 102, 693, 131, 716, 988, 245, 266, 778, 752, 189, 446, 927, 91, 924, 974, 701, 50, 974, 132, 769, 580, 98, 970, 669, 40, 258, 948, 764, 789, 455, 709, 893, 76, 75, 502, 116, 829, 692, 120, 807, 207, 654, 399, 19, 620, 100, 289, 533, 658, 911, 563, 575, 705, 923, 736, 822, 712, 322, 73, 63, 96, 54, 690, 456, 866, 243, 72, 178, 718, 172, 826, 822, 862, 305, 401, 308, 315, 930, 852, 294, 913, 772, 697, 462, 169, 940, 870, 693, 454, 668, 226, 458, 735, 25, 864, 164, 864, 417, 449, 460, 623, 517, 941, 504, 661, 186, 836, 907, 175, 437, 5, 37, 872, 625, 950, 13, 92, 58, 998, 205, 417, 107, 480, 116, 787, 369, 751, 202, 725, 228, 933, 702, 895, 757, 100, 851, 411, 691, 526, 899, 537, 858, 480, 289, 773, 187, 636, 556, 717, 656, 789, 506, 720, 739, 327, 33, 487, 10, 139, 995, 487, 811 }));

			
		}



		/// <summary>
		///
		/// Approach 5: Another Approach using Tabulation
		/// 
		/// 這同樣是 n^2
		/// 但是就是快
		/// Runtime: 172 ms, faster than 91.67% of C# online submissions for Stone Game VII.
		/// Memory Usage: 45.6 MB, less than 41.67% of C# online submissions for Stone Game VII.
		///
		///我是覺得  除非V4這矩陣是對稱的 才能只右上或左下半
		/// 來印印看 V4
		///
		/// 已印  不適說對稱  但也符合  只有右上角有值
		///
		///
		///  This is just a different way of traversing and filling the 2D array. Instead of traversing diagonally to find the results of subarrays for each length, we would fix our start index at a certain point. And now the end index would incrementally add an element to the subarray and find the results.
		///  For example, for array = [5, 3, 2, 1], we could fix our start index at[5], end index would incrementally calculate the result for subarrays[5, 3], [5, 3, 2]
		///and[5, 3, 2, 1].
		///
		///  一樣是 Bottom Up  所以想怎麼填表
		///  填的方式又更省力   拿一個子陣列的開頭固定住  然後一職往右延伸
		/// 
		/// 我在這題花得有點久  所以先淺理解到這邊
		/// todo
		///  
		/// </summary>
		class Solution_App5
		{
			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				int[] prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];
				}
				int[,] dp = new int[n,n];
				for (int start = n - 2; start >= 0; start--)
				{
					for (int end = start + 1; end < n; end++)
					{
						int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];
						int scoreRemoveLast = prefixSum[end] - prefixSum[start];
						dp[start,end] = Math.Max(scoreRemoveFirst - dp[start + 1,end],
							scoreRemoveLast - dp[start,end - 1]);
					}
				}
				return dp[0,n - 1];
			}
		}



		/// <summary>
		///Approach 4: Bottom Up Dynamic Programming - Tabulation
		///
		///Instead of recursively finding the solution for the original problem, we would start by finding the solution starting from the smallest subproblem and iteratively move towards a larger subproblem.
		///Example, to find the result for given array stones = [5, 3, 1, 4],
		///The smallest subproblem would be when the stones array has a single element.So we will find the result for subarrays of length 11- [5], [3], [1], [4].
		///Now, we would progress towards finding result for subarrays of length 22 -[5, 3], [3, 1], [1, 4]. It must be noted that at this point we could use the results from previous calculations.
		///	For example, to calculate the result for subarray[5, 3], we could use the result calculated for subarrays[5] and[3].
		///In this way, we could calculate the results of subarrays for each length. At last we would calculate the result for the length of 44 which would be the final result.
		///
		///Bottom up 就是比較不適直接順著遊戲流程步驟走  所以感覺也是沒那麼直覺 沒那麼順
		/// 所以應該是因為這樣  普遍就比較沒教
		/// 
		/// 這種方式意圖就很直截
		/// 直接就是一起手就是建表  一直建一直建
		/// 一直填值  就填完了
		///
		/// 50~80%
		/// Runtime: 176 ms, faster than 86.11% of C# online submissions for Stone Game VII.
		/// Memory Usage: 45.4 MB, less than 72.22% of C# online submissions for Stone Game VII.
		/// 
		/// 我先到這樣  之後有空再來細究
		/// todo
		///
		///
		/// 無論是 v3 或 v4  都是只有右上有值
		/// 所以真的可以直接算右上
		/// 左下不用管 
		/// 
		///    
		///    0   90    7   95   91  115  101  122
		///    0    0   90    5  105   91  115  101
		///    0    0    0    5    1  105   11  115
		///    0    0    0    0  100   10  110   12
		///    0    0    0    0    0  100   10  110
		///    0    0    0    0    0    0   10   10
		///    0    0    0    0    0    0    0   10
		///    0    0    0    0    0    0    0    0
		/// 
		/// </summary>
		class Solution_App4
		{
			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				int[,] dp = new int[n,n];
				int[] prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];
				}
				for (int length = 2; length <= n; length++)
				{
					for (int start = 0; start + length - 1 < n; start++)
					{
						int end = start + length - 1;
						int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];
						int scoreRemoveLast = prefixSum[end] - prefixSum[start];
						dp[start,end] = Math.Max(scoreRemoveFirst - dp[start + 1,end],
							scoreRemoveLast - dp[start,end - 1]);

					}
				}

				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						Console.Write((dp[i,j] + " ").PadLeft(5));
					}

					Console.WriteLine();
				}

				return dp[0,n - 1];
			}
		}


		/// <summary>
		/// Approach 3: Optimised Memoization Approach
		///
		/// 不過測起來跟V2 都差不多
		///
		/// 那大概理解一下新的做法
		///
		/// Both Bob and Alice are trying to maximize their score. Alice is trying to get the maximum score so that she has a maximum difference from Bob's score. Bob is also trying to get the maximum score so that he is as close to Alice as possible.
		/// 這一句要直接講出來  也就是兩個人都在追求最大  我看題意沒辦法這麼確定
		/// 因為不靠遞迴的思考路徑   直接看數字依題目規則直接去推   中間可能先選小的  以讓大的後面能被自己選到
		/// 這樣就有可能有一部先加少的  下一步才加很大的 暴增
		///
		/// 所以這裡的 max 應該還是不是指當下這一步的最大值  還是再說  推論接下來雙方optmize的每一步 再得到現在這一步可能最大值
		///
		///
		/// If both players want to maximize their score, they must return the maximum difference to the other player.
		/// 這句也是很不習慣 max 竟然用最大diff來形容  而不是純數大小
		///
		/// 
		///
		/// To calculate the current difference, each player would subtract the difference returned by the opponent from the current score.
		///
		///
		///If the current player is Bob,
		///Difference = Current Score - Difference returned by Alice
		///If the current player is Alice,
		///Difference = Current Score - Difference returned by Bob
		///
		/// 他這邊最明顯的差異是   本來要分為 A !A  兩條路去走
		/// 並且分別為 + 或 - score
		/// 而且原本的結果可能有正有負  所以在最後的結果才要加上Abs
		///
		/// 應該就是利用這個相反的關係   再利用 原本唯一可能負的是 findDiff - scoreRemoveFirstLast
		/// 倒過來 Remove - findDiff 就會是正的
		/// 也就是找盜用倒過來的方式  負的就會剛好轉正 並且對到每次A !A的  循環關係 所以就剛好同一句程式
		/// 就能達到原本的結果
		///
		/// 細部還要再研究  但大概就是這樣
		/// 因為原方法比較和情境直接相同  我就先不細究這個
		///  Todo
		/// </summary>
		class Solution_App3
		{
			int[] prefixSum;
			int[,] memo;

			private int findDifference(int start, int end, int[] stones)
			{
				if (start == end)
				{
					return 0;
				}
				if (memo[start,end] != 0)
				{
					return memo[start,end];
				}
				if (start + 1 == end)
					return Math.Max(stones[start], stones[end]);

				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];

				memo[start,end] = Math.Max(
					scoreRemoveFirst - findDifference(start + 1, end, stones),
					scoreRemoveLast - findDifference(start, end - 1, stones));

				return memo[start,end];
			}

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				memo = new int[n,n];
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];
				}
				return findDifference(0, n - 1, stones);
			}
		}



		/// <summary>
		/// 這跟DP2 一樣  已經可以命名為
		/// Approach 2: Top Down Dynamic Programming - Memoization
		///
		/// 但是更聰明   我是直接把原寫法  原位置改寫
		/// 但是  他更直接看出更簡化的地方  其實只要在  開頭  和結尾  做cache  位置下的比我直接改得更好
		///
		/// 本機測就進到了 20ms
		///
		/// 光是這樣就進入了
		/// Runtime: 256 ms, faster than 63.64% of C# online submissions for Stone Game VII.
		/// Memory Usage: 45.4 MB, less than 68.18% of C# online submissions for Stone Game VII.
		///
		/// 這range有點大  多送幾次會出現
		/// Runtime: 240 ms, faster than 81.82% of C# online submissions for Stone Game VII.
		/// Memory Usage: 45.4 MB, less than 63.64% of C# online submissions for Stone Game VII.
		///
		/// 
		/// </summary>
		class Solution_V2_Cache_DP3
		{
			int[] prefixSum;
			int[,] memo;

			private int findDifference(int start, int end, bool alice)
			{
				if (start == end)
				{
					return 0;
				}
				if (memo[start,end] != 0)
				{
					return memo[start,end];
				}
				int difference;
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];

				if (alice)
				{
					difference = Math.Max(
						findDifference(start + 1, end, !alice) + scoreRemoveFirst,
						findDifference(start, end - 1, !alice) + scoreRemoveLast);
				}
				else
				{
					difference = Math.Min(
						findDifference(start + 1, end, !alice) - scoreRemoveFirst,
						findDifference(start, end - 1, !alice) - scoreRemoveLast);
				}
				memo[start,end] = difference;
				return difference;
			}

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				memo = new int[n,n];
				//for (int[] arr : memo)
				//{
				//	Arrays.fill(arr, INF);
				//}
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];
				}
				int res = Math.Abs(findDifference(0, n - 1, true));
				
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						Console.Write((memo[i, j] + " ").PadLeft(5));
					}

					Console.WriteLine();
				}

				return res;
			}
		}


		/// <summary>
		/// 唯一想到  可以再試的  Dic已經是頂級快了
		/// 能在更快  可能只有 陣列 ?
		/// 來試試
		///
		/// 不可思議   竟然只需要 40ms  這竟然Dictionary這種存取O(1)的  還能再快
		/// 而且快了  15 倍
		/// 沒有最快  只有更快  奇蹟啊
		/// 陣列簡單  但是 超快
		///
		/// nxn的二維陣列
		///
		/// 這樣就pass了
		///
		/// Runtime: 540 ms, faster than 13.64% of C# online submissions for Stone Game VII.
		/// Memory Usage: 49.3 MB, less than 18.18% of C# online submissions for Stone Game VII.
		///
		/// 還算慢  快的應該都 抄 sol吧
		/// 像是底下的 Approach 5  184ms
		///
		///
		///
		///400 10.7357
		///800 51.7538954
		///1200 108.8203
		///1600 238.1437
		///2000 323.0545
		///2400 510.487
		///2800 716.5367
		///3200 954.2872
		///
		/// 12^2=144 16^2=256    256/144=1.777
		/// 238/109=2.18
		///
		/// (32/16)^2 = 4
		/// 954/238=4.008
		///
		/// (24/16)^2 = 1.5^2 = 2.25
		/// 510/238=2.14
		/// 
		/// (28/16) ^2 = 1.75^2 = 3.0625
		/// 716/238=3.008
		///
		/// 這樣子這個分析就沒錯  DP 如果用2維陣列裝  就真的是 mn  或n^2  確實如此
		/// 這會回想林教的就有提到這點
		/// 
		/// Time Complexity : \mathcal{O}(n^{2})
		/// For all possible subarrays in array stones, we calculate it's result only once. Since there are n^{2}
		/// possible subarrays for an array of length nn, the time complexity would be \mathcal{O}(n^{2})
		/// Space Complexity: \mathcal{O}(n^{2})
		/// We use an array memo of size n x n and prefixSum of size n.This gives us space complexity as \mathcal{ O}(n^{2}) + \mathcal{O}(n) = \mathcal{O}(n^{2})
		///
		/// Approach 2 3 4 不管 Top dwon  Bottom up 都 n^2
		/// </summary>
		class Solution_V2_Cache_DP2
		{
			public static int cou = 0;
			private int findDifference(int start, int end, bool alice)
			{
				if (start == end)
				{
					return 0;
				}
				int difference;       //因為ps 1~n 傳入的end是n-1 所以要+1轉為n
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];// pn - p1
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];//剛看會以為-p0怪  但是對照一下Sol的圖  會發現這是真的  -p0才有保留1st元素的效果

				int num1 = 0, num2 = 0;
				Action findDiff = () =>
				{
					if (findDifferenceCache[start + 1, end] == 0)
					{
						num1 = findDifference(start + 1, end, !alice);//兩個區間就是這樣沒錯  起訖個往左或往右移一位
						findDifferenceCache[start + 1, end] = num1;
					}
					else
						num1 = findDifferenceCache[start + 1, end];

					if (findDifferenceCache[start, end - 1] == 0)
					{
						num2 = findDifference(start, end - 1, !alice);
						findDifferenceCache[start, end - 1] = num2;
					}
					else
						num2 = findDifferenceCache[start, end - 1];
				};

				if (alice)
				{
					findDiff();
					int num1SRF = num1 + scoreRemoveFirst;//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2SRL = num2 + scoreRemoveLast;

					difference = Math.Max(num1SRF, num2SRL);
				}
				else
				{
					findDiff();
					int num1SRF = num1 - scoreRemoveFirst;//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2SRL = num2 - scoreRemoveLast;

					difference = Math.Min(num1SRF, num2SRL);
				}
				return difference;
			}

			int[] prefixSum;
			int[,] findDifferenceCache = null;

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];// 0 ~ n-1  轉換到 1~n  
				}

				findDifferenceCache = new int[n, n];

				int res = Math.Abs(findDifference(0, n - 1, true));
				return res;
			}
		}



		/// <summary>
		/// V2 的 Cache 版   這種直接加到Dic  而不是用一 或二維陣列儲存  不知道還叫不叫dp
		///
		/// 我一開始想  是想  有用到的才加進Cache
		///
		/// 但是看到這個遞迴的特性  一定每個數字段都會拆到最底  代表說等於每種排列都會走過一遍
		/// 所以有可能可以直接全部n*n直接算一遍   不用邊跑邊加
		/// 來試試看
		///
		/// 不對  邊寫突然再想到  其實cache prefixSum的加減計算結果  沒什麼意義  因為+=的速度太快了  跟cache應該沒差多少
		/// 所以會有cache等於沒cache
		///
		/// 所以應該是要cache  F 的結果  也就是 上層的F  底下原本要遞迴100個子  直接紀錄結果
		/// 其他地方要再算相同的F  能省100  這種才有效
		///
		/// 改一下
		///
		/// 確實又大幅進步  雖然TLE  但是已經 55/68 test case pass
		/// 本地測 沒過的 case  570 ms
		/// 
		/// </summary>
		class Solution_V2_Cache_DP
		{
			public static int cou = 0;
			private int findDifference(int start, int end, bool alice)
			{
				if (start == end)
				{
					return 0;
				}
				int difference;       //因為ps 1~n 傳入的end是n-1 所以要+1轉為n
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];// pn - p1
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];//剛看會以為-p0怪  但是對照一下Sol的圖  會發現這是真的  -p0才有保留1st元素的效果

				int num1 = 0, num2 = 0;
				Action findDiff = () =>
				{
					if (!findDifferenceCache.ContainsKey($"{start + 1}_{end}"))
					{
						num1 = findDifference(start + 1, end, !alice);//兩個區間就是這樣沒錯  起訖個往左或往右移一位
						findDifferenceCache.Add($"{start + 1}_{end}", num1);
					}
					else
						num1 = findDifferenceCache[$"{start + 1}_{end}"];

					if (!findDifferenceCache.ContainsKey($"{start}_{end - 1}"))
					{
						num2 = findDifference(start, end - 1, !alice);
						findDifferenceCache.Add($"{start}_{end - 1}", num2);
					}
					else
						num2 = findDifferenceCache[$"{start}_{end - 1}"];
				};

				if (alice)
				{
					findDiff();
					int num1SRF = num1 + scoreRemoveFirst;//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2SRL = num2 + scoreRemoveLast;

					difference = Math.Max(num1SRF, num2SRL);
				}
				else
				{
					findDiff();
					int num1SRF = num1 - scoreRemoveFirst;//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2SRL = num2 - scoreRemoveLast;

					difference = Math.Min(num1SRF, num2SRL);
				}
				return difference;
			}

			int[] prefixSum;
			public Dictionary<string, int> findDifferenceCache = new Dictionary<string, int>();

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];// 0 ~ n-1  轉換到 1~n  
				}

				int res = Math.Abs(findDifference(0, n - 1, true));
				return res;
			}
		}


		/// <summary>
		/// Log 之後  看到過程就很有感覺了   很多過程特徵馬上就能對出來   看出脈絡
		/// 但是順著跑的結果  還是不夠有結構性
		/// 所以在更進一步   用紙筆就可以更透徹理解  遞迴的拆解
		/// 邊拆就能邊對上 順著的log
		/// 就更能看出規則
		/// recursion 特有會出現的 tree 就出現了
		/// 然後就會出現一樣 recursion 特有會出現的  一堆重複相同的計算項目
		/// 然後  就會自動開始聯想到   正是dp出馬省時間的時候了
		///
		/// 紙手畫圖  已加到筆記 能夠幫助完全理解
		/// 
		/// 既然如此  我就先不繼續往下看sol  來試著自己改寫一個dp版  看會不會就pass TLE 了
		///
		/// 這邊的TLE  在長度700的時候   一分鐘都跑不完  差距真的大  真的要cache
		///
		///
		/// Time Complexity : \mathcal{O}(2^{n^{2}}).
		///
		/// For an array of length nn, there are roughly { n^{ 2} } possible subarrays.
		/// 12345
		///5 start 0
		///4 start 0 1
		///3 start 0 1 2
		///2 start 0 1 2 3
		///1 start 0 1 2 3 4
		///可以看出是 1+...+n > n(n+1)/2  所以O(n^2) 個sub array	
		///
		/// We fill the array prefixSum of size n by iterating n times.The time complexity would be \mathcal{ O}(n).
		///For each subarray there are 22 choices, either remove the first element or remove the last element.Thus the time complexity of recursive function would be \mathcal{ O}(2^{n^{2}})

		///This would give us total time complexity as \mathcal{O}(n)) + \mathcal{O}(2^{n^{2}}) = \mathcal{O}(2^{n^{2}})
		/// 2 的  n平方  次方  難怪跑不完
		///This approach is exhaustive and results in Time Limit Exceeded(TLE)
		///
		///從樹狀圖可以看到  主定理 伴隨樹的展現   遞迴是分兩種(去頭 或去尾)下去  所以樹就是2倍數增長
		/// 就是 2 的次方 
		/// 2的次方又要累加 
		/// 1+2+4+8 = 15   2^4 - 1
		/// k層  就是 2^(k+1) - 1
		/// 所以看有幾層
		/// 其實我覺得差不多是n層  因為就陣列長度 n 遞減到 1
		///
		/// 所以是 2^n
		/// 
		/// 但是他說是  n^2平方次方?  我來跑跑看 時測一下時間遞增的倍數  好像滿有趣的
		///
		/// 實測結果 應該是2^n  他可能寫錯了  已提交詢問
		///
		/// 
		///for (int i = 2; i < 32; i++)
		///{
		///	var now = DateTime.Now;
		///	int[] n = new int[i];
		///	for (int j = 0; j < i; j++)
		///	{
		///		n[j] = j;
		///	}
		///	Solution_V2 ss = new Solution_V2();
		///	ss.StoneGameVII(n);
		///	Console.WriteLine(i + " " + DateTime.Now.Subtract(now).TotalMilliseconds);
		///}
		///
		/// 2 0
		///3 0
		///4 0
		///5 0
		///6 0
		///7 0
		///8 0
		///9 0
		///10 0
		///11 0
		///12 0
		///13 0
		///14 0.9765
		///15 0
		///16 1.9511
		///17 1.9518
		///18 5.8563
		///19 8.8091
		///20 20.4743
		///21 44.4265
		///22 81.9833
		///23 177.6695
		///24 311.8522
		///25 559.9039
		///26 1090.7943
		///27 2219.3533
		///28 4382.3762
		///29 8856.4235
		///30 18894.4846
		///31 35567.237
		/// 
		///
		///
		/// 實測結果 應該是2^n  他可能寫錯了  已提交詢問
		/// 因為長度+1   時間x2
		/// 
		///Space Complexity: \mathcal{O}(n)O(n), as we build an array prefixSum of size nn.
		///
		/// </summary>
		class Solution_V2Log
		{
			int[] prefixSum;


			public static int cou = 0;

			private int findDifference(int start, int end, bool alice)
			{
				Console.WriteLine($"#{cou++}");

				if (start == end)
				{
					Console.WriteLine($"{start} == {end}  return 0");
					return 0;
				}
				int difference;       //因為ps 1~n 傳入的end是n-1 所以要+1轉為n
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];// pn - p1
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];//剛看會以為-p0怪  但是對照一下Sol的圖  會發現這是真的  -p0才有保留1st元素的效果
				string p = alice ? "A" : "B";
				Console.WriteLine($"{p} scoreRemoveFirst({start + 1},{end + 1}): {scoreRemoveFirst}  scoreRemoveLast({start},{end}): {scoreRemoveLast}");

				if (alice)
				{

					int num1 = findDifference(start + 1, end, !alice);//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2 = findDifference(start, end - 1, !alice);
					int num1SRF = num1 + scoreRemoveFirst;//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2SRL = num2 + scoreRemoveLast;

					difference = Math.Max(num1SRF, num2SRL);
					Console.WriteLine($"A, s1n  diff from {start + 1} to {end}  is {num1} ,  +scoreRemoveFirst:{scoreRemoveFirst} = {num1SRF}");
					Console.WriteLine($"A, se1 diff from {start } to {end - 1}  is {num2}, +scoreRemoveLast:{scoreRemoveLast} = {num2SRL} ");
					Console.WriteLine($"Max = {difference}");
				}
				else
				{
					int num1 = findDifference(start + 1, end, !alice);//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2 = findDifference(start, end - 1, !alice);
					int num1SRF = num1 - scoreRemoveFirst;//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2SRL = num2 - scoreRemoveLast;

					difference = Math.Min(num1SRF, num2SRL);
					Console.WriteLine($"B, s1n diff from {start + 1} to {end}  is {num1} ,  +scoreRemoveFirst:{scoreRemoveFirst} = {num1SRF}");
					Console.WriteLine($"B, se1 diff from {start } to {end - 1}  is {num2}, +scoreRemoveLast:{scoreRemoveLast} = {num2SRL} ");
					Console.WriteLine($"Min = {difference}");
				}
				return difference;
			}

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];// 0 ~ n-1  轉換到 1~n  
				}
				// 這個版本的diff過程中真的會有正有負  所以才需要abs
				int res = Math.Abs(findDifference(0, n - 1, true));
				Console.WriteLine($"res: {res}");
				return res;
			}
		}




		/// <summary>
		/// So1 1 最原始的遞迴  完全照題意
		/// 的確一步一步細追每一步  都很有道理 然後好像放下去 就會是對的
		/// 但是人一想要追這種好幾層的遞迴  沒有紙筆只靠腦的話   stack好像沒這麼大  很難輕易記住每一步一直拆下去
		/// 特別是要拆到最底  才能知道確切的數字 更是難
		///
		/// 所以這時候 log就派上用場了  來幫sol加 log
		/// 這TLE 但對原理理解很有幫助
		///
		/// 這樣是 9/68 test case pass
		/// </summary>
		class Solution_V2
		{
			int[] prefixSum;

			private int findDifference(int start, int end, bool alice)
			{
				if (start == end)
				{
					return 0;
				}
				int difference;       //因為ps 1~n 傳入的end是n-1 所以要+1轉為n
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];// pn - p1
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];//剛看會以為-p0怪  但是對照一下Sol的圖  會發現這是真的  -p0才有保留1st元素的效果

				if (alice)
				{
					difference = Math.Max(
						findDifference(start + 1, end, !alice) + scoreRemoveFirst,//兩個區間就是這樣沒錯  起訖個往左或往右移一位
						findDifference(start, end - 1, !alice) + scoreRemoveLast);
				}
				else
				{
					difference = Math.Min(
						findDifference(start + 1, end, !alice) - scoreRemoveFirst,
						findDifference(start, end - 1, !alice) - scoreRemoveLast);
				}
				return difference;
			}

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];// 0 ~ n-1  轉換到 1~n  
				}
				return Math.Abs(findDifference(0, n - 1, true));
			}
		}


		/// <summary>
		///
		/// 他人寫的解答
		/// 
		/// https://leetcode.com/problems/stone-game-vii/submissions/
		///
		///Approach 5: Another Approach using Tabulation
		/// 
		/// Runtime: 184 ms, faster than 100.00% of C# online submissions for Stone Game VII.
		//  Memory Usage: 38.5 MB, less than 100.00% of C# online submissions for Stone Game VII.
		///
		/// prefixSum 沒想到可以這樣 也是我原做法兩邊遞減不會用到
		/// 這個好用在於可以直相減知道任意兩點中間的和  就是厲害
		/// 應該是 preprocess之類的
		/// 
		/// </summary>
		class Solution_V1
		{
			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;

				int[,] dp = new int[n, n];


				int[] prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];
				}
				for (int length = 2; length <= n; length++)
				{
					for (int start = 0; start + length - 1 < n; start++)
					{
						int end = start + length - 1;
						int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];
						int scoreRemoveLast = prefixSum[end] - prefixSum[start];
						dp[start, end] = Math.Max(scoreRemoveFirst - dp[start + 1, end],
							scoreRemoveLast - dp[start, end - 1]);

					}
				}
				return dp[0, n - 1];
			}
		}




		/// <summary>
		/// 最後沒自己想出來  這題太複雜了
		/// 人大概只能看往後一兩步  來推論一開始要選左還是右
		/// 跟下棋有點像
		/// 所以沒有簡單的規則
		/// 本來還想說  如果是A一定都選最小  B都選最大
		/// 或者加上  要保留選擇變 3 1 4 給A 選  這樣步論選哪邊  都會剩1給B  B在最後步就能最優化
		///
		/// 但是這種規則太單一情況了   不知道還有多少規則  光是前面要怎麼走  才能讓最後保留 3 1 4 就不簡單
		/// 想不到
		/// 
		/// 甚至連所謂的
		/// Bob decided to minimize the score's difference. Alice's goal is to maximize the difference in the score.
		/// both play optimally.
		/// 
		/// 一個重點是不確定在兩者各自最大或會小diff的情況下  還要不要追求分數最大
		/// 因為也許  分數最大的時候  不一定會最大 或最小差異
		/// 因為造成差異的一個重點是在於移除
		/// 移除大數  會造成sum可能低  直接的效果是  下一個人無法用移除這個大數早成大反差
		/// 但是可能大數的旁邊是大數 所以可以讓下一個人移除 造成更大的差異   之類的
		/// 所以很難確定到底是有沒有要追求  sum最大   當然遊戲規則已經說 A必贏  所以可能沒這條
		/// 應該沒有   無論如何  後來看sol  就很清楚了
		///
		/// For Bob, he will try to return the maximum negative value. So that the difference between his and Alice's score is minimum.
		/// For Alice, she will try to return the maximum positive value.So that the difference between her and Bob's score is maximum.
		/// 
		/// Bob's difference = Alice's difference - Current Score
		/// Alice's difference = Bob's Difference + Current Score
		/// 
		/// 更難得的是看到 Top Down  /  Bottom Up
		/// 以之前林教的 Top Down 是比較常見的  Bottom Up好像比較少說到
		/// 但這邊就看到了
		///
		/// 實際上  就算Sol已經寫得很詳盡了  但是複雜度高有些地方看還是不是很懂
		/// 可見這題的確有難度
		/// 來實際跑跑看
		///
		/// </summary>
		public class Solution_V1_NotSuccess
		{
			public int StoneGameVII(int[] stones)
			{
				//List<int> ls = stones.ToList();
				var s = stones;
				int sum = stones.Sum();
				int A = 0, B = 0;


				//這裡就自己體驗到有練習 的經驗增加的效果
				//一開始會想   移除到沒有  那就是 while count > 0
				//但是之前練過一題  就是試過  雙指標  就是更快
				//所以這裡寫到一半  就會自動想到改用雙指標更快
				//while (ls.Any())
				//{

				//}

				bool roundA = true;
				for (int i = 0, j = stones.Length - 1; i <= j;)
				{

					if (j - i == 1)
					{
						//if (!roundA)
						//{
						if (s[i] < s[j])
						{
							sum -= s[i];
							if (roundA)
								A += sum;
							else
								B += sum;
							i++;
						}
						else if (s[j] < s[i])
						{
							sum -= s[j];
							if (roundA)
								A += sum;
							else
								B += sum;
							j--;
						}
						else
						{
							sum -= s[i];
							if (roundA)
								A += sum;
							else
								B += sum;
							i++;

						}
						//}
						//else
						//{

						//}
					}

					//特別考慮兩邊相同的
					//5625
					//A 要盡量移掉小的  B移大的
					// A 18 移左5   B 13 移右5  A 18+8=26移6  B 13+2=15  > 11 
					// A 18 移右5   B 13 移右2  A 18+11=29移6  B 13+2=15  > 14
					// 所以A要移除附近的是小的   B要移除靠近的是大的
					//
					if (!roundA)//B
					{
						if (s[i] > s[j])
						{
							sum -= s[i];
							B += sum;
							i++;
						}
						else if (s[j] > s[i])
						{
							sum -= s[j];
							B += sum;
							j--;
						}
						else//  == 
						{
							int choose = i;
							int i1 = i, j1 = j;
							bool isChoose = false;
							while (i1 + 1 < j1 - 1)
							{
								if (s[i1 + 1] > s[j1 - 1])
								{
									choose = j1 - 1;
									j--;
									isChoose = true;
									break;
								}
								else if (s[i1 + 1] < s[j1 - 1])
								{
									choose = i1 + 1;
									i++;
									isChoose = true;
									break;
								}
								else
								{
									i1 += 1;
									j1 -= 1;
								}
							}
							sum -= s[choose];
							if (!isChoose)
								i++;
							B += sum;
						}
					}
					else//A 移小的
					{
						if (s[j] > s[i])
						{
							sum -= s[i];
							A += sum;
							i++;
						}
						else if (s[i] > s[j])
						{
							sum -= s[j];
							A += sum;
							j--;
						}
						else//  == 
						{
							int choose = i;
							int i1 = i, j1 = j;
							bool isChoose = false;
							while (i1 + 1 < j1 - 1)
							{
								if (s[i1 + 1] < s[j1 - 1])
								{
									choose = j1 - 1;
									j--;
									isChoose = true;
									break;
								}
								else if (s[i1 + 1] > s[j1 - 1])
								{
									choose = i1 + 1;
									i++;
									isChoose = true;
									break;
								}
								else
								{
									i1 += 1;
									j1 -= 1;
								}
							}
							sum -= s[choose];
							if (!isChoose)
								i++;
							A += sum;
						}
					}

					roundA = !roundA;
				}

				return A - B;
			}
		}

	}
}
