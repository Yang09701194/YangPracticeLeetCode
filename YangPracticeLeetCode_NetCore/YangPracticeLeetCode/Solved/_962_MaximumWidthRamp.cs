using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Solved;

namespace YangPracticeLeetCode.Solved
{
	class _962_MaximumWidthRamp
	{

		public static void Test()
		{
			Solution s = new Solution();

			int[] a4 = new int[] { 6, 0, 8, 2, 1, 5 };
			int[] a5 = new int[] { 9, 8, 1, 0, 1, 9, 4, 0, 4, 1 };


			int[] a6 = File.ReadAllText(".\\TestData\\_962_01.txt").Trim('[').Trim(']').Split(',').ToList().Select(s2=>Convert.ToInt32(s2)).ToArray();
			int[] a7 = File.ReadAllText(".\\TestData\\_962_02.txt").Trim('[').Trim(']').Split(',').ToList().Select(s2=>Convert.ToInt32(s2)).ToArray();


			//int[] a6 = new int[] { 5, 1, 5, 2, 5, 3, 5, 4 };

			a4.PrintList();
			Console.WriteLine(s.MaxWidthRamp(a4) + " is 4");

			a5.PrintList();
			Console.WriteLine(s.MaxWidthRamp(a5) + " is 7");

			//a6.PrintList();
			DateTime start = DateTime.Now;
			Console.WriteLine(s.MaxWidthRamp(a6));
			double during = DateTime.Now.Subtract(start).TotalMilliseconds;
			Console.WriteLine(during);

			//a6.PrintList();
			start = DateTime.Now;
			Console.WriteLine(s.MaxWidthRamp(a7));
			during = DateTime.Now.Subtract(start).TotalMilliseconds;
			Console.WriteLine(during);



		}



		public class Solution
		{
			public int MaxWidthRamp(int[] A)
			{
				if (A.Length == 0)
					return 0;
				//all equal
				//for (int i = 0; i < A.Length; i++)
				//{
				//	if (A[i] == A[0] && i < A.Length-1)
				//		continue;
				//	else if (A[i] == A[0] && i == A.Length - 1)
				//		return A.Length - 1;
				//	else 
				//		break;
				//}

				int maxWidth = 0;

				//for (int i = 0; i < A.Length-1; i++)
				//{
				//	if (A[i] < A[i + 1])
				//	{
				//		Console.WriteLine(A[i] +" "+ A[i+1]);
				//		break;
				//	}
				//}



				//這一段很誇張   
				//在int[] a6 = File.ReadAllText(".\\TestData\\_962_01.txt").Trim('[').Trim(']').Split(',').ToList().Select(s2=>Convert.ToInt32(s2)).ToArray();
				//有加這段  跟沒加這段  可以從 2600ms 縮短到 12ms    12ms耶...
				//這邊很簡單的算法
				//i < j兩個迴圈的 印象中應該是類似   1 + 2 + 3... + n = n(n+1)/2 ~ n^2
				//但是  Sort最快狀態  就是arr本身就是sort過的  時間應該是 n  也就是 直接一直比 i > i+1 
				//然後我用迴圈 == 去累計  跑一次就算完 就是 n  
				//所以加起來就是 2n   
				//下面的程式碼看似很多行  但是實際就是2n
				if (A.Length > 1)
				{
					//descending  <= 
					int[] A2 = new int[A.Length];
					A.CopyTo(A2, 0);
					//https://stackoverflow.com/questions/5430016/better-way-to-sort-array-in-descending-order
					Array.Sort<int>(A2,
						new Comparison<int>(
							(i1, i2) => -i1.CompareTo(i2)
						));
					//https://stackoverflow.com/questions/4423318/how-to-compare-arrays-in-c
					if (Enumerable.SequenceEqual(A, A2))
					{
						int maxNum = 0;
						int current = A[0];
						int currentCou = 0;
						int maxCou = 0;
						for (int i = 1; i < A.Length; i++)
						{
							if (current == A[i])
							{
								currentCou++;
								if (currentCou > maxCou)
								{
									maxCou = currentCou;
									maxNum = A[i];
								}
							}
							else
							{
								current = A[i];
								currentCou = 0;
							}
						}

						Console.WriteLine(maxNum);
						return maxCou;
					}
				}

				// normal
				for (int i = 0; i < A.Length-1; i++)
				{
					if (i>1 && A[i] == A[i - 1]) //後一個等於前一個的時後 後一個的長度一定小於前一個 直接忽略  
						continue;

					//if (i > A.Length / 2 && maxWidth > A.Length / 2)
					//	return maxWidth;

					for (int j = i+1; j < A.Length; j++)
					{
						if (A[i] > A[j]/*這句加快3倍*/ || (j < A.Length - 1 && A[j] == A[j + 1]/*也是關鍵  在一堆重複值的時後*/ ))
							continue;
						if (A[i] <= A[j] && j - i > maxWidth)
							maxWidth = j - i;
						if (maxWidth > A.Length - i)
							return maxWidth;
					}
				}
				return maxWidth;
			}
		}
	}
}
