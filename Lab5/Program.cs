using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public int Factorial(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        return (n * Factorial(n - 1));
    }
    public int Combinations(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (k > n || n < 0 || k < 0) return 0;
        answer = Combinations(n, k);
        // end

        return answer;
    }
    double GeronArea(double a, double b, double c)
    {
        double t = a + b + c;
        double p = t / 2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double sum_1 = 0;
        double m_1 = first[0];
        double sum_2 = 0;
        double m_2 = second[0];

        for (int i = 0; i < 3; i++)
        {
            sum_1 += first[i];
            if (m_1 < first[i])
            {
                m_1 = first[i];
            }
        }
        for (int i = 0; i < 3; i++)
        {
            sum_2 += second[i];
            if (m_2 < second[i])
            {
                m_2 = second[i];
            }
        }
        if ((m_1 >= (sum_1 - m_1)) || (m_2 >= (sum_2 - m_2)))
        {
            answer = -1;
            return answer;
        }

        double t1 = GeronArea(first[0], first[1], first[2]);
        double t2 = GeronArea(second[0], second[1], second[2]);

        if (t1 > t2)
        {
            answer = 1;
        }
        else if (t1 == t2)
        {
            answer = 0;
        }
        else
        {
            answer = 2;
        }


        // create and use GeronArea(a, b, c);
        static double GeronArea(double a, double b, double c)
        {
            double t = (a + b + c) / 2;
            double s = Math.Sqrt(t * (t - a) * (t - b) * (t - c));
            return s;
        }

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double sum_1 = GetDistance(v1, a1, time);
        double sum_2 = GetDistance(v2, a2, time);
        if (sum_2 < sum_1)
        {
            answer = 1;
        }
        else if (sum_1 == sum_2)
        {
            answer = 0;
        }
        else
        {
            answer = 2;
        }

        // create and use GetDistance(v, a, t); t - hours

        static double GetDistance(double v, double a, int t)
        {
            double p = v * t + a * t * t / 2;
            return p;
        }
        // end
        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        int tmp = 1;

        // use GetDistance(v, a, t); t - hours
        while ((GetDistance(v1, a1, tmp)) > GetDistance(v2, a2, tmp))
        {
            tmp += 1;

        }
        answer = tmp;

        static double GetDistance(double v, double a, int t)
        {
            double m = v * t + a * t * t / 2;
            return m;
        }
        // end

        Console.WriteLine(answer);
        return answer;

        // end
    }
    #endregion
    public void FindMaxIndex(int[,] matrix, out int row, out int col)
    {
        
        row = -1; col = -1;
        int max = int.MinValue;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (max < matrix[i, j])
                {
                    max = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        int row, col;
        int a_row, b_row, a_col, b_col;
        FindMaxIndex(A, out a_row, out a_col);
        FindMaxIndex(B, out b_row, out b_col);
        int tmp;
        tmp = A[a_row, a_col];
        A[a_row, a_col] = B[b_row, b_col];
        B[b_row, b_col] = tmp;

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }
    
    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        int[,] new_b = new int[4, 5];
        int[,] new_c = new int[5, 6];
        int B_max = FindDiagonalMaxIndex(B);
        int C_max = FindDiagonalMaxIndex(C);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (B_max > i)
                {
                    new_b[i, j] = B[i, j];
                }

                else
                {
                    new_b[i, j] = B[i + 1, j];
                }
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (C_max > i)
                {
                    new_c[i, j] = C[i, j];
                }

                else
                {
                    new_c[i, j] = C[i + 1, j];
                }
            }
        }
        B = new_b;
        C = new_c;


    }
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int max = -1000;
        int max_index = -1;


        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (max < matrix[i, i])
            {
                max = matrix[i, i];
                max_index = i;
            }
        }
        return max_index;
    }


    //  create and use method FindDiagonalMaxIndex(matrix);




    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }
    int FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        rowIndex = 0;
        int max_value = matrix[0, columnIndex];
        
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > max_value)
            {
                max_value = matrix[i, columnIndex];
                rowIndex = i;
            }
        }
        return max_value;
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        int A_row;
        int B_row;
        int f = 0;


        int m = A.GetLength(1);
        int max_A = FindMaxInColumn(A, f, out A_row);
        int max_B = FindMaxInColumn(B, f, out B_row);
        
        for (int j = 0; j < m; j++)
        {
            int p = A[A_row, j];
            A[A_row, j] = B[B_row, j];
            B[B_row, j] = p;
        }
        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }
    int CountRowPositive(int[,] matrix, int row_index)
    {
        int res = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[row_index, j] > 0)
            {
                res++;
            }
        }
        return res;
    }
    int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int res = 0;
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, colIndex] > 0) res++;
        }
        return res;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        int maxValueB = -1;
        int maxIndexB = -1;
        for (int i = 0; i < 4; i++)
        {
            if (CountRowPositive(B, i) > maxValueB)
            {
                maxValueB = CountRowPositive(B, i);
                maxIndexB = i;
            }
        }
        int maxValueC = -1;
        int maxIndexC = -1;
        for (int j = 0; j < 6; j++)
        {
            if (CountColumnPositive(C, j) > maxValueC)
            {
                maxValueC = CountColumnPositive(C, j);
                maxIndexC = j;
            }
        }
        int[,] B_result = new int[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i <= maxIndexB)
                {
                    B_result[i, j] = B[i, j];
                }
                else if (i == maxIndexB + 1)
                {
                    B_result[i, j] = C[j, maxIndexC];
                }
                else
                {
                    B_result[i, j] = B[i - 1, j];
                }
            }
        }
        B = B_result;

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }
    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(1)];
        int n = matrix.GetLength(1);
        int m = matrix.GetLength(0);
        for (int j = 0; j < n; j++)
        {
            int sum = 0;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i, j] > 0)
                {
                    sum += matrix[i, j];
                }
            }
            ans[j] = sum;
        }
        return ans;
    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here
        answer = new int[A.GetLength(1) + C.GetLength(1)];
        int[] array_1 = SumPositiveElementsInColumns(A);
        int[] array_2 = SumPositiveElementsInColumns(C);
        for (int i = 0; i < array_1.Length; i++)
        {
            answer[i] = array_1[i];
        }
            
        for (int i = 0; i < array_2.Length; i++)
        {
            answer[i + array_1.Length] = array_2[i];
        }
   

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here
        int max_row_a;
        int max_row_b;
        int max_col_a;
        int max_col_b;
        
        FindMaxIndex(A, out max_row_a, out max_col_a);
        FindMaxIndex(B, out max_row_b, out max_col_b);
        int max_A;
        int max_B;

        max_A = A[max_row_a, max_col_a];
        max_B = B[max_row_b, max_col_b];

        A[max_row_a, max_col_a] = max_B;
        B[max_row_b, max_col_b] = max_A;

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }
    void RemoveRow(ref int[,] matrix, int rowIndex)
    {
        int[,] new_Matrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        int kol = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i == rowIndex)
            {
                continue;
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                new_Matrix[kol, j] = matrix[i, j];
            }
            kol++;
        }
        matrix = new_Matrix;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        int max_row = 0;
        int min_row = 0;

        int max = matrix[0, 0];
        int min = matrix[0, 0];

        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    max_row = i;
                }
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    min_row = i;
                }
            }
        }
        if (max_row == min_row)
        {
            RemoveRow(ref matrix, max_row);
        }

        else
        {
            if (max_row > min_row)
            {
                RemoveRow(ref matrix, max_row);
                RemoveRow(ref matrix, min_row);
            }
            else
            {
                RemoveRow(ref matrix, min_row);
                RemoveRow(ref matrix, max_row);
            }
        }
}

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }
    
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;
        // code here
        double avg_a = GetAverageWithoutMinMax(A);
        double avg_b = GetAverageWithoutMinMax(B);
        double avg_c= GetAverageWithoutMinMax(C);
        // Determine the sequence: 1 - increasing, -1 - decreasing, 0 - no sequence
        if ((avg_a < avg_b) && (avg_b < avg_c))
        {
            answer = 1;
        }
        else if ((avg_a > avg_b) && (avg_b > avg_c))
        {
            answer = -1;
        }
        else
        {
            answer = 0;
        }
        return answer;
    }
    double GetAverageWithoutMinMax(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int totalElements = n * m;

        if (totalElements <= 2)
        {
            return 0;
        }

        int min = int.MaxValue;
        int max = int.MinValue;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int value = matrix[i, j];
                sum = sum + value;

                if (max < value)
                {
                    max = value;
                }

                if (min > value)
                {
                    min = value;
                }

            }
        }
        sum = sum - (max + min);

        int answer = sum / (totalElements - 2);

        return answer;
    }


    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }
    
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);
        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);

        // end
    }
    void SortRowsByMaxElement(int[,] matrix)
    {
        int k1 = matrix.GetLength(0);
        int k2 = matrix.GetLength(1);

        for (int i = 0; i < k1 - 1; i++)
        {
            for (int j = i + 1; j < k1; j++)
            {
                int max_row_i = matrix[i, 0];

                for (int c = 1; c < k2; c++)
                {
                    if (matrix[i, c] > max_row_i)
                    {
                        max_row_i = matrix[i, c];
                    }
                }

                int max_row_j = matrix[j, 0];

                for (int c = 1; c < k2; c++)
                {
                    if (matrix[j, c] > max_row_j)
                    {
                        max_row_j = matrix[j, c];
                    }
                }
                if (max_row_i < max_row_j)
                {
                    for (int c = 0; c < k2; c++)
                    {
                        int temp = matrix[i, c];
                        matrix[i, c] = matrix[j, c];
                        matrix[j, c] = temp;
                    }
                }
            }
        }
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here
        if (matrix.GetLength(0) == 0 || matrix == null)
        {
            return;
        }

        for (int i = (matrix.GetLength(0) - 1); i >= 0; i--)
        {
            int t = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    t = 1;
                    break;
                }
            }

            if (t == 1)
            {
                RemoveRow(ref matrix, i);
            }
        }

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;
        
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
       
    }

    int[] CreateArrayFromMins(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        int[] res = new int[n];
        int min = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            min = 10000;
            for (int j = i; j < m; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
            res[i] = min;
        }
        return res;
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    void MatrixValuesChange(double[,] matrix)
    {
        double[] top5 = new double[5];
        double t = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        for (int i = 0; i < 5; i++)
        {
            top5[i] = double.MinValue;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                t = matrix[i, j];
                for (int c = 0; c < top5.Length; c++)
                {
                    if (t > top5[c])
                    {
                        for (int q = 4; q > c; q--)
                        {
                            top5[q] = top5[q - 1];
                        }
                        top5[c] = t;
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int x = 0;
                for (int k = 0; k < top5.Length; k++)
                {
                    if (matrix[i, j] == top5[k])
                    {
                        x = 1;
                        break;
                    }
                }


                if (matrix[i, j] > 0 && x == 1)
                {
                    matrix[i, j] *= 2;
                }

                else if (matrix[i, j] < 0 && x == 1)
                {
                    matrix[i, j] /= 2;
                }


                else if (matrix[i, j] > 0 && x == 0) 
                {
                    matrix[i, j] /= 2;
                }

                else if (matrix[i, j] < 0 && x == 0)
                {
                    matrix[i, j] *= 2;
                }


            }
        }
    }
    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // create and use MatrixValuesChange(matrix);
        //        В двух заданных матрицах по пять наибольших элементов увеличить вдвое,
        //остальные вдвое уменьшить. Преобразование матрицы оформить в виде метода.
        // end
    }


    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;
        // code here
        maxA = FindMaxNegativeRow(A);
        maxB = FindMaxNegativeRow(B);
        
    }
    int CountRowNegative(int[,] matrix, int rowIndex)
    {
        
        int n = matrix.GetLength(1);
        int res = 0;

        for (int j = 0; j < n; j++)
        {
            
            if (matrix[rowIndex, j] < 0)
            {
                res++;
            }
        }
        return res;
    }
    int FindMaxNegativeRow(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int max = -1;
        int r = -1;

        for (int i = 0; i < m; i++)
        {
            if (CountRowNegative(matrix, i) > max)
            {
                max = CountRowNegative(matrix, i);
                r = i;
            }
        }
        return r;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        ReplaceMaxElementEven(A);
        ReplaceMaxElementOdd(A);
        ReplaceMaxElementEven(B);
        ReplaceMaxElementOdd(B);
        
    }
    public int FindRowMaxIndex(int[,] matrix, int rowIndex)
    {
        int max = -10000;
        int max_index = -1;
        int n = matrix.GetLength(1);
        
        for (int j = 0; j < n; j++)
        {
            if (max < matrix[rowIndex, j])
            {
                max = matrix[rowIndex, j];
                max_index = j;
            }
        }
        return max_index;
    }
    public void ReplaceMaxElementEven(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        int r = -1;

        for (int i = 1; i < m; i += 2)
        {
            r = FindRowMaxIndex(matrix, i);

            for (int j = 0; j < n; j++)
            {


                if (matrix[i, j] == matrix[i, r])
                {
                    matrix[i, j] = 0;
                }
            }
        }
    }
    public void ReplaceMaxElementOdd(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        int r = -1;


        for (int i = 0; i < m; i += 2)
        {
            r = FindRowMaxIndex(matrix, i);


            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == matrix[i, r])
                {
                    matrix[i, j] *= j + 1;
                }
                    
            }
        }
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        double a_1 = 0.1;
        double b_1 = 1;
        double h_1 = 0.1;

        firstSumAndY = new double[(int)((b_1 - a_1) / h_1) + 1, 2];
        GetSumAndY(S1, y1, a_1, b_1, h_1, firstSumAndY);

        double a_2 = Math.PI / 5;
        double b_2 = Math.PI;
        double h_2 = Math.PI / 25;

        secondSumAndY = new double[(int)((b_2 - a_2) / h_2) + 1, 2];
        GetSumAndY(S2, y2, a_2, b_2, h_2, secondSumAndY, 1);

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }
    public delegate double SumFunction(int i, double x, ref int change);
    public delegate double YFunction(double x);
    public double S1(int i, double x, ref int in_f)
    {
        if (i > 0)
        {
            in_f *= i;
        }


        return Math.Cos(i * x) / in_f;
    }
    public double S2(int i, double x, ref int dw)
    {
        dw *= -1;
        return dw * Math.Cos(i * x) / (i * i);
    }
    public double y1(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public double y2(double x)
    {
        return (((x * x) - Math.PI * Math.PI / 3) / 4);
    }
    public double CalculateSum(SumFunction sumFunction, double x, int i)
    {
        double ps = 0.0001;
        double sum = 0;
        int ww = 1;
        double c = sumFunction(i, x, ref ww);

        while (Math.Abs(c) > ps)
        {
            sum += c;
            c = sumFunction(++i, x, ref ww);
        }
        return sum;
    }
    public void GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h, double[,] SumY, int startI = 0)
    {
        for (int i = 0; i < ((b - a) / h + 1); i++)
        {
            double x = a + (i * h);
            double sum = CalculateSum(sFunction, x, startI);
            double y = yFunction(x);
            SumY[i, 0] = sum;
            SumY[i, 1] = y;
        }
    }


    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);
        // code here

        if (array.Length == 0 || array == null)
        {
            return 0;
        }

        double aver = CalculateAverage(array);

        if (array[0] > aver)
        {
            swapper = SwapLeft;
        }

        else
        {
            swapper = SwapRight;
        }

        swapper(array);

        answer = GetSum(array);


        return answer;
    }
    public delegate void SwapDirection(double[] array);
    public double CalculateAverage(double[] array)
    {
        double summa = 0;
        foreach (int n in array)
        {
            summa += n;
        }
        return summa / array.Length;
    }
    public void SwapLeft(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            double t = array[i];
            array[i] = array[i + 1];

            array[i + 1] = t;
        }
    }
    public void SwapRight(double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double t = array[i];
            array[i] = array[i - 1];
            array[i - 1] = t;
        }
    }
    public double GetSum(double[] array)
    {
        double summa = 0;
        for (int i = 1; i < array.Length; i += 2)
        {
            summa = summa + array[i];
        }
        return summa;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        double a1 = 0;
        double b1 = 2;
        double h1 = 0.1;
        double a2 = -1;
        double b2 = 1;
        double h2 = 0.2;


        func1 = CountSignFlips(F1, a1, b1, h1);
        func2 = CountSignFlips(F2, a2, b2, h2);
        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public delegate double FunctionDelegate(double x);
    public double F1(double x)
    {
        return x * x - Math.Sin(x);
    }
    public double F2(double x)
    {
        return Math.Exp(x) - 1;
    }
    public int CountSignFlips(YFunction y, double a, double b, double h)
    {
        int k = 0;
        double l = y(a);
        for (double x = a + h; x <= b; x += h)
        {
            double r = y(x);
            if (l * r < 0)
            {
                k++;
            }
            if (r != 0)
            {
                l = r;
            }
        }
        return k;
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }
    public delegate int CountPositive(int[,] matrix, int index);
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        CountPositive count = CountRowPositive;
        int max_b = -1;
        int max_index_b = -1;


        for (int i = 0; i < 4; i++)
        {
            if (count(B, i) > max_b)
            {
                max_b = count(B, i);
                max_index_b = i;
            }
        }


        count = CountColumnPositive;
        int max_c = -1;
        int max_index_c = -1;


        for (int j = 0; j < 6; j++)
        {
            if (count(C, j) > max_c)
            {
                max_c = count(C, j);
                max_index_c = j;
            }
        }
        int[,] Br = new int[5, 5];


        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i <= max_index_b)
                    Br[i, j] = B[i, j];
                else if (i == max_index_b + 1)
                    Br[i, j] = C[j, max_index_c];
                else
                    Br[i, j] = B[i - 1, j];
            }
        }
        B = Br;
        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        RemoveRows(ref matrix, FindMax, FindMin);

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);

    public int FindMax(int[,] matrix)
    {
        int max = matrix[0, 0];
        int max_index = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {


                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    max_index = i;
                }
            }
        }
        return max_index;
    }
    public int FindMin(int[,] matrix)
    {
        int min = matrix[0, 0];
        int min_index = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    min_index = i;
                }
            }
        }
        return min_index;
    }
    public void RemoveRows(ref int[,] matrix, FindElementDelegate FindMax, FindElementDelegate FindMin)
    {
        int max_index = FindMax(matrix);
        int min_index = FindMin(matrix);


        if (max_index == min_index)
        {
            RemoveRow(ref matrix, max_index);
        }
        else
        {
            RemoveRow(ref matrix, Math.Max(max_index, min_index));
            RemoveRow(ref matrix, Math.Min(max_index, min_index));
        }
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;
        
    }
    public delegate void ReplaceMaxElement(int[,] matrix);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement replaceMaxElement1, ReplaceMaxElement replaceMaxElement2)
    {
        replaceMaxElement1(matrix);

        replaceMaxElement2(matrix);
    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here


        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);



        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me
        // code here
        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle
        // end
        return matrix;
    }

    #endregion
}
