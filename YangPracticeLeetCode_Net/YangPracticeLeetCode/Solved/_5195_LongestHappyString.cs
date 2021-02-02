using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5195_LongestHappyString
	{
		public static void Test()
		{

			Solution s = new Solution();
			Console.WriteLine(s.LongestDiverseString(1, 1, 7) + "  \r\nccaccbcc");
			Console.WriteLine(s.LongestDiverseString(2, 2, 1) + "  \r\naabbc");
			Console.WriteLine(s.LongestDiverseString(7, 1, 0) + "  \r\naabaa");
			Console.WriteLine(s.LongestDiverseString(2, 2, 1) + "  \r\n");
			Console.WriteLine(s.LongestDiverseString(0,8,11) + "  \r\n");
			Console.WriteLine(s.LongestDiverseString(4,42,7) + "  \r\nbbcbbcbbcbbabbcbbabbcbbabbcbbabbcbb");


		}

		public class Solution
		{
			public string LongestDiverseString(int a, int b, int c)
			{
				//	Description say  "at most" so no limit
				//var ints = new List<int>() {a, b, c}.OrderByDescending(i => i).ToList();
				//if (ints[0] >
				//    (2 * (ints[1] + ints[2] + 1)) + 1)
				//	return "";

				Info f = new Info(a,b,c);

				string result = "";
				string last = "f";
				while (f.NotAll0())
				{
					if (last == "")
						break;
					last = f.GetAndDecrease(last);
					result += last;
				}

				return result;
			}


			public class Info
			{
				Dictionary<string, int> ints = new Dictionary<string, int>();
				public Info(int a, int b, int c)
				{
					ints.Add("a", a);
					ints.Add("b", b);
					ints.Add("c", c);
				}


				public string GetAndDecrease(string last)
				{
					
					string las = last.First().ToString();

					var currChoose = ints.Where(i => i.Key != las);
					var orderInts = currChoose.OrderByDescending(i => i.Value).ToList();

					//return 1 char  ,  got case error then add  ,  if interest can comment the code and send answer see error
					var lastChoose = ints.Where(i => i.Key == las);
					int lasChNum = !lastChoose.Any() ? -10 : lastChoose.First().Value;
					if (
						(  orderInts[0].Value == lasChNum - 1 && orderInts[0].Value > 0 )// condition 1
					    ||
						lasChNum >  orderInts[0].Value + orderInts[1].Value // condition 2
						)
					{
						int nu = orderInts[0].Value - 1;
						if (nu < 0)
							return "";
						ints[orderInts[0].Key] = nu;
						return orderInts[0].Key;
					}
					//return 1 char    got case error then add

					//return 2 char  
					var curr = orderInts.First();
					int num = curr.Value;
					string retur = "";
					num--;
					if (num < 0)
						return "";
					ints[curr.Key] = num;
					if (num >= 0)
						retur += curr.Key;
					else
						return retur;
					num--;
					if (num < 0)
						return retur;
					ints[curr.Key] = num;
					if (num >= 0)
						retur += curr.Key;
					return retur;
				}

				public bool NotAll0()
				{
					return ints.Any(i => i.Value != 0);
				}
			}
		}


	}
}
