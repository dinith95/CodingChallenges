namespace LeetCodeSolutions.mediumProblems;

// problem: https://leetcode.com/problems/custom-sort-string/
class CustomSortString
{
    public string GetCustomSortString(string order, string str)
    {
        Dictionary<char, int> orderMap = new Dictionary<char, int>();
        var result = string.Empty;

        // create ampping of the character and its counts in the string 
        foreach (var c in str)
        {
            // if the character is there increase the count 
           if(orderMap.ContainsKey(c))
                orderMap[c] += 1;
           // if the character is not there add it to the map
           else
               orderMap.Add(c, 1);
        }

        // iterate through the order string and add the characters to the result string
        foreach (var c in order)
        {
            if (orderMap.ContainsKey(c))
            {
                int count = orderMap[c];

                for (int i = 0; i < count; i++)
                    result += c;

                orderMap.Remove(c); // remove the character from the map as it is already processed
            }
        }

        // add the remaining characters to the result string
        foreach (var character in orderMap)
        {
            for (int i = 0; i < character.Value; i++)
                result += character.Key;
        }

        return result;
    }   
}
