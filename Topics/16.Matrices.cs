using System;

namespace CodingInterview.Topics
{
    public class Matrices
    {
        public Matrices()
        {
            Console.WriteLine("16. Matrices ---------------------------");
            DiagnolMatrix dm = new DiagnolMatrix();


        }
    }
    public class DiagnolMatrix
    {
        int size;
        int[] d;
        public DiagnolMatrix()
        {
            size = 4;
            Console.WriteLine("01. Diagnol matrix size : {0}", size);
            //ConsoleEx.Console.ReadInt();
            //Console.WriteLine("1 2 3 4");
            //d = ConsoleEx.Console.ReadIntArray();
            d = new int[] { 1, 5, 3, 4 };
            Console.WriteLine("01. Display : {0}", Display());
            Console.WriteLine("02. Get Diagnol matrix value at index ({0},{1}) : {2}", 2, 2, Get(1, 1));
        }
        public string Display()
        {
            string result = "[";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result += Get(i, j) + " ";
                }
                result += i < size - 1 ? ", " : "";
            }
            result += "]";
            return result;
        }
        public int Get(int i, int j)
        {
            return i == j ? d[i] : 0;
        }
    }

    public class LowerTriangleMatrix
    {

    }
    public class UpperTriangleMatrix
    {
        
    }
    public class SymmetricMatrix
    {
        
    }
    public class TriDiagnolMatrix
    {
        
    }
    public class Toplitz
    {
        
    }
}