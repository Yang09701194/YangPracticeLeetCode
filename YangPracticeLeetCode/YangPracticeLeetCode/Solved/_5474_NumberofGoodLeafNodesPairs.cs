using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5474_NumberofGoodLeafNodesPairs
	{


		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());


		}







		//Definition for a binary tree node.
		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
			{
				this.val = val;
				this.left = left;
				this.right = right;
			}
		}




		public class Solution
		{


			public List<int> isLeafsIndexes = new List<int>();
			public List<int> isLeafsDistances = new List<int>();

			public class Edge
			{
				public Edge(int start, int end)
				{
					this.start = start;
					this.end = end;
				}

				public int start;
				public int end;
			}

			public int CountPairs(TreeNode root, int distance)
			{

				//	建立邊的連接資訊
				List<Edge> edges = new List<Edge>();
				List<int> nodes = new List<int>();
				root.val = 1;
				AddEdgeInfo(root, edges, nodes);

				//  adjacency matrix
				int[,] adjMtx = new int[nodes.Count, nodes.Count];
				foreach (Edge edge in edges)
				{
					adjMtx[edge.start - 1, edge.end - 1] = 1;
					adjMtx[edge.end - 1, edge.start - 1] = 1;
				}



				for (int i = 0; i < isLeafsIndexes.Count; i++)
				{
					DijkstraAlgo(adjMtx, isLeafsIndexes[i], nodes.Count);
				}
				return isLeafsDistances.Where(d => d <= distance).Count() / 2;
			}

			int n = 1;
			private void AddEdgeInfo(TreeNode node, List<Edge> edges, List<int> nodes)
			{
				if (node != null)
				{
					nodes.Add(node.val);
					if(node.left == null && node.right == null)
						isLeafsIndexes.Add(nodes.Count - 1);

					if (node.left != null)
					{
						node.left.val = ++n;
						edges.Add(new Edge(node.val, node.left.val));
						AddEdgeInfo(node.left, edges, nodes);
					}
					if (node.right != null)
					{
						node.right.val = ++n;
						edges.Add(new Edge(node.val, node.right.val));
						AddEdgeInfo(node.right, edges, nodes);
					}
				}
			}



			public void DijkstraAlgo(int[,] graph, int source, int verticesCount)
			{
				int[] distance = new int[verticesCount];
				bool[] shortestPathTreeSet = new bool[verticesCount];

				for (int i = 0; i < verticesCount; ++i)
				{
					distance[i] = int.MaxValue;
					shortestPathTreeSet[i] = false;
				}

				distance[source] = 0;

				for (int count = 0; count < verticesCount - 1; ++count)
				{
					int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
					shortestPathTreeSet[u] = true;

					for (int v = 0; v < verticesCount; ++v)
						if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
							distance[v] = distance[u] + graph[u, v];
				}

				Print(distance, verticesCount);
			}
			private  int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
			{
				int min = int.MaxValue;
				int minIndex = 0;

				for (int v = 0; v < verticesCount; ++v)
				{
					if (shortestPathTreeSet[v] == false && distance[v] <= min)
					{
						min = distance[v];
						minIndex = v;
					}
				}



				return minIndex;
			}
			private void Print(int[] distance, int verticesCount)
			{
				//Console.WriteLine("Vertex    Distance from source");

				for (int i = 0; i < verticesCount; ++i)
				{
					//Console.WriteLine("{0}\t  {1}", i, distance[i]);

					if (distance[i] != 0 && isLeafsIndexes.Contains(i))
					{
						isLeafsDistances.Add(distance[i]);
					}
				}
			}


		}



	}


}
