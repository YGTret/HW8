/// <summary>
/// Этот метод заполняет двумерный массив
/// числами от min до max (общее описание)
/// </summary>
/// <param name="rows">Количество строк (описывается параметр)</param>
/// <param name="cols">Количество столбцов (описывается параметр)</param>
/// <param name="min">Минимальное число для рандома(описывается параметр)</param>
/// <param name="max">Максимальное число для рандома(описывается параметр)</param>
/// <returns>Заполненный двумерный массив целых чисел</returns>
int[,] GetMatrix(int rows, int cols, int min, int max) // параметры (4)
{
    int[,] matrix = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i, j] = new Random().Next(min, max + 1);
        }
    }
    return matrix;
}

/// <summary>
/// Этот метод заполняет трехмерный массив
/// числами от min до max
/// </summary>
/// <param name="d1">Первая размерность</param>
/// <param name="d2">Вторая размерность</param>
/// <param name="d3">Третья размерность</param>
/// <param name="min">Минимальное число для рандома</param>
/// <param name="max">Максимальное число для рандома</param>
/// <returns>Заполненный трехмерный массив целых чисел</returns>
int[,,] Get3DMatrix(int d1, int d2, int d3, int min, int max) // параметры (4)
{
    int[,,] matrix = new int[d1, d2, d3];
    int[] numbers  = new int [d1 * d2 * d3];
    for (int i = 0; i < d1; i++)
    {
        for (int j = 0; j < d2; j++)
        {
            for (int k = 0; k < d3; k++)
            {
                int value = new Random().Next(min, max + 1);
                while (numbers.Contains(value))
                {
                    value = new Random().Next(min, max + 1);
                }
                matrix[i, j, k] = value;
                numbers.Append(value);
                
            }
        }
    }
    return matrix;
}

/// <summary>т
/// Метод печатает матрицу, которую передали на вход
/// </summary>
/// <param name="inputMatrix"> Двумерный массив или таблица </param>
void PrintMatrix(int[,] inputMatrix)
{
    for (int i = 0; i < inputMatrix.GetLength(0); i++) // Строчки
    {
        for (int j = 0; j < inputMatrix.GetLength(1); j++) // Столбцы
        {
            Console.Write(inputMatrix[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

// <summary>
/// Задача 54: Сортировка по убыванию элементов строки.
/// </summary>
/// <param name="matrix">Начальный двумерный массив</param>
/// <returns>результирующий двумерный массив</returns>
int[,] Task_54(int[,] matrix) {
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                int temp;
                if (matrix[i, k] > matrix[i, j])
                {
                    temp = matrix[i, j];
                    matrix[i, j] = matrix[i, k];
                    matrix[i, k] = temp;
                }
            }
        }
    }
    return matrix;
}

/// <summary>
/// Задача 56: Поиск строки с наименьшей суммой.
/// </summary>
/// <param name="matrix">Начальный двумерный массив</param>
/// <returns>индекс искомой строки</returns>
int Task_56(int[,] matrix) {
    int summ = 0;
    int result = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int currRowSumm = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            currRowSumm += matrix[i, j];
        }

        if (i == 0)
        {
            summ = currRowSumm;
            result = i;
        }
        else
        {
            if (currRowSumm < summ)
            {
                summ = currRowSumm;
                result = i;
            }
        }
    }

    return result;
}

/// <summary>
/// Задача 58:Произведение матриц.
/// </summary>
/// <param name="matr_a">Первая матрица</param>
/// <param name="matr_и">Вторая матрица</param>
/// <returns>Результирующая матрица</returns>
int[,] Task_58(int[,] matr_a, int[,] matr_b) {
    int rows = matr_a.GetLength(0);
    int cols = matr_b.GetLength(1);
    int [,] result = new int [rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            for (int k = 0; k < matr_b.GetLength(0); k++)
            {
                result[i,j] += matr_a[i,k] * matr_b[k,j];
            }
        }
    }

    return result;
}

/// <summary>
/// Задача 60:Вывод 3хмерного массива с индексами элементов.
/// </summary>
/// <param name="matrix">Массив, который надо вывести</param>
/// <returns></returns>
void Task_60(int[,,] matrix) {
    for (int i = 0; i < matrix.GetLength(2); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                Console.Write("{0}({1},{2},{3}) ", matrix[j, k, i], j, k, i);
            }
        
            Console.WriteLine();
        }
    }
}

int rows = 3;
int cols = 4;
int min = 0;
int max = 10;
int [,] matrix = GetMatrix(rows, cols, min, max);
Console.WriteLine("Задача 54:");
Console.WriteLine("Начальный массив:");
PrintMatrix(matrix);
Console.WriteLine("Результат:");
PrintMatrix(Task_54(matrix));
Console.WriteLine();

rows = 3;
cols = 3;
min = 0;
max = 10;
matrix = GetMatrix(rows, cols, min, max);
Console.WriteLine("Задача 56:");
Console.WriteLine("Начальный массив:");
PrintMatrix(matrix);
Console.WriteLine("Результат:");
Console.Write(Task_56(matrix) + 1);
Console.WriteLine(" строка");
Console.WriteLine();

int size = 2;
min = 2;
max = 4;
int[,] a = GetMatrix(size, size, min, max);
int[,] b = GetMatrix(size, size, min, max);
Console.WriteLine("Задача 58:");
Console.WriteLine("Матрица №1:");
PrintMatrix(a);
Console.WriteLine("Матрица №2:");
PrintMatrix(b);
Console.WriteLine("Результат:");
PrintMatrix(Task_58(a, b));
Console.WriteLine();

size = 2;
int[,,] matrix3d = Get3DMatrix(size, size, size, 10, 99);
Console.WriteLine("Задача 60:");
Console.WriteLine("Результат:");
Task_60(matrix3d);