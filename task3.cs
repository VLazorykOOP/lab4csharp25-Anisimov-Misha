using System;

class MatrixInt
{
    // Поля класу
    protected int[,] IntArray;
    protected int n, m;
    protected int codeError;
    static int num_vec = 0;

    // Конструктори
    public MatrixInt()
    {
        n = 1;
        m = 1;
        IntArray = new int[n, m];
        IntArray[0, 0] = 0;
        num_vec++;
    }

    public MatrixInt(int n, int m)
    {
        this.n = n;
        this.m = m;
        IntArray = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                IntArray[i, j] = 0;
        num_vec++;
    }

    public MatrixInt(int n, int m, int initValue)
    {
        this.n = n;
        this.m = m;
        IntArray = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                IntArray[i, j] = initValue;
        num_vec++;
    }

    // Деструктор
    ~MatrixInt()
    {
        Console.WriteLine("Matrix destroyed");
        num_vec--;
    }

    // Методи
    public void InputElements()
    {
        Console.WriteLine("Enter elements of the matrix:");
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                IntArray[i, j] = int.Parse(Console.ReadLine());
    }

    public void OutputElements()
    {
        Console.WriteLine("Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(IntArray[i, j] + " ");
            Console.WriteLine();
        }
    }

    public void SetAllElements(int value)
    {
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                IntArray[i, j] = value;
    }

    public static int GetNumVec()
    {
        return num_vec;
    }

    // Властивості
    public int N => n;
    public int M => m;
    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатори
    public int this[int i, int j]
    {
        get
        {
            if (i >= n || j >= m || i < 0 || j < 0)
            {
                codeError = -1;
                return 0;
            }
            return IntArray[i, j];
        }
        set
        {
            if (i >= n || j >= m || i < 0 || j < 0)
            {
                codeError = -1;
            }
            else
            {
                IntArray[i, j] = value;
            }
        }
    }

    public int this[int k]
    {
        get
        {
            if (k >= n * m || k < 0)
            {
                codeError = -1;
                return 0;
            }
            return IntArray[k / m, k % m];
        }
        set
        {
            if (k >= n * m || k < 0)
            {
                codeError = -1;
            }
            else
            {
                IntArray[k / m, k % m] = value;
            }
        }
    }

    // Перевантаження операцій
    // Оператор додавання для двох матриць
    public static MatrixInt operator +(MatrixInt m1, MatrixInt m2)
    {
        int rows = Math.Min(m1.n, m2.n);
        int cols = Math.Min(m1.m, m2.m);
        MatrixInt result = new MatrixInt(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result.IntArray[i, j] = m1.IntArray[i, j] + m2.IntArray[i, j];
        return result;
    }

    // Оператор додавання для матриці та скаляра
    public static MatrixInt operator +(MatrixInt m, int scalar)
    {
        MatrixInt result = new MatrixInt(m.n, m.m);
        for (int i = 0; i < m.n; i++)
            for (int j = 0; j < m.m; j++)
                result.IntArray[i, j] = m.IntArray[i, j] + scalar;
        return result;
    }

    // Оператор віднімання для двох матриць
    public static MatrixInt operator -(MatrixInt m1, MatrixInt m2)
    {
        int rows = Math.Min(m1.n, m2.n);
        int cols = Math.Min(m1.m, m2.m);
        MatrixInt result = new MatrixInt(rows, cols);
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result.IntArray[i, j] = m1.IntArray[i, j] - m2.IntArray[i, j];
        return result;
    }

    // Оператор множення для двох матриць
    public static MatrixInt operator *(MatrixInt m1, MatrixInt m2)
    {
        if (m1.m != m2.n)
        {
            Console.WriteLine("Matrix dimensions do not allow multiplication.");
            return null;
        }
        MatrixInt result = new MatrixInt(m1.n, m2.m);
        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m2.m; j++)
                for (int k = 0; k < m1.m; k++)
                    result.IntArray[i, j] += m1.IntArray[i, k] * m2.IntArray[k, j];
        return result;
    }

    // Оператор множення для матриці та скаляра
    public static MatrixInt operator *(MatrixInt m, int scalar)
    {
        MatrixInt result = new MatrixInt(m.n, m.m);
        for (int i = 0; i < m.n; i++)
            for (int j = 0; j < m.m; j++)
                result.IntArray[i, j] = m.IntArray[i, j] * scalar;
        return result;
    }

    // Перевантаження порівняння
    public static bool operator ==(MatrixInt m1, MatrixInt m2)
    {
        if (m1.n != m2.n || m1.m != m2.m)
            return false;

        for (int i = 0; i < m1.n; i++)
            for (int j = 0; j < m1.m; j++)
                if (m1.IntArray[i, j] != m2.IntArray[i, j])
                    return false;

        return true;
    }

    public static bool operator !=(MatrixInt m1, MatrixInt m2)
    {
        return !(m1 == m2);
    }

    // Перевантаження операцій порівняння
    public static bool operator >(MatrixInt m1, MatrixInt m2)
    {
        return m1.IntArray.Length > m2.IntArray.Length;
    }

    public static bool operator <(MatrixInt m1, MatrixInt m2)
    {
        return m1.IntArray.Length < m2.IntArray.Length;
    }

    public static bool operator >=(MatrixInt m1, MatrixInt m2)
    {
        return m1.IntArray.Length >= m2.IntArray.Length;
    }

    public static bool operator <=(MatrixInt m1, MatrixInt m2)
    {
        return m1.IntArray.Length <= m2.IntArray.Length;
    }

    // Статичний метод для отримання кількості створених матриць
    public static int GetNumVec()
    {
        return num_vec;
    }

    // Перевантаження унарної операції !
    public static bool operator !(MatrixInt m)
    {
        for (int i = 0; i < m.n; i++)
            for (int j = 0; j < m.m; j++)
                if (m.IntArray[i, j] != 0)
                    return true;
        return false;
    }

    // Перевантаження операції побітового заперечення ~
    public static MatrixInt operator ~(MatrixInt m)
    {
        MatrixInt result = new MatrixInt(m.n, m.m);
        for (int i = 0; i < m.n; i++)
            for (int j = 0; j < m.m; j++)
                result.IntArray[i, j] = ~m.IntArray[i, j];
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MatrixInt mat1 = new MatrixInt(2, 2, 1);
        MatrixInt mat2 = new MatrixInt(2, 2, 2);
        
        mat1.OutputElements();
        mat2.OutputElements();
        
        MatrixInt mat3 = mat1 + mat2;
        mat3.OutputElements();

        MatrixInt mat4 = mat1 * 2;
        mat4.OutputElements();
        
        Console.WriteLine(mat1 == mat2);  // False
        Console.WriteLine(mat1 != mat2);  // True
        
        Console.WriteLine(MatrixInt.GetNumVec());  // 3
    }
}
