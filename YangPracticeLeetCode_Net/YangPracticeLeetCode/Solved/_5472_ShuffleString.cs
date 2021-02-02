using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5472_ShuffleString
	{

		public static void Test()
		{
			Solution s = new Solution();

			Console.WriteLine(s.RestoreString("aaiougrt", new int[] { 4, 0, 2, 6, 7, 3, 1, 5 }));


		}

		public class Solution
		{
			public string RestoreString(string s, int[] indices)
			{
				char[] result = new char[s.Length];

				for (int i = 0; i < s.Length; i++)
				{
					result[indices[i]] = s[i];
				}

				return new string(result);
			}
		}


	}
}
