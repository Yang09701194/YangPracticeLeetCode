using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _1105_FillingBookcaseShelves
	{


		/// <summary>
		/// 這題我直接想想不出來  最後是看discuss才知道的
		/// 原本一開始以為是無序  難度就覺得增加許多  沒有範圍的感覺  要用暴力破解窮舉法
		/// 後來看解答才發現他是有序的
		/// 但是自己想還是不會想到要從後面一直數回來  取Min
		/// https://leetcode.com/contest/weekly-contest-143/problems/filling-bookcase-shelves/
		/// </summary>
		public class Solution
		{
			public int MinHeightShelves(int[][] books, int shelf_width)
			{
				int[] dp = new int[books.Length  + 1];

				dp[0] = 0;

				for (int i = 1; i <= books.Length ; ++i)
				{
					int width = books[i - 1][0];
					int height = books[i - 1][1];
					dp[i] = dp[i - 1] + height;
					for (int j = i - 1; j > 0 && width + books[j - 1][0] <= shelf_width; --j)
					{
						height = Math.Max(height, books[j - 1][1]);
						width += books[j - 1][0];
						dp[i] = Math.Min(dp[i], dp[j - 1] + height);
					}
				}
				return dp[books.Length ];
			}
		}

	}
}
