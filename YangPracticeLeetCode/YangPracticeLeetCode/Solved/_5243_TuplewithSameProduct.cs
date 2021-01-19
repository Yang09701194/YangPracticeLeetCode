using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace YangPracticeLeetCode.Solved
{
	class _5243_TuplewithSameProduct
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.TupleSameProduct(new int[] { 2, 3, 4, 6 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 1, 2, 4, 5, 10 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 2, 3, 4, 6, 8, 12 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 2, 3, 5, 7 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 161, 388, 242, 520, 558, 671, 127, 769, 709, 288, 855, 673, 438, 788, 649, 258, 192, 391, 743, 868, 603, 104, 23, 705, 328, 918, 707, 943, 792, 835, 146, 132, 508, 214, 552, 300, 133, 504, 999, 79, 598, 917, 843, 366, 564, 11, 71, 70, 615, 605, 318, 218, 191, 773, 344, 37, 844, 424, 273, 791, 884, 755, 685, 913, 829, 962, 964, 500, 464, 90, 210, 873, 271, 298, 479, 361, 177, 320, 359, 916, 484, 409, 805, 136, 383, 533, 268, 526, 19, 634, 149, 59, 691, 560, 539, 750, 433, 517, 17, 701 }));
			Console.WriteLine(s.TupleSameProduct(new int[] { 336, 1771, 851, 1091, 3860, 89, 361, 2382, 2000, 194, 60, 2093, 3844, 59, 967, 240, 570, 2642, 281, 2662, 3795, 2195, 2795, 1473, 2403, 1833, 3398, 3554, 141, 781, 1359, 2498, 3918, 1783, 3514, 3193, 3732, 594, 952, 2883, 2162, 1738, 3174, 1412, 1016, 335, 2277, 3764, 161, 1136, 1553, 1628, 528, 145, 3562, 786, 3549, 2622, 870, 380, 3827, 2580, 879, 1308, 2587, 2309, 1607, 3858, 3916, 2270, 2064, 1045, 1487, 1848, 638, 3721, 777, 2594, 1770, 2746, 3191, 2755, 2649, 2969, 1497, 1753, 474, 2179, 1933, 984, 1587, 2407, 2931, 3451, 3259, 1083, 1402, 1556, 288, 2043, 1943, 1429, 2397, 322, 3896, 3234, 2132, 146, 2691, 2687, 2955, 1675, 2588, 1912, 310, 2624, 785, 2501, 912, 616, 3876, 2011, 1522, 1294, 1346, 3567, 1847, 2196, 1357, 482, 2128, 855, 3108, 2734, 3085, 3692, 3443, 3035, 3389, 3376, 1057, 1011, 353, 418, 3775, 1196, 1525, 2189, 3340, 3907, 3609, 614, 1460, 468, 3044, 1526, 712, 916, 1085, 3252, 2329, 1199, 377, 2327, 1961, 3129, 3586, 675, 2207, 3183, 3449, 1966, 2557, 555, 3421, 2967, 1882, 2298, 3622, 3683, 1463, 3283, 585, 400, 1757, 2429, 3073, 1619, 3310, 478, 1023, 709, 2024, 2493, 3264, 3439, 2838, 1604, 3263, 1022, 1439, 3619, 2489, 84, 452, 1984, 2436, 1622, 2170, 3367, 1950, 621, 3929, 3256, 3455, 3664, 2293, 574, 3636, 850, 1445, 112, 1019, 2896, 3513, 2231, 1328, 1571, 3349, 1374, 2986, 2970, 1782, 732, 3980, 3529, 1502, 2881, 2950, 435, 2848, 2048, 439, 3046, 3565, 1006, 1241, 447, 3232, 94, 2695, 2366, 1236, 3185, 173, 1281, 3371, 157, 3227, 3144, 1488, 2888, 1361, 3248, 3125, 462, 1546, 3885, 1233, 987, 3082, 3230, 169, 230, 2866, 2661, 1515, 3671, 1072, 394, 3221, 541, 3213, 1573, 1060, 2906, 3940, 317, 803, 2378, 3104, 1043, 868, 1115, 2152, 665, 1741, 2497, 3685, 339, 1363, 2626, 2181, 2937, 600, 1536, 2514, 3276, 1867, 1101, 1325, 1951, 3362, 1561, 688, 1828, 942, 2120, 1276, 214, 1727, 642, 1324, 2425, 1705, 1096, 76, 774, 694, 2680, 1190, 1177, 2441, 746, 1520, 1709, 1348, 2591, 108, 2818, 2699, 1413, 2459, 1442, 540, 1065, 826, 111, 3099, 1838, 3838, 2670, 2640, 1279, 2105, 2021, 3488, 1852, 1514, 323, 1397, 3016, 2644, 1028, 2976, 3668, 2445, 2664, 828, 3425, 1484, 3761, 640, 1653, 962, 2432, 1296, 2971, 433, 3141, 2890, 672, 3124, 1861, 1589, 1419, 706, 3131, 2136, 3033, 90, 3978, 308, 1696, 2160, 338, 954, 2529, 1844, 738 }));


		}

		/// <summary>
		/// �o�D�F�ܤj  �F�k��@�� easy ���t���h  ���Omedium���F�k  �G�M�O�����ݥX��
		/// �S�ݥX�ӴN�@�w TLE
		///
		/// ���O�D�N�ԭz  �i�ݰ_�ӹ��O�b�� combination  C n �� k �M�� permutation
		/// �쥻�u�� perm �� code   �w�g�X comb ��  �Q��perm����z  recursion
		/// perm �����Q�|�Q  �w��n�X�h for �Sť�L�ݹL�|�Q���X�ӫ��Ȼs����N�j�p
		/// �ݹL���j������  �x����z  combi�N�i�H��X�ӤF
		/// �֤�����N�O ex��3 comb   �Ĥ@�h�D 1~n-2 ��  �ĤG�h 2~n-1 ��  ��3�h�� 3~n
		/// �ҥH�|�O�������索�U��  �T����               
		/// ex 1234 �� 3�� comb   123 124 134 234
		/// ���j�p���@�k   ����ǻ����ѼƴN�O�W�@�h��for  start index �Ǩ�U�@�h�Nfor  +1 �٦��ثe�Ҧb�h��  �H�ά����ثecomb���@��array �C�@�h���]�w�����h�Ʀbarray��index  �V�k���W
		/// �� recur �h == comb����  �N�O�@��comb���G  �i�H�`��  ��ToArray copy �H���v�T�i�椤��comb
		///
		/// comb��   ���[��k  �i�H���D  �@��comb���ߤ��� perm �N�O * 8  ����*8 ���Ϊ�ɶ�perm
		/// �@��comb  �|���T��22�ۭ��i��  �pcode
		///  
		/// ����TLE  �o�{����copy�����`����  �bfor�ˬd  �i�H�bcomb�o�쪺�ɭ�  �����ˬd   �ٱ�copy  �ٶW�j  �n����10��  �ѰO�T��  �٫ܦh�N��F
		///
		/// �A�� tle �S�b�Q  �|���|�O�ۭ���ɶ�  ��ڸչL����   for 10000000 �ۭ�
		/// ������ۭ��M�S����ۭ����ɶ��t���h  �W�X�Q�� �N��ۭ��u������ɶ�  �O�j��q���j�p�M�w
		/// 
		/// �p�G�Q�� �b�P�_22�ۭ��۵�  ���n�d�ȱo�j�Ƭۭ� �Ƥp�@�I �Ҧp % 10���A�� �� & 1��
		/// �����|�����  �]�N�O��  ���H�ӻ�  �Ƥp�@�I�i��u���n�P�_�@�I   ���b�q���S�t  �i�ೣ�ӧ֤F ������ɶ�
		/// 
		/// �ҥH���I�|�ܦ�   ���S���i�����`�j���
		/// �o�˴N�u���@����   �ɶq��C���j�� �M�j���
		/// �N�n�A��S����z�a��  �i�H��²��p��N��F������ˬd
		///
		/// �ĤG�ӷQ��  4�hrecur ���i���� 3�h��
		/// ���N�O 3�Ӽ�  �n���D�ĥ|�Ӽ�   �[���i��  3�Ӽ�  �@���T�جۭ��i��
		/// 12 13 23 �o�˥i�� �ĥ|�Ӽ� �n�۵��o�T��     �N��²�ƫܦh
		/// �p�Gcase���� �X�ʭ�  �N��̦h�u�|���o�T��
		/// �o�˭쥻���ˬd�O O n  �ηj�M��������o3��  �⥦�ئ�HashSet������DS  �j�M�N�u�� logn
		/// �N�i�Jlog�Ҧa    �粒����  �N�֤F�Q��  11s��case  �ܦ��u�n1s 
		///
		/// ���G�٬O  tle  case��M���i�B
		///
		/// �o�䦳�ǲӸ`  ��ĥ|�Ӽ�  �����O  n1*n2/n3= n4  �����O��n���ƪ���  �p���I int�|�˱�
		/// �o��o�{  �p�G��HashSet  �M �p��* ���� decimal �ϦӺC�D�`�h
		/// �̫�o�{  ���l��n3 == 0 &&  n1*n2/n3  �N�ܧ֤S��
		/// �T�w���F  �]���@�}�l��HS�O�����  �o�{�u�n�b���j�L�{add remove  �N�|�ܺC
		/// �ҥH�ĥ� ����  �b�u���T�w  �A�i�hcurr index�H�����C�ӼƳ̷�
		/// �w�g�ܧ�  �쥻1s �� 0.3s
		///
		/// �٬Otle
		///
		/// �A�Q  �Q��  �i��comb�O�@���F��
		/// ��걶�|�@�Q  22�ۭ�����   �S�O�� pre-processing���ޥ�
		/// ��������k�������22�ۭ�����
		/// �A�ˬd  �e�������G  for��᭱  �u�n���@�˪�  �N�O++  �o�ˬO�諸
		/// �i���ӺC    �o�ɤ@�Q  n^2 �O�C ?
		/// ���|  �]�� 3�hrecur �O n^3  �ҥH�O��
		/// ���O�٬O tle
		///
		/// ���O�]�� �������֥[��P��List  �HList�ӻ�  �̫�n�P�_�᭱�۵���  �u��Contains > O n
		///
		/// �����[��P��List  �p�G�n��  �j�M  ���ĪG  dic �� HashSet ���� key unique ������
		/// �ҥH�L�k�����ƭ�  �e�ᶶ�Ǫ�����
		///
		/// �d���[  �̫�ݧO�H���ѵ�  �w�g�ܱ���  �u�t�̫��{���@�}
		///
		/// �W�������D  ��Ӥ�V�N�ѨM�F �]�N�O�e�����Y  �N�O�ι�ڭp�⪺�ɭԥh��
		/// �ܪ������Z  ���N�O�o��
		/// �M��ۦP������   �t�~�Τ@��dictionary  �� ��X�{�ƶq   �o�ˤl�h����
		/// �N����F�W�����ݨD  �S�ֳt
		/// �ӥB�ޥ��ϥΤF  �֥[���֥[
		/// �ثe�� k��  �A�X�{�@��  �N�O���� total+=k �]���s���i�H��ek�ӳ���W  �M��s���A�[�i��
		/// ��s�� k+1
		///
		/// Solved!
		///
		/// 
		/// 
		/// </summary>
		public class Solution
		{
			public int TupleSameProduct(int[] nums)
			{
				int totalSameComb = 0;
				Dictionary<int, int> dic = new Dictionary<int, int>();
				for (int i = 0; i < nums.Length - 1; i++)
				{
					for (int j =  i + 1; j < nums.Length; j++)
					{
						int multi = nums[i] * nums[j];
						if (!dic.ContainsKey(multi))
							dic.Add(multi, 1);
						else
						{
							totalSameComb+= dic[multi];
							dic[multi]++;
						}
					}
				}

				return totalSameComb*8;
			}
		}


		//public class Solution
		//{

		//	HashSet<int> hashSet = new HashSet<int>();
		//	public int TupleSameProduct(int[] nums)
		//	{
		//		hashSet.Clear();
		//		allCombs.Clear();
		//		totalValidComb = 0;

		//		foreach (int num in nums)
		//		{
		//			hashSet.Add(num);
		//		}
				
		//		//find all comb
		//		for (int i = 0; i < nums.Length - 3; i++)
		//		{
		//			hashSet.Remove(nums[i]);
		//			int[] comb = new int[4];
		//			comb[0] = nums[i];
		//			int parentIndex = i;
		//			int recurDepth = 0;
		//			FindCombination(comb, ref recurDepth, parentIndex, nums);
		//		}

				
				
		//		return totalValidComb * 8;
		//	}

		//	List<int[]> allCombs = new List<int[]>();
		//	int totalValidComb = 0;

		//	public void FindCombination(int[] comb, ref int recurDepth, int parentIndex, int[] nums)
		//	{
		//		recurDepth++;
		//		if (recurDepth < 3)
		//		{
		//			for (int j = parentIndex + 1; j < nums.Length; j++)
		//			{
		//				comb[recurDepth] = nums[j];
		//				parentIndex = j;
		//				if (recurDepth < 2)
		//				{
		//					FindCombination(comb, ref recurDepth, parentIndex, nums);
		//				}

		//				if (recurDepth == 2)
		//				{

		//					if (
		//						comb[0] * comb[1] % comb[2] == 0 && hashSet.Contains(comb[0] * comb[1] / comb[2])
		//						||
		//						comb[0] * comb[2] % comb[1] == 0 && hashSet.Contains(comb[0] * comb[2] / comb[1])
		//						||
		//						comb[1] * comb[2] % comb[0] == 0 && hashSet.Contains(comb[1] * comb[2] / comb[0])
		//					)
		//					{
		//						for (int k = j + 1; k < nums.Length; k++)
		//						{
		//							comb[3] = nums[k];
		//							//allCombs.Add(comb.ToArray());
		//							if (comb[0] * comb[1] == comb[2] * comb[3])
		//								totalValidComb++;
		//							if (comb[0] * comb[2] == comb[1] * comb[3])
		//								totalValidComb++;
		//							if (comb[0] * comb[3] == comb[1] * comb[2])
		//								totalValidComb++;

		//						}
		//					}

		//				}
		//			}
		//		}
		//		else
		//		{
					

		//		}
		//		recurDepth--;
		//	}
		//}


	}
}
