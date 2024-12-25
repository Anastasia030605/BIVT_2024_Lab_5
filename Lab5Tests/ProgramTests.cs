using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        Program main = new Program();
        int[,] matrix4x4 = new int[,] {
            { 1, 2, 3, 4 },
            { 5, -5, 5, -5 },
            { 6, 7, 8, 9 },
            { -6, -5, -8, 0 }};
        int[,] matrix7x4 = new int[,] {
            { 1, 2, 3, 4 },
            { 5, 5, 4, 6 },
            { 5, -5, 5, -5 },
            { 6, 7, 8, 9 },
            { -6, -5, -8, 0 },
            { 11, 12, 13, 14 },
            { 6, 5, 8, 0 }};
        int[,] matrix3x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 10 } };
        int[,] matrix4x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { -11, 12, 13, 14, -15 },
            { 6, 7, 8, 9, 0 }};
        int[,] matrix5x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
        int[,] matrix6x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 },
            { 0, 1, 0, 2, 0 },
            { 6, 7, 8, 9, 0 }};
        int[,] matrix4x6 = new int[,] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }};
        int[,] matrix5x6 = new int[,] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }};
        int[,] matrix6x6 = new int[,] {
            { 1,    2,  3,  4,  5,  -1 },
            { 6,    7,  8,  9,  10, -2 },
            { 11,   12, 13, 14, 15, -3 },
            { -1,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  20, -2 },
            { 1,    3,  3,  1,  5, 5 }};
        double[,] matrix2x2 = new double[,] {
            { 1, -2 },
            { 5, -5 }};
        double[,] matrix3x3 = new double[,] {
            { 1, -2, 3 },
            { 5, -5, 5 },
            { 6, 7, 8 }};
        int[] arr6 = new int[] { -3, 5, 5, 1, 0, 4 };
        int[] arr6b = new int[] { 13, 10, 1, 0, -2, -4 };
        int[] arr7 = new int[] { 1, 2, 13, 4, -5, 6, 7 };
        int[] arr7b = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        int[] arr8 = new int[] { 1, 8, -3, 5, 5, 1, 0, 4 };
        int[] arr9 = new int[] { 1, 12, 3, 4, 5, -6, 7, 0, 9 };
        int[] arr10 = new int[] { 1, -8, -3, 5, -5, 1, 0, -4, -1, 2 };
        int[] arr11 = new int[] { 1, 12, 13, 0, 9, 1, 5, -6, 7, 12, 14 };
        double[] array7 = new double[] { 1, 2, 13, 4, -5, 6, 7 };
        double[] array8 = new double[] { 1, 8, -3, 5, -5, 1, 0, 4 };
        double[] array9 = new double[] { 1, 12, 3, 4, 5, -6, 7, 0, 9 };

        [TestMethod()]
        public void Task_1_1Test()
        {
            // Arrange
            var rand = new Random();
            int n = rand.Next(-1, 7);
            int k = rand.Next(-1, 5);
            int diff = n - k;
            long actual, expected = 1;
            // Act
            actual = main.Task_1_1(n, k);
            if (k == 0 || k > 0 && k == n) expected = 1;
            else if (k > 0 && k < n)
            {
                do
                    expected *= n;
                while (--n > 0);
                do
                    expected /= k;
                while (--k > 0);
                do
                    expected /= diff;
                while (--diff > 0);
            }
            else expected = 0;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Task_1_2Test()
        {
            // Arrange
            const int len = 3;
            double[] a = new double[len] { 1, 1.5, 1 };
            double[] b = new double[len] { 1, 1.75, 1 };
            double[] c = new double[len] { 1.25, 1.25, 2.5 };
            double[] actual = new double[len * len * len];
            double[] expected = new double[len * len * len] {
                0, 2, -1, 2, 2, 1, 0, 2, -1,
                1, 1, -1, 1, 0, 1, 1, 1, -1,
                -1, 2, -1, -1, 2, -1, -1, 2, -1 };
            // Act
            int count = 0;
            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                    for (int k = 0; k < len; k++, count++)
                        actual[count] = main.Task_1_2(new double[] { a[i], b[j], c[k] }, new double[] { c[i], a[j], b[k] });
            // Assert
            for (int i = 0; i < len * len * len; i++)
                Assert.AreEqual(expected[i], actual[i], 0.00005);
        }

        [TestMethod()]
        public void Task_1_3aTest()
        {
            // Arrange
            const int len = 3;
            double[] v = new double[len] { 10, 9.5, 9 };
            double[] a = new double[len] { 1, 1.5, 1.6 };
            int[] t = new int[len] { 1, 4, 6 };
            double[] actual = new double[len * len * len];
            double[] expected = new double[len * len * len] {
                0, 0, 0, 1, 2, 2, 1, 2, 2,
                2, 1, 1, 0, 0, 0, 1, 1, 1,
                2, 1, 1, 2, 2, 2, 0, 0, 0 };
            // Act
            int count = 0;
            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++)
                    for (int k = 0; k < len; k++, count++)
                        actual[count] = main.Task_1_3a(v[i], a[i], v[j], a[j], t[k]);
            // Assert
            for (int i = 0; i < len * len * len; i++)
                Assert.AreEqual(expected[i], actual[i], 0.00005);
        }

        [TestMethod()]
        public void Task_1_3bTest()
        {
            // Arrange
            const int len = 3;
            double[] v = new double[len] { 10, 9.5, 9 };
            double[] a = new double[len] { 1, 1.5, 1.6 };
            int[] actual = new int[len * len];
            int[] expected = new int[len * len] {
                1, 2, 4, 1, 1, 10, 1, 1, 1};
            // Act
            int count = 0;
            for (int i = 0; i < len; i++)
                for (int j = 0; j < len; j++, count++)
                    actual[count] = main.Task_1_3b(v[i], a[i], v[j], a[j]);
            // Assert
            for (int i = 0; i < len * len; i++)
                Assert.AreEqual(expected[i], actual[i], 0.00005);
        }

        [TestMethod()]
        public void Task_2_1Test()
        {
            // Arrange
            int[,] A = new int[5, 6], B = new int[3, 5];
            int[,] answerA = new int[5, 6], answerB = new int[3, 5];
            Array.Copy(matrix5x6, A, A.LongLength);
            Array.Copy(matrix3x5, B, B.LongLength);
            Array.Copy(matrix5x6, answerA, answerA.LongLength);
            Array.Copy(matrix3x5, answerB, answerB.LongLength);
            int temp = answerB[2, 3];
            answerB[2, 3] = answerA[2, 4];
            answerA[2, 4] = temp;
            // Act
            main.Task_2_1(A, B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }

        [TestMethod()]
        public void Task_2_3Test()
        {
            // Arrange
            int[,] B = new int[5, 5], C = new int[6, 6];
            int[,] answerB = new int[4, 5] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
            int[,] answerC = new int[5, 6] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 1, 3, 3, 1, 5, 5 }};
            Array.Copy(matrix5x5, B, B.LongLength);
            Array.Copy(matrix6x6, C, C.LongLength);
            // Act
            main.Task_2_3(ref B, ref C);
            // Assert
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            Assert.AreEqual(answerC.GetLength(0), C.GetLength(0));
            Assert.AreEqual(answerC.GetLength(1), C.GetLength(1));
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
            for (int i = 0; i < C.GetLength(0); i++)
                for (int j = 0; j < C.GetLength(1); j++)
                    Assert.AreEqual(C[i, j], answerC[i, j]);
        }

        [TestMethod()]
        public void Task_2_5Test()
        {
            // Arrange
            int[,] A = new int[4, 6], B = new int[6, 6];
            int[,] answerA = new int[4, 6] {
            { 1, 2, 3, 4, 5, -1 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }};
            int[,] answerB = new int[6, 6] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 6, 7, 8, 9, 10, -2 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 20, -2 },
            { 1, 3, 3, 1, 5, 5 }};
            Array.Copy(matrix4x6, A, A.LongLength);
            Array.Copy(matrix6x6, B, B.LongLength);
            // Act
            main.Task_2_5(A, B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }

        [TestMethod()]
        public void Task_2_7Test()
        {
            // Arrange
            int[,] B = new int[4, 5], C = new int[5, 6];
            int[,] answerB = new int[5, 5] {
            { 1, 2, 3, 4, 5 },
            { 1, 6, 11, -1, 6 },
            { 6, 7, 8, 9, 10 },
            { -11, 12, 13, 14, -15 },
            { 6, 7, 8, 9, 0 }};
            int[,] answerC = new int[5, 6] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }};
            Array.Copy(matrix4x5, B, B.LongLength);
            Array.Copy(matrix5x6, C, C.LongLength);
            // Act
            main.Task_2_7(ref B, C);
            // Assert
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            Assert.AreEqual(answerC.GetLength(0), C.GetLength(0));
            Assert.AreEqual(answerC.GetLength(1), C.GetLength(1));
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
            for (int i = 0; i < C.GetLength(0); i++)
                for (int j = 0; j < C.GetLength(1); j++)
                    Assert.AreEqual(C[i, j], answerC[i, j]);
        }

        [TestMethod()]
        public void Task_2_9Test()
        {
            // Arrange
            int[,] A = new int[7, 4], C = new int[6, 5];
            Array.Copy(matrix7x4, A, A.LongLength);
            Array.Copy(matrix6x5, C, C.LongLength);
            int[] answer = new int[9] { 34, 31, 41, 33, 24, 29, 32, 38, 30 }, result;
            // Act
            result = main.Task_2_9(A, C);
            // Assert
            Assert.AreEqual(answer.Length, result.Length);
            for (int i = 0; i < answer.Length; i++)
                Assert.AreEqual(answer[i], result[i]);
        }

        [TestMethod()]
        public void Task_2_11Test()
        {
            // Arrange
            int[,] A = new int[5, 5], B = new int[6, 6], C = new int[7, 4];
            int[,] answerAB = new int[5, 5] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 20 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
            int[,] answerBA = new int[6, 6]  {
            { 1,    2,  3,  4,  5,  -1 },
            { 6,    7,  8,  9,  10, -2 },
            { 11,   12, 13, 14, 15, -3 },
            { -1,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  15, -2 },
            { 1,    3,  3,  1,  5, 5 }};
            int[,] answerCA = new int[7, 4] {
            { 1, 2, 3, 4 },
            { 5, 5, 4, 6 },
            { 5, -5, 5, -5 },
            { 6, 7, 8, 9 },
            { -6, -5, -8, 0 },
            { 11, 12, 13, 15 },
            { 6, 5, 8, 0 } };
            int[,] answerAC = new int[5, 5] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 14 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
            int[,] answerCB = new int[7, 4] {
            { 1, 2, 3, 4 },
            { 5, 5, 4, 6 },
            { 5, -5, 5, -5 },
            { 6, 7, 8, 9 },
            { -6, -5, -8, 0 },
            { 11, 12, 13, 20 },
            { 6, 5, 8, 0 } };
            int[,] answerBC = new int[6, 6]  {
            { 1,    2,  3,  4,  5,  -1 },
            { 6,    7,  8,  9,  10, -2 },
            { 11,   12, 13, 14, 15, -3 },
            { -1,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  14, -2 },
            { 1,    3,  3,  1,  5, 5 }};
            Array.Copy(matrix5x5, A, A.LongLength);
            Array.Copy(matrix6x6, B, B.LongLength);
            Array.Copy(matrix7x4, C, C.LongLength);
            int rand = new Random().Next(3);
            // Act
            switch (rand)
            {
                case 0: main.Task_2_11(A, B); break;
                case 1: main.Task_2_11(A, C); break;
                case 2: main.Task_2_11(C, B); break;
            }
            // Assert
            Assert.AreEqual(A.GetLength(0), answerAB.GetLength(0));
            Assert.AreEqual(B.GetLength(0), answerBA.GetLength(0));
            Assert.AreEqual(A.GetLength(1), answerAB.GetLength(1));
            Assert.AreEqual(B.GetLength(1), answerBA.GetLength(1));
            Assert.AreEqual(A.GetLength(0), answerAC.GetLength(0));
            Assert.AreEqual(C.GetLength(0), answerCA.GetLength(0));
            Assert.AreEqual(A.GetLength(1), answerAC.GetLength(1));
            Assert.AreEqual(C.GetLength(1), answerCA.GetLength(1));
            Assert.AreEqual(C.GetLength(0), answerCB.GetLength(0));
            Assert.AreEqual(B.GetLength(0), answerBC.GetLength(0));
            Assert.AreEqual(C.GetLength(1), answerCB.GetLength(1));
            Assert.AreEqual(B.GetLength(1), answerBC.GetLength(1));
            switch (rand)
            {
                case 0:
                    for (int i = 0; i < A.GetLength(0); i++)
                        for (int j = 0; j < A.GetLength(1); j++)
                            Assert.AreEqual(answerAB[i, j], A[i, j]);
                    for (int i = 0; i < B.GetLength(0); i++)
                        for (int j = 0; j < B.GetLength(1); j++)
                            Assert.AreEqual(answerBA[i, j], B[i, j]);
                    break;
                case 1:
                    for (int i = 0; i < A.GetLength(0); i++)
                        for (int j = 0; j < A.GetLength(1); j++)
                            Assert.AreEqual(A[i, j], answerAC[i, j]);
                    for (int i = 0; i < C.GetLength(0); i++)
                        for (int j = 0; j < C.GetLength(1); j++)
                            Assert.AreEqual(answerCA[i, j], C[i, j]);
                    break;
                case 2:
                    for (int i = 0; i < B.GetLength(0); i++)
                        for (int j = 0; j < B.GetLength(1); j++)
                            Assert.AreEqual(answerBC[i, j], B[i, j]);
                    for (int i = 0; i < C.GetLength(0); i++)
                        for (int j = 0; j < C.GetLength(1); j++)
                            Assert.AreEqual(answerCB[i, j], C[i, j]);
                    break;
            }
        }


        [TestMethod()]
        public void Task_2_13Test()
        {
            // Arrange
            int[,] A = new int[5, 5], B = new int[4, 5];
            int[,] answerA = new int[3, 5] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 6, 7, 8, 9, 0 }};
            int[,] answerB = new int[3, 5]  {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 6, 7, 8, 9, 0 }};
            Array.Copy(matrix5x5, A, A.LongLength);
            Array.Copy(matrix4x5, B, B.LongLength);
            // Act
            main.Task_2_13(ref A);
            main.Task_2_13(ref B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }


        [TestMethod()]
        public void Task_2_15Test()
        {
            // Arrange
            int[,] A = new int[6, 6], B = new int[5, 5], C = new int[3, 5];
            Array.Copy(matrix6x6, A, A.LongLength);
            Array.Copy(matrix5x5, B, B.LongLength);
            Array.Copy(matrix3x5, C, C.LongLength);
            int sequence1, sequence2, sequence3;
            int answer1 = 1, answer2 = 0, answer3 = -1;
            // Act
            sequence1 = main.Task_2_15(A, B, C);
            sequence2 = main.Task_2_15(A, C, B);
            sequence3 = main.Task_2_15(C, B, A);
            // Assert
            Assert.AreEqual(answer1, sequence1);
            Assert.AreEqual(answer2, sequence2);
            Assert.AreEqual(answer3, sequence3);
        }

        [TestMethod()]
        public void Task_2_17Test()
        {
            // Arrange
            int[,] A = new int[4, 6], B = new int[6, 6];
            int[,] answerA = new int[4, 6] {
            { 6, 7, 8, 9, 10, -2 },
            { 6, 7, 8, 9, 0, -2 },
            { 1, 2, 3, 4, 5, -1 },
            { -1, -2, -3, -4, -5, -1 }};
            int[,] answerB = new int[6, 6] {
            { 6,    7,  8,  9,  20, -2 },
            { 11,   12, 13, 14, 15, -3 },
            { 6,    7,  8,  9,  10, -2 },
            { 1,    2,  3,  4,  5,  -1 },
            { 1,    3,  3,  1,  5,  5 },
            { -1,   -2, -3, -4, -5, -1 }};
            Array.Copy(matrix4x6, A, A.LongLength);
            Array.Copy(matrix6x6, B, B.LongLength);
            // Act
            main.Task_2_17(A, B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }

        [TestMethod()]
        public void Task_2_19Test()
        {
            // Arrange
            int[,] A = new int[7, 4], B = new int[6, 5];
            int[,] answerA = new int[5, 4] {
            { 1, 2, 3, 4 },
            { 5, 5, 4, 6 },
            { 5, -5, 5, -5 },
            { 6, 7, 8, 9 },
            { 11, 12, 13, 14 }};
            int[,] answerB = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 }};
            Array.Copy(matrix7x4, A, A.LongLength);
            Array.Copy(matrix6x5, B, B.LongLength);
            // Act
            main.Task_2_19(ref A);
            main.Task_2_19(ref B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }

        [TestMethod()]
        public void Task_2_21Test()
        {
            // Arrange
            int[,] A = new int[5, 5], B = new int[6, 6];
            Array.Copy(matrix5x5, A, A.LongLength);
            Array.Copy(matrix6x6, B, B.LongLength);
            int[] answerA = new int[5] { 1, 7, 13, -5, 0 }, answerB = new int[6] { -1, -2, -3, -5, -2, 5 };
            // Act
            main.Task_2_21(A, B, out int[] resultA, out int[] resultB);
            // Assert
            Assert.AreEqual(answerA.Length, resultA.Length);
            Assert.AreEqual(answerB.Length, resultB.Length);
            for (int i = 0; i < answerA.Length; i++)
                Assert.AreEqual(answerA[i], resultA[i]);
            for (int i = 0; i < answerB.Length; i++)
                Assert.AreEqual(answerB[i], resultB[i]);
        }

        [TestMethod()]
        public void Task_2_23Test()
        {// Arrange
            double[,] A = new double[2, 2], B = new double[3, 3];
            double[,] answerA = new double[,] {
            { 2, -1 },
            { 10, -2.5 }};
            double[,] answerB = new double[,] {
            { 0.5, -4, 1.5 },
            { 10, -10, 10 },
            { 12, 14, 16 }};
            Array.Copy(matrix2x2, A, A.LongLength);
            Array.Copy(matrix3x3, B, B.LongLength);
            // Act
            main.Task_2_23(A, B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }

        [TestMethod()]
        public void Task_2_25Test()
        {
            // Arrange
            int[,] A = new int[7, 4], B = new int[6, 6], C = new int[5, 6], D = new int[3, 5];
            Array.Copy(matrix7x4, A, A.LongLength);
            Array.Copy(matrix6x6, B, B.LongLength);
            Array.Copy(matrix5x6, C, C.LongLength);
            Array.Copy(matrix3x5, D, D.LongLength);
            int answerA = 4, answerB = 3, answerC = 3, answerD = 0;
            // Act
            main.Task_2_25(A, B, out int resA, out int resB);
            main.Task_2_25(C, D, out int resC, out int resD);
            // Assert
            Assert.AreEqual(answerA, resA);
            Assert.AreEqual(answerB, resB);
            Assert.AreEqual(answerC, resC);
            Assert.AreEqual(answerD, resD);
        }

        [TestMethod()]
        public void Task_2_27Test()
        {
            // Arrange
            int[,] A = new int[5, 5], B = new int[6, 6];
            int[,] answerA = new int[5, 5] {
            { 1, 2, 3, 4, 25 },
            { 6, 7, 8, 9, 0 },
            { 11, 12, 13, 14, 75 },
            { 0, -2, -3, -4, -5 },
            { 6, 7, 8, 36, 0 }};
            int[,] answerB = new int[6, 6] {
            { 1,    2,  3,  4,  25,  -1 },
            { 6,    7,  8,  9,  0, -2 },
            { 11,   12, 13, 14, 75, -3 },
            { 0,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  100, -2 },
            { 1,    3,  3,  1,  0, 5 }};
            Array.Copy(matrix5x5, A, A.LongLength);
            Array.Copy(matrix6x6, B, B.LongLength);
            // Act
            main.Task_2_27(A, B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }

        [TestMethod()]
        public void Task_3_1Test()
        {
            double[,] answerA = new double[10, 2] {
                { 2.691248985686179, 2.691268139166703 },
                { 2.612188250758326, 2.6122204929844544 },
                { 2.486877948066567, 2.486856868603152 },
                { 2.3239116638734316, 2.3238842457941966 },
                { 2.133946805639821, 2.133930111437405 },
                { 1.9284273029461472, 1.9283342378052784 },
                { 1.7179407535719313, 1.7179999609519054 },
                { 1.5124407582589756, 1.5124670047163078 },
                { 1.3192885674454282, 1.3193027107322826 },
                { 1.1438419924605645, 1.1438356437916406 } },
            answerB = new double[21, 2] {
                { -0.7238669986035898, -0.7237709894132196 },
                { -0.6800294442208453, -0.6803447300484264 },
                { -0.6288481110204656, -0.6290227871627618 },
                { -0.5696189001753262, -0.5698051607562258 },
                { -0.502415222304551, -0.5026918508288181 },
                { -0.4278435589203152, -0.427682857380539 },
                { -0.34443026987495795, -0.34477818041138847 },
                { -0.25471794631816486, -0.2539778199213665 },
                { -0.15454959244621724, -0.15528177591047287 },
                { -0.04810703315931994, -0.04869004837870794 },
                { 0.06595397252545775, 0.06579736267392855 },
                { 0.18738245716549815, 0.1881804572474367 },
                { 0.3177351886901729, 0.3184592353418164 },
                { 0.45569126052265907, 0.45663369695706757 },
                { 0.6043531113374438, 0.6027038420931904 },
                { 0.7562775769271242, 0.7566696707501847 },
                { 0.9208780246049812, 0.9185311829280504 },
                { 1.0853866065595277, 1.0882883786267876 },
                { 1.2696395428461231, 1.2659412578463964 },
                { 1.4468099697676662, 1.4514898205868763 },
                { 1.6348839001848923, 1.6449340668482284 }  },
                resultA = null, resultB = null;
            // Act
            main.Task_3_1(ref resultA, ref resultB);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), resultA.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), resultA.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), resultB.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), resultB.GetLength(1));
            for (int i = 0; i < answerA.GetLength(0); i++)
                for (int j = 0; j < answerA.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], resultA[i, j], 0.00005);
            for (int i = 0; i < answerB.GetLength(0); i++)
                for (int j = 0; j < answerB.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], resultB[i, j], 0.00005);
        }

        [TestMethod()]
        public void Task_3_3Test()
        {
            // Arrange
            double[] A = new double[8], B = new double[9];
            double[] answerA = new double[] { 8, 1, 5, -3, 1, -5, 4, 0 };
            double[] answerB = new double[] { 1, 3, 12, 5, 4, 7, -6, 9, 0 };
            double ansSumA = -7, ansSumB = 24, resSumA, resSumB;
            Array.Copy(array8, A, A.Length);
            Array.Copy(array9, B, B.Length);
            // Act
            resSumA = main.Task_3_3(A);
            resSumB = main.Task_3_3(B);
            // Assert
            Assert.AreEqual(answerA.Length, A.Length);
            Assert.AreEqual(answerB.Length, B.Length);
            Assert.AreEqual(ansSumA, resSumA);
            Assert.AreEqual(ansSumB, resSumB);
            for (int i = 0; i < A.Length; i++)
                Assert.AreEqual(A[i], answerA[i]);
            for (int i = 0; i < B.Length; i++)
                Assert.AreEqual(B[i], answerB[i]);
        }

        [TestMethod()]
        public void Task_3_5Test()
        {
            // Arrange
            int answerA = 1, answerB = 1;
            // Act
            main.Task_3_5(out int resultA, out int resultB);
            // Assert
            Assert.AreEqual(answerA, resultA);
            Assert.AreEqual(answerB, resultB);
        }


        [TestMethod()]
        public void Task_3_7Test()
        {
            // Arrange
            int[,] B = new int[4, 5], C = new int[5, 6];
            int[,] answerB = new int[5, 5] {
            { 1, 2, 3, 4, 5 },
            { 1, 6, 11, -1, 6 },
            { 6, 7, 8, 9, 10 },
            { -11, 12, 13, 14, -15 },
            { 6, 7, 8, 9, 0 }};
            int[,] answerC = new int[5, 6] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }};
            Array.Copy(matrix4x5, B, B.LongLength);
            Array.Copy(matrix5x6, C, C.LongLength);
            // Act
            main.Task_3_7(ref B, C);
            // Assert
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            Assert.AreEqual(answerC.GetLength(0), C.GetLength(0));
            Assert.AreEqual(answerC.GetLength(1), C.GetLength(1));
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
            for (int i = 0; i < C.GetLength(0); i++)
                for (int j = 0; j < C.GetLength(1); j++)
                    Assert.AreEqual(C[i, j], answerC[i, j]);
        }


        [TestMethod()]
        public void Task_3_13Test()
        {
            // Arrange
            int[,] A = new int[5, 5], B = new int[4, 5];
            int[,] answerA = new int[3, 5] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 6, 7, 8, 9, 0 }};
            int[,] answerB = new int[3, 5]  {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 6, 7, 8, 9, 0 }};
            Array.Copy(matrix5x5, A, A.LongLength);
            Array.Copy(matrix4x5, B, B.LongLength);
            // Act
            main.Task_3_13(ref A);
            main.Task_3_13(ref B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }


        [TestMethod()]
        public void Task_3_27Test()
        {
            // Arrange
            int[,] A = new int[5, 5], B = new int[6, 6];
            int[,] answerA = new int[5, 5] {
            { 1, 2, 3, 4, 25 },
            { 6, 7, 8, 9, 0 },
            { 11, 12, 13, 14, 75 },
            { 0, -2, -3, -4, -5 },
            { 6, 7, 8, 36, 0 }};
            int[,] answerB = new int[6, 6] {
            { 1,    2,  3,  4,  25,  -1 },
            { 6,    7,  8,  9,  0, -2 },
            { 11,   12, 13, 14, 75, -3 },
            { 0,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  100, -2 },
            { 1,    3,  3,  1,  0, 5 }};
            Array.Copy(matrix5x5, A, A.LongLength);
            Array.Copy(matrix6x6, B, B.LongLength);
            // Act
            main.Task_3_27(A, B);
            // Assert
            Assert.AreEqual(answerA.GetLength(0), A.GetLength(0));
            Assert.AreEqual(answerA.GetLength(1), A.GetLength(1));
            Assert.AreEqual(answerB.GetLength(0), B.GetLength(0));
            Assert.AreEqual(answerB.GetLength(1), B.GetLength(1));
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    Assert.AreEqual(answerA[i, j], A[i, j]);
            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    Assert.AreEqual(answerB[i, j], B[i, j]);
        }

        [TestMethod()]
        public void Task_4Test()
        {
            // Arrange
            double[,] matrix = {
            {2, 1, -1},
            {1, -1, 1},
            {-1, 1, 2}};
            double[,] matrix2 = {
            {5, 1, 2, 1},
            {1, 6, 2, 3},
            {2, 2, 7, 2},
            {1, 3, 2, 8}};
            double[,] answerMatrixU = {
            {2,     1,  -1},
            {0, -1.5,   1.5},
            {0,     0,  3}};
            double[,] answerMatrixL = {
            {3,     0,  0},
            {1.5, -1.5, 0},
            {-1,    1,  2}};
            double[,] answerMatrixLD = {
            {2,     0,  0},
            {0, -1.5,   0},
            {0,     0,  3}};
            double[,] answerMatrixRD = {
            {3,     0,  0},
            {0, -1.5,   0},
            {0,     0,  2}};
            double[,] answerMatrix2U = {
            {5, 1,      2,          1},
            {0, 5.8,    1.6,        2.8},
            {0, 0,      5.75862069, 0.82758621},
            {0, 0,      0,          6.32934132}};
            double[,] answerMatrix2L = {
            {4.38589,   0,      0,  0},
            {0.28846,   4.63462, 0, 0},
            {1.75,      1.25,   6.5, 0},
            {1,         3,      2,   8}};
            double[,] answerMatrix2LD = {
            {5, 0,      0,          0},
            {0, 5.8,    0,          0},
            {0, 0,      5.7586206,  0},
            {0, 0,      0,      6.32934132}};
            double[,] answerMatrix2RD = {
            {4.38589, 0,    0,  0},
            {0,     4.63462, 0, 0},
            {0,     0,      6.5, 0},
            {0,     0,      0,  8}};
            // Act
            var rand = new Random().Next(10);
            double[,] answer = matrix, output = matrix;
            if (rand < 4)
            {
                output = main.Task_4(matrix, rand % 4);
            }
            else if (rand < 8)
            {
                answer = matrix2;
                output = main.Task_4(matrix2, rand % 4);
            }

            // Assert
            Assert.AreEqual(answer.GetLength(0), output.GetLength(0));
            Assert.AreEqual(answer.GetLength(1), output.GetLength(1));
            switch (rand)
            {
                case 0:
                    answer = answerMatrixU; break;
                case 1:
                    answer = answerMatrixL; break;
                case 2:
                    answer = answerMatrixLD; break;
                case 3:
                    answer = answerMatrixRD; break;
                case 4:
                    answer = answerMatrix2U; break;
                case 5:
                    answer = answerMatrix2L; break;
                case 6:
                    answer = answerMatrix2LD; break;
                case 7:
                    answer = answerMatrix2RD; break;
            }
            for (int i = 0; i < output.GetLength(0); i++)
                for (int j = 0; j < output.GetLength(1); j++)
                    Assert.AreEqual(answer[i, j], output[i, j], 0.00005);
        }

    }
}
