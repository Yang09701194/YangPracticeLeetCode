using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _395_LongestSubstringwithAtLeastKRepeatingCharacters
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.LongestSubstring("aaabbb", 3));//3
			Console.WriteLine(s.LongestSubstring("aaabb", 3));//3
			Console.WriteLine(s.LongestSubstring("ababbc", 2));//5
			Console.WriteLine(s.LongestSubstring("ababacb", 3));//0
			Console.WriteLine(s.LongestSubstring("bbaaacbd", 3));//3
			Console.WriteLine(s.LongestSubstring("aaaaaaaaaaaaaaaabbbbbbbbbbbbaaaaaaabbbbbbbbbbbbcccccccccccdddddddddddddddddddeeeeeeeeeeeeeeefffffffffffffffgggggggggggggggggggghhhhhhhhhhhhhhhhiiiiiiiiiiiiiiiiiiiiiijjjjjjjjjjjjjjjjjjjjjjjjkkkkkkkkkkkkkkkkkkkk", 20));//66
			Console.WriteLine(s.LongestSubstring("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiijjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz", 301));//301


		}


		/// <summary>
		/// 這題是靠林講的 Dynamic Programming 書上解過的那幾題  的講述加紙筆解題經驗  就直接手寫程式碼  靠領悟的DP精神  直接推出來要這樣做的
		/// 最簡單的DP 是 一維的數列的前後關係   靠自己推導出這題的 一維上 每個位置都是一個多維陣列
		/// 前後相減會獲得字串狀態差異
		///
		/// 另外自己想出這題題目得到的規則
		/// 
		/// 1 一開始讀肯定是失敗  但是走著走著  如果在某個點成功了   拿從最開始到這個點都算成功
		///   所以前面成功部分   直接長度就是  開始-最後一個成功點
		/// 2 如果最後一個成功後面有失敗  代表就是失敗到底
		/// 但是失敗的部分   可能會因為去掉少部分失敗的  就變成成功
		/// 所以最後失敗的部分  因為子字串可能在任意起到訖
		/// 所以就用暴力法  n x n 個點全部測試  取最長成功的
		///
		/// 但是暴力法沒辦法通過最後一個TLE
		/// 所以把  連續字串  中間的點部分跳過不測試  例如  abbbbc  最中間的兩個b可以跳過
		/// 因為整個連續字串  要嘛大於k 那就全拿  不然小於k就全丟
		/// 就可以Accepted
		///
		/// 但原本跳過的點 用 List裝   Contains檢查太慢  TLE
		/// 改成用Dictionary就過了 
		/// 
		/// 又再更優化   連跳過這個動作都省掉  改成只跑不用跳過的    又更精準  就是這版
		///
		/// 
		/// </summary>
		public class Solution
		{
			public int LongestSubstring(string s, int k)
			{
				Func<char, int> toAscii = c =>
				{
					return Convert.ToInt32(c) - 97;
				};
				//int i3 = Convert.ToInt32('a'); //97
				//int i2 = Convert.ToInt32('z'); //132

				List<int[]> dpCharCouSnapShot = new List<int[]>();
				int[] charCou = new int[26];

				for (int i = 0; i < s.Length; i++)//O n
				{
					charCou[toAscii(s[i])] += 1;
					dpCharCouSnapShot.Add(charCou.ToArray());
				}



				bool[] matchOrNotArr = new bool[s.Length];

				for (int i = 0; i < s.Length; i++)// O 26n
				{
					bool isMatch = true;
					for (int j = 0; j < charCou.Length; j++)
					{
						if (dpCharCouSnapShot[i][j] != 0 && dpCharCouSnapShot[i][j] < k)
						{
							isMatch = false;
							break;
						}
					}

					matchOrNotArr[i] = isMatch;
				}

				List<int> successPos = new List<int>();
				for (int i = 0; i < matchOrNotArr.Length; i++) //O n
				{
					if (matchOrNotArr[i])
						successPos.Add(i);
				}

				int maxLength = 0;
				int lastFailStart = -1;
				int lastFailEnd = -1;
				if (successPos.Any())// O 1
				{
					int lastSucPos = successPos.Last();
					maxLength = lastSucPos + 1;

					if (lastSucPos < s.Length - 1)
					{
						lastFailStart = lastSucPos + 1;
						lastFailEnd = s.Length - 1;
					}
				}
				else
				{
					lastFailStart = 0;
					lastFailEnd = s.Length - 1;
				}


				int[] skipMiddleContiPos = new int[s.Length];
				char prevChar = ' ';
				int contiCharCou = 0;
				for (int i = 0; i < s.Length; i++)// O n
				{
					if (s[i] != prevChar)
					{
						prevChar = s[i];
						contiCharCou = 1;
					}
					else
					{
						contiCharCou++;
						if (contiCharCou >= 3)
							skipMiddleContiPos[i - 1] = -1;
					}
				}
				List<int> validPos = new List<int>();// 視lastFailStart而定  大的話  花費就少  worst O n
				for (int i = lastFailStart; i < skipMiddleContiPos.Length && i != -1; i++)
				{
					if (skipMiddleContiPos[i] == 0)
						validPos.Add(i);
				}

				//暴力計算全部起訖組合的字串
				for (int i = 0; i < validPos.Count(); i++)//  連續的字元多 會比n小很多  lastFailStart大 也會小  其他反之     worst 26n
				{
					//if (skipMiddleContiPos.ContainsKey(i))
					//	continue;
					for (int j = 0; j < validPos.Count(); j++)
					{
						//if(i == 208 && j == 143)
						//	Console.WriteLine();
						//if (skipMiddleContiPos.ContainsKey(j))
						//	continue;

						int iV = validPos[i];
						int jV = validPos[j];

						if (iV < jV)
						{
							var iArr = dpCharCouSnapShot[iV].ToArray();
							var jArr = dpCharCouSnapShot[jV].ToArray();

							for (int l = 0; l < jArr.Length; l++)
							{
								jArr[l] -= iArr[l];
							}

							bool isMatch = true;
							for (int m = 0; m < charCou.Length; m++)  //26
							{
								if (jArr[m] != 0 && jArr[m] < k)
								{
									isMatch = false;
									break;
								}
							}

							if (isMatch && (jV - iV > maxLength))
								maxLength = jV - iV;

						}
					}
				}

				return maxLength;

			}
		}


		//其實說起來這邊的做法  和我上面  是有點類似
		//discuss top vote
		public class Solution2
		{
			public int LongestSubstring(String s, int k)
			{
				char[] str = s.ToCharArray();
				int[] counts = new int[26];
				int h, i, j, idx, max = 0, unique, noLessThanK;

				for (h = 1; h <= 26; h++)
				{
					counts = new int[26];
					i = 0;
					j = 0;
					unique = 0;
					noLessThanK = 0;
					while (j < str.Length)
					{
						if (unique <= h)
						{
							idx = str[j] - 'a';
							if (counts[idx] == 0)
								unique++;
							counts[idx]++;
							if (counts[idx] == k)
								noLessThanK++;
							j++;
						}
						else
						{
							idx = str[i] - 'a';
							if (counts[idx] == k)
								noLessThanK--;
							counts[idx]--;
							if (counts[idx] == 0)
								unique--;
							i++;
						}
						if (unique == h && unique == noLessThanK)
							max = Math.Max(j - i, max);
					}
				}

				return max;
			}
		}

		//接下來看  LC 的 Sol 2
		//  Divide And Conquer 標準起手式
		//longestSustring(start, end) = max(longestSubstring(start, mid), longestSubstring(mid+1, end))
		//跟算 Master Theorem 有點類似

		//仔細看這個  好聰明喔
		//比我原本想到的東西 再往前推進了一步  我就是差這一步  所以才沒有繼續往下走
		//第一個想到的一定是 整個字串  合法的  剛好中間就卡一個不合法的
		//或卡兩個   
		//但我接下來的想法就走成   從頭開始  中間遇到不合法的  可能最後累積之後變合法的
		//所以我就往   前面成功  後面失敗  的路走上去了
		//整個找不合法的   最直接就會想到  數完第一次  又能怎樣   只會知道中間可能是成功的 但是又會不確定  因為是算整個的   中間一考慮步合法點之間的子字串  就全部要重算    所以算整個的又沒用了
		//如果沒有接受  divide and conquer的觀念 就不會知道  這正是 d a c 的開端就是長這樣  這樣的疑問剛好就是套用 d a c的情境
		//我之前林當然也有講過  也有紙筆練過  不過到這邊就不會自然套用   也算是多學習了一次
		//但是再看 time compl分析   最糟也是 O n^2  再下一個 Sliding Window 只要26N
		//可見不是 d a c 就好棒棒    所以買premium應該真的不錯  那麼多人在說要買  是有道理的
		//
		//既然要練  我就用腦理解後  自己用手來刻出程式  不看ans
		//就靠這句 //longestSustring(start, end) = max(longestSubstring(start, mid), longestSubstring(mid+1, end))

		//其實說起來這邊的做法  和我上面  是有點類似
		//public class Solution3
		//{
		//	public int LongestSubstring(String s, int k)
		//	{
		//		Func<char, int> toAscii = c =>
		//		{
		//			return Convert.ToInt32(c) - 97;
		//		};
		//		Func<int, char> toChar = i =>
		//		{
		//			return (char)i;
		//		};

		//		//int i3 = Convert.ToInt32('a'); //97
		//		//int i2 = Convert.ToInt32('z'); //132
		//		int[] charCou = new int[26];

		//		for (int i = 0; i < s.Length; i++)//O n
		//		{
		//			charCou[toAscii(s[i])] += 1;
		//		}

		//		char lessKChar = ' ';
		//		for (int i = 0; i < charCou.Length; i++)
		//		{
		//			if (charCou[i] < k)
		//			{
		//				lessKChar = toChar(i);
		//			}
		//		}

		//		if (lessKChar ==' ')
		//			return s.Length;

		//		int lessKCharPos = -1;
		//		for (int i = 0; i < s.Length; i++)//O n
		//		{
		//			//	寫到這邊  突然覺得  只要是遞迴方法  裡面再分兩個子呼叫的  好像都叫做 D A C   那Fibonacci這種基礎常見的作法  
		//			if()
		//		}

		//		//  分割位置就是 LessCharASCII  
		//		return lessKCharAscii[i]
		//	}
		//}

	}
}
