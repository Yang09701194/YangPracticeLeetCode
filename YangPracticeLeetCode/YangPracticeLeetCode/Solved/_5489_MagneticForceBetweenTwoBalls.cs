using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	//Todo
	class _5489_MagneticForceBetweenTwoBalls
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.MaxDistance(new int[] { 1, 2, 3, 4, 7 }, 3));
			Console.WriteLine(s.MaxDistance(new int[] { 79, 74, 57, 22 }, 4));

		}


		public class Solution
		{
			public int MaxDistance(int[] position, int m)
			{
				// Sort the positions 
				Array.Sort(position);

				// Initialize result. 
				int res = -1;

				// Consider the maximum possible distance 
				int left = position[0], right = position[position.Length - 1];

				// Do binary search for largest 
				// minimum distance 
				while (left < right)
				{
					int mid = (left + right) / 2;

					// If it is possible to place k  
					// elements with minimum distance mid,  
					// search for higher distance. 
					if (isFeasible(mid, position, position.Length, m))
					{
						// Change value of variable max to 
						// mid if all elements can be 
						// successfully placed 
						res = Math.Max(res, mid);
						left = mid + 1;
					}

					// If not possible to place k elements,  
					// search for lower distance 
					else
						right = mid;
				}

				return res;
			}


			static bool isFeasible(int mid, int[] arr, int n, int k)
			{
				// Place first element at arr[0] position 
				int pos = arr[0];

				// Initialize count of elements placed. 
				int elements = 1;

				// Try placing k elements with minimum 
				// distance mid. 
				for (int i = 1; i < n; i++)
				{
					if (arr[i] - pos >= mid)
					{
						// Place next element if its 
						// distance from the previously 
						// placed element is greater 
						// than current mid 
						pos = arr[i];
						elements++;

						// Return if all elements are  
						// placed successfully 
						if (elements == k)
							return true;
					}
				}
				return false;
			}


		}

	}
}
