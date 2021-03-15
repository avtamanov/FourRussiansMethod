using Microsoft.VisualStudio.TestTools.UnitTesting;
using four_russians;
using System;
using System.Collections.Generic;
using System.Text;

namespace four_russians.Tests
{
    [TestClass()]
    public class FourRussiansTests
    {
        [TestMethod()]
        public void calculateParameterTest()
        {
            // arrange
            int N5 = 5;
            int N10 = 10;
            int N50 = 50;
            int N100 = 100;
            int N200 = 200;
            int N500 = 500;
            int N1000 = 1000;
            int N2000 = 2000;

            // assert
            Assert.AreEqual(FourRussians.calculateParameter(N5),3);
            Assert.AreEqual(FourRussians.calculateParameter(N10),5);
            Assert.AreEqual(FourRussians.calculateParameter(N50),17);
            Assert.AreEqual(FourRussians.calculateParameter(N100),25);
            Assert.AreEqual(FourRussians.calculateParameter(N200),40);
            Assert.AreEqual(FourRussians.calculateParameter(N500),84);
            Assert.AreEqual(FourRussians.calculateParameter(N1000),167);
            Assert.AreEqual(FourRussians.calculateParameter(N2000),286);
        }

        [TestMethod()]
        public void PPM_FillTest()
        {
            // arrange
            int N = 6;
            int N_M = FourRussians.calculateParameter(N);
            int subN = N / N_M;

            int[][] A = new int[][]{
                new int[]{ 0, 1, 1, 0, 0, 0},
                new int[]{ 1, 0, 1, 0, 1, 0}, };

            int[][] A_PPM = new int[][]{
                new int[]{ 0, 0, 0, 0, 0, 0}, // 00
                new int[]{ 1, 0, 1, 0, 1, 0}, // 01
                new int[]{ 0, 1, 1, 0, 0, 0}, // 10
                new int[]{ 1, 1, 1, 0, 1, 0}, // 11
            };

            // action
            bool actual1 = Operations.MatrixEqual(FourRussians.PPM_Fill(A, subN), A_PPM);

            // assert
            Assert.AreEqual(actual1, true);
        }

        [TestMethod()]
        public void FourRussiansMethodTest()
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
            bool actual1 = Operations.MatrixEqual(FourRussians.FourRussiansMethod(A, B), C);
            bool actual2 = Operations.MatrixEqual(FourRussians.FourRussiansMethod(X, Y), Z);

            // assert
            Assert.AreEqual(actual1, true);
            Assert.AreEqual(actual2, true);
        }
    }
}