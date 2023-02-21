Console.Clear();
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

Console.Clear();
Console.WriteLine("Task 56");
Console.WriteLine("------");

void MinSum(int [,] matrix){
    int minSum = int.MaxValue, numStr = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++){
            sum += matrix[i,j];
        }
        if (sum < minSum){
            numStr = i;
            minSum = sum;
        }
    }
    Console.WriteLine($"Наименьшая сумма {minSum} в строке {numStr}");
}

Console.Write("Введите размер прямоугольного массива: ");
int[] size2 = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
while (size2[0]<=size2[1])
{
    Console.Write("Строки должны быть больше столбцов: ");
    size2 = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
}
int[,] matrix2 = new int[size2[0], size2[1]];
InputMatrixInt(matrix2);
PrintMatrixInt(matrix2);
MinSum(matrix2);

Console.ReadLine();

/*--------------------------------------------*/

Console.Clear();
Console.WriteLine("Task 58");
Console.WriteLine("------");

int [,] MultiplyMatrix(int [,] matrix1, int [,] matrix2){
    int[,] newMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                for (int k = 0; k < matrix2.GetLength(0); k++)
                {
                    newMatrix[i,j] += matrix1[i,k] * matrix2[k,j];
                }
            }
        }
    return newMatrix;
}

Console.Write("Введите размер (одно число) квадратного массива: ");
int size3 = Convert.ToInt32(Console.ReadLine());

int[,] matrix31 = new int[size3, size3];
int[,] matrix32 = new int[size3, size3];
InputMatrixInt(matrix31);
InputMatrixInt(matrix32);
PrintMatrixInt(matrix31);
Console.WriteLine("---------------");
PrintMatrixInt(matrix32);
Console.WriteLine("Произведение двух матриц:");
PrintMatrixInt(MultiplyMatrix(matrix31, matrix32));

Console.ReadLine();

/*--------------------------------------------*/

Console.Clear();
Console.WriteLine("Task 60");
Console.WriteLine("------");

void InputMatrixTriple(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++){
        for (int j = 0; j < matrix.GetLength(1); j++){
            for (int k = 0; k < matrix.GetLength(2); k++){
                 int num = new Random().Next(10,100);
                 while (CheckMatrixTriple(matrix, num))
                    num = new Random().Next(10,100);
                 matrix[i, j, k] = num;
            }
        }
    }
}

bool CheckMatrixTriple(int[,,] matrix, int num)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++){
            for (int k = 0; k < matrix.GetLength(2); k++)
                if (matrix [i,j,k] == num) return true;
        }  
    }
    return false;
}

void PrintMatrixTriple(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++){
            for (int k = 0; k < matrix.GetLength(2); k++)
                Console.Write($"{matrix[i, j, k]} ({i},{j},{k}) \t");
            Console.WriteLine();
        }
    }
}
int[,,] matrixTriple = new int[2, 2, 2];
InputMatrixTriple(matrixTriple );
PrintMatrixTriple(matrixTriple );

Console.ReadLine();

/*--------------------------------------------*/

Console.Clear();
Console.WriteLine("Task 61");
Console.WriteLine("------");

void InputMatrixPascal(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++){
            if(i == 0 && j == matrix.GetLength(1)/2) matrix[i,j] = 1;
            if((j == 0 || j == matrix.GetLength(1)-1) 
                && i == matrix.GetLength(0)-1) matrix[i,j] = 1;
            if(matrix.GetLength(0)%2 == 0){
                if(i>=1 && j <=matrix.GetLength(1)-2 && j>0){
                    if (i%2==0 && (j+i)%2!=0) matrix[i,j] =
                        matrix[i-1,j-1]
                    + matrix[i-1,j+1];
                    if (i%2!=0 && (j+i)%2!=0) matrix[i,j] =
                        matrix[i-1,j-1]
                    + matrix[i-1,j+1];
                }
            }
            else{
                if(i>=1 && j <=matrix.GetLength(1)-2 && j>0){
                    if (i%2==0 && (j+i)%2==0) matrix[i,j] =
                        matrix[i-1,j-1]
                    + matrix[i-1,j+1];
                    if (i%2!=0 && (j+i)%2==0) matrix[i,j] =
                        matrix[i-1,j-1]
                    + matrix[i-1,j+1];
                }
            }
        }
    }
}

void PrintMatrixPascal(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++){
            if(matrix[i, j] == 0) Console.Write("   ");
            else Console.Write($" {matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

Console.Write("Введите число строк: ");
int size4 = Convert.ToInt32(Console.ReadLine());
int[,] matrixPascal = new int[size4, size4+size4-1];
InputMatrixPascal(matrixPascal);
PrintMatrixPascal(matrixPascal);

Console.ReadLine();

/*--------------------------------------------*/

Console.Clear();
Console.WriteLine("Task 62");
Console.WriteLine("------");

void InputMatrixSpiral(int[,] matrix)
{
    int i = 0, j = 0, k = 0, count = 1, num = matrix.GetLength(0)*matrix.GetLength(0);
    bool right = true, top = false;
    while(num > 0){
        matrix[i,j] = count;
        count++;

        if (j == matrix.GetLength(0)-1-k && right){
            right = !right;
        }
        
        if (i == matrix.GetLength(0)-1-k && !top){
            top = !top;
            k++;
        }
        
        if(right && !top) j++;
        if(!right && top) j--;
        if(!right && !top) i++;
        if(right && top) i--;
        if(j == k-2 && !right){
            j++;
            i--;
            right = !right;
        }
        if(i == k-1 && top){
            i++;
            j++;
            top = !top;
        }
        num--;
    }
}

Console.Write("Введите размер (одно число) квадратного массива: ");
int size5 = Convert.ToInt32(Console.ReadLine());
int[,] matrixSpiral = new int[size5, size5];
InputMatrixSpiral(matrixSpiral);
PrintMatrixInt(matrixSpiral);

Console.ReadLine();

/*--------------------------------------------*/