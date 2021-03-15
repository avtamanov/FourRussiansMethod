using Microsoft.VisualStudio.TestTools.UnitTesting;
using four_russians;
using System;
using System.Collections.Generic;
using System.Text;

namespace four_russians.Tests
{
    [TestClass()]
    public class OperationsTests
    {

        [TestMethod()]
        public void MatrixEqualTest()
        {
            // arrange
            int[][] A = new int[][]{
                new int[]{ 0, 0},
                new int[]{ 1, 0}
            };
            int[][] B1 = new int[][]{
                new int[]{ 0, 0},
                new int[]{ 1, 0}
            };
            int[][] B2 = new int[][]{
                new int[]{ 0, 0},
                new int[]{ 1, 1}
            };

            // assert
            Assert.AreEqual(Operations.MatrixEqual(A, B1), true);
            Assert.AreEqual(Operations.MatrixEqual(A, B2), false);
        }

        [TestMethod()]
        public void MatrixCreation_NullTest()
        {
            // arrange
            int[][] A1 = new int[][]{
                new int[]{ 0, 0},
                new int[]{ 0, 0}
            };
            int[][] A2 = new int[][]{
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0}
            };

            // action
            bool actual1 = Operations.MatrixEqual(Operations.MatrixCreation_Null(2, 2), A1);
            bool actual2 = Operations.MatrixEqual(Operations.MatrixCreation_Null(3, 3), A2);

            // assert
            Assert.AreEqual(actual1, true);
            Assert.AreEqual(actual2, true);
        }

        [TestMethod()]
        public void MatrixCreation_RandomTest()
        {
            // arrange
            int[][] A = new int[][]{
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0}
            };

            // action
            int[][] B1 = Operations.MatrixCreation_Random(3, 3);
            int[][] B2 = Operations.MatrixCreation_Random(3, 3);

            bool actual1 = Operations.MatrixEqual(A, B1);
            bool actual2 = Operations.MatrixEqual(B1, B2);

            // assert
            Assert.AreEqual(actual1, false);
            Assert.AreEqual(actual2, false);
        }

        [TestMethod()]
        public void MatrixSelectionTest()
        {
            // arrange
            int[][] A = new int[][]{
                new int[]{ 0, 0, 1, 0, 0, 1},
                new int[]{ 1, 0, 1, 1, 0, 0},
                new int[]{ 1, 0, 0, 0, 0, 0},
                new int[]{ 0, 1, 0, 1, 1, 1},
                new int[]{ 1, 0, 1, 0, 0, 1},
                new int[]{ 0, 0, 0, 1, 0, 1} };

            int[][] subA1 = new int[][] {
                new int[] { 0, 0 },
                new int[] { 1, 0 } };

            int[][] subA2 = new int[][]{
                new int[]{ 0, 0, 0 },
                new int[]{ 0, 1, 1 },
                new int[]{ 1, 0, 0 } };

            // action 
            bool actual1 = Operations.MatrixEqual(Operations.MatrixSelection(A, 2, 2), subA1);
            bool actual2 = Operations.MatrixEqual(Operations.MatrixSelection(A, 5, 5, 2, 2), subA2);

            // assert
            Assert.AreEqual(actual1, true);
            Assert.AreEqual(actual2, true);
        }

        [TestMethod()]
        public void MatrixMultiplication_BooleanTest()
        {
            // arrange
            int[][] A = new int[][]{
                new int[]{ 0, 0, 1},
                new int[]{ 1, 0, 1},
                new int[]{ 1, 0, 0} };
            int[][] B = new int[][]{
                new int[]{ 1, 1, 1},
                new int[]{ 0, 0, 1},
                new int[]{ 1, 0, 1} };
            int[][] C = new int[][]{
                new int[]{ 1, 0, 1},
                new int[]{ 1, 1, 1},
                new int[]{ 1, 1, 1} };

            int[][] X = new int[][]{
                new int[]{ 1, 1, 1},
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0} };
            int[][] Y = new int[][]{
                new int[]{ 1, 0, 0},
                new int[]{ 1, 0, 0},
                new int[]{ 1, 0, 0} };
            int[][] Z = new int[][]{
                new int[]{ 1, 0, 0},
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0} };

            // action 
            bool actual1 = Operations.MatrixEqual(Operations.MatrixMultiplication_Boolean(A, B), C);
            bool actual2 = Operations.MatrixEqual(Operations.MatrixMultiplication_Boolean(X, Y), Z);

            // assert
            Assert.AreEqual(actual1, true);
            Assert.AreEqual(actual2, true);
        }

        [TestMethod()]
        public void MatrixMultiplication_SimplifiedTest()
        {
            // arrange
            int[][] A = new int[][]{
                new int[]{ 0, 0, 1},
                new int[]{ 1, 0, 1},
                new int[]{ 1, 0, 0} };
            int[][] B = new int[][]{
                new int[]{ 1, 1, 1},
                new int[]{ 0, 0, 1},
                new int[]{ 1, 0, 1} };
            int[][] C = new int[][]{
                new int[]{ 1, 0, 1},
                new int[]{ 1, 1, 1},
                new int[]{ 1, 1, 1} };

            int[][] X = new int[][]{
                new int[]{ 1, 1, 1},
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0} };
            int[][] Y = new int[][]{
                new int[]{ 1, 0, 0},
                new int[]{ 1, 0, 0},
                new int[]{ 1, 0, 0} };
            int[][] Z = new int[][]{
                new int[]{ 1, 0, 0},
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0} };

            // action 
            bool actual1 = Operations.MatrixEqual(Operations.MatrixMultiplication_Simplified(A, B), C);
            bool actual2 = Operations.MatrixEqual(Operations.MatrixMultiplication_Simplified(X, Y), Z);

            // assert
            Assert.AreEqual(actual1, true);
            Assert.AreEqual(actual2, true);
        }

        [TestMethod()]
        public void MatrixConjunctionTest()
        {
            // arrange
            int[][] A = new int[][]{
                new int[]{ 0, 0, 1},
                new int[]{ 1, 0, 1},
                new int[]{ 1, 0, 0} };
            int[][] B = new int[][]{
                new int[]{ 1, 1, 1},
                new int[]{ 0, 0, 1},
                new int[]{ 1, 0, 1} };
            int[][] C = new int[][]{
                new int[]{ 1, 1, 1},
                new int[]{ 1, 0, 1},
                new int[]{ 1, 0, 1} };

            int[][] X = new int[][]{
                new int[]{ 1, 1, 1},
                new int[]{ 0, 0, 0},
                new int[]{ 0, 0, 0} };
            int[][] Y = new int[][]{
                new int[]{ 1, 0, 0},
                new int[]{ 1, 0, 0},
                new int[]{ 1, 0, 0} };
            int[][] Z = new int[][]{
                new int[]{ 1, 1, 1},
                new int[]{ 1, 0, 0},
                new int[]{ 1, 0, 0} };

            // action 
            bool actual1 = Operations.MatrixEqual(Operations.MatrixConjunction(A, B), C);
            bool actual2 = Operations.MatrixEqual(Operations.MatrixConjunction(X, Y), Z);

            // assert
            Assert.AreEqual(actual1, true);
            Assert.AreEqual(actual2, true);
        }
    }
}