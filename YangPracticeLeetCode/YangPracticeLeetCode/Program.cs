using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YangPracticeLeetCode.Solved;

namespace YangPracticeLeetCode
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] s = new[] {"123", "t34", "as", "145"};

            Regex numberReg = new Regex("^[0-9]+");
            
            
            //_892_SurfaceAreaOf3DShapes.Test();
            //_917_IeverseOnlyLetters.Test();
            _937_ReorderLogFiles.Test();


            Console.Read(); 

        }

        
        public class Solution
        {



        }
    }
}
