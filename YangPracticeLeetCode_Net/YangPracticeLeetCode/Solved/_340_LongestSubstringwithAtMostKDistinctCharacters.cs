using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _340_LongestSubstringwithAtMostKDistinctCharacters
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.LengthOfLongestSubstringKDistinct("eceba", 2));
			Console.WriteLine(s.LengthOfLongestSubstringKDistinct("aa", 1));

		}


		/// <summary>
		/// 改寫  雙  pointer
		/// Runtime: 116 ms, faster than 12.13% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		///Memory Usage: 26.8 MB, less than 9.90% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		///
		///
		/// 如下說明  100% speed
		/// Runtime: 60 ms, faster than 100.00% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		///Memory Usage: 23.6 MB, less than 40.84% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		///
		/// 概念同  第一個參考更快的人寫的解答
		///
		/// 自己分析  time O n  space 看來是 O 1 
		///
		/// </summary>
		public class Solution
		{
			public int LengthOfLongestSubstringKDistinct(string s, int k)
			{
				int window_start = 0;
				int window_end = -1;
				int[] freq = new int[128];
				int max = 0;
				int freqGreaterEq1Cou = 0;
				for (int i = 0; i < s.Length; i++)//O n    裡面沒有更複雜的  所以應該 O n
				{
					int idx = Convert.ToInt32(s[i]);
					window_end++;
					freq[idx]++;
					if (freq[idx] == 1)
						freqGreaterEq1Cou++;

					while (freqGreaterEq1Cou > k)
					{
						char d = s[window_start++];
						int currIdx = Convert.ToInt32(d); ;
						freq[currIdx]--;
						if (freq[currIdx] == 0)
						{
							freqGreaterEq1Cou--;
						}


						//原本 freq 裝次數  另用 List 裝大於0次數的 idx  兩個都純值  就要另外關聯處理
						//而且 歸 0 還要 list.Remove  O n    跟 HashSet底層HashTable Remove O 1 有巨大差距  所以改寫 Dic  標註此  直接  dic.Count(f=> f.Value > 0)
						//if (freqCou[currIdx] == 0)
						//{
						//	hasValIdx.Remove(currIdx);
						//}
						//更正 Dic.Cou 反而超慢  變到 600ms  不行
						//改成特殊機制 搭配純數
						//
						//有了   !!!    直接進 100%  成功  不用看Sol


					}

					max = Math.Max(window_end - window_start + 1, max);
				}
				return max;
			}
		}



		/// <summary>
		/// 常見的  window  左右彈性縮放 往右移動  發現重複的就從左邊while 移除
		///
		/// 然後數字的出現數量  一開始以為是字母  就 new int 26   c - '0'
		/// 後面發現有特殊字元   推是 ascii  128  convert.toint(c) 成功
		/// 
		/// 己寫  Pass  但速度慢
		/// Runtime: 160 ms, faster than 5.94% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		/// Memory Usage: 27.3 MB, less than 6.68% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		/// 
		/// 看了很速解  概念完全相同  差在 我 Queue 因為queue符合順序往右移動
		/// 他  雙 index pointer 就搞定
		/// </summary>
		public class Solution_V1
		{
			public int LengthOfLongestSubstringKDistinct(string s, int k)
			{
				Queue<char> chs = new Queue<char>();
				int[] freq = new int[128];
				int max = 0;
				for (int i = 0; i < s.Length; i++)
				{
					int idx = Convert.ToInt32(s[i]);
					chs.Enqueue(s[i]);
					freq[idx]++;

					List<int> hasValIdx = new List<int>();
					for (int j = 0; j < 128; j++)
					{
						if (freq[j] > 0)
						{
							hasValIdx.Add(j);
						}
					}

					while (hasValIdx.Count > k)
					{
						char d = chs.Dequeue();
						int currIdx = Convert.ToInt32(d); ;
						freq[currIdx]--;
						if (freq[currIdx] == 0)
						{
							hasValIdx.Remove(currIdx);
						}
					}

					max = Math.Max(chs.Count(), max);
				}
				return max;
			}
		}



		// LC Sol1    概念相同 只是他把同char的 用Map裝  char目前出現的最右邊的index
		// 發現 > k 時   移除最右邊的所有min的  
		// 只是這個min  可能 O 比較大    應該比我100%純arr慢
		//
		// For the best case when input string contains not more than k distinct characters the answer is yes. It's the only one pass along the string with N characters and the time complexity is O(N).
		// 
		// For the worst case when the input string contains n distinct characters, the answer is no. In that case at each step one uses O(k) time to find a minimum value in the hashmap with k elements and so the overall time complexity is O(Nk).
		// 
		// Time complexity : O(N) in the best case of k distinct characters in the string and O(Nk) in the worst case of N distinct characters in the string.
		// 
		// Space complexity : O(k) since additional space is used only for a hashmap with at most k + 1 elements.
		//
		//
		// class Solution {
		//     public int lengthOfLongestSubstringKDistinct(String s, int k) {
		//         int n = s.length();
		//         if (n * k == 0) {
		//             return 0;
		//         }
		//         int left = 0;
		//         int right = 0;
		// 
		//         Map<Character, Integer> rightmostPosition = new HashMap<>();
		// 
		//         int maxLength = 1;
		// 
		//         while (right < n) {
		//             rightmostPosition.put(s.charAt(right), right++);
		// 
		//             if (rightmostPosition.size() == k + 1) {
		//                 int lowestIndex = Collections.min(rightmostPosition.values());
		//                 rightmostPosition.remove(s.charAt(lowestIndex));
		//                 left = lowestIndex + 1;
		//             }
		// 
		//             maxLength = Math.max(maxLength, right - left);
		//         }
		//         return maxLength;
		//     }
		// }


		// Approach 2: Sliding Window + Ordered Dictionary.
		// How to achieve O(N) time complexity
		// 
		// Approach 1 with a standard hashmap couldn't ensure O(N) time complexity.
		// 
		// To have O(N) algorithm performance, one would need a structure, which provides four operations in O(1) time :
		// 
		// Insert the key
		// 
		// Get the key and check if the key exists
		// 
		// Delete the key
		// 
		// Return the first or last added key/ value
		// 
		// The first three operations in O(1) time are provided by the standard hashmap, and the forth one - by linked list.
		// 
		// There is a structure called
		// !! Ordered Dictionary,
		// it combines behind both hashmap and linked list. In Python this structure is called OrderedDict and in Java LinkedHashMap.

		//詳 Algorithm 描述見網頁

		// class Solution {
		//     public int lengthOfLongestSubstringKDistinct(String s, int k) {
		//         int n = s.length();
		//         if (n * k == 0) {
		//             return 0;
		//         }
		//         int left = 0;
		//         int right = 0;
		// 
		//         Map<Character, Integer> rightmostPosition = new LinkedHashMap<>();
		// 
		//         int maxLength = 1;
		// 
		//         while (right < n) {
		//             Character character = s.charAt(right);
		//             if (rightmostPosition.containsKey(character)) {
		//                 rightmostPosition.remove(character);
		//             }
		//             rightmostPosition.put(character, right++);
		// 
		//             if (rightmostPosition.size() == k + 1) {
		//                 Map.Entry<Character, Integer> leftmost =
		//                     rightmostPosition.entrySet().iterator().next();
		//                 rightmostPosition.remove(leftmost.getKey());
		//                 left = leftmost.getValue() + 1;
		//             }
		// 
		//             maxLength = Math.max(maxLength, right - left);
		//         }
		//         return maxLength;
		//     }
		// }

		// Complexity Analysis
		// 
		// Time complexity : (N)O(N) since all operations with ordered dictionary : insert/get/delete/popitem (put/containsKey/remove) are done in a constant time.
		// 
		// Space complexity : (k)O(k) since additional space is used only for an ordered dictionary with at most k + 1 elements.



	}
}
