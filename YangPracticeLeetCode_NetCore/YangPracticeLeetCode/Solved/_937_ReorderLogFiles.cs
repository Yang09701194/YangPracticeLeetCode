using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
    public class _937_ReorderLogFiles
    {

		/// <summary>
		/// 
		/// </summary>
        public static void Test()
        {
            Solution s = new Solution();

            string[] logs1 = new[] {"a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo"};
            var results = s.ReorderLogFiles(logs1);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

        }



		/// <summary>
		///Runtime: 256 ms, faster than 85.94% of C# online submissions for Reorder Data in Log Files.
		///Memory Usage: 34.9 MB, less than 62.38% of C# online submissions for Reorder Data in Log Files.
		///
		/// 這題關鍵在於  其實用簡單的SubString 就能處理  簡單卻快
		/// 還有兩層排序  一開始用一班排序演算法去想  就想不下去怎麼排兩層  一般都只想一層的
		/// 後來回到一般在寫  其實就發現就是常用的 ThenBy
		///
		/// 一開始看到空格隔開  就會直接想split 成List處理
		/// 但是拆開再合起來  就會慢  反而能substring  就完全不用拆組 快
		///
		/// 還有數字判斷   題目沒看透  就會想怎麼比整個字串任意長度要都數字
		/// 其實題意只要比第一個字元  這樣就可以用 char 比較  就簡單又快
		///
		/// 上面的技巧都看 java top answer來的
		/// 印象最深刻 原本也是想用C# comparer 但是看到comparer  code龐大  又是類  就會覺得好像很笨重
		/// 但是 java 99% 竟然就是用 comparer
		/// 而且重點是  竟然只要2ms  ...
		/// C# comparer 沒有比Order快
		/// </summary>
		public class Solution
		{
			public string[] ReorderLogFiles(string[] logs)
			{

				List<string> numLogs = new List<string>();
				List<string> strLogs = new List<string>();


				foreach (string log in logs)
				{
					int index = log.IndexOf(' ');
					char c = log[index + 1];
					if (c >= '0' && c <= '9')
					{
						numLogs.Add(log);
					}
					else
					{
						strLogs.Add(log);
					}
				}

				strLogs = strLogs.OrderBy(l => Remove1stToStr(l)).ThenBy(l => l[0]).ToList();

				strLogs.AddRange(numLogs);
				return strLogs.ToArray();
			}
			public static string Remove1stToStr(string str)
			{
				int i = str.IndexOf(" ");
				return str.Substring(i + 1);
			}
		}




		/// <summary>
		/// 
		/// </summary>
		public class Solution_V2
		{
			public string[] ReorderLogFiles(string[] logs)
			{
				var log_ = logs.OrderBy(l => l, new MyComparer()).ToList();
				return log_.ToArray();
			}
			
		}


		public class MyComparer : IComparer<string>
		{
				
			public int Compare(string a, string b)
			{

				int ia = a.IndexOf(" ");
				int ib = b.IndexOf(" ");

				char cA = a[ia + 1];
				char cB = b[ib + 1];
				bool isANum = cA >= '0' && cA <= '9';
				bool isBNum = cB >= '0' && cB <= '9';
				if (isANum || isBNum)
				{
					if(isANum && isBNum)
						return 0;
					return isBNum ? 1 : -1;
				}


				int i = String.Compare(a.Substring(ia+1), b.Substring(ib+1));
				if (i == 0)
					i = String.Compare(a[0].ToString(), b[0].ToString());

				return i;
			}
		}





		/// <summary>
		/// Runtime: 292 ms, faster than 7.43% of C# online submissions for Reorder Data in Log Files.
		/// Memory Usage: 36 MB, less than 6.02% of C# online submissions for Reorder Data in Log Files.
		/// </summary>
		public class Solution_V1
		{
			public string[] ReorderLogFiles(string[] logs)
			{
				List<string> Logs = logs.ToList();
				List<List<string>> Logss = Logs.Select(s => s.Split(' ').ToList()).ToList();

				Regex numberReg = new Regex("^[0-9]+");

				List<List<string>> numLogss = new List<List<string>>();
				List<List<string>> strLogss = new List<List<string>>();

				foreach (var _Logs in Logss)
				{

					if (numberReg.IsMatch(_Logs[1]))
						numLogss.Add(_Logs);
					else
						strLogss.Add(_Logs);
				}

				strLogss.Reverse();//這句很奇怪   有一個 case 明明除了第一個字之外後面的字都一樣  但是順序不是依照原本的順序
				strLogss = strLogss.OrderBy(llogs => Remove1stToStr(llogs)).ToList();

				List<string> result = new List<string>();

				foreach (List<string> lllogs in strLogss)
					result.Add(lllogs.Aggregate(((pre, next) => pre + " " + next)));
				foreach (List<string> lllogs in numLogss)
					result.Add(lllogs.Aggregate(((pre, next) => pre + " " + next)));

				return result.ToArray();
			}
			public static string Remove1stToStr(List<string> strs)
			{
				List<string> temp = new List<string>();
				for (int i = 1; i < strs.Count; i++)
				{
					temp.Add(strs[i]);
				}
				return temp.Aggregate(((pre, next) => pre + " " + next));
			}



		}



	}
}
