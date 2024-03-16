namespace LeetCodeSolutions.mediumProblems;

class ThreeSum
{
    record TwoSumResult(int num1, int num2);
    public IList<IList<int>> GetThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();

        var twoSumDict = getTwoSumDict(nums);

        foreach (var n in nums)
        {
            if(twoSumDict.ContainsKey(-n))
            {
                var twoSum = twoSumDict[-n];
                result.Add(new List<int> { n , twoSum.num1, twoSum.num2});
                twoSumDict.Remove(-n);
            }
        }

        return result;
    }


    private Dictionary<int, TwoSumResult> getTwoSumDict(int[] nums)
    {
        var twoSumDict = new Dictionary<int, TwoSumResult>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var sum = nums[i] + nums[j];
                if (!twoSumDict.ContainsKey(sum))
                    twoSumDict.Add(sum, new TwoSumResult(nums[i], nums[j]));       
            }
        }
        return twoSumDict;
    }
}
