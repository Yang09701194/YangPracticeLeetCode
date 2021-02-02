using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Solved;

namespace YangPracticeLeetCode.Algorithm
{

	class Sort_SelectionSort
	{

		public static void Test()
		{
			int[] a5 = new int[] { 12, 72, 43, 43, 65, 26, 17, 48 };
			a5.PrintList();
			SelectionSort(a5).PrintList();
		}
		
		public static int[] SelectionSort(int[] A)
		{
			for (int i = 0; i < A.Length; i++)
			{
				int smallSub = i;
				//找出最小的 
				for (int j = i+1; j < A.Length; j++)
				{
					if (A[j] < A[smallSub])
						smallSub = j;   
				}
				//交換到最前面
				var temp = A[i];
				A[i] = A[smallSub];
				A[smallSub] = temp;
			}
			return A;
		}




	}
}
