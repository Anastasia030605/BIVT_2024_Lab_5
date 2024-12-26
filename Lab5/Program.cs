using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        program.Task_2_17( new int[,] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }}, new int[,] {{ 1,    2,  3,  4,  5,  -1 },
            { 6,    7,  8,  9,  10, -2 },
            { 11,   12, 13, 14, 15, -3 },
            { -1,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  20, -2 },
            { 1,    3,  3,  1,  5, 5 }});
    }
    #region Level 1
    public long Combinations(int n, int k) {
            if(k == 0 || k > 0 && n == k) {
                return 1;
            } 
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }
    public long Factorial(int n) {
            if(n == 0) {
                return 1;
            }
            long res = 1;
            for(int i = 2; i <= n; ++i) {
                res *= i;
            }
            return res;
        }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        // create and use Combinations(n, k);
        return Combinations(n, k);
        // create and use Factorial(n);

        // end
    }

    public bool CheckTriangle(double[] triangle) {
            if(triangle[0] + triangle[1] > triangle[2] && triangle[1] + triangle[2] > triangle[0]
            && triangle[0] + triangle[2] > triangle[1]) {
                return true;
            } else {
                return false;
            }
        }
    public double GeronArea(double a, double b, double c) {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        if(first.Length != 3 || second.Length != 3) {
            return -1;
        }


        if(!CheckTriangle(first) || !CheckTriangle(second)) {
            return -1;
        }

        // create and use GeronArea(a, b, c);
        double area_first = GeronArea(first[0], first[1], first[2]), area_second = GeronArea(second[0], second[1], second[2]);
        if(area_first > area_second) {
            return 1;
        } else if(area_second > area_first) {
            return 2;
        } else {
            return 0;
        }
        // end

        // first = 1, second = 2, equal = 0, error = -1
    }

    public double GetDistance(double v, double a, int t) {
            return v * t + a * t * t / 2;
        }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours

        double dist_first = GetDistance(v1, a1, time), dist_second = GetDistance(v2, a2, time);

        if(dist_first > dist_second) {
            return 1;
        } else if(dist_first < dist_second) {
            return 2;
        } else {
            return 0;
        }

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        for(int time = 1; time < int.MaxValue; ++time) {
         double dist_first = GetDistance(v1, a1, time), dist_second = GetDistance(v2, a2, time);
         if(dist_second >= dist_first) {
            return time;
         }
        }

        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void FindMaxIndex(int[,] matrix, out int row, out int column) {
            row = 0; column = 0;
            int maximum = int.MinValue;
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                for(int j = 0; j < matrix.GetLength(1); ++j) {
                    if(matrix[i, j] > maximum) {
                        maximum = matrix[i, j];
                        row = i; column = j;
                    }
                }
            }
        }
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        int row1 = 0, row2 = 0, column1 = 0, column2;
        // create and use FindMaxIndex(matrix, out row, out column);
        FindMaxIndex(A, out row1, out column1);
        FindMaxIndex(B, out row2, out column2);
        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;
        // end
    }

    public void FindDiagonalMaxIndex(int[,] A, out int ind) {
            ind = 0;
            int maximum = int.MinValue;
            for(int i = 0; i < A.GetLength(0); ++i) {
                if(A[i, i] > maximum) {
                    maximum = A[i, i];
                    ind = i;
                }
            }
        }
    public int[,] DeleteRow(int[,] A, int ind) {
            int n = A.GetLength(0);
            int[,] res = new int[n - 1, n];
            int cur = 0;
            for(int i = 0; i < n; ++i) {
                if(i == ind) {
                    continue;
                }
                for(int j = 0; j < n; ++j) {
                    res[cur, j] = A[i, j];
                }
                ++cur;
            }
            return res;
        }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);
        int ind1, ind2;
        FindDiagonalMaxIndex(B, out ind1);
        FindDiagonalMaxIndex(C, out ind2);
        B = DeleteRow(B, ind1);
        C = DeleteRow(C, ind2);
        // end
    }

    void PrintMatrix(int[,] A) {
        for(int i = 0; i < A.GetLength(0); ++i) {
            for(int j = 0; j < A.GetLength(1); ++j) {
                Console.Write(A[i,j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex) {
            rowIndex = 0;
            int maximum = int.MinValue;
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                if(matrix[i, columnIndex] > maximum) {
                    maximum = matrix[i, columnIndex];
                    rowIndex = i;
                }
            }
        }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        int row1, row2;
        FindMaxInColumn(A, 0, out row1);
        FindMaxInColumn(B, 0, out row2);
        for(int i = 0; i < 6; ++i) {
            int temp = A[row1, i];
            A[row1, i] = B[row2, i];
            B[row2, i] = temp;
        }
        // end
    }

        public int CountRowPositive(int[,] matrix, int rowIndex) {
            int cnt = 0, n = matrix.GetLength(0), m = matrix.GetLength(1);
            for(int i = 0; i < n; ++i) {
                if(matrix[rowIndex, i] > 0) {
                    ++cnt;
                }
            }
            return cnt;
        }
        public int CountColumnPositive(int[,] matrix, int colIndex) {
            int cnt = 0, n = matrix.GetLength(0), m = matrix.GetLength(1);
            for(int i = 0; i < n; ++i) {
                if(matrix[i, colIndex] > 0) {
                    ++cnt;
                }
            }
            return cnt;
        }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        int indRow = 0, maxim = 0;
        for(int i = 0; i < B.GetLength(0); ++i) {
            int cnt = CountRowPositive(B, i);
            if(cnt > maxim) {
                indRow = i;
                maxim = cnt;
            }
        }
        int indCol = 0; maxim = 0;
        for(int i = 0; i < C.GetLength(1); ++i) {
            int cnt = CountColumnPositive(C, i);
            if(cnt > maxim) {
                indCol = i;
                maxim = cnt;
            }
        }
        int[,] res = new int[B.GetLength(0) + 1, B.GetLength(1)];
        int cur = 0;
        for(int i = 0; i < res.GetLength(0); ++i) {
            for(int j = 0; j < res.GetLength(1); ++j) {
                if(i == indRow + 1) {
                    res[i, j] = C[j, indCol];
                } else {
                    res[i, j] = B[cur, j];
                }
            }
            if(i != indRow + 1) {
                ++cur;
            }
        }
        B = res;
        // end
    }

    public int[] SumPositiveElementsInColumns(int[,] matrix) {
            int[] res = new int[matrix.GetLength(1)];
            for(int j = 0; j < matrix.GetLength(1); ++j) {
                int sum = 0;
                for(int i = 0; i < matrix.GetLength(0); ++i) {
                    if(matrix[i, j] > 0) {
                        sum += matrix[i, j];
                    }
                }
                res[j] = sum;
            }
            return res;
        }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);
        int ind = 0;
        answer = new int[A.GetLength(1) + C.GetLength(1)];
        foreach(int x in SumPositiveElementsInColumns(A)) {
            answer[ind] = x;
            ++ind;
        }
        foreach(int x in SumPositiveElementsInColumns(C)) {
            answer[ind] = x;
            ++ind;
        }
        // end

        return answer;
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        int row1 = 0, row2 = 0, column1 = 0, column2;
        // create and use FindMaxIndex(matrix, out row, out column);
        FindMaxIndex(A, out row1, out column1);
        FindMaxIndex(B, out row2, out column2);
        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;
        // end
    }

    public void RemoveRow(ref int[,] matrix, int rowIndex) {
            int[,] res = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int cur = 0;
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                if(i == rowIndex) {
                    continue;
                }
                for(int j = 0; j < matrix.GetLength(1); ++j) {
                    res[cur, j] = matrix[i, j];
                }
                ++cur;
            }
            matrix = res;
        }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);
        int indMax = 0, maximum = int.MinValue, indMin = 0, minimum = int.MaxValue;
        for(int i = 0; i < matrix.GetLength(0); ++i) {
            for(int j = 0; j < matrix.GetLength(1); ++j) {
                if(matrix[i, j] > maximum) {
                    maximum = matrix[i, j];
                    indMax = i;
                }
                if(matrix[i, j] < minimum) {
                    minimum = matrix[i, j];
                    indMin = i;
                }
            }
        }
        RemoveRow(ref matrix, indMax);
        if(indMin > indMax) {
            --indMin;
        } else if(indMin == indMax) {
            return;
        }
        RemoveRow(ref matrix, indMin);
        // end
    }
    public double GetAverageWithoutMinMax(int[,] matrix) {
            int minimum = matrix[0, 0];
            int maximum = matrix[0, 0];
            double sum = 0;
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                for(int j = 0; j < matrix.GetLength(1); ++j) {
                    if(matrix[i, j] > maximum) {
                        sum += maximum;
                        maximum = matrix[i, j];
                    } else if(matrix[i, j] < minimum) {
                        sum += minimum;
                        minimum = matrix[i, j];
                    } else {
                        sum += matrix[i, j];
                    }
                }
            }
            return sum / (double)(matrix.GetLength(0) + matrix.GetLength(1) - 2);
        }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);
        double[] res = new double[3];
        res[0] = GetAverageWithoutMinMax(A);
        res[1] = GetAverageWithoutMinMax(B);
        res[2] = GetAverageWithoutMinMax(C);
        if(res[1] > res[0] && res[2] > res[1]) {
            return 1;
        } else if(res[1] < res[0] && res[2] < res[1]) {
            return -1;
        } else {
            return 0;
        }
        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public int[] maxEls(int[,] matrix) {
            int[] res = new int[matrix.GetLength(0)];
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                int maximum = int.MinValue;
                for(int j = 0; j < matrix.GetLength(1); ++j) {
                    if(matrix[i, j] > maximum) {
                        maximum = matrix[i, j];
                    }
                }
                res[i] = maximum;
            }
            return res;
        }
    public void SortRowsByMaxElement(int[,] matrix) {
            int[] mas = maxEls(matrix);
            for(int k = 0; k < matrix.GetLength(0) - 1; ++k) {
                for(int i = 0; i < matrix.GetLength(0) - k - 1; ++i) {
                    if(mas[i + 1] > mas[i]) {
                        int t = mas[i];
                        mas[i] = mas[i + 1];
                        mas[i + 1] = t;
                        for(int j = 0; j < matrix.GetLength(1); ++j) {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i + 1, j];
                            matrix[i + 1, j] = temp;
                        }
                    }
                }
            }
        }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);
        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);
        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for(int i = 0; i < n; ++i) {
            bool f = false;
            for(int j = 0; j < m; ++j) {
                if(matrix[i, j] == 0) {
                    f = true;
                    break;
                }
            }
            if(f) {
                RemoveRow(ref matrix, i);
                --i;
                --n;
            }
        }
        // end
    }

    public void CreateArrayFromMins(int[,] matrix, out int[] answer) {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n];
            for(int i = 0; i < n; ++i) {
                int minimum = int.MaxValue;
                for(int j = i; j < m; ++j) {
                    if(matrix[i, j] < minimum) {
                        minimum = matrix[i, j];
                    }
                }
                answer[i] = minimum;
            }
        }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);
        CreateArrayFromMins(A, out answerA);
        CreateArrayFromMins(B, out answerB);
        // end
    }

    public void MatrixValuesChange(double[,] matrix) {
            int[] rows = {-1, -1, -1, -1, -1};
            int[] columns = new int[5];
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                for(int j = 0; j < matrix.GetLength(1); ++j) {
                    int tempRow = i, tempCol = j;
                    for(int cur = 0; cur < 5; ++cur) {
                        if(rows[cur] == -1) {
                            rows[cur] = tempRow; columns[cur] = tempCol;
                            tempRow = -1;
                            break;
                        }
                        if(matrix[tempRow, tempCol] > matrix[rows[cur], columns[cur]]) {
                            int tR = tempRow, tC = tempCol;
                            tempRow = rows[cur]; tempCol = columns[cur];
                            rows[cur] = tR; columns[cur] = tC;
                        }
                    }
                    if(tempRow != -1) {
                        if(matrix[tempRow, tempCol] > 0) {
                            matrix[tempRow, tempCol] /= 2;
                        } else {
                            matrix[tempRow, tempCol] *= 2;
                        }
                    }
                }
            }
            for(int i = 0; i < 5; ++i) {
                if(rows[i] == -1) {
                    break;
                }
                if(matrix[rows[i], columns[i]] > 0) {
                    matrix[rows[i], columns[i]] *= 2;
                } else {
                    matrix[rows[i], columns[i]] /= 2;
                }
            }
        }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // end
    }

    public int FindRowWithMaxNegativeCount(int[,] matrix) {
            int max = 0;
            int ind = 0;
            int CountNegativeInRow(int[,] matrix, int row) {
                int count = 0;
                for(int i = 0; i < matrix.GetLength(1); ++i) {
                    if(matrix[row, i] < 0) {
                        ++count;
                    }
                }
                return count;
            }
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                int cnt = CountNegativeInRow(matrix, i);
                if(cnt > max) {
                    max = cnt;
                    ind = i;
                }
            }
            return ind; 
        }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // end
    }
    public void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex) {
            columnIndex = 0;
            for(int j = 0; j < matrix.GetLength(1); ++j) {
                if(matrix[rowIndex, columnIndex] < matrix[rowIndex, j]) {
                    columnIndex = j;
                }
            }
        }
        public void ReplaceMaxElementOdd(int[,] matrix, int rowIndex, int columnIndex) {
            matrix[rowIndex, columnIndex] *= columnIndex + 1;
        }
        public void ReplaceMaxElementEven(int[,] matrix, int rowIndex, int columnIndex) {
            matrix[rowIndex, columnIndex] = 0;
        }
        public void FindAndReplaceMaxes(int[,] matrix) {
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                int columnIndex;
                FindRowMaxIndex(matrix, i, out columnIndex);
                if(i % 2 == 0) {
                    ReplaceMaxElementOdd(matrix, i, columnIndex);
                } else {
                    ReplaceMaxElementEven(matrix, i, columnIndex);
                }
            }
        }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);
        FindAndReplaceMaxes(A);
        FindAndReplaceMaxes(B);
        // end
    }
    #endregion

    #region Level 3
    
    public delegate double SumFunction(double x);
    public delegate double YFunction(double x);

    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h) {
            double[,] ans = new double[(int)((b - a + h) / h), 2];
            int cur = 0;
            for(double i = a; i <= b + 0.000001; i += h) {
                ans[cur, 0] = sFunction(i);
                ans[cur, 1] = yFunction(i);
                ++cur;
            }
            return ans;
        }

        // create and use 2 methods for both functions calculating at specific x
        public double firstCalculate(double x) {
            double res = 0;
            double fact = 1;
            double s = 1;
            int i = 1;
            while(Math.Abs(s) > 0.0001) {
                res += s;
                fact *= i;
                s = Math.Cos(i * x) / fact;
                ++i;
            }
            return res;
        }
        public double secondCalculate(double x) {
            double res = 0;
            double s = 0;
            double i = 1;
            while(Math.Abs(s) > 0.0001 || i == 1) {
                res += s;
                s = ((i % 2 == 1) ? -1 : 1) * (Math.Cos(i * x) / Math.Pow(i, 2));
                ++i;
            }
            return res;
        }
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        firstSumAndY = GetSumAndY(firstCalculate, delegate(double x) {return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));}, 0.1, 1, 0.1);
        secondSumAndY = GetSumAndY(secondCalculate, delegate(double x) {return (x * x - Math.PI * Math.PI / 3) / 4; }, Math.PI / 5, Math.PI, Math.PI / 25);
        // end
    }

    public delegate void SwapDirection(double[] array);

    public void SwapRight(double[] array) {
            for(int i = 0; i < array.Length - 1; i += 2) {
                double temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
        }
    public void SwapLeft(double[] array) {
            for(int i = array.Length - 1; i > 0; i -= 2) {
                double temp = array[i];
                array[i] = array[i - 1];
                array[i - 1] = temp;
            }
        }
    public double GetSum(double[] array) {
            double res = 0;
            for(int i = 1; i < array.Length; i += 2) {
                res += array[i];
            }
            return res;
        }
    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        double sum = 0;
        for(int i = 0; i < array.Length; ++i) {
            sum += array[i];
        }
        if(array[0] > sum / array.Length) {
            swapper = SwapRight;
        } else {
            swapper = SwapLeft;
        }
        swapper(array);
        answer = GetSum(array);
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Sign(double x) {
            if(x < 0) {
                return -1;
            } else if(x == 0) {
                return 0;
            } else {
                return 1;
            }
        }
    public int CountSignFlips(YFunction func, double a, double b, double h) {
            int cnt = 0;
            double prev = Sign(func(a));
            for(double i = a + h; i <= b; i += h) {
                double temp = Sign(func(i));
                if(prev == 0) {
                    prev = temp;
                    continue;
                }
                if(prev != temp ) {
                    ++cnt;
                }
                prev = temp;
            }
            return cnt;
        }
        // create and use 2 methods for both functions
    public double firstFunc(double x) {
            return x * x - Math.Sin(x);
        }
    public double secondFunc(double x) {
            return Math.Exp(x) - 1;
        }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        func1 = CountSignFlips(firstFunc, 0, 2, 0.1);
        func2 = CountSignFlips(secondFunc, -1, 1, 0.2);
        // end
    }

    public delegate int CountPositive(int[,] matrix, int index);

    public void InsertColumn(ref int[,] matrixB, CountPositive CountRow, int[,] matrixC, CountPositive CountColumn) {
            int indRow = 0, maxim = 0;
        for(int i = 0; i < matrixB.GetLength(0); ++i) {
            int cnt = CountRow(matrixB, i);
            if(cnt > maxim) {
                indRow = i;
                maxim = cnt;
            }
        }
        int indCol = 0; maxim = 0;
        for(int i = 0; i < matrixC.GetLength(1); ++i) {
            int cnt = CountColumn(matrixC, i);
            if(cnt > maxim) {
                indCol = i;
                maxim = cnt;
            }
        }
        int[,] res = new int[matrixB.GetLength(0) + 1, matrixB.GetLength(1)];
        int cur = 0;
        for(int i = 0; i < res.GetLength(0); ++i) {
            for(int j = 0; j < res.GetLength(1); ++j) {
                if(i == indRow + 1) {
                    res[i, j] = matrixC[j, indCol];
                } else {
                    res[i, j] = matrixB[cur, j];
                }
            }
            if(i != indRow + 1) {
                ++cur;
            }
            }
            matrixB = res;
        }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
        InsertColumn(ref B, CountRowPositive, C, CountColumnPositive);
        // end
    }

    public delegate int FindElementDelegate(int[,] matrix);
    public int FindMax(int[,] matrix) {
            int indMax = 0, maximum = int.MinValue;
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                for(int j = 0; j < matrix.GetLength(1); ++j) {
                    if(matrix[i, j] > maximum) {
                        maximum = matrix[i, j];
                        indMax = i;
                    }
                }
            }
            return indMax;
        }
        public int FindMin(int[,] matrix) {
            int indMin = 0, minimum = int.MaxValue;
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                for(int j = 0; j < matrix.GetLength(1); ++j) {
                    if(matrix[i, j] < minimum) {
                        minimum = matrix[i, j];
                        indMin = i;
                    }
                }
            }
            return indMin;
        }
        // create and use method RemoveRows(matrix, findMax, findMin)
        public void RemoveRows(ref int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin) {
            int mx = findMax(matrix);
            int mn = findMin(matrix);
            RemoveRow(ref matrix, mx);
            if(mn == mx) {
                return;
            } else if(mn > mx) {
                --mn;
            }
            RemoveRow(ref matrix, mn);
        }
    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        RemoveRows(ref matrix, FindMax, FindMin);
        // end
    }

    public delegate void ReplaceMaxElement(int[,] matrix, int rowIndex, int max);

    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven) {
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                int max;
                FindRowMaxIndex(matrix, i, out max);
                if(i % 2 == 1) {
                    replaceMaxElementEven(matrix, i, max);
                } else {
                    replaceMaxElementOdd(matrix, i, max);
                }
            }
        }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        // end
    }

    #endregion
    #region bonus part
    public void SumRows(double[,] matrix, double k, int row1, int row2) {
        for(int i = 0; i < matrix.GetLength(1); ++i) {
            matrix[row2, i] += matrix[row1, i] * k;
        }
    }
    public delegate void MatrixConverter(double[,] matrix);

    public void ToUpperTriangular(double[,] matrix) {
            for(int i = matrix.GetLength(0) - 1; i >= 0; --i) {
                for(int j = i - 1; j >= 0; --j) {
                    if(matrix[i, j] == 0) {
                        continue;
                    }
                    SumRows(matrix, -1 * (matrix[i, j] / matrix[i, i]), i, j);
                }
            }
        }
    public void ToLowerTriangular(double[,] matrix) {
            for(int i = 0; i < matrix.GetLength(0); ++i) {
                for(int j = i + 1; j < matrix.GetLength(0); ++j) {
                    if(matrix[j, i] == 0) {
                        continue;
                    }
                    SumRows(matrix, -1 * (matrix[j, i] / matrix[i, i]), i, j);
                }
            }
        }
    public void ToLeftDiagonal(double[,] matrix) {
            ToUpperTriangular(matrix);
            ToLowerTriangular(matrix);
        }
    public void ToRightDiagonal(double[,] matrix) {
            ToLowerTriangular(matrix);
            ToUpperTriangular(matrix);
        }
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4];

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        switch(index) {
            case 0:
                ToLowerTriangular(matrix);
                break;
            case 1:
                ToUpperTriangular(matrix);
                break;
            case 2:
                ToLeftDiagonal(matrix);
                break;
            case 3:
                ToRightDiagonal(matrix);
                break;
        }
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
