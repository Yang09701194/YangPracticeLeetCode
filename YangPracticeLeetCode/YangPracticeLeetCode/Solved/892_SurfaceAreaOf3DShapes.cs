using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.Solved
{
    /// <summary>
    /// https://leetcode.com/problems/surface-area-of-3d-shapes/description/
    /// </summary>
    public class _892_SurfaceAreaOf3DShapes
    {
        static void Test(string[] args)
        {

            Solution s = new Solution();


            int[][] grid2 = new int[2][];
    
            grid2[0] = new[] { 1, 2 };
            grid2[1] = new[] { 3, 4 };



            int[][] grid3 = new int[3][];

            grid3[0] = new[] { 1, 1, 1 };
            grid3[1] = new[] { 1, 0, 1 };
            grid3[2] = new[] { 1, 1, 1 };


            Console.WriteLine(s.SurfaceArea(grid2));
            Console.WriteLine(s.SurfaceArea(grid3));
            Console.Read();

        }


        public class Solution
        {
            public int SurfaceArea(int[][] grid)
            {
                int sideLength = grid.Count();

                //上方和下方的表面積
                int counOf0 = 0;
                foreach (var row in grid)
                    foreach (var column in row)
                        if (column == 0)
                            counOf0 += 1;
                int topAndDown = (grid.Count() * grid.Count() - 2 * counOf0) * 2;

                //前後左右的表面積
                int outside = 0;
                for (int i = 0; i < sideLength; i++)
                {
                    outside += grid[0][i];
                    outside += grid[i][0];
                    outside += grid[sideLength - 1][i];
                    outside += grid[i][sideLength - 1];
                }


                //內部的方塊高度差的表面積
                int inside = 0;
                //由左往右互減
                for (int i = 0; i < grid.Count(); i++)
                {
                    for (int j = 0; j < grid[i].Count() - 1; j++)
                        inside += Math.Abs(grid[i][j] - grid[i][j + 1]);
                }
                //由上往下互減
                for (int i = 0; i < sideLength; i++)
                {
                    for (int j = 0; j < sideLength - 1; j++)
                        inside += Math.Abs(grid[j][i] - grid[j + 1][i]);
                }

                return topAndDown + outside + inside;
            }
        }


    }
}
