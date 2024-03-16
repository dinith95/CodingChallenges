using System.Dynamic;

namespace LeetCodeSolutions.mediumProblems;

// https://leetcode.com/problems/reverse-integer/description/
class ReverseInteger
{
    public int GetReverseInt(int x)
    {
        if(x >= int.MaxValue || x <= int.MinValue)
            return 0;

        int num = Math.Abs(x);
        int result = 0;

        while(num >= 1)
        {
            var rem = num % 10;
            num = num / 10;

            if((int.MaxValue - rem)/10 < result)
                return 0;

            result = result * 10 + rem;          
        }

        return x < 0 ? -result : result;
    }
}
