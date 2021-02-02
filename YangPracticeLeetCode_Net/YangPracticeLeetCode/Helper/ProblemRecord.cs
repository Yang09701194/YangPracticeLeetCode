using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Helper
{
	class ProblemRecord
	{
		public static void List()
		{
			string filePath = @"E:\WITS2018\Wits_h\LC\List.txt";

			int index = 0;

			List<string> ls = File.ReadAllText(filePath).Split(new []{"\r\n"}, StringSplitOptions.None).ToList();

			string name = "";
			foreach (string s in ls)
			{
				name += s;
				index++;
				if (index % 2 == 0)
				{
					int iS = s.IndexOf("  ");
					name = name.Substring(0, iS).Replace("\t","");
					File.WriteAllText($@"E:\WITS2018\Wits_h\LC\{name}.txt", "");
					name = "";
				}
			}

			
		}

	}
}
