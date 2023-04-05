using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions.mediumProblems
{
    // question link https://leetcode.com/problems/integer-to-roman/
    public class RomanToInt
    {
        public string IntToRoman(int num)
        {
            string finalResult = string.Empty;
            Dictionary<int, char> romanIntMap = new Dictionary<int, char>()
            {
                {1000, 'M' } ,{500 , 'D'} , {100, 'C'} , {50, 'L'} , {10, 'X'}, {5, 'V'}, {1, 'I'}
            };

            foreach (KeyValuePair<int,char> keyValuePair  in romanIntMap)
            {
                 (string result,num) = RecursivelyMap(num, keyValuePair.Key, keyValuePair.Value);
                if (result == "_")
                    finalResult = HandleSpecialCase(finalResult, keyValuePair.Value);
                else
                    finalResult += result;          
            }
            return finalResult;
           
        }

        private string HandleSpecialCase(string finalResult , char charLetter)
        {
            if (charLetter == 'C' && finalResult.EndsWith('D'))
               return  finalResult.Replace("D", "CM");

            if (charLetter == 'C' && finalResult.EndsWith('M'))
                return finalResult.Replace("M", "MD");

            if (charLetter == 'X' && finalResult.EndsWith('C'))
                return finalResult.Replace("C", "XL");

            if (charLetter == 'X' && finalResult.EndsWith('L'))
                return finalResult.Replace("L", "XC");

            if (charLetter == 'I' && finalResult.EndsWith('V'))
                return finalResult.Replace("V", "IX");

            if (charLetter == 'I' && (finalResult.EndsWith('X') || finalResult)
                return finalResult.Replace("X", "IV");
            return finalResult;
        }


        private (string,int) RecursivelyMap(int numtoConvert, int placeValue, char romanLetter)
        {
            string result = string.Empty;
            int quotient = (int)(numtoConvert / placeValue);
            if(quotient > 3)
                return ("_", numtoConvert % placeValue);
            for (int i = 0; i < quotient; i++)
                result += romanLetter;
            return (result, numtoConvert % placeValue);
        }

    }
}
