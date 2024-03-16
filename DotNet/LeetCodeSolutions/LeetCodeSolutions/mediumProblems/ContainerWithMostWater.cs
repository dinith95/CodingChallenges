namespace LeetCodeSolutions.mediumProblems;

class ContainerWithMostWater
{

    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int area = height[left] < height[right] ?
                height[left] * (right - left) : height[right] * (right - left);
           
            if(area > maxArea)
                maxArea = area;

            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return maxArea;
    }
}
