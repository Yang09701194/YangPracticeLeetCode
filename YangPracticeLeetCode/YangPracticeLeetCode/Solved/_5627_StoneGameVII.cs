using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5627_StoneGameVII
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.StoneGameVII(new int[] { 5, 3, 1, 4, 2 }));
			//Console.WriteLine(s.StoneGameVII(new int[] { 7, 90, 5, 1, 100, 10, 10, 2 }));
			//Console.WriteLine(s.StoneGameVII(new int[] { 3, 5 }));

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
		/// 
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
					string p = alice ? "A" : "B";

					int num1=0, num2 = 0;
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
				Console.WriteLine($"{p} scoreRemoveFirst({start+1},{end+1}): {scoreRemoveFirst}  scoreRemoveLast({start},{end}): {scoreRemoveLast}");

				if (alice)
				{

					int num1 = findDifference(start + 1, end, !alice);//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2 = findDifference(start, end - 1, !alice);
					int num1SRF = num1 + scoreRemoveFirst;//兩個區間就是這樣沒錯  起訖個往左或往右移一位
					int num2SRL = num2 + scoreRemoveLast;

					difference = Math.Max(num1SRF, num2SRL);
					Console.WriteLine($"A, s1n  diff from {start +1} to {end}  is {num1} ,  +scoreRemoveFirst:{scoreRemoveFirst} = {num1SRF}");
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
				int res =  Math.Abs(findDifference(0, n - 1, true));
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
				return dp[0,n - 1];
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
							while (i1 + 1 < j1 -1)
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
