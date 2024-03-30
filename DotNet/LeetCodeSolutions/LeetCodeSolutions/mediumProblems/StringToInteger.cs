namespace LeetCodeSolutions.mediumProblems;

class StringToInteger
{
    public int MyAtoi(string s)
    {
        bool isNegative = false;
        bool startProcessing = false;
        int result = 0;
        // return 0 if string is empty
        if(string.IsNullOrEmpty(s))
            return 0;   

        // ignore surrounding white spaces
        s = s.Trim();

        for (int i =0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '-' || c == '+')
            {
                // if there is not a digit after the sign, then return 0
                if(i+1 >= s.Length)
                    return 0;

                // if the next character is not a digit, then return 0
                var nextchar = GetDigit(s[i+1]);
                if(nextchar < 0)
                    return 0;

                isNegative = c == '-';
                continue;
            }


            int digit = GetDigit(c);
            
            if(digit >= 0)
            {
                // check if the computed result will be greater than int.MaxValue
                // if yes , then return int.MaxValue
                if (result > (int.MaxValue - digit) / 10 )
                    return isNegative ? int.MinValue : int.MaxValue;

                result = result * 10 + digit;  
                
            }
            // if the returned digit is -1, then the character is not a digit
            else
            {
                break; // if the character is not a digit, then we should stop processing
            }          
        }
        return isNegative ? -result : result;
    }

    private int GetDigit(char c) => c switch
    {
        '0' => 0,
        '1' => 1,
        '2' => 2,
        '3' => 3,
        '4' => 4,
        '5' => 5,
        '6' => 6,
        '7' => 7,
        '8' => 8,
        '9' => 9,
        _ => -1
    };
     
    
}
