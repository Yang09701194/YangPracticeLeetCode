using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _395_LongestSubstringwithAtLeastKRepeatingCharacters
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.LongestSubstring("aaabbb", 3));//3
			Console.WriteLine(s.LongestSubstring("aaabb", 3));//3
			Console.WriteLine(s.LongestSubstring("ababbc", 2));//5
			Console.WriteLine(s.LongestSubstring("ababacb", 3));//0
			Console.WriteLine(s.LongestSubstring("bbaaacbd", 3));//3
			Console.WriteLine(s.LongestSubstring("aaaaaaaaaaaaaaaabbbbbbbbbbbbaaaaaaabbbbbbbbbbbbcccccccccccdddddddddddddddddddeeeeeeeeeeeeeeefffffffffffffffgggggggggggggggggggghhhhhhhhhhhhhhhhiiiiiiiiiiiiiiiiiiiiiijjjjjjjjjjjjjjjjjjjjjjjjkkkkkkkkkkkkkkkkkkkk", 20));//66
			Console.WriteLine(s.LongestSubstring("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiijjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz", 301));//301


		}


		/// <summary>
		/// �o�D�O�a�L���� Dynamic Programming �ѤW�ѹL�����X�D  �����z�[�ȵ����D�g��  �N������g�{���X  �a�⮩��DP�믫  �������X�ӭn�o�˰���
		/// ��²�檺DP �O �@�����ƦC���e�����Y   �a�ۤv���ɥX�o�D�� �@���W �C�Ӧ�m���O�@�Ӧh���}�C
		/// �e��۴�|��o�r�ꪬ�A�t��
		///
		/// �t�~�ۤv�Q�X�o�D�D�رo�쪺�W�h
		/// 
		/// 1 �@�}�lŪ�֩w�O����  ���O���ۨ���  �p�G�b�Y���I���\�F   ���q�̶}�l��o���I���⦨�\
		///   �ҥH�e�����\����   �������״N�O  �}�l-�̫�@�Ӧ��\�I
		/// 2 �p�G�̫�@�Ӧ��\�᭱������  �N��N�O���Ѩ쩳
		/// ���O���Ѫ�����   �i��|�]���h���ֳ������Ѫ�  �N�ܦ����\
		/// �ҥH�̫ᥢ�Ѫ�����  �]���l�r��i��b���N�_��W
		/// �ҥH�N�μɤO�k  n x n ���I��������  ���̪����\��
		///
		/// ���O�ɤO�k�S��k�q�L�̫�@��TLE
		/// �ҥH��  �s��r��  �������I�������L������  �Ҧp  abbbbc  �̤��������b�i�H���L
		/// �]����ӳs��r��  �n���j��k ���N����  ���M�p��k�N����
		/// �N�i�HAccepted
		///
		/// ���쥻���L���I �� List��   Contains�ˬd�ӺC  TLE
		/// �令��Dictionary�N�L�F 
		/// 
		/// �S�A���u��   �s���L�o�Ӱʧ@���ٱ�  �令�u�]���θ��L��    �S����  �N�O�o��
		///
		/// 
		/// </summary>
		public class Solution
		{
			public int LongestSubstring(string s, int k)
			{
				Func<char, int> toAscii = c =>
				{
					return Convert.ToInt32(c) - 97;
				};
				//int i3 = Convert.ToInt32('a'); //97
				//int i2 = Convert.ToInt32('z'); //132

				List<int[]> dpCharCouSnapShot = new List<int[]>();
				int[] charCou = new int[26];

				for (int i = 0; i < s.Length; i++)//O n
				{
					charCou[toAscii(s[i])] += 1;
					dpCharCouSnapShot.Add(charCou.ToArray());
				}



				bool[] matchOrNotArr = new bool[s.Length];

				for (int i = 0; i < s.Length; i++)// O 26n
				{
					bool isMatch = true;
					for (int j = 0; j < charCou.Length; j++)
					{
						if (dpCharCouSnapShot[i][j] != 0 && dpCharCouSnapShot[i][j] < k)
						{
							isMatch = false;
							break;
						}
					}

					matchOrNotArr[i] = isMatch;
				}

				List<int> successPos = new List<int>();
				for (int i = 0; i < matchOrNotArr.Length; i++) //O n
				{
					if (matchOrNotArr[i])
						successPos.Add(i);
				}

				int maxLength = 0;
				int lastFailStart = -1;
				int lastFailEnd = -1;
				if (successPos.Any())// O 1
				{
					int lastSucPos = successPos.Last();
					maxLength = lastSucPos + 1;

					if (lastSucPos < s.Length - 1)
					{
						lastFailStart = lastSucPos + 1;
						lastFailEnd = s.Length - 1;
					}
				}
				else
				{
					lastFailStart = 0;
					lastFailEnd = s.Length - 1;
				}


				int[] skipMiddleContiPos = new int[s.Length];
				char prevChar = ' ';
				int contiCharCou = 0;
				for (int i = 0; i < s.Length; i++)// O n
				{
					if (s[i] != prevChar)
					{
						prevChar = s[i];
						contiCharCou = 1;
					}
					else
					{
						contiCharCou++;
						if (contiCharCou >= 3)
							skipMiddleContiPos[i - 1] = -1;
					}
				}
				List<int> validPos = new List<int>();// ��lastFailStart�өw  �j����  ��O�N��  worst O n
				for (int i = lastFailStart; i < skipMiddleContiPos.Length && i != -1; i++)
				{
					if (skipMiddleContiPos[i] == 0)
						validPos.Add(i);
				}

				//�ɤO�p������_�W�զX���r��
				for (int i = 0; i < validPos.Count(); i++)//  �s�򪺦r���h �|��n�p�ܦh  lastFailStart�j �]�|�p  ��L�Ϥ�     worst 26n
				{
					//if (skipMiddleContiPos.ContainsKey(i))
					//	continue;
					for (int j = 0; j < validPos.Count(); j++)
					{
						//if(i == 208 && j == 143)
						//	Console.WriteLine();
						//if (skipMiddleContiPos.ContainsKey(j))
						//	continue;

						int iV = validPos[i];
						int jV = validPos[j];

						if (iV < jV)
						{
							var iArr = dpCharCouSnapShot[iV].ToArray();
							var jArr = dpCharCouSnapShot[jV].ToArray();

							for (int l = 0; l < jArr.Length; l++)
							{
								jArr[l] -= iArr[l];
							}

							bool isMatch = true;
							for (int m = 0; m < charCou.Length; m++)  //26
							{
								if (jArr[m] != 0 && jArr[m] < k)
								{
									isMatch = false;
									break;
								}
							}

							if (isMatch && (jV - iV > maxLength))
								maxLength = jV - iV;

						}
					}
				}

				return maxLength;

			}
		}


		//��껡�_�ӳo�䪺���k  �M�ڤW��  �O���I����
		//discuss top vote
		public class Solution2
		{
			public int LongestSubstring(String s, int k)
			{
				char[] str = s.ToCharArray();
				int[] counts = new int[26];
				int h, i, j, idx, max = 0, unique, noLessThanK;

				for (h = 1; h <= 26; h++)
				{
					counts = new int[26];
					i = 0;
					j = 0;
					unique = 0;
					noLessThanK = 0;
					while (j < str.Length)
					{
						if (unique <= h)
						{
							idx = str[j] - 'a';
							if (counts[idx] == 0)
								unique++;
							counts[idx]++;
							if (counts[idx] == k)
								noLessThanK++;
							j++;
						}
						else
						{
							idx = str[i] - 'a';
							if (counts[idx] == k)
								noLessThanK--;
							counts[idx]--;
							if (counts[idx] == 0)
								unique--;
							i++;
						}
						if (unique == h && unique == noLessThanK)
							max = Math.Max(j - i, max);
					}
				}

				return max;
			}
		}

		//���U�Ӭ�  LC �� Sol 2
		//  Divide And Conquer �зǰ_�⦡
		//longestSustring(start, end) = max(longestSubstring(start, mid), longestSubstring(mid+1, end))
		//��� Master Theorem ���I����

		//�J�Ӭݳo��  �n�o����
		//��ڭ쥻�Q�쪺�F�� �A���e���i�F�@�B  �ڴN�O�t�o�@�B  �ҥH�~�S���~�򩹤U��
		//�Ĥ@�ӷQ�쪺�@�w�O ��Ӧr��  �X�k��  ��n�����N�d�@�Ӥ��X�k��
		//�Υd���   
		//���ڱ��U�Ӫ��Q�k�N����   �q�Y�}�l  �����J�줣�X�k��  �i��̫�ֿn�����ܦX�k��
		//�ҥH�ڴN��   �e�����\  �᭱����  �������W�h�F
		//��ӧ䤣�X�k��   �̪����N�|�Q��  �Ƨ��Ĥ@��  �S����   �u�|���D�����i��O���\�� ���O�S�|���T�w  �]���O���Ӫ�   �����@�Ҽ{�B�X�k�I�������l�r��  �N�����n����    �ҥH���Ӫ��S�S�ΤF
		//�p�G�S������  divide and conquer���[�� �N���|���D  �o���O d a c ���}�ݴN�O���o��  �o�˪��ðݭ�n�N�O�M�� d a c������
		//�ڤ��e�L��M�]�����L  �]���ȵ��m�L  ���L��o��N���|�۵M�M��   �]��O�h�ǲߤF�@��
		//���O�A�� time compl���R   ���V�]�O O n^2  �A�U�@�� Sliding Window �u�n26N
		//�i�����O d a c �N�n�δ�    �ҥH�Rpremium���ӯu������  ����h�H�b���n�R  �O���D�z��
		//
		//�J�M�n�m  �ڴN�θ��z�ѫ�  �ۤv�Τ�Ө�X�{��  ����ans
		//�N�a�o�y //longestSustring(start, end) = max(longestSubstring(start, mid), longestSubstring(mid+1, end))

		//��껡�_�ӳo�䪺���k  �M�ڤW��  �O���I����
		//public class Solution3
		//{
		//	public int LongestSubstring(String s, int k)
		//	{
		//		Func<char, int> toAscii = c =>
		//		{
		//			return Convert.ToInt32(c) - 97;
		//		};
		//		Func<int, char> toChar = i =>
		//		{
		//			return (char)i;
		//		};

		//		//int i3 = Convert.ToInt32('a'); //97
		//		//int i2 = Convert.ToInt32('z'); //132
		//		int[] charCou = new int[26];

		//		for (int i = 0; i < s.Length; i++)//O n
		//		{
		//			charCou[toAscii(s[i])] += 1;
		//		}

		//		char lessKChar = ' ';
		//		for (int i = 0; i < charCou.Length; i++)
		//		{
		//			if (charCou[i] < k)
		//			{
		//				lessKChar = toChar(i);
		//			}
		//		}

		//		if (lessKChar ==' ')
		//			return s.Length;

		//		int lessKCharPos = -1;
		//		for (int i = 0; i < s.Length; i++)//O n
		//		{
		//			//	�g��o��  ��Mı�o  �u�n�O���j��k  �̭��A����Ӥl�I�s��  �n�����s�� D A C   ��Fibonacci�o�ذ�¦�`�����@�k  
		//			if()
		//		}

		//		//  ���Φ�m�N�O LessCharASCII  
		//		return lessKCharAscii[i]
		//	}
		//}

	}
}
