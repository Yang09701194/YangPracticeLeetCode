using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace YangPracticeLeetCode.Solved
{
	class _5243_TuplewithSameProduct
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.TupleSameProduct(new int[] { 2, 3, 4, 6 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 1, 2, 4, 5, 10 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 2, 3, 4, 6, 8, 12 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 2, 3, 5, 7 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 161, 388, 242, 520, 558, 671, 127, 769, 709, 288, 855, 673, 438, 788, 649, 258, 192, 391, 743, 868, 603, 104, 23, 705, 328, 918, 707, 943, 792, 835, 146, 132, 508, 214, 552, 300, 133, 504, 999, 79, 598, 917, 843, 366, 564, 11, 71, 70, 615, 605, 318, 218, 191, 773, 344, 37, 844, 424, 273, 791, 884, 755, 685, 913, 829, 962, 964, 500, 464, 90, 210, 873, 271, 298, 479, 361, 177, 320, 359, 916, 484, 409, 805, 136, 383, 533, 268, 526, 19, 634, 149, 59, 691, 560, 539, 750, 433, 517, 17, 701 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 336, 1771, 851, 1091, 3860, 89, 361, 2382, 2000, 194, 60, 2093, 3844, 59, 967, 240, 570, 2642, 281, 2662, 3795, 2195, 2795, 1473, 2403, 1833, 3398, 3554, 141, 781, 1359, 2498, 3918, 1783, 3514, 3193, 3732, 594, 952, 2883, 2162, 1738, 3174, 1412, 1016, 335, 2277, 3764, 161, 1136, 1553, 1628, 528, 145, 3562, 786, 3549, 2622, 870, 380, 3827, 2580, 879, 1308, 2587, 2309, 1607, 3858, 3916, 2270, 2064, 1045, 1487, 1848, 638, 3721, 777, 2594, 1770, 2746, 3191, 2755, 2649, 2969, 1497, 1753, 474, 2179, 1933, 984, 1587, 2407, 2931, 3451, 3259, 1083, 1402, 1556, 288, 2043, 1943, 1429, 2397, 322, 3896, 3234, 2132, 146, 2691, 2687, 2955, 1675, 2588, 1912, 310, 2624, 785, 2501, 912, 616, 3876, 2011, 1522, 1294, 1346, 3567, 1847, 2196, 1357, 482, 2128, 855, 3108, 2734, 3085, 3692, 3443, 3035, 3389, 3376, 1057, 1011, 353, 418, 3775, 1196, 1525, 2189, 3340, 3907, 3609, 614, 1460, 468, 3044, 1526, 712, 916, 1085, 3252, 2329, 1199, 377, 2327, 1961, 3129, 3586, 675, 2207, 3183, 3449, 1966, 2557, 555, 3421, 2967, 1882, 2298, 3622, 3683, 1463, 3283, 585, 400, 1757, 2429, 3073, 1619, 3310, 478, 1023, 709, 2024, 2493, 3264, 3439, 2838, 1604, 3263, 1022, 1439, 3619, 2489, 84, 452, 1984, 2436, 1622, 2170, 3367, 1950, 621, 3929, 3256, 3455, 3664, 2293, 574, 3636, 850, 1445, 112, 1019, 2896, 3513, 2231, 1328, 1571, 3349, 1374, 2986, 2970, 1782, 732, 3980, 3529, 1502, 2881, 2950, 435, 2848, 2048, 439, 3046, 3565, 1006, 1241, 447, 3232, 94, 2695, 2366, 1236, 3185, 173, 1281, 3371, 157, 3227, 3144, 1488, 2888, 1361, 3248, 3125, 462, 1546, 3885, 1233, 987, 3082, 3230, 169, 230, 2866, 2661, 1515, 3671, 1072, 394, 3221, 541, 3213, 1573, 1060, 2906, 3940, 317, 803, 2378, 3104, 1043, 868, 1115, 2152, 665, 1741, 2497, 3685, 339, 1363, 2626, 2181, 2937, 600, 1536, 2514, 3276, 1867, 1101, 1325, 1951, 3362, 1561, 688, 1828, 942, 2120, 1276, 214, 1727, 642, 1324, 2425, 1705, 1096, 76, 774, 694, 2680, 1190, 1177, 2441, 746, 1520, 1709, 1348, 2591, 108, 2818, 2699, 1413, 2459, 1442, 540, 1065, 826, 111, 3099, 1838, 3838, 2670, 2640, 1279, 2105, 2021, 3488, 1852, 1514, 323, 1397, 3016, 2644, 1028, 2976, 3668, 2445, 2664, 828, 3425, 1484, 3761, 640, 1653, 962, 2432, 1296, 2971, 433, 3141, 2890, 672, 3124, 1861, 1589, 1419, 706, 3131, 2136, 3033, 90, 3978, 308, 1696, 2160, 338, 954, 2529, 1844, 738 }));


		}

		/// <summary>
		/// 這題騙很大  騙法跟一般 easy 的差不多  但是medium的騙法  果然是更難看出來
		/// 沒看出來就一定 TLE
		///
		/// 先是題意敘述  可看起來像是在說 combination  C n 取 k 然後 permutation
		/// 原本只有 perm 的 code   硬寫出 comb 的  利用perm的原理  recursion
		/// perm 直接想會想  硬刻好幾層 for 沒聽過看過會想不出來怎麼客製到任意大小
		/// 看過遞迴的巧妙  掌握原理  combi就可以刻出來了
		/// 核心關鍵就是 ex取3 comb   第一層挑 1~n-2 個  第二層 2~n-1 個  第3層取 3~n
		/// 所以會是直角面對左下的  三角形               
		/// ex 1234 取 3個 comb   123 124 134 234
		/// 遞迴如此作法   關鍵傳遞的參數就是上一層的for  start index 傳到下一層就for  +1 還有目前所在層數  以及紀錄目前comb的一個array 每一層都設定對應層數在array的index  向右遞增
		/// 當 recur 層 == comb長度  就是一個comb結果  可以蒐集  用ToArray copy 以不影響進行中的comb
		///
		/// comb完   用觀察法  可以知道  一個comb成立之後 perm 就是 * 8  直接*8 不用花時間perm
		/// 一個comb  會有三種22相乘可能  如code
		///  
		/// 接著TLE  發現不用copy全部蒐集完  在for檢查  可以在comb得到的時候  直接檢查   省掉copy  省超大  好像有10倍  忘記確切  省很多就對了
		///
		/// 再來 tle 又在想  會不會是相乘花時間  實際試過之後   for 10000000 相乘
		/// 有執行相乘和沒執行相乘的時間差不多  超出想像 代表相乘真的不花時間  是迴圈量的大小決定
		/// 
		/// 如果想說 在判斷22相乘相等  不要千值得大數相乘 化小一點 例如 % 10完再乘 或 & 1乘
		/// 都不會比較快  也就是說  對於人來說  化小一點可能真的好判斷一點   但在電腦沒差  可能都太快了 都不花時間
		/// 
		/// 所以重點會變成   有沒有可能減少總迴圈數
		/// 這樣就只有一條路   盡量減低遞迴數 和迴圈數
		/// 就要再找特殊的原理地方  可以用簡單計算就能達到全部檢查
		///
		/// 第二個想到  4層recur 有可能變 3層嗎
		/// 那就是 3個數  要知道第四個數   觀察後可知  3個數  共有三種相乘可能
		/// 12 13 23 這樣可知 第四個數 要相等這三數     就能簡化很多
		/// 如果case長度 幾百個  代表最多只會有這三種
		/// 這樣原本全檢查是 O n  用搜尋的直接找這3個  把它建成HashSet之類的DS  搜尋就只需 logn
		/// 就進入log境地    改完之後  就快了十倍  11s的case  變成只要1s 
		///
		/// 結果還是  tle  case當然有進步
		///
		/// 這邊有些細節  找第四個數  直接是  n1*n2/n3= n4  但不是剛好倍數的話  小數點 int會捨掉
		/// 這邊發現  如果用HashSet  和 計算* 都用 decimal 反而慢非常多
		/// 最後發現  先餘數n3 == 0 &&  n1*n2/n3  就很快又準
		/// 確定有了  因為一開始建HS是對全部  發現只要在遞迴過程add remove  就會變慢
		/// 所以採用 先有  在真正確定  再進去curr index以後比較每個數最準
		/// 已經很快  原本1s 變 0.3s
		///
		/// 還是tle
		///
		/// 再想  想到  可能comb是一個騙局
		/// 其實捷徑一想  22相乘之後   又是用 pre-processing的技巧
		/// 直接左到右階梯全部22相乘之後
		/// 再檢查  前面的結果  for到後面  只要有一樣的  就是++  這樣是對的
		/// 可惜太慢    這時一想  n^2 是慢 ?
		/// 不會  因為 3層recur 是 n^3  所以是快
		/// 但是還是 tle
		///
		/// 應是因為 全部都累加到同個List  以List來說  最後要判斷後面相等的  只能Contains > O n
		///
		/// 全部加到同個List  如果要有  搜尋  的效果  dic 或 HashSet 都有 key unique 的限制
		/// 所以無法有重複值  前後順序的紀錄
		///
		/// 卡住滿久  最後看別人的解答  已經很接近  只差最後臨門一腳
		///
		/// 上面的問題  轉個方向就解決了 也就是前後關係  就是用實際計算的時候去做
		/// 很直接平凡  但就是這樣
		/// 然後相同的部分   另外用一個dictionary  值 跟出現數量   這樣子去紀錄
		/// 就做到了上面的需求  又快速
		/// 而且技巧使用了  累加的累加
		/// 目前有 k個  再出現一個  就是等於 total+=k 因為新的可以跟前k個都對上  然後新的再加進來
		/// 更新為 k+1
		///
		/// Solved!
		///
		/// 
		/// 
		/// </summary>
		public class Solution
		{
			public int TupleSameProduct(int[] nums)
			{
				int totalSameComb = 0;
				Dictionary<int, int> dic = new Dictionary<int, int>();
				for (int i = 0; i < nums.Length - 1; i++)
				{
					for (int j =  i + 1; j < nums.Length; j++)
					{
						int multi = nums[i] * nums[j];
						if (!dic.ContainsKey(multi))
							dic.Add(multi, 1);
						else
						{
							totalSameComb+= dic[multi];
							dic[multi]++;
						}
					}
				}

				return totalSameComb*8;
			}
		}


		//public class Solution
		//{

		//	HashSet<int> hashSet = new HashSet<int>();
		//	public int TupleSameProduct(int[] nums)
		//	{
		//		hashSet.Clear();
		//		allCombs.Clear();
		//		totalValidComb = 0;

		//		foreach (int num in nums)
		//		{
		//			hashSet.Add(num);
		//		}
				
		//		//find all comb
		//		for (int i = 0; i < nums.Length - 3; i++)
		//		{
		//			hashSet.Remove(nums[i]);
		//			int[] comb = new int[4];
		//			comb[0] = nums[i];
		//			int parentIndex = i;
		//			int recurDepth = 0;
		//			FindCombination(comb, ref recurDepth, parentIndex, nums);
		//		}

				
				
		//		return totalValidComb * 8;
		//	}

		//	List<int[]> allCombs = new List<int[]>();
		//	int totalValidComb = 0;

		//	public void FindCombination(int[] comb, ref int recurDepth, int parentIndex, int[] nums)
		//	{
		//		recurDepth++;
		//		if (recurDepth < 3)
		//		{
		//			for (int j = parentIndex + 1; j < nums.Length; j++)
		//			{
		//				comb[recurDepth] = nums[j];
		//				parentIndex = j;
		//				if (recurDepth < 2)
		//				{
		//					FindCombination(comb, ref recurDepth, parentIndex, nums);
		//				}

		//				if (recurDepth == 2)
		//				{

		//					if (
		//						comb[0] * comb[1] % comb[2] == 0 && hashSet.Contains(comb[0] * comb[1] / comb[2])
		//						||
		//						comb[0] * comb[2] % comb[1] == 0 && hashSet.Contains(comb[0] * comb[2] / comb[1])
		//						||
		//						comb[1] * comb[2] % comb[0] == 0 && hashSet.Contains(comb[1] * comb[2] / comb[0])
		//					)
		//					{
		//						for (int k = j + 1; k < nums.Length; k++)
		//						{
		//							comb[3] = nums[k];
		//							//allCombs.Add(comb.ToArray());
		//							if (comb[0] * comb[1] == comb[2] * comb[3])
		//								totalValidComb++;
		//							if (comb[0] * comb[2] == comb[1] * comb[3])
		//								totalValidComb++;
		//							if (comb[0] * comb[3] == comb[1] * comb[2])
		//								totalValidComb++;

		//						}
		//					}

		//				}
		//			}
		//		}
		//		else
		//		{
					

		//		}
		//		recurDepth--;
		//	}
		//}


	}
}
