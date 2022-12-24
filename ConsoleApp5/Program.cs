using DryIoc;
using DryIoc.FastExpressionCompiler.LightExpression;
using System.Net.Sockets;

internal class Program
{
    static int[] GetUniqueArray(int length)
    {
        if (length > 10) length = 10;
        int[] arr = new int[length];
        Random random = new();
        bool isAlreadyThere = false;
        for (int i = 0; i < arr.Length;)
        {
            isAlreadyThere = false;
            var tmp = random.Next(10);
            for (int j = 0; j < i; j++)
            {
                if (arr[j] != tmp) continue;
                isAlreadyThere = true;
                break;
            }

            if (isAlreadyThere) continue;
            arr[i] = tmp;
            i++;
        }

        return arr;
    }

    static void Start()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("####################################################################################################\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                          БЫКИ И КОРОВЫ                                           #\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                                                                                  #\r\n" +
            "#                                                                                                  #\r\n" +
            "####################################################################################################\r\n\r\n\r\n" +
            "  ^__^                ^__^                ^___^                ^__^                ^__^\r\n" +
            "  (оо)\\_______        (оо)\\_______        (T T)\\_______        (оо)\\_______        (оо)\\_______\r\n" +
            "  (__)\\       )\\/\\    (__)\\       )\\/\\    (___)\\       )\\/\\    (__)\\       )\\/\\    (__)\\       )\\/\\\r\n" +
            "     ||----w |           ||----w |            ||----- |            ||----w |           ||----w |\r\n" +
            "     ||     ||           ||     ||            ||     ||            ||     ||           ||     ||\r\n");
        Console.WriteLine("\n\n\n\n\t\t\t\tНажмите любую клавишу чтобы продолжить!");
        Console.ReadKey();
        Console.Clear();
       
    }

    static void ShowArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }
    
    static int GetNumber(out bool flag)
    {
        int number = 0;
        while (true)
        {
            Cow("Введите четырехзначное число\nВведите 0 чтобы выйти");
            int.TryParse(Console.ReadLine(), out number);
            flag = number==0? true : false;
            if (number != 0 && number < 1000 || number > 9999) continue;
            break;
        }
        return number;
    }
    
    static void Cow(string moo)
    {
        Console.WriteLine($"< {moo} >\r\n -----\r\n        \\   ^__^\r\n         \\  (oo)\\_______\r\n            (__)\\       )\\/\\\r\n                ||----w |\r\n                ||     ||");
    }
    static void Intro()
    {
        string[] arr = { "Привет", "Я коровка матрёшка!", "Я раскажу тебе правила игры", "Я загадала четырехзначное число", "Попробуй его отгадать", "Я буду давать тебе подскаски в виде быков и коров", "Коровы - это правильные цифры на неправильных местах", "Быки - это правильные числа на правильных местах в числе" };
        foreach (var phrase in arr)
        {
            Cow(phrase);
            Console.WriteLine("Нажмите любую клавишу что бы продолжить");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static int[] GetUserArray(int number)
    {
        int[] arr = new int[4];
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            arr[i] = number % 10;
            number /= 10;
        }
        return arr;
    }
    static void Game()
    {
        int[] secret = GetUniqueArray(4);
        ShowArray(secret);
        var tries = 0;
        while (true)
        {
            tries++;
            var number = GetNumber(out bool flag);
            if (flag) break;
            int[] arr = GetUserArray(number);
            int cow = 0, bull = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (secret[i] != arr[j]) continue;
                    if (i == j) bull++;
                    else cow++;
                }
            }
            if (bull == 4)
            {
                Console.WriteLine($"Вы победили! Количество попыток : {tries}");
                break;
            }
            Console.WriteLine($"Вы не угадали. Быков: {bull}. Коров: {cow}");
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
    }
    
    private static void Main(string[] args)
    {
        Start();
        Intro();
        Game();
    }
}