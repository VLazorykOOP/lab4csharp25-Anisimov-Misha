using System;

class Point
{
    protected int x, y;
    protected int c;

    public Point()
    {
        x = 0;
        y = 0;
        c = 0;
    }

    public Point(int x, int y, int c)
    {
        this.x = x;
        this.y = y;
        this.c = c;
    }

    // Метод для виведення координат точки на екран
    public void PrintCoordinates()
    {
        Console.WriteLine($"Point coordinates: ({x}, {y}), Color: {c}");
    }

    public double DistanceFromOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void Move(int x1, int y1)
    {
        x += x1;
        y += y1;
    }

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public int Color
    {
        get { return c; }
        set { c = value; }
    }

    // Індексатор
    public object this[int index]
    {
        get
        {
            return index switch
            {
                0 => x,
                1 => y,
                2 => c,
                _ => throw new IndexOutOfRangeException("Невірний індекс. Дозволені: 0 (x), 1 (y), 2 (колір).")
            };
        }
        set
        {
            switch (index)
            {
                case 0: x = Convert.ToInt32(value); break;
                case 1: y = Convert.ToInt32(value); break;
                case 2: c = Convert.ToInt32(value); break;
                default: throw new IndexOutOfRangeException("Невірний індекс. Дозволені: 0 (x), 1 (y), 2 (колір).");
            }
        }
    }

    // Перевантаження ++
    public static Point operator ++(Point p)
    {
        return new Point(p.x + 1, p.y + 1, p.c);
    }

    // Перевантаження --
    public static Point operator --(Point p)
    {
        return new Point(p.x - 1, p.y - 1, p.c);
    }

    // Перевантаження true
    public static bool operator true(Point p)
    {
        return p.x == p.y;
    }

    // Перевантаження false
    public static bool operator false(Point p)
    {
        return p.x != p.y;
    }

    // Перевантаження +
    public static Point operator +(Point p, int scalar)
    {
        return new Point(p.x + scalar, p.y + scalar, p.c);
    }

    // Перетворення Point → string
    public static implicit operator string(Point p)
    {
        return $"{p.x},{p.y},{p.c}";
    }

    // Перетворення string → Point
    public static implicit operator Point(string s)
    {
        var parts = s.Split(',');
        if (parts.Length != 3)
            throw new FormatException("Строка має містити 3 значення, розділені комами.");
        return new Point(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення об'єкта Point
        Point p = new Point(3, 3, 1);
        
        // Перевірка рівності x та y
        Console.WriteLine(p ? "x == y" : "x != y"); // Виведе: x == y

        // Збільшення координат на 1
        p++;
        Console.WriteLine((string)p); // Виведе: 4,4,1

        // Перетворення з рядка у точку
        Point q = "5,6,2";
        q.PrintCoordinates(); // Виведе: Point coordinates: (5, 6), Color: 2

        // Доступ до координат через індексатор
        Console.WriteLine(q[0]); // Виведе: 5

        // Зміна координати y через індексатор
        q[1] = 10;
        q.PrintCoordinates(); // Виведе: Point coordinates: (5, 10), Color: 2
    }
}
