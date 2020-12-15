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
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.StoneGameVII(new int[] { 5, 3, 1, 4, 2 }));
			//Console.WriteLine(s.StoneGameVII(new int[] { 7, 90, 5, 1, 100, 10, 10, 2 }));
			//Console.WriteLine(s.StoneGameVII(new int[] { 3, 5 }));

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
		/// 
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
					string p = alice ? "A" : "B";

					int num1=0, num2 = 0;
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
				Console.WriteLine($"{p} scoreRemoveFirst({start+1},{end+1}): {scoreRemoveFirst}  scoreRemoveLast({start},{end}): {scoreRemoveLast}");

				if (alice)
				{

					int num1 = findDifference(start + 1, end, !alice);//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2 = findDifference(start, end - 1, !alice);
					int num1SRF = num1 + scoreRemoveFirst;//��Ӱ϶��N�O�o�˨S��  �_�W�ө����Ω��k���@��
					int num2SRL = num2 + scoreRemoveLast;

					difference = Math.Max(num1SRF, num2SRL);
					Console.WriteLine($"A, s1n  diff from {start +1} to {end}  is {num1} ,  +scoreRemoveFirst:{scoreRemoveFirst} = {num1SRF}");
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
				int res =  Math.Abs(findDifference(0, n - 1, true));
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

				int[,] dp = new int[n,n];


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
						dp[start,end] = Math.Max(scoreRemoveFirst - dp[start + 1,end],
							scoreRemoveLast - dp[start,end - 1]);

					}
				}
				return dp[0,n - 1];
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
							while (i1 + 1 < j1 -1)
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
