using System;

namespace Ravi_Q
{
    class Program
    {
        static char[,] Init(int rows, int cols)
        {

            char[,] metrix = new char[rows,cols];
            for(int r=0; r<rows; r++)
            {
                for(int c=0; c<cols; c++)
                {
                    metrix[r,c] = (char)((int)'A' + (int)c);
                }
            }
            return metrix;
        }

        static  void Print(char[,] metrix, int row, int colStart, int colEnd)
        {
            //Console.Write("How are you?");

            for(int i=colStart; i<=colEnd ; i++)
            {
                Console.Write(metrix[row, i]);
            }
            Console.WriteLine("");
        }

        // static void Main(string[] args)
        // {
        //     Console.WriteLine("Hello World!");

        //     var rows = 26;
        //     var cols = 26;
        //     var metrix = Init(rows, cols);
            
        //     for(int r=0; r<rows; r++)
        //     {
        //         for(int c=0; c<cols; c++)
        //         {
        //             for(int k=c;k<cols; k++)
        //             {
        //                 Print(metrix, r, c, k);
        //             }
        //         }
        //     }
        // }
    }
}
