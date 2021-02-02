using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5377_NumberofStepstoReduceaNumberinBinaryRepresentationtoOne
	{

		public static void Test()
		{

			Solution s = new Solution();
			string p = "1101";
			Console.WriteLine(s.NumSteps(p));
			p = "10";
			Console.WriteLine(s.NumSteps(p));


		}

		public class Solution
		{
			public int NumSteps(string s)
			{
				var binArr = s.ToCharArray();
				
				int steps = 0;
				while (new string(binArr) != "1")
				{
					steps++;
					string currStr = new string(binArr);
					if (currStr.EndsWith("0"))
					{
						currStr = currStr.Substring(0, currStr.Length - 1);
						binArr = currStr.ToCharArray();
					}
					else
					{
						binArr[binArr.Length - 1] = '0';
						bool isAllAdd = true;
						for (int i = binArr.Length - 2; i >= 0; i--)
						{
							if (binArr[i] == '1')
							{
								binArr[i] = '0';
							}
							else if (binArr[i] == '0')
							{
								binArr[i] = '1';
								isAllAdd = false;
								break;
							}
						}

						string result = new string(binArr);
						if (isAllAdd)
							result = "1" + result;
						binArr = result.ToCharArray();
					}
				}

				return steps;
			}
		}



	}
}
