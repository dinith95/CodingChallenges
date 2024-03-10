using System.Net;

namespace LeetCodeSolutions.mediumProblems;

// https://leetcode.com/problems/longest-palindromic-substring/
class LongestPalindromeSubstring
{
    private readonly object resultStrLock = new object();
    public string LongestPalindrome(string s)
    {
        if(s.Length == 1)
            return s;
        if (s.Length == 2 )
            return s[0] == s[1] ? s : s[0].ToString();

        int point = s.Length / 2;
        var resultStr = string.Empty;
      
        Task t1 = PropogateRight(s, point, ref resultStr);
        Task t2 = ProppgateLeft(s, point, ref resultStr);
       
        Task.WaitAll(t1, t2);
        return resultStr;
    }

    private Task PropogateRight(string s, int right, ref string resultStr)
    {
        // between the right and end ( index s.Length - 1 )  should has atleast half of the
        // charaters in result string to be able to find a longer palindrome
        while ((right + resultStr.Length / 2) < s.Length - 1)
        {
            var p1 = ExpandAroundIndex_OddPalindrome(s, right);

            lock (resultStrLock)
            {
                if (p1.Length > resultStr.Length)
                    resultStr = p1;
            }
           
            // check for even palindrome
            if (right + 1 < s.Length && s[right] == s[right + 1])
            {
                var p2 = ExpandAroundIndex_EvenPalindrome(s, right, right + 1);
                
                lock (resultStrLock)
                {
                    if (p2.Length > resultStr.Length)
                        resultStr = p2;
                }         
            }
            right += 1;
        }
        return Task.CompletedTask;
    }

    private Task ProppgateLeft(string s, int left, ref string resultStr)
    {
        // between the left and start ( index 0 )  should has atleast half of the
        // charaters in result string to be able to find a longer palindrome
        while ((left - resultStr.Length / 2) >= 0)
        {
            var p1 = ExpandAroundIndex_OddPalindrome(s, left);

            lock (resultStrLock)
            {
                if (p1.Length > resultStr.Length)
                    resultStr = p1;
            }
         
            // check for even palindrome
            if (left > 0 && s[left] == s[left - 1])
            {
                var p2 = ExpandAroundIndex_EvenPalindrome(s, left - 1, left);
                lock (resultStrLock)
                {
                    if (p2.Length > resultStr.Length)
                        resultStr = p2;
                }         
            }
            left -= 1;
        }
        return Task.CompletedTask;
    }

    private string ExpandAroundIndex_OddPalindrome(string s, int pos)
    {
        bool isPalindrome = true;
        int left = pos;
        int right = pos;
        while (isPalindrome && left > 0 && right +1 < s.Length)
        {
            left -= 1;
            right += 1;
            isPalindrome &= s[left] == s[right];

            // if palidrome is not valid reset the left and right
            if (!isPalindrome)
            {
                left += 1;
                right -= 1;
            }
        }

        // adding 1 since converting number of characters from index
        return s.Substring(left , right + 1 - left) ; 
    }

    private string ExpandAroundIndex_EvenPalindrome(string s, int left, int right)
    {
        bool isPalindrome = true;
         
        while (isPalindrome && left - 1 >= 0 && right + 1 < s.Length)
        {     
            left -= 1;
            right += 1;
            isPalindrome &= s[left] == s[right];
            // if palidrome is not valid reset the left and right
            if (!isPalindrome)
            {
                left += 1;
                right -= 1;
            }
        }

        // adding 1 since converting number of characters from index
        return s.Substring(left , right + 1 - left);
    }   
}
