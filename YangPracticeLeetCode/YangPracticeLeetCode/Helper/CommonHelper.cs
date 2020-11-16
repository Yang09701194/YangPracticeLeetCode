using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace YangPracticeLeetCode.Solved
{
    public static class CommonHelper
    {


	    public static void FormatProblemName()
	    {
			string t = Clipboard.GetText();
			//1604. Alert Using Same Key-Card Three or More Times in a One Hour Period

			string title = $"_{t.Replace(".", "_").Replace(" ", "").Replace("-", "")}";

			string filePath =
				@"E:\GS2018\E\Yang\Program\Git\GitYang\YangPracticeLeetCode\YangPracticeLeetCode\YangPracticeLeetCode\YangPracticeLeetCode.csproj";

			XElement X = XElement.Load(filePath);

			XmlNamespaceManager Nspace = new XmlNamespaceManager(new XmlDocument().NameTable);
			string xpath = "ItemGroup[2]";
			string n = "";

			X.AddNameSpacePreAndValue(ref Nspace, ref n);

			string filename = title;
			XNamespace nameSpace = "http://schemas.microsoft.com/developer/msbuild/2003";
			var ele2 = new XElement(nameSpace + "Compile", new XAttribute("Include", $"Solved\\{filename}.cs")); // strange but true

			//var ele = XElement.Parse($"<Compile Include=\"Solved\\{title}.cs\" />");
			IEnumerable<XElement> search = X.XmlSerachElementXI("default:ItemGroup[2]", Nspace);
			search.First().Add(ele2);

			X.Save(filePath);


			string cs =
				$@"E:\GS2018\E\Yang\Program\Git\GitYang\YangPracticeLeetCode\YangPracticeLeetCode\YangPracticeLeetCode\Solved\{filename}.cs";
			string cstemplate =
				$@"E:\GS2018\E\Yang\Program\Git\GitYang\YangPracticeLeetCode\YangPracticeLeetCode\YangPracticeLeetCode\Solved\template.txt";

			string csTempl = File.ReadAllText(cstemplate);
			csTempl = csTempl.Replace("CsName", filename);
			File.WriteAllText(cs, csTempl);

	    }

		public static IEnumerable<XElement> XmlSerachElementXI(this XElement X, string SearchEleXPath, XmlNamespaceManager N)
	    {//XI >>> Xml的IEnumerable的簡寫
		    IEnumerable XI = (IEnumerable)X.XPathEvaluate(SearchEleXPath, N);
		    IEnumerable<XElement> XAList = XI.Cast<XElement>();
		    if (XAList.LongCount() > 0)
			    return XAList;
		    else return null;//等於0
	    }

	    public static void AddNameSpacePreAndValue(this XElement X, ref XmlNamespaceManager N, ref string XPathIn)
	    {
		    //先判斷有沒有ns，有的話NS manager加入NS
		    IEnumerable<XAttribute> A2 = X.Attributes();
		    if (A2.Count() > 0)
		    {
			    foreach (XAttribute xe in A2)
			    {
				    string NamespacePre = "";
				    string NamespaceValue = xe.Value;

				    bool FlagIsDefaultNameSpaceExist = false;

				    //這裡單純在NS Manager加NS
				    if (xe.ToString().Contains("xmlns"))
				    {
					    int i = xe.Name.ToString().IndexOf('}');
					    if (i > 0)
					    {
						    NamespacePre = xe.Name.ToString().Substring(i + 1);
						    N.AddNamespace(NamespacePre, NamespaceValue);
					    }
					    else if (xe.Name.ToString() == "xmlns")//有defalutNS的話
					    {
						    NamespacePre = xe.Name.ToString();
						    N.AddNamespace("default", NamespaceValue);
						    XPathIn = XPathIn.XPathAddDeafultNameSpaceProccess();//對XPATH做default前綴處理
					    }
				    }
			    }
		    }

		    //沒NS就什麼都不做
	    }


	    /// <summary>
	    /// 處理XMLNamespace上的問題
	    /// </summary>
	    public static string XPathAddDeafultNameSpaceProccess(this string XPathProcess)
	    {
		    string[] XPSplit = XPathProcess.Split('/');//先拆開

		    for (int i = 0; i < XPSplit.Length; i++)//在沒namespace的元素前面加上default
		    {
			    if (
				    (!XPSplit[i].Contains('@') && !XPSplit[i].Contains(':')) ||
				    (XPSplit[i].Contains('@') && XPSplit[i].Contains('[') &&
				     !XPSplit[i].Contains(':') && XPSplit[i].IndexOf('@') > XPSplit[i].IndexOf('['))
				    ||
				    (XPSplit[i].Contains('@') && XPSplit[i].Contains('[') &&
				     XPSplit[i].Contains(':') && XPSplit[i].IndexOf('@') > XPSplit[i].IndexOf('[')
				     && XPSplit[i].IndexOf(':') > XPSplit[i].IndexOf('[')))

				    XPSplit[i] = "default:" + XPSplit[i];
		    }
		    for (int i = 0; i < XPSplit.Length; i++)
		    {
			    if (i != XPSplit.Length - 1)//不是最後一個字串的話，後面都再加上斜線
				    XPSplit[i] += "/";
		    }

		    string output = "";
		    foreach (string s in XPSplit)//處理後再合成
			    output += s;
		    return output;
	    }






		public static void PrintList<T>(this IList<T> ls)  
        {
            if (ls.Count == 0)
            {
                Console.WriteLine("list no item");
                return;
            }
            Console.WriteLine(
                ls.Select(i=>i.ToString()).Aggregate(
                    (pre, next) => pre + "," + next)
                    );
        }


	    public static List<List<T>> ChunkBy<T>(this IList<T> source, int chunkSize)
	    {
		    return source
			    .Select((x, i) => new { Index = i, Value = x })
			    .GroupBy(x => x.Index / chunkSize)
			    .Select(x => x.Select(v => v.Value).ToList())
			    .ToList();
	    }



	}

	

}
