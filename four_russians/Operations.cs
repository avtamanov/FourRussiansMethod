using System;
using System.Collections.Generic;
using System.Text;

namespace four_russians
{
    public static class Operations
    {
        public static Random random = new Random();

        // -------------------------------- Matrix Creation ----------------------------


        // matrix of numbers size of (a x b)
        public static int[][] MatrixCreation_Random(int a, int b)
        {
            int[][] arr = new int[a][];

            for (int i = 0; i < a; i++)
            {
                arr[i] = new int[b];
                for (int j = 0; j < b; j++)
                {
                    arr[i][j] = random.Next(2);
                }
            }
            return arr;
        }


        // matrix of ZEROs (a x b)
        public static int[][] MatrixCreation_Null(int a, int b)
        {
            int[][] arr = new int[a][];

            for (int i = 0; i < a; i++)
            {
                arr[i] = new int[b];
                for (int j = 0; j < b; j++)
                {
                    arr[i][j] = 0;
                }
            }
            return arr;
        }

        // return array copy from 'a' till 'b' index
        public static int[] ArraySlice(int[] array, int a, int b)
        {
            int[] new_array = new int[b-a];
            for(int i = 0; i < b-a; i++)
            {
                new_array[i] = array[a + i];
            }
            return new_array;
        }
        // return matrix copy from 'a' till 'b' index (override)
        public static int[][] ArraySlice(int[][] array, int a, int b)
        {
            int[][] new_array = new int[b - a][];
            for (int i = 0; i < b - a; i++)
            {
                new_array[i] = array[a + i];
            }
            return new_array;
        }

        // "cut" new matrix with rows [a_start,a_end) and columns [b_start, b_end) from "matrix"
        public static int[][] MatrixSelection(int[][]  matrix, int a_end, int b_end, int a_start = 0, int b_start = 0)
        {
            //int[][] new_matrix = matrix.slice(a_start, a_end);
            int[][] new_matrix = ArraySlice(matrix, a_start, a_end);
            for (int i = 0; i < new_matrix.Length; i++)
            {
                new_matrix[i] = ArraySlice(matrix[i + a_start], b_start, b_end);
            }
            return new_matrix;
        }


        // -------------------------------- Matrix Operation ----------------------------

        // matrix multiplications
        // C[i,j] =  for 1..k += A[i,k] * B[k,j]
        public static int[][] MatrixMultiplication_Boolean(int[][] A, int[][] B)
        {
            int[][] result = MatrixCreation_Null(A.Length, B[0].Length);

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B[0].Length; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < A[0].Length; k++)
                        sum += A[i][k] * B[k][j];

                    if (sum > 0)
                        result[i][j] = 1;
                    else
                        result[i][j] = 0;
                }
            }
            return result;
        }

        // matrix multiplications.
        // accidentally found this method :-))
        // while multipling row and column, if found first A[i,k] * B[k,j] = 1,
        // skip rest part of this row'n'column and go next row'n'column.
        public static int[][] MatrixMultiplication_Simplified(int[][] A, int[][] B)
        {
            int[][] result = MatrixCreation_Null(A.Length, B[0].Length);

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B[0].Length; j++)
                {
                    for (int k = 0; k < A[0].Length; k++)
                    {
                        if (A[i][k] * B[k][j] == 1)
                        {
                            result[i][j] = 1;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // matrix conjunction
        // C[i,j] = A[i,j] AND B[i,j]
        public static int[][] MatrixConjunction(int[][] A, int[][] B)
        {
            int[][] result;
            if (A.Length == B.Length) {
                result = MatrixCreation_Null(A.Length, B[0].Length);

                for (int i = 0; i < A.Length; i++)
                {
                    for (int j = 0; j < A[0].Length; j++)
                    {
                        result[i][j] = Math.Max(A[i][j], B[i][j]);
                    }
                }
            } else {
                result = MatrixCreation_Null(B.Length, B[0].Length);

                for (int i = 0; i < B.Length; i++)
                {
                    for (int j = 0; j < B[0].Length; j++)
                    {
                        result[i][j] = Math.Max(A[j][i], B[i][j]);
                    }
                }
            }
            return result;
        }
        // array conjunction (override)
        public static int[] MatrixConjunction(int[] A, int[] B)
        {
            if (A.Length != B.Length)
            {
                Console.WriteLine("Матрицы не равны");
                Console.WriteLine(A);
                Console.WriteLine(B);
            }

            int[] result = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            { 
                result[i] = Math.Max(A[i], B[i]);
            }
            return result;
        }

        // -------------------------------------- Matrix Output -----------------------------------
        // print matrix in console
        public static void MatrixPrint(int[][] matrix, string name = "")
        {
            string str = "";
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[0] != null)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        str += matrix[i][j] + " ";
                    }
                    str += '\n';
                }
                else
                {
                    str += matrix[i] + " ";
                }
            }
            Console.Write(name + " matrix:\n" + str);
        }

        // -------------------------------------- Matrix Check Equality ----------------------------------------
        //check matrix equality A[i,j] = B[i,j], and print result in console
        public static bool MatrixEqual(int[][] A, int[][] B, string nameA = "", string nameB = "")
        {
            bool equals = true;
            for(int i = 0; i < A.Length && equals; i++)
            {
                for(int j = 0; j < A[0].Length; j++)
                {
                    if(A[i][j] != B[i][j])
                    {
                        equals = false;
                        break;
                    }
                }
            }
            Console.WriteLine($"matrix {nameA} equal matrix {nameB} is "+equals);
            return equals;
        }
    }
}
