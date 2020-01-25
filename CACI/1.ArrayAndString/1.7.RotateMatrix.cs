using System;

namespace CodingInterview.ArrayAndString
{
    public class RotateMatrix
    {
        int[][] pixel = new int[][]
            {
                new int[]{1,2,3,4},
                new int[]{5,6,7,8},
                new int[]{9,10,11,12},
                new int[]{13,14,15,16}
            };
        public RotateMatrix()
        {
            Console.WriteLine("1.7. Rotate Matrix : ");
            //RotateThePixels();
            InPlaceRotation();
            for (int i = 0; i < pixel.Length; i++)
            {
                for (int j = 0; j < pixel[i].Length; j++)
                {
                    Console.Write(pixel[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void RotateThePixels()
        {
            int length = pixel.Length;
            for (int i = 0; i < length / 2; i++)
            {
                Swap(ref pixel[i], ref pixel[length - 1 - i]);
            }
        }
        public bool InPlaceRotation()
        {
            if (pixel.Length == 0 || pixel.Length != pixel[0].Length)
                return false;
            int length = pixel.Length;
            for (int i = 0; i < length / 2; i++)
            {
                int last = length - 1 - i;
                for (int j = i; j < last; j++)
                {
                    int offset = j - i;
                    int top = pixel[i][j];

                    pixel[i][j] = pixel[last - offset][i];
                    pixel[last - offset][i] = pixel[last][last - offset];
                    pixel[last][last - offset] = pixel[j][last];
                    pixel[j][last] = top;
                }
            }
            return true;
        }
        public void Swap(ref int[] x, ref int[] y)
        {
            int[] temp = x;
            x = y;
            y = temp;
        }
    }
}