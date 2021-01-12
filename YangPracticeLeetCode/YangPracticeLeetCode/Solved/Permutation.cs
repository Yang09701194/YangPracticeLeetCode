using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class Permutation
	{
		private static void Swap(ref char a, ref char b)
		{
			if (a == b) return;

			var temp = a;
			a = b;
			b = temp;
		}

		public static void GetPer(char[] list)
		{
			int x = list.Length - 1;
			GetPer(list, 0, x);
		}

		private static void GetPer(char[] list, int k, int m)
		{

			if (k == m)
			{
				Console.WriteLine("ok " + new string(list));
			}
			else
			{
				Console.WriteLine(new string(list));
				for (int i = k; i <= m; i++)
				{
					Swap(ref list[k], ref list[i]);
					GetPer(list, k + 1, m);
					Swap(ref list[k], ref list[i]);
				}
			}
				
		}

		public static void Run()
		{
			string str = "123";
			//關鍵的交換 k, i,  傳入 k+1 當成下個遞迴的 k 的數字
			// k i k+1
			// 0 0 1     123                                   00換 為基底去跑 
			// 1 1 2     123
			//     2  ok 123  退出遞迴  回到上個迴圈 i=1++
			// 1 2 2  ok 132  退出遞迴  回到上個迴圈 i=0++
			// 0 1 1     213                                   01換 為基底去跑
			// 1 1 2  ok 213  退出遞迴  回到上個迴圈 i=1++
			// 1 2 2  ok 231  退出遞迴  回到上個迴圈 i=0++  
			// 0 2 1     321                                   02換 為基底去跑
			// 1 1 2  ok 321 同上
			// 1 2 2  ok 312

			//簡化版本  換的樣態
			//00
			//  > 11  和 12
			//01
			//  > 11  和 12
			//02
			//  > 11  和 12
			//所以六種

			char[] arr = str.ToCharArray();
			GetPer(arr);
		}


	}
}
