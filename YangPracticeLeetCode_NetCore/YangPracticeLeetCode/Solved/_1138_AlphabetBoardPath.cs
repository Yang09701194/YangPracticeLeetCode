using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1138_AlphabetBoardPath
	{

		public static void Test()
		{

			Solution s = new Solution();
			Console.WriteLine(s.AlphabetBoardPath("leet"));
			Console.WriteLine(s.AlphabetBoardPath("code"));
			Console.WriteLine(s.AlphabetBoardPath("zb"));


		}

		public class Solution
		{

			private Dictionary<char, int[]> AlphabetPos = new Dictionary<char, int[]>();

			public Solution()
			{
				string alpha = "abcdefghijklmnopqrstuvwxyz";
				for (int i = 0; i < alpha.Length; i++)
				{
					AlphabetPos.Add(alpha[i], new int[] {i%5, i/5});
				}
			}

			public string AlphabetBoardPath(string target)
			{
				string result = "";

				int[] prePos = new[] {0, 0};

				foreach (char c in target)
				{
					int[] pos = AlphabetPos[c];
					int columnDelta = pos[0] - prePos[0];
					int rowDelta = pos[1] - prePos[1];

					Action ColumnMove = () =>
					{
						if (columnDelta < 0)
						{
							for (int i = 0; i < Math.Abs(columnDelta); i++)
								result += "L";
						}
						else if (columnDelta > 0)
						{
							for (int i = 0; i < columnDelta; i++)
								result += "R";
						}
					};
					Action RowMove = () =>
					{
						if (rowDelta < 0)
						{
							for (int i = 0; i < Math.Abs(rowDelta); i++)
								result += "U";
						}
						else if (rowDelta > 0)
						{
							for (int i = 0; i < rowDelta; i++)
								result += "D";
						}
					};

					//z
					if (prePos[0] == 0 && prePos[1] == 5)
					{
						RowMove();
						ColumnMove();
					}
					else
					{
						ColumnMove();
						RowMove();
					}

					result += "!";
					prePos = pos;
				}

				return result;
			}
		}


	}
}
