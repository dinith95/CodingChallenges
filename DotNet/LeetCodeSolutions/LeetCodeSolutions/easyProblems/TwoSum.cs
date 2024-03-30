namespace LeetCodeSolutions.easyProblems;

// problem: https://leetcode.com/problems/two-sum/
class TwoSum
{
    public int[] GetTwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            var diffIndex = Array.IndexOf(nums, diff);

            if(diffIndex != -1 && diffIndex != i)
                return new int[] { i, diffIndex };
            
        }
        return new int[] { 0, 0 };
    }

    public int[] GetTwoSumOptimized(int[] nums, int target)
    {
        // dictionary to store the number ( key )  and its index ( value )
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            // if the difference is in the dictionary, return the indexes
            if(dict.ContainsKey(diff))
                return new int[] { dict[diff], i };

            // add the number to the dictionary
            dict[nums[i]] = i;
        }
        return new int[] { 0, 0 };
    }
}
