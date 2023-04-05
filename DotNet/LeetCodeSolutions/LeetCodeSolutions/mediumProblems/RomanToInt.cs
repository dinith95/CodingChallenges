using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions.mediumProblems
{
    public class RomanToInt
    {

        public int GetIntNumber(string romanNumber)
        {
            Dictionary<char, int> romanLetterMap = new Dictionary<char, int>()
            {
                {'M',1000 } , {'D', 500} , {'C', 100} , {'L', 50} , {'X', 10}, {'V', 5} , {'I',1}
            };
            int result = 0;
            for (int i = 0; i < romanNumber.Length; i++)
            {
                int num = 0;
                int numNext = 0;
                romanLetterMap.TryGetValue(romanNumber[i], out num);
                if (i + 1 < romanNumber.Length)
                {
                    // this is done to correct values for numbers like : IV , IX, XC , XL 
                    romanLetterMap.TryGetValue(romanNumber[i + 1], out numNext);
                    if (numNext > num)
                        result -= num;
                    else
                        result += num;
                }
                else
                    result += num;
            }

            return result;
        }
    }
}
