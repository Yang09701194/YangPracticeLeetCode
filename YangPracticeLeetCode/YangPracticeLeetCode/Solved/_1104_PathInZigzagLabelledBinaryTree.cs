using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1104_PathInZigzagLabelledBinaryTree
	{

		public static void Test()
		{
			Solution s = new Solution();

			int labe1 = 14;
			s.PathInZigZagTree(labe1).PrintList();

			labe1 = 13;
			s.PathInZigZagTree(labe1).PrintList();
			labe1 = 10;
			s.PathInZigZagTree(labe1).PrintList();
			

			int labe2 = 26;
			s.PathInZigZagTree(labe2).PrintList();

		}


		   //                        1
					//		2  				3
					//	4 		5		6		7
					//8    9  10 11   12 13   14 15

		public class Solution
		{
			public IList<int> PathInZigZagTree(int label)
			{
				List<int> paths = new List<int>();

				int powerOf2 = 0;
				int labelCopy = label;
				while (labelCopy > 0)
				{
					labelCopy /= 2;
					powerOf2++;	
				}

				int labelPath = label;
				paths.Add(label);
				while (labelPath > 1)
				{

					int diff = (int)Math.Pow(2, powerOf2) - 1 - labelPath;
					int upLevelPosDiff = diff / 2;

					int add = (int) Math.Pow(2, powerOf2 - 2) - 1 - upLevelPosDiff;

					//zizgzag  在同一列倒過來  位置反射
					add = (int) Math.Pow(2, powerOf2 - 2) - 1 - add;

					int upLevelPoint = (int) Math.Pow(2, powerOf2 - 2) + add;
					paths.Add(upLevelPoint);
					powerOf2 -= 1;
					labelPath = upLevelPoint;
				}
				paths.Reverse();
				return paths;
			}


			/// <summary>
			/// 竟然這樣短短幾行就可以找到path  完全不用建Tree  你就知道數學多強了
			/// </summary>
			/// <param name="label"></param>
			/// <returns></returns>
			public IList<int> PathInZigZagTreeAllLeftToRightFindPathWork(int label)
			{
				List<int> paths = new List<int>();

				int powerOf2 = 0;
				int labelCopy = label;
				while (labelCopy > 0)
				{
					labelCopy /= 2;
					powerOf2++;
				}

				int labelPath = label;
				paths.Add(label);
				while (labelPath > 1)
				{

					int diff = (int)Math.Pow(2, powerOf2) - 1 - labelPath;
					int upLevelPosDiff = diff / 2;

					int add = (int)Math.Pow(2, powerOf2 - 2) - upLevelPosDiff - 1;
					int upLevelPoint = (int)Math.Pow(2, powerOf2 - 2) + add;
					paths.Add(upLevelPoint);
					powerOf2 -= 1;
					labelPath = upLevelPoint;
				}
				paths.Reverse();
				return paths;
			}




		}

	}
}
