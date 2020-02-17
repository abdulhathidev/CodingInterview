using System;

namespace CodingInterview.LeetCode
{
    public class ArrayInLeetCode
    {
        public ArrayInLeetCode()
        {
            Console.Write("189. Rotate Array : {0} \n", RotateArray2(new int[] { 1, 2, 3, 4, 5, 6 }, 3));
            Console.Write("189. Rotate Array : {0} \n", RotateArray2(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3));
        }
        public string Display(int[] arr)
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
                result += arr[i] + " ";
            return result;
        }
        public string RotateArray(int[] nums, int k)
        {
            while (k > 0)
            {
                int temp = nums[nums.Length - 1];
                for (int i = nums.Length - 1; i > 0; i--)
                {
                    nums[i] = nums[i - 1];
                }
                nums[0] = temp;
                k--;
            }
            return Display(nums);
        }

        public string RotateArray1(int[] nums, int k)
        {
            if (nums.Length <= 1 || k <= 0)
                return Display(nums);
            int even = (nums.Length % k) == 0 ? nums.Length / k : -1;
            int n = 0, i = 0, j = 0, temp1 = 0, temp = 0, l = even;
            bool reStart = true;
            while (n < nums.Length)
            {
                l--;
                j = (i + k) % nums.Length;
                temp1 = nums[j];
                nums[j] = reStart ? nums[i] : temp;
                temp = temp1;
                reStart = false;
                if (n == 0)
                {
                    temp = 0;
                    i = j + 1;
                    l = even;
                    reStart = true;
                }
                else
                    i = j;
                n++;
            }

            return Display(nums);
        }

        public string RotateArray2(int[] nums, int k)
        {
            /*
                1 2 3 4 5 6
            */
            k = k % nums.Length;
            int partALength = nums.Length - k;
            ReverseArray(nums, 0, partALength - 1);
            ReverseArray(nums, partALength, nums.Length - 1);
            ReverseArray(nums, 0, nums.Length - 1);

            //ReverseArray(nums, 0, nums.Length - 1 - k);
            return Display(nums);
        }
        public void ReverseArray(int[] nums, int i, int j)
        {
            for (; i < j; i++, j--)
            {
                int t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
            }
        }

        public string Rotate(int[] nums, int k)
        {
            if (nums.Length < 2) return Display(nums);

            k = k % nums.Length;
            reverse(nums, 0, nums.Length - 1 - k);
            reverse(nums, nums.Length - k, nums.Length - 1);
            reverse(nums, 0, nums.Length - 1);
            return Display(nums);
        }

        private void reverse(int[] nums, int left, int right)
        {
            while (left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;

                left++;
                right--;
            }
        }
    }
}