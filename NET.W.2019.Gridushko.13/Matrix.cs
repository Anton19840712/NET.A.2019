using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._13
{
        public delegate void MatrixElementChanged<T>(T arg, int i, int j);
        class Matrix<T>
        {
            protected int HeightMatrix { get; set; }
            protected int WidthMatrix { get; set; }
            internal T[,] MatrixData { get; set; }
            protected Matrix() { }
            internal Matrix(T[,] matrix)
            {
                HeightMatrix = matrix.GetLength(0);
                WidthMatrix = matrix.GetLength(1);
                MatrixData = new T[HeightMatrix, WidthMatrix];
                for (int i = 0; i < HeightMatrix; i++)
                {
                    for (int j = 0; j < WidthMatrix; j++)
                    {
                        MatrixData[i, j] = matrix[i, j];
                    }
                }
            }
            public event MatrixElementChanged<T> ElementChangedMatrix;
            public virtual void ChangedElementMatrix(T arg, int i, int j)
            {
                if (MatrixData[i, j].Equals(arg))
                {
                    return;
                }
                MatrixData[i, j] = arg;
                if (ElementChangedMatrix != null)
                {
                    ElementChangedMatrix(arg, i, j);
                }
            }
            internal static Matrix<T> AdditionMatrix(Matrix<T> matrix1, Matrix<T> matrix2)
            {
                if (matrix1.MatrixData is int[,] && matrix2.MatrixData is int[,] && matrix1.MatrixData.GetLength(0) == matrix2.MatrixData.GetLength(0) && matrix1.MatrixData.GetLength(1) == matrix2.MatrixData.GetLength(1))
                {
                    int[,] matrixOne = matrix1.MatrixData as int[,];
                    int[,] matrixTwo = matrix2.MatrixData as int[,];
                    for (int i = 0; i < matrix1.HeightMatrix; i++)
                    {
                        for (int j = 0; j < matrix1.WidthMatrix; j++)
                        {
                            matrixOne[i, j] += matrixTwo[i, j];
                        }
                    }
                    T[,] matrixCreate = matrixOne as T[,];
                    Matrix<T> returnMatrix = new Matrix<T>(matrixCreate);
                    return returnMatrix;
                }
                else if (matrix1.MatrixData is double[,] && matrix2.MatrixData is double[,] && matrix1.MatrixData.GetLength(0) == matrix2.MatrixData.GetLength(0) && matrix1.MatrixData.GetLength(1) == matrix2.MatrixData.GetLength(1))
                {
                    double[,] matrixOne = matrix1.MatrixData as double[,];
                    double[,] matrixTwo = matrix2.MatrixData as double[,];
                    for (int i = 0; i < matrix1.HeightMatrix; i++)
                    {
                        for (int j = 0; j < matrix1.WidthMatrix; j++)
                        {
                            matrixOne[i, j] += matrixTwo[i, j];
                        }
                    }
                    T[,] matrixCreate = matrixOne as T[,];
                    Matrix<T> returnMatrix = new Matrix<T>(matrixCreate);
                    return returnMatrix;
                }
                else if (matrix1.MatrixData is string[,] && matrix2.MatrixData is string[,] && matrix1.MatrixData.GetLength(0) == matrix2.MatrixData.GetLength(0) && matrix1.MatrixData.GetLength(1) == matrix2.MatrixData.GetLength(1))
                {
                    string[,] matrixOne = matrix1.MatrixData as string[,];
                    string[,] matrixTwo = matrix2.MatrixData as string[,];
                    for (int i = 0; i < matrix1.HeightMatrix; i++)
                    {
                        for (int j = 0; j < matrix1.WidthMatrix; j++)
                        {
                            matrixOne[i, j] += matrixTwo[i, j];
                        }
                    }
                    T[,] matrixCreate = matrixOne as T[,];
                    Matrix<T> returnMatrix = new Matrix<T>(matrixCreate);
                    return returnMatrix;
                }
                else
                {
                    Matrix<T> returnMatrix = new Matrix<T>();
                    return returnMatrix;
                }
            }
        }
    class MatrixSquare<T> : Matrix<T>
        {
            protected MatrixSquare() { }
            internal MatrixSquare(T[,] matrix)
            {
                HeightMatrix = matrix.GetLength(0);
                WidthMatrix = HeightMatrix;
                MatrixData = new T[HeightMatrix, WidthMatrix];
                for (int i = 0; i < HeightMatrix; i++)
                {
                    for (int j = 0; j < WidthMatrix; j++)
                    {
                        MatrixData[i, j] = matrix[i, j];
                    }
                }
            }
            public static MatrixSquare<T> AdditionMatrix(MatrixSquare<T> matrix1, MatrixSquare<T> matrix2)
            {
                Matrix<T> matrix = Matrix<T>.AdditionMatrix(matrix1, matrix2);
                MatrixSquare<T> returnMatrixSquare = new MatrixSquare<T>(matrix.MatrixData);
                return returnMatrixSquare;
            }
        }
        class MatrixSymmetric<T> : MatrixSquare<T>
        {
            internal MatrixSymmetric(T[,] matrix)
            {
                HeightMatrix = matrix.GetLength(0);
                WidthMatrix = HeightMatrix;
                MatrixData = new T[HeightMatrix, WidthMatrix];
                for (int i = 0; i < HeightMatrix; i++)
                {
                    for (int j = 0; j < WidthMatrix; j++)
                    {
                        if (i <= j)
                        {
                            MatrixData[i, j] = matrix[i, j];
                        }
                        else
                        {
                            MatrixData[i, j] = matrix[j, i];
                        }
                    }
                }
            }
            public event MatrixElementChanged<T> ElementChangedMatrixSymmetric;
            public override void ChangedElementMatrix(T arg, int i, int j)
            {
                if (MatrixData[i, j].Equals(arg))
                {
                    return;
                }
                MatrixData[i, j] = arg;
                MatrixData[j, i] = arg;
                if (ElementChangedMatrixSymmetric != null)
                {
                    ElementChangedMatrixSymmetric(arg, i, j);
                }
            }
            public static MatrixSymmetric<T> AdditionMatrix(MatrixSymmetric<T> matrix1, MatrixSymmetric<T> matrix2)
            {
                Matrix<T> matrix = Matrix<T>.AdditionMatrix(matrix1, matrix2);
                MatrixSymmetric<T> returnMatrixSymmetric = new MatrixSymmetric<T>(matrix.MatrixData);
                return returnMatrixSymmetric;
            }
        }
        class MatrixDiagonal<T> : MatrixSquare<T>
        {
            internal MatrixDiagonal(T[,] matrix)
            {
                HeightMatrix = matrix.GetLength(0);
                WidthMatrix = HeightMatrix;
                MatrixData = new T[HeightMatrix, WidthMatrix];
                for (int i = 0; i < HeightMatrix; i++)
                {
                    for (int j = 0; j < WidthMatrix; j++)
                    {
                        if (i == j)
                        {
                            MatrixData[i, j] = matrix[i, j];
                        }
                        else
                        {
                            MatrixData[i, j] = default;
                        }
                    }
                }
            }
            public event MatrixElementChanged<T> ElementChangedMatrixDiagonal;
            public override void ChangedElementMatrix(T arg, int i, int j)
            {
                if (MatrixData[i, j].Equals(arg))
                {
                    return;
                }
                if (i == j)
                {
                    MatrixData[i, j] = arg;
                }
                if (ElementChangedMatrixDiagonal != null)
                {
                    ElementChangedMatrixDiagonal(arg, i, j);
                }
            }
            public static MatrixDiagonal<T> AdditionMatrix(MatrixDiagonal<T> matrix1, MatrixDiagonal<T> matrix2)
            {
                Matrix<T> matrix = Matrix<T>.AdditionMatrix(matrix1, matrix2);
                MatrixDiagonal<T> returnMatrixDiagonal = new MatrixDiagonal<T>(matrix.MatrixData);
                return returnMatrixDiagonal;
            }
        }
    }