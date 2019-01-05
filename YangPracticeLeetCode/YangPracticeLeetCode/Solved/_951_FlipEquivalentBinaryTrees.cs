using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Solved;

namespace YangPracticeLeetCode.Solved
{

	class _951_FlipEquivalentBinaryTrees
	{

		public static void Test()
		{
			Solution s = new Solution();

			int?[] a4 = new int?[] { 3 };
			int?[] a5 = new int?[] { 1, 2, 3, 4, 5, 6, null, null, null, 7, 8 };
			TreeNode root = new TreeNode(a5[0].GetValueOrDefault());
			ProduceTreeNode(a5, a5.Length, 0, root);

			int?[] a6 = new int?[] { 1, 2, 3, 4, 5, 6, null, null, null, 7, 8 };
			TreeNode root2 = new TreeNode(a5[0].GetValueOrDefault());
			ProduceTreeNode(a6, a6.Length, 0, root2);

			//a4.PrintList();
			Console.WriteLine(s.FlipEquiv(root, root2)+" is true");
		}

		//							0
		//			1								2
		//	3				4				5				6
		//7		8		9		10		11		12		13		14		
		//	由上面觀察可知  陣列中位置n的node的左node和右node 在分別為	位置2n+1和位置2n+2

		public static void ProduceTreeNode(int?[] values, int length, int currentPos, TreeNode node)
		{
			if (node == null)
				return;
			int left = 2 * currentPos + 1;
			int right = 2 * currentPos + 2;
			if (left < length && values[left] != null)
				node.left = new TreeNode(values[left].GetValueOrDefault());
			if (right < length && values[right] != null)
				node.right = new TreeNode(values[right].GetValueOrDefault());
			ProduceTreeNode(values, length, left, node.left);
			ProduceTreeNode(values, length, right, node.right);
		}


		public class Solution
		{
			public bool FlipEquiv(TreeNode root1, TreeNode root2)
			{
				return TraverseLeftRightUnorderEqual(root1, root2)
					&& TraverseLeftRightUnorderEqual(root2, root1);
			}

			/// <summary>
			/// 這題的策略很簡單	對tree1的每個點  去遍歷尋找tree2任何位置存在相同的點
			/// 不存在直接false  存在的話只比  left right 相等 或交換相等 (我用unorder表示)
			/// 都相等就true 一有false就結束
			/// </summary>
			/// <param name="root1Node"></param>
			/// <param name="root2"></param>
			/// <returns></returns>
			public bool TraverseLeftRightUnorderEqual(TreeNode root1Node, TreeNode root2)
			{
				if (root1Node == null ) return true;
				TreeNode root2NodeFind = TraverseFind(root1Node.val, root2);
				if (root2NodeFind == null)
					return false;
				if (!LeftRightUnorderEqual(root2NodeFind, root1Node))
					return false;
				if (!TraverseLeftRightUnorderEqual(root1Node.left, root2))
					return false;
				if (!TraverseLeftRightUnorderEqual(root1Node.right, root2))
					return false;
				return true;
			}

			public bool LeftRightUnorderEqual(TreeNode node1, TreeNode node2)
			{
				if (node1 == null && node2 == null)
					return true;

				int l1, r1, l2, r2;

				if (node1 != null && node2 != null)
				{
					l1 = node1.left == null ? -1 : node1.left.val;
					r1 = node1.right == null ? -1 : node1.right.val;
					l2 = node2.left == null ? -1 : node2.left.val;
					r2 = node2.right == null ? -1 : node2.right.val;
					
					if ( 
						(
						(l1 == l2 && r1 ==r2)
						||
						(l1 == r2 && r1 == l2)
						)
						&&
						node1.val == node2.val
					)
						return true;


				}
				return false;
			}
			
			public TreeNode TraverseFind(int val, TreeNode node)
			{
				if (node == null)
					return null;
				if (node.val == val)
					return node;
				TreeNode findL = TraverseFind(val, node.left);
				TreeNode findR = TraverseFind(val, node.right);
				if (findL != null)
					return findL;
				if (findR != null)
					return findR;

				return null;
			}

		}
		
	}


	//Definition for a binary tree node.
	public class TreeNode
	{
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }

		public override string ToString()
		{
			return val.ToString();
		}
	}

}
