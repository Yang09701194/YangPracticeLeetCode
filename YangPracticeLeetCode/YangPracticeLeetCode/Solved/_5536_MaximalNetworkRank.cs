using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
	class _5536_MaximalNetworkRank
	{

		public static void Test()
		{
			Solution s = new Solution();

			//Console.WriteLine(s.NumPoints());

			Console.WriteLine(s.MaximalNetworkRank(5,
				new int[][]
				{
					new int[]{0,1},new int[]{0,3},new int[]{1,2},new int[]{1,3},new int[]{2,3},new int[]{2,4}
				}));

			Console.WriteLine(s.MaximalNetworkRank(5,
				new int[][]
				{
					new int[]{0,1},new int[]{1,2},new int[]{2,3},new int[]{2,4},new int[]{5,6},new int[]{5,7}
				}));



		}



		/// <summary>
		/// �o�D�ۤv�Q�X�Ӫ�   �]���O contest �D   �ƾ��٤��h  �ҥH�F�� 100 100     �ҥH���S��discuss
		/// �o�D��������   �s����@���I���u���ƶq  ���󪽱��p��  �Ҧ��䪺���I�X�{������
		/// �򥻤W�`�׬�s�L dfs bfs ����  ���Ϫ��D�ثܦ����U  �H�o�D�ӻ�  ��Adjacency List������  ���D�ϳo��������F��  ��adj List �]�N�O����I�����X  �N�i�H�u������ܧ��㪺��  �O�@�Ӻ�����  �����D�|������  �@�z�ѫ᪾�D�N�|�����ܦ��O��  �n�Τu��
		/// 
		/// �ҥH�p���I�s����Ƥ���    ���̤j���e���  ����S�O���O  �ĤG�W�i�঳�ܦh���I����Ƴ��ۦP
		/// �o�ɭԴN�|�t�b���S�����I�����۳s����n��@  �ҥH�N��ĤG�W�P�ƶq�������զX  ���p��@�M  ���̤j�Ȫ�����I
		///
		/// �ˬd���I�����۳s �ΰ}�C�M���ܺC  �ҥH��Chr���ޥ�  key_key  dic
		/// </summary>
		public class Solution
		{
			public int MaximalNetworkRank(int n, int[][] roads)
			{
				if (roads.Length == 0)
					return 0;

				Dictionary<string,string> roadStr = new Dictionary<string, string>();

				Dictionary<int,int> numCou = new Dictionary<int, int>();
				for (int i = 0; i < roads.Length; i++)
				{
				
					for (int j = 0; j <= 1; j++)
					{
						if (!numCou.ContainsKey(roads[i][j]))
							numCou[roads[i][j]] = 1;
						else
							numCou[roads[i][j]]++;
					}

					roadStr[$"{roads[i][0]}_{roads[i][1]}"] = "";

				}

				var orderCou = numCou.OrderByDescending(kv => kv.Value).ToList();


				int secondMaxCou = orderCou[1].Value;

				var gEqSec = orderCou.Where(c => c.Value >= secondMaxCou).ToList();

				List<List<KeyValuePair<int,int>>> pairs = new List<List<KeyValuePair<int, int>>>();
				for (int i = 0; i < gEqSec.Count; i++)
				{
					for (int j = i + 1; j < gEqSec.Count; j++)
					{
						pairs.Add(new List<KeyValuePair<int, int>>() {gEqSec[i], gEqSec[j]});
						
					}
				}

				int maxRes = 0;
				for (int i = 0; i < pairs.Count; i++)
				{
					int max1 = pairs[i][0].Key;
					int max2 = pairs[i][1].Key;
					int max1Cou = pairs[i][0].Value;
					int max2Cou = pairs[i][1].Value;

					int sum = max1Cou + max2Cou;
					if (roadStr.ContainsKey($"{max1}_{max2}") || roadStr.ContainsKey($"{max2}_{max1}"))
						sum -= 1;
					if (sum > maxRes)
						maxRes = sum;
				}
				
				return maxRes;
			}
		}


	}
}
