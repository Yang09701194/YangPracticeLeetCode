using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangPracticeLeetCode.OtherProblem
{
    public class MultipleOf3
    {
        public static bool IsMultipleOf3(int input)
        {
            return (input / 3) * 3 == input;
        }
        
    }
}
