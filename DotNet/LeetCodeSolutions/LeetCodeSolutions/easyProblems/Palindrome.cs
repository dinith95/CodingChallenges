namespace LeetCodeSolutions.easyProblems;

// problem: https://leetcode.com/problems/palindrome-number/
class Palindrome
{
    // average on the memory side and the runtime 
    public bool IsPalindrome(int x)
    {
        // negative numbers are not palindrome because of the - sign
        if(x < 0)
            return false;   

        var numStr = x.ToString();
        int midPoint =  numStr.Length / 2 ; 

        for (int i = 0; i < midPoint; i++)
        {
            if (numStr[i] != numStr[numStr.Length - 1 - i])
                return false;
        }
        return true;
    }

    // this is taken from the number reversal
    // performs well on the memory side 
    public bool isPalindrome2(int x)
    {
        // numbers less than 0 are not palindrome because of the - sign
        if(x < 0)
            return false;

        int temp = x;
        int reversed = 0;

        while(temp > 0)
        {
            var lastDigit = temp % 10;
            temp = temp / 10;
            reversed = reversed * 10 + lastDigit; 
        }

        return reversed == x;
    }
}
