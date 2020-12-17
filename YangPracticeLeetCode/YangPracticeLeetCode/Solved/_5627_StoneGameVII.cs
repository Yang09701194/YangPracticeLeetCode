using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5627_StoneGameVII
	{

		public static void Test()
		{
			Solution_V2Log s = new Solution_V2Log();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.StoneGameVII(new int[] { 5, 3, 1, 4, 2 }));

			//Console.WriteLine(s.StoneGameVII(new int[] { 7, 90, 5, 1, 100, 10, 10, 2 }));
			//Console.WriteLine(s.StoneGameVII(new int[] { 3, 5 }));


			for (int i = 2; i < 32; i++)
			{
				var now = DateTime.Now;
				int[] n = new int[i];
				for (int j = 0; j < i; j++)
				{
					n[j] = j;
				}
				Solution_V2 ss = new Solution_V2();
				ss.StoneGameVII(n);
				Console.WriteLine(i + " " + DateTime.Now.Subtract(now).TotalMilliseconds);
			}

			//Console.WriteLine(s.StoneGameVII(new int[] { 454, 989, 739, 904, 646, 100, 639, 449, 891, 46, 32, 483, 99, 311, 270, 224, 151, 188, 667, 513, 880, 758, 720, 861, 460, 270, 461, 164, 46, 755, 409, 921, 913, 623, 959, 33, 671, 536, 716, 907, 377, 481, 871, 757, 644, 402, 795, 904, 852, 591, 122, 564, 109, 661, 160, 530, 73, 835, 195, 622, 724, 443, 620, 531, 771, 152, 423, 450, 944, 391, 757, 673, 886, 924, 161, 413, 899, 167, 356, 250, 548, 581, 403, 708, 685, 723, 363, 362, 980, 395, 593, 926, 323, 126, 939, 150, 176, 316, 776, 136, 757, 495, 613, 252, 605, 203, 743, 50, 363, 867, 467, 570, 269, 373, 919, 149, 75, 342, 658, 870, 723, 245, 587, 963, 172, 500, 361, 589, 812, 647, 515, 827, 334, 740, 416, 436, 1000, 382, 65, 179, 233, 896, 910, 316, 419, 860, 48, 523, 562, 31, 520, 247, 152, 703, 326, 182, 883, 199, 18, 278, 468, 191, 885, 32, 950, 510, 668, 47, 87, 485, 194, 803, 58, 77, 717, 245, 711, 836, 633, 442, 874, 767, 27, 433, 815, 611, 580, 135, 834, 686, 551, 471, 27, 146, 99, 488, 484, 586, 25, 372, 931, 734, 856, 231, 346, 925, 345, 692, 930, 295, 978, 786, 98, 720, 868, 952, 417, 364, 937, 502, 340, 803, 266, 612, 611, 191, 165, 516, 506, 489, 917, 651, 135, 333, 564, 937, 787, 917, 619, 702, 622, 143, 238, 253, 901, 401, 594, 861, 439, 439, 823, 986, 928, 329, 187, 339, 772, 551, 128, 845, 112, 418, 862, 127, 929, 905, 528, 841, 85, 313, 111, 645, 169, 557, 683, 796, 677, 706, 758, 367, 773, 217, 400, 141, 140, 706, 144, 148, 817, 855, 82, 400, 193, 10, 586, 448, 752, 901, 164, 761, 257, 909, 611, 288, 963, 713, 272, 81, 409, 249, 189, 531, 359, 339, 173, 374, 854, 20, 180, 501, 359, 732, 197, 529, 422, 485, 135, 243, 672, 448, 7, 109, 141, 180, 222, 910, 203, 445, 710, 509, 900, 980, 443, 172, 253, 272, 881, 519, 946, 852, 463, 570, 478, 260, 894, 930, 276, 870, 493, 69, 2, 439, 61, 93, 510, 9, 442, 652, 94, 569, 666, 604, 967, 209, 641, 274, 784, 215, 557, 621, 665, 962, 812, 304, 874, 115, 62, 785, 917, 116, 646, 57, 551, 389, 569, 749, 102, 561, 556, 4, 583, 832, 480, 104, 345, 31, 907, 1000, 234, 129, 487, 483, 432, 491, 239, 550, 381, 641, 565, 939, 18, 541, 484, 828, 7, 904, 757, 283, 808, 46, 764, 784, 115, 674, 170, 402, 952, 413, 616, 454, 623, 212, 864, 459, 729, 680, 134, 600, 834, 922, 674, 266, 21, 772, 622, 172, 169, 611, 527, 25, 78, 178, 919, 505, 796, 445, 476, 944, 710, 733, 484, 866, 175, 121, 778, 47, 269, 981, 755, 569, 586, 403, 364, 831, 602, 547, 294, 51, 681, 302, 319, 370, 573, 184, 691, 953, 236, 248, 364, 636, 846, 763, 503, 29, 623, 744, 141, 410, 79, 309, 227, 127, 268, 861, 165, 644, 451, 127, 491, 223, 880, 236, 251, 978, 622, 702, 63, 349, 448, 579, 637, 672, 416, 302, 222, 544, 412, 821, 787, 17, 37, 906, 186, 599, 767, 233, 78, 191, 535, 909, 551, 727, 992, 297, 137, 838, 881, 58, 860, 36, 726, 953, 245, 330, 261, 261, 118, 427, 632, 599, 431, 162, 409, 718, 102, 693, 131, 716, 988, 245, 266, 778, 752, 189, 446, 927, 91, 924, 974, 701, 50, 974, 132, 769, 580, 98, 970, 669, 40, 258, 948, 764, 789, 455, 709, 893, 76, 75, 502, 116, 829, 692, 120, 807, 207, 654, 399, 19, 620, 100, 289, 533, 658, 911, 563, 575, 705, 923, 736, 822, 712, 322, 73, 63, 96, 54, 690, 456, 866, 243, 72, 178, 718, 172, 826, 822, 862, 305, 401, 308, 315, 930, 852, 294, 913, 772, 697, 462, 169, 940, 870, 693, 454, 668, 226, 458, 735, 25, 864, 164, 864, 417, 449, 460, 623, 517, 941, 504, 661, 186, 836, 907, 175, 437, 5, 37, 872, 625, 950, 13, 92, 58, 998, 205, 417, 107, 480, 116, 787, 369, 751, 202, 725, 228, 933, 702, 895, 757, 100, 851, 411, 691, 526, 899, 537, 858, 480, 289, 773, 187, 636, 556, 717, 656, 789, 506, 720, 739, 327, 33, 487, 10, 139, 995, 487, 811 }));


		}



		/// <summary>
		/// Approach 3: Optimised Memoization Approach
		///
		/// ���L���_�Ӹ�V2 ���t���h
		///
		/// ���j���z�Ѥ@�U�s�����k
		///
		/// Both Bob and Alice are trying to maximize their score. Alice is trying to get the maximum score so that she has a maximum difference from Bob's score. Bob is also trying to get the maximum score so that he is as close to Alice as possible.
		/// �o�@�y�n�������X��  �]�N�O��ӤH���b�l�D�̤j  �ڬ��D�N�S��k�o��T�w
		/// �]�����a���j����Ҹ��|   �����ݼƦr���D�سW�h�����h��   �����i�����p��  �H���j���᭱��Q�ۤv���
		/// �o�˴N���i�঳�@�����[�֪�  �U�@�B�~�[�ܤj�� �ɼW
		///
		/// �ҥH�o�̪� max �����٬O���O����U�o�@�B���̤j��  �٬O�A��  ���ױ��U������optmize���C�@�B �A�o��{�b�o�@�B�i��̤j��
		///
		///
		/// If both players want to maximize their score, they must return the maximum difference to the other player.
		/// �o�y�]�O�ܤ��ߺD max ���M�γ̤jdiff�ӧήe  �Ӥ��O�¼Ƥj�p
		///
		/// 
		///
		/// To calculate the current difference, each player would subtract the difference returned by the opponent from the current score.
		///
		///
		///If the current player is Bob,
		///Difference = Current Score - Difference returned by Alice
		///If the current player is Alice,
		///Difference = Current Score - Difference returned by Bob
		///
		/// 
		/// 
		/// </summary>
		class Solution_App3
		{
			int[] prefixSum;
			int[,] memo;

			private int findDifference(int start, int end, int[] stones)
			{
				if (start == end)
				{
					return 0;
				}
				if (memo[start,end] != 0)
				{
					return memo[start,end];
				}
				if (start + 1 == end)
					return Math.Max(stones[start], stones[end]);

				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];

				memo[start,end] = Math.Max(
					scoreRemoveFirst - findDifference(start + 1, end, stones),
					scoreRemoveLast - findDifference(start, end - 1, stones));

				return memo[start,end];
			}

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				memo = new int[n,n];
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];
				}
				return findDifference(0, n - 1, stones);
			}
		}



		/// <summary>
		/// �o��DP2 �@��  �w�g�i�H�R�W��
		/// Approach 2: Top Down Dynamic Programming - Memoization
		///
		/// ���O���o��   �ڬO�������g�k  ���m��g
		/// ���O  �L�󪽱��ݥX��²�ƪ��a��  ���u�n�b  �}�Y  �M����  ��cache  ��m�U����ڪ�����o��n
		///
		/// �������N�i��F 20ms
		///
		/// ���O�o�˴N�i�J�F
		/// Runtime: 256 ms, faster than 63.64% of C# online submissions for Stone Game VII.
		/// Memory Usage: 45.4 MB, less than 68.18% of C# online submissions for Stone Game VII.
		///
		/// �orange���I�j  �h�e�X���|�X�{
		/// Runtime: 240 ms, faster than 81.82% of C# online submissions for Stone Game VII.
		/// Memory Usage: 45.4 MB, less than 63.64% of C# online submissions for Stone Game VII.
		///
		/// 
		/// </summary>
		class Solution_V2_Cache_DP3
		{
			int[] prefixSum;
			int[,] memo;

			private int findDifference(int start, int end, bool alice)
			{
				if (start == end)
				{
					return 0;
				}
				if (memo[start,end] != 0)
				{
					return memo[start,end];
				}
				int difference;
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];

				if (alice)
				{
					difference = Math.Max(
						findDifference(start + 1, end, !alice) + scoreRemoveFirst,
						findDifference(start, end - 1, !alice) + scoreRemoveLast);
				}
				else
				{
					difference = Math.Min(
						findDifference(start + 1, end, !alice) - scoreRemoveFirst,
						findDifference(start, end - 1, !alice) - scoreRemoveLast);
				}
				memo[start,end] = difference;
				return difference;
			}

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				memo = new int[n,n];
				//for (int[] arr : memo)
				//{
				//	Arrays.fill(arr, INF);
				//}
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];
				}
				return Math.Abs(findDifference(0, n - 1, true));
			}
		}


		/// <summary>
		/// �ߤ@�Q��  �i�H�A�ժ�  Dic�w�g�O���ŧ֤F
		/// ��b���  �i��u�� �}�C ?
		/// �Ӹո�
		///
		/// ���i��ĳ   ���M�u�ݭn 40ms  �o���MDictionary�o�ئs��O(1)��  �ٯ�A��
		/// �ӥB�֤F  15 ��
		/// �S���̧�  �u�����  �_�ݰ�
		/// �}�C²��  ���O �W��
		///
		/// nxn���G���}�C
		///
		/// �o�˴Npass�F
		///
		/// Runtime: 540 ms, faster than 13.64% of C# online submissions for Stone Game VII.
		/// Memory Usage: 49.3 MB, less than 18.18% of C# online submissions for Stone Game VII.
		///
		/// �ٺ�C  �֪����ӳ� �� sol�a
		/// ���O���U�� Approach 5  184ms
		///
		/// 
		/// </summary>
		class Solution_V2_Cache_DP2
		{
			public static int cou = 0;
			private int findDifference(int start, int end, bool alice)
			{
				if (start == end)
				{
					return 0;
				}
				int difference;       //�]��ps 1~n �ǤJ��end�On-1 �ҥH�n+1�ରn
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];// pn - p1
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];//��ݷ|�H��-p0��  ���O��Ӥ@�USol����  �|�o�{�o�O�u��  -p0�~���O�d1st�������ĪG

				int num1 = 0, num2 = 0;
				Action findDiff = () =>
				{
					if (findDifferenceCache[start + 1, end] == 0)
					{
						num1 = findDifference(start + 1, end, !alice);//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
						findDifferenceCache[start + 1, end] = num1;
					}
					else
						num1 = findDifferenceCache[start + 1, end];

					if (findDifferenceCache[start, end - 1] == 0)
					{
						num2 = findDifference(start, end - 1, !alice);
						findDifferenceCache[start, end - 1] = num2;
					}
					else
						num2 = findDifferenceCache[start, end - 1];
				};

				if (alice)
				{
					findDiff();
					int num1SRF = num1 + scoreRemoveFirst;//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2SRL = num2 + scoreRemoveLast;

					difference = Math.Max(num1SRF, num2SRL);
				}
				else
				{
					findDiff();
					int num1SRF = num1 - scoreRemoveFirst;//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2SRL = num2 - scoreRemoveLast;

					difference = Math.Min(num1SRF, num2SRL);
				}
				return difference;
			}

			int[] prefixSum;
			int[,] findDifferenceCache = null;

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];// 0 ~ n-1  �ഫ�� 1~n  
				}

				findDifferenceCache = new int[n, n];

				int res = Math.Abs(findDifference(0, n - 1, true));
				return res;
			}
		}



		/// <summary>
		/// V2 �� Cache ��   �o�ت����[��Dic  �Ӥ��O�Τ@ �ΤG���}�C�x�s  �����D�٥s���sdp
		///
		/// �ڤ@�}�l�Q  �O�Q  ���Ψ쪺�~�[�iCache
		///
		/// ���O�ݨ�o�ӻ��j���S��  �@�w�C�ӼƦr�q���|���̩�  �N������C�رƦC���|���L�@�M
		/// �ҥH���i��i�H��������n*n������@�M   ������]��[
		/// �Ӹոլ�
		///
		/// ����  ��g��M�A�Q��  ���cache prefixSum���[��p�⵲�G  �S����N�q  �]��+=���t�פӧ֤F  ��cache���ӨS�t�h��
		/// �ҥH�|��cache����Scache
		///
		/// �ҥH���ӬO�ncache  F �����G  �]�N�O �W�h��F  ���U�쥻�n���j100�Ӥl  �����������G
		/// ��L�a��n�A��ۦP��F  ���100  �o�ؤ~����
		///
		/// ��@�U
		///
		/// �T��S�j�T�i�B  ���MTLE  ���O�w�g 55/68 test case pass
		/// ���a�� �S�L�� case  570 ms
		/// 
		/// </summary>
		class Solution_V2_Cache_DP
		{
			public static int cou = 0;
			private int findDifference(int start, int end, bool alice)
			{
				if (start == end)
				{
					return 0;
				}
				int difference;       //�]��ps 1~n �ǤJ��end�On-1 �ҥH�n+1�ରn
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];// pn - p1
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];//��ݷ|�H��-p0��  ���O��Ӥ@�USol����  �|�o�{�o�O�u��  -p0�~���O�d1st�������ĪG

				int num1 = 0, num2 = 0;
				Action findDiff = () =>
				{
					if (!findDifferenceCache.ContainsKey($"{start + 1}_{end}"))
					{
						num1 = findDifference(start + 1, end, !alice);//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
						findDifferenceCache.Add($"{start + 1}_{end}", num1);
					}
					else
						num1 = findDifferenceCache[$"{start + 1}_{end}"];

					if (!findDifferenceCache.ContainsKey($"{start}_{end - 1}"))
					{
						num2 = findDifference(start, end - 1, !alice);
						findDifferenceCache.Add($"{start}_{end - 1}", num2);
					}
					else
						num2 = findDifferenceCache[$"{start}_{end - 1}"];
				};

				if (alice)
				{
					findDiff();
					int num1SRF = num1 + scoreRemoveFirst;//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2SRL = num2 + scoreRemoveLast;

					difference = Math.Max(num1SRF, num2SRL);
				}
				else
				{
					findDiff();
					int num1SRF = num1 - scoreRemoveFirst;//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2SRL = num2 - scoreRemoveLast;

					difference = Math.Min(num1SRF, num2SRL);
				}
				return difference;
			}

			int[] prefixSum;
			public Dictionary<string, int> findDifferenceCache = new Dictionary<string, int>();

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];// 0 ~ n-1  �ഫ�� 1~n  
				}

				int res = Math.Abs(findDifference(0, n - 1, true));
				return res;
			}
		}


		/// <summary>
		/// Log ����  �ݨ�L�{�N�ܦ��Pı�F   �ܦh�L�{�S�x���W�N���X��   �ݥX�ߵ�
		/// ���O���۶]�����G  �٬O���������c��
		/// �ҥH�b��i�@�B   �ίȵ��N�i�H��z���z��  ���j�����
		/// ���N�����W ���۪�log
		/// �N���ݥX�W�h
		/// recursion �S���|�X�{�� tree �N�X�{�F
		/// �M��N�|�X�{�@�� recursion �S���|�X�{��  �@�ﭫ�ƬۦP���p�ⶵ��
		/// �M��  �N�|�۰ʶ}�l�p�Q��   ���Odp�X���ٮɶ����ɭԤF
		///
		/// �Ȥ�e��  �w�[�쵧�O ������U�����z��
		/// 
		/// �J�M�p��  �ڴN�����~�򩹤U��sol  �Ӹյۦۤv��g�@��dp��  �ݷ|���|�Npass TLE �F
		///
		/// �o�䪺TLE  �b����700���ɭ�   �@�������]����  �t�Z�u���j  �u���ncache
		///
		///
		/// Time Complexity : \mathcal{O}(2^{n^{2}}).
		///
		/// For an array of length nn, there are roughly { n^{ 2} } possible subarrays.
		/// 12345
		///5 start 0
		///4 start 0 1
		///3 start 0 1 2
		///2 start 0 1 2 3
		///1 start 0 1 2 3 4
		///�i�H�ݥX�O 1+...+n > n(n+1)/2  �ҥHO(n^2) ��sub array	
		///
		/// We fill the array prefixSum of size n by iterating n times.The time complexity would be \mathcal{ O}(n).
		///For each subarray there are 22 choices, either remove the first element or remove the last element.Thus the time complexity of recursive function would be \mathcal{ O}(2^{n^{2}})

		///This would give us total time complexity as \mathcal{O}(n)) + \mathcal{O}(2^{n^{2}}) = \mathcal{O}(2^{n^{2}})
		/// 2 ��  n����  ����  ���Ƕ]����
		///This approach is exhaustive and results in Time Limit Exceeded(TLE)
		///
		///�q�𪬹ϥi�H�ݨ�  �D�w�z ���H�𪺮i�{   ���j�O�����(�h�Y �Υh��)�U�h  �ҥH��N�O2���ƼW��
		/// �N�O 2 ������ 
		/// 2������S�n�֥[ 
		/// 1+2+4+8 = 15   2^4 - 1
		/// k�h  �N�O 2^k+1 - 1
		/// �ҥH�ݦ��X�h
		/// ����ı�o�t���h�On�h  �]���N�}�C���� n ����� 1
		///
		/// ���O�L���O  n^2����?  �ڨӶ]�]�� �ɴ��@�U�ɶ����W������  �n�������쪺
		/// 
		///
		/// 
		///Space Complexity: \mathcal{O}(n)O(n), as we build an array prefixSum of size nn.
		///
		/// </summary>
		class Solution_V2Log
		{
			int[] prefixSum;


			public static int cou = 0;

			private int findDifference(int start, int end, bool alice)
			{
				Console.WriteLine($"#{cou++}");

				if (start == end)
				{
					Console.WriteLine($"{start} == {end}  return 0");
					return 0;
				}
				int difference;       //�]��ps 1~n �ǤJ��end�On-1 �ҥH�n+1�ରn
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];// pn - p1
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];//��ݷ|�H��-p0��  ���O��Ӥ@�USol����  �|�o�{�o�O�u��  -p0�~���O�d1st�������ĪG
				string p = alice ? "A" : "B";
				Console.WriteLine($"{p} scoreRemoveFirst({start + 1},{end + 1}): {scoreRemoveFirst}  scoreRemoveLast({start},{end}): {scoreRemoveLast}");

				if (alice)
				{

					int num1 = findDifference(start + 1, end, !alice);//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2 = findDifference(start, end - 1, !alice);
					int num1SRF = num1 + scoreRemoveFirst;//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2SRL = num2 + scoreRemoveLast;

					difference = Math.Max(num1SRF, num2SRL);
					Console.WriteLine($"A, s1n  diff from {start + 1} to {end}  is {num1} ,  +scoreRemoveFirst:{scoreRemoveFirst} = {num1SRF}");
					Console.WriteLine($"A, se1 diff from {start } to {end - 1}  is {num2}, +scoreRemoveLast:{scoreRemoveLast} = {num2SRL} ");
					Console.WriteLine($"Max = {difference}");
				}
				else
				{
					int num1 = findDifference(start + 1, end, !alice);//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2 = findDifference(start, end - 1, !alice);
					int num1SRF = num1 - scoreRemoveFirst;//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2SRL = num2 - scoreRemoveLast;

					difference = Math.Min(num1SRF, num2SRL);
					Console.WriteLine($"B, s1n diff from {start + 1} to {end}  is {num1} ,  +scoreRemoveFirst:{scoreRemoveFirst} = {num1SRF}");
					Console.WriteLine($"B, se1 diff from {start } to {end - 1}  is {num2}, +scoreRemoveLast:{scoreRemoveLast} = {num2SRL} ");
					Console.WriteLine($"Min = {difference}");
				}
				return difference;
			}

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];// 0 ~ n-1  �ഫ�� 1~n  
				}
				// �o�Ӫ�����diff�L�{���u���|�������t  �ҥH�~�ݭnabs
				int res = Math.Abs(findDifference(0, n - 1, true));
				Console.WriteLine($"res: {res}");
				return res;
			}
		}




		/// <summary>
		/// So1 1 �̭�l�����j  �������D�N
		/// ���T�@�B�@�B�Ӱl�C�@�B  ���ܦ��D�z �M��n����U�h �N�|�O�諸
		/// ���O�H�@�Q�n�l�o�ئn�X�h�����j  �S���ȵ��u�a������   stack�n���S�o��j  ���������O��C�@�B�@����U�h
		/// �S�O�O�n���̩�  �~�ા�D�T�����Ʀr ��O��
		///
		/// �ҥH�o�ɭ� log�N���W�γ��F  ����sol�[ log
		/// �oTLE �����z�z�ѫܦ����U
		///
		/// �o�ˬO 9/68 test case pass
		/// </summary>
		class Solution_V2
		{
			int[] prefixSum;

			private int findDifference(int start, int end, bool alice)
			{
				if (start == end)
				{
					return 0;
				}
				int difference;       //�]��ps 1~n �ǤJ��end�On-1 �ҥH�n+1�ରn
				int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];// pn - p1
				int scoreRemoveLast = prefixSum[end] - prefixSum[start];//��ݷ|�H��-p0��  ���O��Ӥ@�USol����  �|�o�{�o�O�u��  -p0�~���O�d1st�������ĪG

				if (alice)
				{
					difference = Math.Max(
						findDifference(start + 1, end, !alice) + scoreRemoveFirst,//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
						findDifference(start, end - 1, !alice) + scoreRemoveLast);
				}
				else
				{
					difference = Math.Min(
						findDifference(start + 1, end, !alice) - scoreRemoveFirst,
						findDifference(start, end - 1, !alice) - scoreRemoveLast);
				}
				return difference;
			}

			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;
				prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];// 0 ~ n-1  �ഫ�� 1~n  
				}
				return Math.Abs(findDifference(0, n - 1, true));
			}
		}


		/// <summary>
		///
		/// �L�H�g���ѵ�
		/// 
		/// https://leetcode.com/problems/stone-game-vii/submissions/
		///
		///Approach 5: Another Approach using Tabulation
		/// 
		/// Runtime: 184 ms, faster than 100.00% of C# online submissions for Stone Game VII.
		//  Memory Usage: 38.5 MB, less than 100.00% of C# online submissions for Stone Game VII.
		///
		/// prefixSum �S�Q��i�H�o�� �]�O�ڭ찵�k���仼��|�Ψ�
		/// �o�Ӧn�Φb��i�H���۴�D���N���I�������M  �N�O�F�`
		/// ���ӬO preprocess������
		/// 
		/// </summary>
		class Solution_V1
		{
			public int StoneGameVII(int[] stones)
			{
				int n = stones.Length;

				int[,] dp = new int[n, n];


				int[] prefixSum = new int[n + 1];
				for (int i = 0; i < n; i++)
				{
					prefixSum[i + 1] = prefixSum[i] + stones[i];
				}
				for (int length = 2; length <= n; length++)
				{
					for (int start = 0; start + length - 1 < n; start++)
					{
						int end = start + length - 1;
						int scoreRemoveFirst = prefixSum[end + 1] - prefixSum[start + 1];
						int scoreRemoveLast = prefixSum[end] - prefixSum[start];
						dp[start, end] = Math.Max(scoreRemoveFirst - dp[start + 1, end],
							scoreRemoveLast - dp[start, end - 1]);

					}
				}
				return dp[0, n - 1];
			}
		}




		/// <summary>
		/// �̫�S�ۤv�Q�X��  �o�D�ӽ����F
		/// �H�j���u��ݩ���@��B  �ӱ��פ@�}�l�n�索�٬O�k
		/// ��U�Ѧ��I��
		/// �ҥH�S��²�檺�W�h
		/// �����ٷQ��  �p�G�OA�@�w����̤p  B����̤j
		/// �Ϊ̥[�W  �n�O�d����� 3 1 4 ��A ��  �o�˨B�׿����  ���|��1��B  B�b�̫�B�N����u��
		///
		/// ���O�o�سW�h�ӳ�@���p�F   �����D�٦��h�ֳW�h  ���O�e���n���  �~�����̫�O�d 3 1 4 �N��²��
		/// �Q����
		/// 
		/// �Ʀܳs�ҿת�
		/// Bob decided to minimize the score's difference. Alice's goal is to maximize the difference in the score.
		/// both play optimally.
		/// 
		/// �@�ӭ��I�O���T�w�b��̦U�۳̤j�η|�pdiff�����p�U  �٭n���n�l�D���Ƴ̤j
		/// �]���]�\  ���Ƴ̤j���ɭ�  ���@�w�|�̤j �γ̤p�t��
		/// �]���y���t�����@�ӭ��I�O�b�󲾰�
		/// �����j��  �|�y��sum�i��C  �������ĪG�O  �U�@�ӤH�L�k�β����o�Ӥj�Ʀ����j�Ϯt
		/// ���O�i��j�ƪ�����O�j�� �ҥH�i�H���U�@�ӤH���� �y����j���t��   ������
		/// �ҥH�����T�w�쩳�O���S���n�l�D  sum�̤j   ��M�C���W�h�w�g�� A��Ĺ  �ҥH�i��S�o��
		/// ���ӨS��   �L�צp��  ��Ӭ�sol  �N�ܲM���F
		///
		/// For Bob, he will try to return the maximum negative value. So that the difference between his and Alice's score is minimum.
		/// For Alice, she will try to return the maximum positive value.So that the difference between her and Bob's score is maximum.
		/// 
		/// Bob's difference = Alice's difference - Current Score
		/// Alice's difference = Bob's Difference + Current Score
		/// 
		/// �����o���O�ݨ� Top Down  /  Bottom Up
		/// �H���e�L�Ъ� Top Down �O����`����  Bottom Up�n������ֻ���
		/// ���o��N�ݨ�F
		///
		/// ��ڤW  �N��Sol�w�g�g�o�ܸԺɤF  ���O�����װ����Ǧa����٬O���O����
		/// �i���o�D���T������
		/// �ӹ�ڶ]�]��
		/// 
		/// </summary>
		public class Solution_V1_NotSuccess
		{
			public int StoneGameVII(int[] stones)
			{
				//List<int> ls = stones.ToList();
				var s = stones;
				int sum = stones.Sum();
				int A = 0, B = 0;


				//�o�̴N�ۤv����즳�m�� ���g��W�[���ĪG
				//�@�}�l�|�Q   ������S��  ���N�O while count > 0
				//���O���e�m�L�@�D  �N�O�չL  ������  �N�O���
				//�ҥH�o�̼g��@�b  �N�|�۰ʷQ���������Ч��
				//while (ls.Any())
				//{

				//}

				bool roundA = true;
				for (int i = 0, j = stones.Length - 1; i <= j;)
				{

					if (j - i == 1)
					{
						//if (!roundA)
						//{
						if (s[i] < s[j])
						{
							sum -= s[i];
							if (roundA)
								A += sum;
							else
								B += sum;
							i++;
						}
						else if (s[j] < s[i])
						{
							sum -= s[j];
							if (roundA)
								A += sum;
							else
								B += sum;
							j--;
						}
						else
						{
							sum -= s[i];
							if (roundA)
								A += sum;
							else
								B += sum;
							i++;

						}
						//}
						//else
						//{

						//}
					}

					//�S�O�Ҽ{����ۦP��
					//5625
					//A �n�ɶq�����p��  B���j��
					// A 18 ����5   B 13 ���k5  A 18+8=26��6  B 13+2=15  > 11 
					// A 18 ���k5   B 13 ���k2  A 18+11=29��6  B 13+2=15  > 14
					// �ҥHA�n�������񪺬O�p��   B�n�����a�񪺬O�j��
					//
					if (!roundA)//B
					{
						if (s[i] > s[j])
						{
							sum -= s[i];
							B += sum;
							i++;
						}
						else if (s[j] > s[i])
						{
							sum -= s[j];
							B += sum;
							j--;
						}
						else//  == 
						{
							int choose = i;
							int i1 = i, j1 = j;
							bool isChoose = false;
							while (i1 + 1 < j1 - 1)
							{
								if (s[i1 + 1] > s[j1 - 1])
								{
									choose = j1 - 1;
									j--;
									isChoose = true;
									break;
								}
								else if (s[i1 + 1] < s[j1 - 1])
								{
									choose = i1 + 1;
									i++;
									isChoose = true;
									break;
								}
								else
								{
									i1 += 1;
									j1 -= 1;
								}
							}
							sum -= s[choose];
							if (!isChoose)
								i++;
							B += sum;
						}
					}
					else//A ���p��
					{
						if (s[j] > s[i])
						{
							sum -= s[i];
							A += sum;
							i++;
						}
						else if (s[i] > s[j])
						{
							sum -= s[j];
							A += sum;
							j--;
						}
						else//  == 
						{
							int choose = i;
							int i1 = i, j1 = j;
							bool isChoose = false;
							while (i1 + 1 < j1 - 1)
							{
								if (s[i1 + 1] < s[j1 - 1])
								{
									choose = j1 - 1;
									j--;
									isChoose = true;
									break;
								}
								else if (s[i1 + 1] > s[j1 - 1])
								{
									choose = i1 + 1;
									i++;
									isChoose = true;
									break;
								}
								else
								{
									i1 += 1;
									j1 -= 1;
								}
							}
							sum -= s[choose];
							if (!isChoose)
								i++;
							A += sum;
						}
					}

					roundA = !roundA;
				}

				return A - B;
			}
		}

	}
}
