using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangPracticeLeetCode.Helper;

namespace YangPracticeLeetCode.Solved
{
	class _347_TopKFrequentElements
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			//Console.WriteLine(s.SpecialArray(new int[] { 3, 5 }));

		


			//        O nlogn (Order)  O n  (Bucket)
			//  ��   �ɶ�
			//  
			//  �᭱�϶W
			//
			
			int[] testCases = new int[]
			{
				//300, 3000, 30000, 300000,3000000, 30000000,
				300000000
			};

			foreach (int testCase in testCases)
			{
				List<int> test = new List<int>();
				//for (int i = 1; i < 10000; i++)
				//{
				//	for (int j = 0; j < i; j++)
				//	{
				//		test.Add(i);
				//	}
				//}
				Random r = new Random();
				for (int i = 1; i < testCase; i++)
				{
					test.Add(r.Next(testCase/10000));
				}

				int topK = testCase / 10000;
				var ta = test.ToArray();
				Console.WriteLine("length: " + ta.Length + " top: " + topK);
				Solution_RemoveMax so = new Solution_RemoveMax();
				Solution_BucketSort sb = new Solution_BucketSort();
				TimerY t = TimerY.New();
				so.TopKFrequent(ta, topK);
				Console.WriteLine("so " + t.TimingMs());
				t = TimerY.New();
				sb.TopKFrequent(ta, topK);
				Console.WriteLine("sb " + t.TimingMs());

			}
			// length: 299999999 top: 30000

			// RemoveMax
			// 13673.8614    //�ƨC�Ӽƪ�freq
			// 3.9296        //freq���s
			// 3.9041        //���ek
			// 13686.5751

			// Bucket
			// 15042.0228
			// 0.974
			// 2205.1969
			// sb 17252.1434

			// ���G��  �e��B�J�����Ʊ����t���h  �ɶ��]�t���h  ���O�@��
			// �u���̫�@�B�����j�t�Z
			// ���ӬO�]��  bucket �|�@��ŭ�  �]���L��freq bucket �}�ӲӤӤj�F
			// removemax �ܺ��  �]���o�N�O�Ҧ��s�b��freq���� �ܺ��
			// �ҥH�@��max remove  �ʧ@�ֶ̤q
			//  ���� max �N�O�ȩȪ� O n   ����N�O  �Ȫ�  n^2
			//  ���O�۸����U  freq�ֶq���    �ҥH�ϦӤ� bucket��
			//  �o�ӯŶZ�O bucket�O�}�ۦP���� 3 ��
			//  ���removemax  �]�� 30000�ӼƦr  �̥����|�Ofreq = 10000  �ҥH���h30000 �i��֫ܦh
			//  �ҥH�N�t10000��   ��ڶ]�t1000�����k
			//  �ҥH O ���@�w�����M�w   �򰵪k�٬O����  ���k���P  O �� n�N�S���P�F
			//  �Ϊ̬O��   bucket �O O n    removeMax �O O k^2
			//  
			//  ���O�o�� k �N�ܦ���
			//  k �p����  ���λ�  �̫�@�B�� �@�w�W��
			// �n��ɶ��̪� �Ҽ{ k �̤j    �]��  k�Ӽ� * ����freq =  �}�C��n
			// �[�W�̫��� �O freq �� k ��̤p����  �M�w�ɶ�
			//  freq���P�Ʀp�G�p k �A�j �@�U�l�N�[��    �C��freq�����j�q��
			//  k�p   freq�A�j  �]�u��k��
			//  
			//  �ҥH�]��   k * freq = n
			//  �ҥH k freq �� min �n�̤j  �N�O�}�ڸ�  
			//  �ڸ��@�U�h  ���W�N�p�ܦh�F   �N�֫ܦh  n^1/2  
			//  �ҥH O��  k  freq �M�w   ���N�u���p�ܦh  �]�֫ܦh
			//  �ҥH O k freq  �� O n �@�w�֫ܦh
			//

			 
		}


		/// <summary>
		/// 
		/// </summary>
		public class Solution_RemoveMax
		{
			public int[] TopKFrequent(int[] nums, int k)
			{
				var numFreq = new Dictionary<int, int>();

				var t = TimerY.New();

				foreach (int num in nums)//�ƨC�Ӽƪ�freq
				{
					if (numFreq.ContainsKey(num))
					{
						numFreq[num]++;
					}
					else
					{
						numFreq.Add(num, 1);
					}
				}

				t.TimingMs(true);
				t = TimerY.New();

				var freqNum = new Dictionary<int, HashSet<int>>();
				foreach (int num in numFreq.Keys)//freq���s
				{
					int freq = numFreq[num];
					if (freqNum.ContainsKey(freq))
					{
						freqNum[freq].Add(num);
					}
					else
					{
						freqNum.Add(freq, new HashSet<int> { num });
					}
				}

				t.TimingMs(true);
				t = TimerY.New();

				List<int> res = new List<int>();
				while (k > 0)//���ek
				{
					int maxFreq = freqNum.Keys.Max();
					res.AddRange(freqNum[maxFreq].ToList());
					k -= freqNum[maxFreq].Count();
					freqNum.Remove(maxFreq);
				}

				t.TimingMs(true);
				t = TimerY.New();

				return res.ToArray();
			}
		}


		public class Solution_BucketSort
		{
			public int[] TopKFrequent(int[] nums, int k)
			{

				List<int>[] bucket = new List<int>[nums.Length + 1];
				Dictionary<int, int> frequencyDictionary = new Dictionary<int, int>();

				var t = TimerY.New();
				foreach (int n in nums)//�ƨC�Ӽƪ�freq
				{
					if (frequencyDictionary.ContainsKey(n))
						frequencyDictionary[n]++;
					else
						frequencyDictionary[n] = 1;
				}

				t.TimingMs(true);
				t = TimerY.New();

				foreach (int key in frequencyDictionary.Keys)//freq���s
				{
					int frequency = frequencyDictionary[key];
					if (bucket[frequency] == null)
					{
						bucket[frequency] = new List<int>();
					}
					bucket[frequency].Add(key);
				}
				t.TimingMs(true);
				t = TimerY.New();


				List<int> res = new List<int>();//���ek
				for (int pos = bucket.Length - 1; pos >= 0 && res.Count() < k; pos--)
				{
					if (bucket[pos] != null)
					{
						res.AddRange(bucket[pos]);
					}
					//else
					//{
					//	//Console.WriteLine("null");
					//}
				}
				t.TimingMs(true);
				t = TimerY.New();


				return res.ToArray();
			}
		}


	}
}
