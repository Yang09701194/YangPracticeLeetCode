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
			Console.WriteLine(s.StoneGameVII(new int[] { 7, 90, 5, 1, 100, 10, 10, 2 }));
			//Console.WriteLine(s.StoneGameVII(new int[] { 3, 5 }));

		}

		public class Solution
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
