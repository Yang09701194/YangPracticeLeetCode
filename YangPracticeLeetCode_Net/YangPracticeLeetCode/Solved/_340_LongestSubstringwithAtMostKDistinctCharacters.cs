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
		/// ��g  ��  pointer
		/// Runtime: 116 ms, faster than 12.13% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		///Memory Usage: 26.8 MB, less than 9.90% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		///
		///
		/// �p�U����  100% speed
		/// Runtime: 60 ms, faster than 100.00% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		///Memory Usage: 23.6 MB, less than 40.84% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		///
		/// �����P  �Ĥ@�ӰѦҧ�֪��H�g���ѵ�
		///
		/// �ۤv���R  time O n  space �ݨӬO O 1 
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
				for (int i = 0; i < s.Length; i++)//O n    �̭��S���������  �ҥH���� O n
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


						//�쥻 freq �˦���  �t�� List �ˤj��0���ƪ� idx  ��ӳ��­�  �N�n�t�~���p�B�z
						//�ӥB �k 0 �٭n list.Remove  O n    �� HashSet���hHashTable Remove O 1 �����j�t�Z  �ҥH��g Dic  �е���  ����  dic.Count(f=> f.Value > 0)
						//if (freqCou[currIdx] == 0)
						//{
						//	hasValIdx.Remove(currIdx);
						//}
						//�� Dic.Cou �ϦӶW�C  �ܨ� 600ms  ����
						//�令�S����� �f�t�¼�
						//
						//���F   !!!    �����i 100%  ���\  ���ά�Sol


					}

					max = Math.Max(window_end - window_start + 1, max);
				}
				return max;
			}
		}



		/// <summary>
		/// �`����  window  ���k�u���Y�� ���k����  �o�{���ƪ��N�q����while ����
		///
		/// �M��Ʀr���X�{�ƶq  �@�}�l�H���O�r��  �N new int 26   c - '0'
		/// �᭱�o�{���S��r��   ���O ascii  128  convert.toint(c) ���\
		/// 
		/// �v�g  Pass  ���t�׺C
		/// Runtime: 160 ms, faster than 5.94% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		/// Memory Usage: 27.3 MB, less than 6.68% of C# online submissions for Longest Substring with At Most K Distinct Characters.
		/// 
		/// �ݤF�ܳt��  ���������ۦP  �t�b �� Queue �]��queue�ŦX���ǩ��k����
		/// �L  �� index pointer �N�d�w
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



		// LC Sol1    �����ۦP �u�O�L��Pchar�� ��Map��  char�ثe�X�{���̥k�䪺index
		// �o�{ > k ��   �����̥k�䪺�Ҧ�min��  
		// �u�O�o��min  �i�� O ����j    ���Ӥ��100%��arr�C
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

		//�� Algorithm �y�z������

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
