﻿Console.Clear();
Console.WriteLine("Task 54");
Console.WriteLine("------");

void InputMatrixInt(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[i, j] = new Random().Next(1,10);
    }
}

void PrintMatrixInt(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i, j]} \t");
        Console.WriteLine();
    }
}

void EditMatrix(int [,] matrix){
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++){
            for (int m = 0; m < matrix.GetLength(1); m++){
                int temp = matrix[i,j];
                if (matrix[i,m]<temp){
                    temp = matrix[i,m];
                    matrix[i,m] = matrix[i,j];
                    matrix[i,j] = temp;
                }
            }
        }
    }
}

Console.Write("Введите размер массива: ");
int[] size1 = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
int[,] matrix = new int[size1[0], size1[1]];
InputMatrixInt(matrix);
PrintMatrixInt(matrix);
EditMatrix(matrix);
Console.WriteLine("Упорядоченные строки: ");
PrintMatrixInt(matrix);

Console.ReadLine();

/*--------------------------------------------*/