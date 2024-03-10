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
}
