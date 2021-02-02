using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5400_DestinationCity
	{
		public static void Test()
		{
			Solution s = new Solution();

			

		}

		public class Solution
		{
			public string DestCity(IList<IList<string>> paths)
			{
				List<string> allTocites = paths.Select(p => p[1]).ToList();
				Dictionary<string, string> allTFromcites = paths.Select(p => p[0]).ToDictionary(p => p);

				allTocites = allTocites.Where(to => !allTFromcites.ContainsKey(to)).ToList();

				return allTocites.First();

				//Dictionary<string, int> cityCou = new Dictionary<string, int>();
				//foreach (string tocity in allTocites)
				//{
				//	if (cityCou.ContainsKey(tocity))
				//		cityCou[tocity]++;
				//	else
				//	{
				//		cityCou.Add(tocity, 1);
				//	}

				//}

				//return cityCou.Where(c => c.Value == 1).First().Key;
			}
		}


	}
}
