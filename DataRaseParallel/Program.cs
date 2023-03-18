double[,] GenerateMatrix(int rows, int columns)
{
    double[,] result = new double[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = Random.Shared.Next(1, 5);
        }
    }
    return result;
}

void Print(double[,] matrix)
{
     int rows = matrix.GetLength(0);
     int columns = matrix.GetLength(1);
     for (int i = 0; i < rows; i++)
     {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

double[,] MultiplySync(double[,] m1, double[,] m2)
{
    int rowsM1 = m1.GetLength(0),
        k = m1.GetLength(1),
        columnsM2 = m2.GetLength(1);

     double[,] result = new double[rowsM1, columnsM2];

    for (int i = 0; i < rowsM1; i++)
    {
        for (int j = 0; j < columnsM2; j++)
        {
            double s = 0;
            for (int r = 0; r < k; r++)
            {
                s += m1[i, r] * m2[r,j];
            }
            result[i, j] = s;
        }
    }
return result;
}

double[,] MultiplyParallels(double[,] m1, double[,] m2)
{
     int rowsM1 = m1.GetLength(0),
        k = m1.GetLength(1),
        columnsM2 = m2.GetLength(1);

     double[,] result = new double[rowsM1, columnsM2];

    Parallel.For(0,rowsM1, i =>
    {
        for (int j = 0; j < columnsM2; j++)
        {
            double s = 0;
            for (int r = 0; r < k; r++)
            {
                s += m1[i, r] * m2[r,j];
            }
            result[i, j] = s;
        }
    });

     return result;
}

int n = 200;
var m1 = GenerateMatrix(n, n);
//Print(m1);
var m2 = GenerateMatrix(n ,n);
//Print(m2);


DateTime s = DateTime.Now;
var m = MultiplySync(m1, m2);
//Print(m);
DateTime e = DateTime.Now;
Console.WriteLine((e-s).TotalMilliseconds);

s = DateTime.Now;
m = MultiplyParallels(m1, m2);
//Print(m);
e = DateTime.Now;
Console.WriteLine((e-s).TotalMilliseconds);

Console.WriteLine("+");
