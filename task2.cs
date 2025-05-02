using System;

class VectorInt
{
    protected int[] IntArray;
    protected uint size;
    protected int codeError;
    static uint num_vec;

    // Конструктор без параметрів
    public VectorInt()
    {
        size = 1;
        IntArray = new int[size];
        IntArray[0] = 0; // ініціалізуємо елемент нулем
        codeError = 0;
        num_vec++;
    }

    // Конструктор з одним параметром
    public VectorInt(uint sz)
    {
        size = sz;
        IntArray = new int[size];
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = 0;
        }
        codeError = 0;
        num_vec++;
    }

    // Конструктор з двома параметрами
    public VectorInt(uint sz, int initValue)
    {
        size = sz;
        IntArray = new int[size];
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
        codeError = 0;
        num_vec++;
    }

    // Деструктор (викликається під час видалення об'єкта)
    ~VectorInt()
    {
        Console.WriteLine($"Destructor called for vector of size {size}");
        num_vec--;
    }

    // Метод для введення елементів вектора з клавіатури
    public void Input()
    {
        Console.WriteLine($"Enter {size} elements: ");
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = int.Parse(Console.ReadLine());
        }
    }

    // Метод для виведення елементів вектора на екран
    public void Display()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(IntArray[i] + " ");
        }
        Console.WriteLine();
    }

    // Статичний метод для підрахунку кількості векторів
    public static uint GetNumVec()
    {
        return num_vec;
    }

    // Індексатор для доступу до елементів масиву
    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < size)
            {
                return IntArray[index];
            }
            else
            {
                codeError = -1;
                return 0; // Повертаємо 0 при неправильному індексі
            }
        }
        set
        {
            if (index >= 0 && index < size)
            {
                IntArray[index] = value;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    // Операція інкрементації (збільшення кожного елемента на 1)
    public static VectorInt operator ++(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]++;
        }
        return v;
    }

    // Перевантаження операції додавання для двох векторів
    public static VectorInt operator +(VectorInt v1, VectorInt v2)
    {
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(Math.Max(v1.size, v2.size));

        for (int i = 0; i < minSize; i++)
        {
            result.IntArray[i] = v1.IntArray[i] + v2.IntArray[i];
        }

        return result;
    }

    // Перевантаження операції додавання для вектора і скаляра
    public static VectorInt operator +(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] + scalar;
        }
        return result;
    }

    // Перевантаження операції порівняння для рівності
    public static bool operator ==(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size)
            return false;

        for (int i = 0; i < v1.size; i++)
        {
            if (v1.IntArray[i] != v2.IntArray[i])
                return false;
        }

        return true;
    }

    public static bool operator !=(VectorInt v1, VectorInt v2)
    {
        return !(v1 == v2);
    }

    // Операція порівняння "більше"
    public static bool operator >(VectorInt v1, VectorInt v2)
    {
        for (int i = 0; i < Math.Min(v1.size, v2.size); i++)
        {
            if (v1.IntArray[i] <= v2.IntArray[i])
                return false;
        }
        return true;
    }

    // Операція порівняння "менше"
    public static bool operator <(VectorInt v1, VectorInt v2)
    {
        for (int i = 0; i < Math.Min(v1.size, v2.size); i++)
        {
            if (v1.IntArray[i] >= v2.IntArray[i])
                return false;
        }
        return true;
    }

    // Статичний лічильник векторів
    public static uint NumVec()
    {
        return num_vec;
    }
}

class Program
{
    static void Main()
    {
        VectorInt v1 = new VectorInt(5);  // створення вектора з 5 елементів
        VectorInt v2 = new VectorInt(3, 10);  // створення вектора з 3 елементів і значенням 10

        // Виведення векторів
        Console.WriteLine("Vector 1: ");
        v1.Display();

        Console.WriteLine("Vector 2: ");
        v2.Display();

        // Додавання двох векторів
        VectorInt v3 = v1 + v2;
        Console.WriteLine("After addition (v1 + v2): ");
        v3.Display();

        // Додавання вектора і скаляра
        VectorInt v4 = v1 + 5;
        Console.WriteLine("After adding scalar to v1: ");
        v4.Display();

        // Інкремент кожного елемента вектора
        ++v1;
        Console.WriteLine("After incrementing v1: ");
        v1.Display();

        // Перевірка рівності
        Console.WriteLine("v1 == v2: " + (v1 == v2));

        // Порівняння векторів
        Console.WriteLine("v1 > v2: " + (v1 > v2));
        Console.WriteLine("v1 < v2: " + (v1 < v2));

        // Статичний лічильник
        Console.WriteLine("Number of vectors created: " + VectorInt.NumVec());
    }
}
