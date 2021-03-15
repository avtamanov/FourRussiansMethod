using System;
using System.Diagnostics;

namespace four_russians
{
    // Tamanov Andrey
    // Student of HSE BSE, 4 Course.
    // Four Russians Algorithm Implementation
    class Program
    {
        public static Random random = new Random();
        /* for check
         * int[][] A = new int[][]{
                new int[]{ 0, 0, 1, 0, 0, 1},
                new int[]{ 1, 0, 1, 1, 0, 0},
                new int[]{ 1, 0, 0, 0, 0, 0},
                new int[]{ 0, 1, 0, 1, 1, 1},
                new int[]{ 1, 0, 1, 0, 0, 1},
                new int[]{ 0, 0, 0, 1, 0, 1},
            };
            int[][] B = new int[][]{
                new int[]{ 0, 1, 1, 0, 0, 0},
                new int[]{ 1, 0, 1, 0, 1, 0},
                new int[]{ 0, 1, 0, 1, 1, 0},
                new int[]{ 1, 1, 0, 0, 1, 0},
                new int[]{ 1, 0, 0, 1, 1, 0},
                new int[]{ 1, 0, 1, 0, 0, 1},
            };*/
        static void Main(string[] args)
        {
            
            // for matrix NxN, where N = 10, 50, ..., 2000.
            // measure processor ticks for computing.
            // expected result:
            // russian_mult(NxN) = casual_mult(NxN) / log(N).
            //
            // plus bonus, accidentally i found one condition in casual_mult operation,
            // which speed it up from N^3 to N^2 in best case and to N^3 (no spped up) in worst case.
            // but in practice it acceleration closer to N^2.
            // 
            // сompile, wait a minute and enjoy numbers :-)
            // (martixes build randomly, so you can restart process to get NEW time)
            int[] Ns = { 10, 50, 100, 200, 500, 1000, 2000 };
            for(int i = 0; i < Ns.Length; i++)
            {
                int N = Ns[i];
                int[][] A = Operations.MatrixCreation_Random(N, N);
                int[][] B = Operations.MatrixCreation_Random(N, N);
                int param = FourRussians.calculateParameter(N);
                float subMatrixSize = (float)N / param;
                Console.WriteLine($"N = {N},\n M = N/log(N) = {param}\nN/M ~= {subMatrixSize}");

                /*Operations.MatrixPrint(A, "A");
                Operations.MatrixPrint(B, "B");*/

                // casual
                Stopwatch casual_SW = new Stopwatch();
                casual_SW.Start();
                int[][] casual_C = Operations.MatrixMultiplication_Boolean(A, B);
                casual_SW.Stop();

                Console.WriteLine("casual_C computed");

                // russian
                Stopwatch russian_SW = new Stopwatch();
                russian_SW.Start();
                int[][] russian_C = FourRussians.FourRussiansMethod(A, B);
                //Operations.MatrixPrint(russian_C, "russian_C");
                russian_SW.Stop();

                Console.WriteLine("russian_C computed");

                // simplified
                Stopwatch simplified_SW = new Stopwatch();
                simplified_SW.Start();
                int[][] simplified_C = Operations.MatrixMultiplication_Simplified(A, B);
                //Operations.MatrixPrint(russian_C, "russian_C");
                simplified_SW.Stop();

                Console.WriteLine("simplified_C computed");

                // output
                Console.WriteLine("Casual Time:   \t\t" + String.Format("{0:0,0} processor ticks", casual_SW.ElapsedTicks));
                Console.WriteLine("Russian Time:  \t\t" + String.Format("{0:0,0} processor ticks", russian_SW.ElapsedTicks));
                Console.WriteLine("Simplified Time:\t" + String.Format("{0:0,0} processor ticks", simplified_SW.ElapsedTicks));

                // check
                Operations.MatrixEqual(casual_C, russian_C, "casual_C", "russian_C");
                Operations.MatrixEqual(russian_C, simplified_C, "russian_C", "simplified_C");
                Operations.MatrixEqual(simplified_C, casual_C, "simplified_C", "casual_C");
                Console.WriteLine();

                /*Operations.MatrixPrint(casual_C, "casual_C");
                Operations.MatrixPrint(russian_C, "russian_C");
                Operations.MatrixPrint(simplified_C, "simplified_C");*/
            }
        }
    }
}
