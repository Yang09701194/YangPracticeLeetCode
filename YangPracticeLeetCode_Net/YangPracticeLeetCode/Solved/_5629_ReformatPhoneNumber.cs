using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5629_ReformatPhoneNumber
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.ReformatNumber("1-23-45 6"));
			Console.WriteLine(s.ReformatNumber("123 4-567"));
			Console.WriteLine(s.ReformatNumber("123 4-5678"));
			Console.WriteLine(s.ReformatNumber("12"));
			Console.WriteLine(s.ReformatNumber("--17-5 229 35-39475 "));


		}

		public class Solution
		{
			public string ReformatNumber(string number)
			{

				string res = "";
				number = number.Replace("-", "").Replace(" ", "");
				int n = number.Length;


				int m = n % 3;

				int len = 0;

				string s3 = "";
				Action<string> get3 = (num) =>
				{
					for (int i = 0; i < num.Length; i++)
					{
						s3 += num[i];
						len++;
						if (len == 3)
						{
							s3 += "-";
							len = 0;
						}
					}
				};

				if (m == 0)
				{
					get3(number);
					

					return s3.Trim('-');
				}

				if (m == 1)
				{
					res = number.Substring(n - 2, 2);
					number = number.Substring(0, n - 2);
					if (number.Length >= 2)
					{
						res = number.Substring(number.Length-2, 2) + "-" + res ;
						number = number.Substring(0, number.Length - 2);
					}

					if (number.Length >= 3)
					{
						get3(number);
					}

					return s3 + res;
				}

				if (m == 2)
				{
					res = number.Substring(n - 2, 2);
					number = number.Substring(0, n - 2);
					if (number.Length >= 3)
					{
						get3(number);
					}

					return s3 + res;
				}

				return "n/a";
			}
		}



	}
}
