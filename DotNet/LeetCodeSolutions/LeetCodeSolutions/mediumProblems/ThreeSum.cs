namespace LeetCodeSolutions.mediumProblems;

class ThreeSum
{
    record TwoSumResult(int pos1, int pos2);
    public IList<IList<int>> GetThreeSum(int[] nums)
    {
        var resultDict = new Dictionary<string,IList<int>>();

        var twoSumDict = getTwoSumDict(nums);

        for (int i =0; i < nums.Length; i++)
        {
            var n = nums[i];
            if (twoSumDict.ContainsKey(-n))
            {
                var twoSumList = twoSumDict[-n];
                foreach (var item in twoSumList)
                    ProcessTwoSumMatch(item,nums, resultDict, i);
            }
        }

      return resultDict.Values.ToList();
       
    }

    private void ProcessTwoSumMatch(TwoSumResult twoSum,int[] nums, Dictionary<string, IList<int>> resultDict, int i)
    {
        if (i == twoSum.pos1 || i == twoSum.pos2)
            return;

        var resultList = new List<int> { nums[i], nums[twoSum.pos1], nums[twoSum.pos2] };
        resultList.Sort();
        var indexstr = string.Join("~", resultList);

        if (!resultDict.ContainsKey(indexstr))
            resultDict.Add(indexstr, resultList);
    }


    private Dictionary<int, List<TwoSumResult>> getTwoSumDict(int[] nums)
    {
        var twoSumDict = new Dictionary<int, List<TwoSumResult>>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                var sum = nums[i] + nums[j];
                if (!twoSumDict.ContainsKey(sum))
                {
                    var list = new List<TwoSumResult>() { new TwoSumResult(i, j) };
                    twoSumDict.Add(sum, list);
                }
                else
                {
                    var list = twoSumDict[sum];
                    list.Add(new TwoSumResult(i, j));
                }
            }
        }
        return twoSumDict;
    }
}
