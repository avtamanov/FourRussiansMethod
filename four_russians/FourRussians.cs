using System;
using System.Collections.Generic;

namespace four_russians
{
    public static class FourRussians
    {
        // parameter N_M equal to N/log(N)
        // means number of subMatrix (or iterations of preprocess)
        // M = log(N)
        public static int calculateParameter(int N)
        {
            int M = (int)Math.Floor(Math.Log(N));
            if (N > 3 && M < 2) M = 2;

            return (int)Math.Ceiling((decimal)N / M);
        }

        // PPM - PreProcessMatrix:
        // (just for testing)
        // print PPM in console
        public static void PPM_Print(int[][] matrix, string name)
        {
            string str = "";
            for (int i = 0; i < matrix.Length; i++)
            {
                string i_binary = Convert.ToString(i, 2);
                // допысываем спереди неостающие нули
                while (i_binary.Length < Math.Pow(matrix.Length, 0.5))
                {
                    i_binary = "0" + i_binary;
                }
                str += i_binary + " | ";
                if (matrix[0].Length > 0)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        str += matrix[i][j] + " ";
                    }
                    str += "\n";
                }
                else
                {
                    str += matrix[i] + " ";
                }
            }
            Console.WriteLine(name + " matrix:\n" + str);
        }

        // PPM - PreProcessMatrix:
        // new row in PPM is result of multiplying the two rows recorded in the table before 
        // (or just row from subB matrix).
        // but before that we compute previous rows, obviously.
        public static int[][] PPM_Fill(int[][] B, int N_M)
        {
            // PPM_binary[i] - binary representation of the index i.
            // PPM[i] - the vector of multiplied rows whose ONEs (1)
            // in PPM_binary[i] are the same as their coefficient in the matrix B.
            int[][] PPM = Operations.MatrixCreation_Null((int)Math.Pow(2, N_M), B[0].Length);
            string [] PPM_binary = new string[(int)Math.Pow(2, N_M)];
            

            // fill PPM
            // for each row in matrix PPM
            for (int i = 0; i < Math.Pow(2, N_M); i++)
            {

                // get binary representation index of array element (matrix row)
                string i_binary = Convert.ToString(i, 2);
                // add the missing ZEROs to the front
                while (i_binary.Length < N_M)
                {
                    i_binary = '0' + i_binary;
                }
                // add to PPM
                PPM_binary[i] = i_binary;
                // first row always ZEROs
                if (i == 0)
                {
                    PPM[i] = new int[B[0].Length];
                    for (int j = 0; j < PPM[i].Length; j++) { PPM[i][j] = 0; }
                    continue;
                }

                // find conjunction "almost the right one" and multiply it on the other simlier "right" row

                // row indexes for multiplication
                int index1 = 0, index2 = 0;

                // take the previous binary number
                string i_binary_previous = PPM_binary[i - 1];

                // compare each character of the binary number with the character of the previous number
                for (int l = 0; l < i_binary.Length; l++)
                {
                    // if current character is bigger then we split binary number at two parts (index1, index2)
                    if (i_binary[i_binary.Length - 1 - l] > i_binary_previous[i_binary.Length - 1 - l])
                    {
                        // index1 - the digit number that is greater than the previous binary number
                        // the row itself represents a number of type 0..1..0 with a unit in the desired digit
                        index1 = (int)Math.Pow(2, i_binary.Length - 1 - l);
                        // index2 - all other digits whose product is already stored in the table
                        index2 = 0;
                        l++;
                        while (l < i_binary.Length)
                        {
                            index2 += (int) (Math.Pow(2, i_binary.Length - 1 - l) * Convert.ToInt32(i_binary.Substring(i_binary.Length - 1 - l, 1)));
                            l++;
                        }
                        break;
                    }
                }

                // if a row consists of multiplying one row,
                // just take it from the matrix B.
                if (index2 == 0)
                {
                    PPM[i] = B[(int)Math.Log2(index1)];
                }
                else
                {
                    // otherwise, we multiply the found two rows
                    PPM[i] = Operations.MatrixConjunction(PPM[index1], PPM[index2]);
                }
            }
            return PPM;
        }


        // main method
        // doing same matrix multiplication, but with preprocess matrix calculations
        // and speeding-up because of that
        public static int[][] FourRussiansMethod(int[][] A, int[][] B)
        {
            // pre-process
            int N_M = calculateParameter(A.Length);
            // subMatrix selection Ai, Bi
            int subN = A.Length / N_M;
            int[][][] arrC = new int[N_M][][];


            // for each subMatrix in original matrix
            for (int i = 0; i < N_M; i++)
            {
                //arrC.push();
                arrC[i] = new int[A.Length][];
                
                // subMatrix select and PreProcessMatrix
                int[][] subA = Operations.MatrixSelection(A, A.Length, (i + 1) * subN, 0, i * subN);
                int[][] subB = Operations.MatrixSelection(B, (i + 1) * subN, B.Length, i * subN, 0);
                int[][] subPPM = PPM_Fill(subB, subN);

                // for each row in A
                for (int j = 0; j < A.Length; j++)
                {
                    // get a string from the matrix in the form of a binary number
                    string binary_sub_index = "";
                    for (int k = 0; k < subN; k++)
                    {
                        binary_sub_index += "" + subA[j][k];
                    }
                    // convert to decimal
                    int sub_index = Convert.ToInt32(binary_sub_index, 2);

                    // in accordance with the PPM, fill in the row in the matrix C[i]
                    arrC[i][j] = subPPM[sub_index];
                }
            }

            // multiply the resulting matrixes (C[1]*C[2]*...C[N_M])
            int[][] C = Operations.MatrixCreation_Null(A.Length, A[0].Length);
            if (N_M > 1)
            {
                for (int i = 0; i < N_M; i++)
                {
                    C = Operations.MatrixConjunction(C, arrC[i]);
                }
                return C;
            }
            else
            {
                return arrC[0];
            }

        }
    }
}
