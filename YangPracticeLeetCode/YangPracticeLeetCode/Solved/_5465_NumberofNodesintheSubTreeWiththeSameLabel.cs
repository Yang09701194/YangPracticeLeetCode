using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5465_NumberofNodesintheSubTreeWiththeSameLabel
	{

		public static void Test()
		{
			Solution s = new Solution();

			////[[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]]
			//var res = s.CountSubTrees(7,
			//	new int[][]
			//	{
			//		new[] {0, 1},
			//		new[] {0, 2},
			//		new[] {1, 4},
			//		new[] {1, 5},
			//		new[] {2, 3},
			//		new[] {2, 6},
			//	},
			//	"abaedcd"
			//);
			//res.PrintList();

			////Input: n = 4, edges = [[0,1],[1,2],[0,3]], labels = "bbbb"
			//res = s.CountSubTrees(4,
			//	new int[][]
			//	{
			//		new[] {0, 1},
			//		new[] {1, 2},
			//		new[] {0, 3},
			//	},
			//	"bbbb"
			//);
			//res.PrintList();

			////Input: n = 5, edges = [[0,1],[0,2],[1,3],[0,4]], labels = "aabab"
			//res = s.CountSubTrees(5,
			//	new int[][]
			//	{
			//		new[] {0, 1},
			//		new[] {0, 2},
			//		new[] {1, 3},
			//		new[] {0, 4},
			//	},
			//	"aabab"
			//);
			//res.PrintList();

			////Input: n = 6, edges = [[0, 1],[0,2],[1,3],[3,4],[4,5]], labels = "cbabaa"
			//res = s.CountSubTrees(6,
			//	new int[][]
			//	{
			//		new[] {0, 1},
			//		new[] {0, 2},
			//		new[] {1, 3},
			//		new[] {3, 4},
			//		new[] {4, 5},
			//	},
			//	"cbabaa"
			//);
			//res.PrintList();

			////Input: n = 7, edges = [[0,1],[1,2],[2,3],[3,4],[4,5],[5,6]], labels = "aaabaaa"
			//res = s.CountSubTrees(7,
			//	new int[][]
			//	{
			//		new[] {0, 1},
			//		new[] {1, 2},
			//		new[] {2, 3},
			//		new[] {3, 4},
			//		new[] {4, 5},
			//		new[] {5, 6},
			//	},
			//	"aaabaaa"
			//);
			//res.PrintList();

			////4 [[0,2],[0,3],[1,2]] "aeed"
			//res = s.CountSubTrees(4,
			//	new int[][]
			//	{
			//		new[] {0, 2},
			//		new[] {0, 3},
			//		new[] {1, 2},
			//	},
			//	"aeed"
			//);
			//res.PrintList();

			string f =
				@"E:\GS2018\E\Yang\Program\Git\GitYang\YangPracticeLeetCode\YangPracticeLeetCode\YangPracticeLeetCode\TestData\_5465_1.txt";
			string[] fs = File.ReadAllText(f).Split(new[] {"\r\n"}, StringSplitOptions.None);

			List<int[]> iss = new List<int[]>();
			string[] ls = fs[1].Substring(1, fs[1].Length - 2).Replace("[", "").Replace("]", "").Split(',');
				
			for (int i = 0; i < ls.Length - 1; )
			{
				iss.Add(new int[] { Convert.ToInt32(ls[i]) , Convert.ToInt32(ls[i+1]) });
				i += 2;
			}

			DateTime dt = DateTime.Now;
			var res = s.CountSubTrees(Convert.ToInt32(fs[0]),
				iss.ToArray(),
				fs[2].Replace("\"","")
			);
			//res.PrintList();



			Console.WriteLine(DateTime.Now.Subtract(dt).TotalMilliseconds);

		}



		public class Solution
		{
			public int[] CountSubTrees(int n, int[][] edges, string labels)
			{
				List<List<int>> adj = new List<List<int>>(n);

				for (int i = 0; i < n; i++)
					adj.Add(new List<int>());

				for (int i = 0; i < edges.Length; i++)
				{
					adj[edges[i][0]].Add(edges[i][1]);
					adj[edges[i][1]].Add(edges[i][0]);
				}

				int[] ans = new int[n];
				int[] visited = new int[n];
				Dfs(adj, 0, labels, visited, ans);
				return ans;
			}

			private int dc = 0;
			private int[] Dfs(List<List<int>> adj, int root, string labels, int[] visited, int[] ans)
			{
				//Console.WriteLine(dc++);
				if (visited[root] == 1)
					return new int[26];

				int[] charCount = new int[26];
				charCount[labels[root] - 'a']++;
				visited[root] = 1;

				for (int i = 0; i < adj[root].Count; i++)
				{
					int[] chCnt = Dfs(adj, adj[root][i], labels, visited, ans);

					for (int j = 0; j < 26; j++)
						charCount[j] += chCnt[j];
				}

				ans[root] = charCount[labels[root] - 'a'];

				return charCount;
			}

		}

		//public class Solution
		//{
		//	public int[] CountSubTrees(int n, int[][] edges, string labels)
		//	{

		//		//bool isOneLineParentChild = true;
		//		//for (int i = 0; i < edges.Length - 1; i++)
		//		//{
		//		//	if (edges[i][0] == edges[i][1] - 1 && edges[i + 1][0] == edges[i][1])
		//		//		continue;
		//		//	else
		//		//		isOneLineParentChild = false;
		//		//}
		//		//if (isOneLineParentChild)
		//		//{
		//		//	Dictionary<char, int> charCou = new Dictionary<char, int>();
		//		//	int[] answer = new int[n];

		//		//	for (int i = labels.Length - 1; i >=0 ; i--)
		//		//	{
		//		//		if (charCou.ContainsKey(labels[i]))
		//		//		{
		//		//			charCou[labels[i]]++;
		//		//		}
		//		//		else
		//		//			charCou.Add(labels[i], 1);

		//		//		answer[i] = charCou[labels[i]];
		//		//	}

		//		//	return answer;
		//		//}


		//		Node root = new Node(labels[0]);
		//		Dictionary<int, Node> pointNodeDic = new Dictionary<int, Node>();
		//		pointNodeDic.Add(0, root);

		//		foreach (int[] edge in edges)
		//		{
		//			int parentNum = -1, childNum = -1;
		//			if (pointNodeDic.ContainsKey(edge[0]))
		//			{
		//				parentNum = edge[0];
		//				childNum = edge[1];
		//			}
		//			else
		//			{
		//				parentNum = edge[1];
		//				childNum = edge[0];
		//			}

		//			Node child = null, parent = null;
		//			parent = pointNodeDic[parentNum];
		//			child = new Node(labels[childNum]);
		//			child.Parent = parent;
		//			pointNodeDic.Add(childNum, child);
		//			parent.Childs.Add(child);
		//		}

		//		//	ok , but Exceed Time Limit
		//		//List<int> nodeTotalSameLs = new List<int>();
		//		//for (int i = 0; i < labels.Length; i++)
		//		//{
		//		//	int totalSame = 1;
		//		//	CountSubTreeSameLabel(pointNodeDic[i], pointNodeDic[i], ref totalSame);
		//		//	nodeTotalSameLs.Add(totalSame);
		//		//}

		//		//return nodeTotalSameLs.ToArray();


		//		//每個點往父層一路相同值的加上去  一次建完表
		//		List<int> nodeTotalSameLs = new List<int>();
		//		for (int i = 0; i < labels.Length; i++)
		//		{
		//			var node = pointNodeDic[i];
		//			Node currNode = node;
		//			while (currNode.Parent != null)
		//			{
		//				if (currNode.Parent.Label == node.Label)
		//					currNode.Parent.SameCou++;
		//				currNode = currNode.Parent;
		//			}
		//			//AddSameCouToParent(node, node);
		//		}

		//		for (int i = 0; i < labels.Length; i++)
		//		{
		//			nodeTotalSameLs.Add(pointNodeDic[i].SameCou);
		//		}

		//		return nodeTotalSameLs.ToArray();



		//	}

		//	//private void CountSubTreeSameLabel(Node findRoot, Node currNode, ref int totalSame)
		//	//{
		//	//	foreach (Node child in currNode.Childs)
		//	//	{
		//	//		if (child.Label == findRoot.Label)
		//	//			totalSame += 1;
		//	//		CountSubTreeSameLabel(findRoot, child, ref totalSame);
		//	//	}
		//	//}


		//	//
		//	private void AddSameCouToParent(Node usedChild, Node currNode)
		//	{
		//		if (currNode.Parent == null)
		//			return;

		//		if (usedChild.Label == currNode?.Parent?.Label)
		//			currNode.Parent.SameCou++;
		//		AddSameCouToParent(usedChild, currNode.Parent);
		//	}


		//	public class Node
		//	{
		//		public Node(char lbl)
		//		{
		//			Label = lbl;
		//		}

		//		public char Label;
		//		public int SameCou = 1;	

		//		public Node Parent = null;

		//		public List<Node> Childs = new List<Node>();


		//	}

		//}




	}
}
