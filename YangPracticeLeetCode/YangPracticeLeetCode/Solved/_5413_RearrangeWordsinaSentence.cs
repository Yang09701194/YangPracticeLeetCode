using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5413_RearrangeWordsinaSentence
	{

		public static void Test()
		{
			Solution s = new Solution();

			
			Console.WriteLine(
				s.ArrangeWords("Keep calm and code on")
			);
			
		}


		public class Solution
		{
			public string ArrangeWords(string text)
			{
				if (string.IsNullOrWhiteSpace(text))
					return "";

				string[] words = text.ToLower().Split(' ');
				Dictionary<int, List<string>> lenthWords = new Dictionary<int, List<string>>();
				foreach (string word in words)
				{
					int length = word.Length;
					if (!lenthWords.ContainsKey(length))
						lenthWords.Add(length, new List<string>() {word});
					else 
						lenthWords[length].Add(word);
				}

				var orderLenWords = lenthWords.OrderBy(d => d.Key);
				string output = "";
				foreach (KeyValuePair<int, List<string>> kv in orderLenWords)
				{
					output += String.Join(" ", kv.Value) + " ";
				}

				char first = output.First();
				output = output.Substring(1);
				output = first.ToString().ToUpper() + output;
				return output.Trim();
			}
		}
	}
}
