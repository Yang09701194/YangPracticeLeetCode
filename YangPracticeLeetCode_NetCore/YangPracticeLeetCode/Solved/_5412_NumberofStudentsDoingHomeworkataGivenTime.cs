using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5412_NumberofStudentsDoingHomeworkataGivenTime
	{
		public static void Test()
		{
			Solution s = new Solution();

			//直接過關不用測
			//Console.WriteLine(
			//	s.BusyStudent()
			//);

		}

		public class Solution
		{


			
			public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
			{
				int cou = 0;
				for (int i = 0; i < startTime.Length; i++)
				{
					if (queryTime >= startTime[i] && queryTime <= endTime[i])
						++cou;
				}

				return cou;



			}
		}

	}
}
