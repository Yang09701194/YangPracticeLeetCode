using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _985_SumOfEvenNumbersAfterQueries
	{
		public static void Test()
		{
			Solution s = new Solution();

			int[][] queries = new int[4][];
			for (int i = 0; i < queries.Length; i++)
				queries[i] = new int[2];

			int[] queriesInts = new[] {1, 0, -3, 1, -4, 0, 2, 3};
			int couRow = 0;
			int couCol = 0;
			for (int j = 0; j < queriesInts.Length; j++)
			{
				queries[couRow][couCol % 2] = queriesInts[j];
				couCol++;
				if (j % 2 != 0)
					couRow++;
			}

			int[] A = new []{1,2,3,4};
			s.SumEvenAfterQueries(A, queries).PrintList();

		}


		public class Solution
		{
			public int[] SumEvenAfterQueries(int[] A, int[][] queries)
			{
				int[] results = new int[A.Length];
				for (int i = 0; i < queries.Length; i++)
				{
					A[queries[i][1]] += queries[i][0];

					//這樣子寫  可以pass 56/58個test case 但57是一個超長的陣列  會time exceed
					//我再仔細看一次整個程式邏輯  發現其實沒什麼地方可以優化
					//因為陣列取值  已經是 o(1)
					//而且操作都是用最基礎的方式  
					// +=  =  迴圈
					//最後看來看去  只有這個Linq 有可能可以再採用最原始的方式
					//這邊就是跟157建議學到的概念有關
					//157  會帶你去思考linq的原始實作方式  其實也是用迴圈
					//也會帶你想很多效能的問題
					//從這題看來  就就能看出那本書的價值
					results[i] = A.Where(a => a % 2 == 0).Sum();

					//改成自己寫的原始方法  就pass了
					//所以  就是逼你去想效能的問題
					//硬要想  就要開始去計時每種語法  有必要時再來試試
					results[i] = EvenSum(A);
				}
				return results;
			}

			public int EvenSum(int[] A)
			{
				int result = 0;
				for (int i = 0; i < A.Length; i++)
				{
					if(A[i] % 2 ==0)
					result += A[i];
				}
				return result;
			}
		}



	}
}
