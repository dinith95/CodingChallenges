# question link - https://leetcode.com/problems/search-insert-position/
from typing import List
class Solution:
    def searchInsert(self, nums: List[int], target: int) -> int:
        start = 0
        end = len(nums) - 1

        if(target < nums[0]):
            return 0
        if(target > nums[-1]):
            return len(nums)

        while start < end - 1:
            midValusPos = (end - start)//2
            midVal = nums[start + midValusPos]

            if midVal == target:
                return start + midValusPos

            if (target < midVal):
                end -= midValusPos

            else:
                start += midValusPos

        if nums[start] == target:
            return start
        else:
            return end 

nums = [1,3,5,6]
target = 7

print(Solution().searchInsert( nums, target))
