using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions.mediumProblems
{
    // question link https://leetcode.com/problems/integer-to-roman/
    public class IntToRoman
    {
        public string NumberToRoman(int num)
        {
            Dictionary<int, string[]> romanLetterMap = new Dictionary<int, string[]>()
            {
                { 1000, new string[]{"", "M", "MM", "MMM" } },
                {100, new string[]{ "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" } },
                {10, new string[]{ "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"} },
                {1,new string[]{ "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" } }
            };
            string result = string.Empty;
            foreach (KeyValuePair<int, string[]> valuePair in romanLetterMap)
            {
                if (num == 0)
                    return result;
                // integer divison of num by the positional element , eg ; 1000 in the first case 
                // result is passed to the string array to get romna number
                result += valuePair.Value[num / valuePair.Key];
                num = num % valuePair.Key;
            }

            return result;

        }

    }
}
