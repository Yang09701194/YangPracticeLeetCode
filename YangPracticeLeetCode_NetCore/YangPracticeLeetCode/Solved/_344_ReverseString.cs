using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _344_ReverseString
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			s.ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
			s.ReverseString(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' });

		}

		/// <summary>
		/// Two Pointers, OK   or iteration as Sol2
		/// </summary>
		public class Solution
		{
			public void ReverseString(char[] s)
			{
				//  1234   1,4  2,3
				//  12345  1,5  2,4  3
				for (int i = 0, j = s.Length - 1; i < j ; i++, j--)
				{
					char temp = s[i];
					s[i] = s[j];
					s[j] = temp;
				}

				//Console.WriteLine(new string(s));
			}
		}


		/// <summary>
		/// Recursion    很明顯  迴圈轉遞迴    經典範例
		/// 
		/// Does in-place mean constant space complexity?
		/// 
		/// No. By definition, an in-place algorithm is an algorithm which transforms input using no auxiliary data structure.
		/// 
		/// The tricky part is that space is used by many actors, not only by data structures. The classical example is to use recursive function without any auxiliary data structures.
		/// 
		/// Is it in-place? Yes.
		/// 
		/// Is it constant space? No, because of recursion stack.
		///
		/// 貼  Complex
		/// </summary>
		class Solution2
		{
			public void helper(char[] s, int left, int right)
			{
				if (left >= right) return;
				char tmp = s[left];
				s[left++] = s[right];
				s[right--] = tmp;
				helper(s, left, right);
			}

			public void reverseString(char[] s)
			{
				helper(s, 0, s.Length - 1);
			}
		}

	}
}
