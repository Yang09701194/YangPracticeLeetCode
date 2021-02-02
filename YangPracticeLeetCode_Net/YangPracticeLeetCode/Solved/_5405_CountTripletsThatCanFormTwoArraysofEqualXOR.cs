using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5405_CountTripletsThatCanFormTwoArraysofEqualXOR
	{
		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(
			//s.LongestSubarray(new[] { 4, 2, 2, 2, 4, 4, 2, 2 }, 0)
			//);
			//Console.WriteLine(
			//	s.CountTriplets(new[] { 2, 3, 1, 6, 7 })
			//);
			Console.WriteLine(
				s.CountTriplets(new[] { 1,1,1,1,1})
			);

			//Console.WriteLine(
			//	s.CountTriplets(new[] { 813, 902, 171, 582, 749, 754, 31, 239, 240, 285, 493, 138, 359, 642, 997, 808, 205, 591, 642, 307, 945, 848, 225, 405, 372, 72, 316, 452, 248, 316, 452, 111, 427, 230, 333, 50, 383, 640, 1023, 897, 126, 603, 549, 618, 79, 851, 796, 368, 620, 108, 512, 245, 757, 779, 510, 935, 601, 413, 964, 838, 130, 621, 751, 214, 569, 1, 568, 461, 1013, 468, 545, 253, 732, 916, 328, 902, 718, 877, 419, 303, 140, 808, 932, 752, 340, 171, 511, 447, 64, 85, 21, 351, 330, 938, 736, 835, 419, 748, 847, 821, 122, 43, 81, 888, 809, 238, 967, 194, 773, 335, 586, 469, 927, 552, 439, 869, 722, 74, 664, 652, 20, 960, 980, 583, 403, 754, 865, 99, 770, 784, 18, 480, 498, 35, 465, 871, 694, 924, 298, 121, 339, 928, 755, 156, 623, 812, 323, 430, 237, 245, 24, 786, 778, 69, 847, 816, 127, 689, 718, 704, 14, 20, 26, 741, 767, 209, 558, 264, 806, 319, 537, 340, 845, 654, 451, 872, 683, 597, 254, 984, 806, 223, 1017, 506, 515, 974, 461, 209, 284, 634, 870, 186, 988, 632, 420, 923, 575, 93, 610, 551, 69, 946, 1015, 362, 669, 15, 658, 506, 872, 301, 581, 19, 598, 294, 880, 139, 1019, 343, 684, 951, 283, 439, 172, 879, 963, 555, 488, 810, 706, 54, 756, 104, 668, 528, 140, 836, 968, 758, 318, 659, 941, 911, 34, 663, 693, 661, 32, 516, 548, 409, 957, 733, 352, 559, 847, 673, 494, 594, 956, 637, 449, 633, 952, 421, 541, 268, 785, 47, 830, 247, 969, 336, 665, 679, 62, 233, 215, 528, 711 })
			//);


		}



		/// <summary>
		/// 我這邊要2600ms    其他解只要150ms  都是已經超自然了
		/// https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/discuss/624099/C-O(N2)-solution-beats-100-time-100-space-with-explanantion
		/// 有空在來研究一下    如果二十分鐘內解完的寫的都是這種程式碼  那就真的超神了 = = ...
		/// </summary>
		public class Solution
		{
			public int CountTriplets(int[] arr)
			{
				if (arr.Length == 1)
					return 0;

				bool isAllSame = true;
				int first = arr[0];
				for (int i = 0; i < arr.Length; i++)
				{
					if (arr[i] != first)
					{
						isAllSame = false;
						break;
					}
				}

				if (isAllSame)
				{
					int coou = 0;
					for (int i = 0; i < arr.Length - 1; i++)
					{
						for (int j = i + 1; j < arr.Length; j++)
						{
							for (int k = j; k < arr.Length; k++)
							{
								if (first == 0)
									coou++;
								else
								{
									//  num ^ num = 0 , num ^ num ^ num = num ... etc
									//  so num num num num num >>>> num 0 num 0 num 0
									if ((j -1 - i) % 2 == (k - j) % 2)
										coou++;

								}
								//Console.WriteLine($"{i} {j} {k}");

							}
						}
					}

					return coou;
				}



				int cou = 0;
				for (int i = 0; i < arr.Length - 1; i++)
				{
					for (int j = i+1; j < arr.Length; j++)
					{

						int a = arr[i];
						for (int l = i + 1; l < j; l++)
						{
							a = a ^ arr[l];
						}

						for (int k = j; k < arr.Length; k++)
						{
							//http://dotnetmis91.blogspot.com/2009/12/blog-post.html
							
							int b = arr[j];
							for (int l = j+1; l <= k; l++)
							{
								b = b ^ arr[l];
							}

							if (a == b)
							{
								cou++;
								Console.WriteLine($"{i} {j} {k}");
							}

						}
					}
				}

				return cou;
			}
		}

	}
}
