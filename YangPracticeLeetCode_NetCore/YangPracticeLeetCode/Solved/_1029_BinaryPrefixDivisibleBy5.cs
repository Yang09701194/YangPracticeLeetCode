using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1029_BinaryPrefixDivisibleBy5
	{
		public static void Test()
		{

			Solution s = new Solution();

			int[] n1 = new int[] { 0, 1, 1, 1, 1, 1 };
			s.PrefixesDivBy5(n1).PrintList();

			int[] n2 = new int[] { 1, 1, 0, 0, 0, 1, 0, 0, 1 };
			s.PrefixesDivBy5(n2).PrintList();


		}



		public class Solution
		{
			public IList<bool> PrefixesDivBy5(int[] A)
			{
				List<bool> answers = new List<bool>();
				int[] remainder = new int[] { 1, 2, 4, 3 };

				//improve pass code
				int previousRemainSum = 0;
				for (int j = 1; j <= A.Length; j++)
				{
					previousRemainSum *= 2;
					previousRemainSum += A[j - 1];
					previousRemainSum = previousRemainSum % 5;
					answers.Add(previousRemainSum == 0);
				}

				//Time limit exceeded code
				//這邊已經很多技巧了 首先他binary 三萬位數  連long都裝不下
				//一定是特殊解法   部過考自己想不出來  goo看到3的倍數的
				//https://www.geeksforgeeks.org/check-binary-string-multiple-3-using-dfa/
				//得知是用餘數  聯想起孫老師的數導  有練過這題
				//馬上推算  1 2 4 8 16 32 的餘數是循環    1 2 4 3 1 2 4 3
				//所以  每個位數對應 特定的餘數  這樣子 2^100這種天文數字  要找是不是五的倍數 一樣他酒就是只要靠餘數  100/4 = 25 就是 3   而已
				//   所以把每個位數是1的 乘上餘數   總和就瞬間化成n  而不是n^n  就可以用int裝的下
				//
				//而且找的時候  要反過來數位數   這樣也會造成兩個迴圈 n^2
				//到這裡已經很聰明的解法  找是已經用很多了
				//不過還是 time exceed  
				// 
				//最後可能想了十多分鐘  才想到  類似一直往左位移的方法  變成單層迴圈  而且數字幾乎應該不會超過20  因為每次必取餘數  這樣就直接pass了 
				//
				//for (int j = 1; j <= A.Length; j++)
				//{
				//	int remainderSum = 0;
				//	int pos = 0;
				//	for (int i = j - 1; i >= 0; i--)
				//	{
				//		remainderSum += A[i] == 0 ? 0 : remainder[pos % 4];
				//		pos++;
				//	}
				//	answers.Add(remainderSum % 5 == 0);
				//}

				return answers;
			}
		}
	}
}
