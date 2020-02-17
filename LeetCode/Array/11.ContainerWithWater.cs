using System;

namespace LeetCode.Array
{
    public class ContainerWithMostWater
    {
        public ContainerWithMostWater()
        {

        }
        
        public int MaxArea(int[] height) 
        {
            int maxArea = 0;
            for(int i = 0, j = height.Length - 1; i < j; i++, j--)
            {
                int d = j - i;
                int min = height[i] < height[j] ? height[i] : height[j];
                int area = min * d;
                if(maxArea < area)
                    maxArea = area;
            }
            return maxArea;
        }
    }
}