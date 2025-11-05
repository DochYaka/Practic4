using System.Linq;

public class Part1
{
    string[] months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    List<Month> monthsObjects = new List<Month>
        {
            new Month {Name = "January", Season = Season.Winter},
            new Month {Name = "February", Season = Season.Winter},
            new Month {Name = "March", Season = Season.Spring},
            new Month {Name = "April", Season = Season.Spring},
            new Month {Name = "May", Season = Season.Spring},
            new Month {Name = "June", Season = Season.Summer},
            new Month {Name = "July", Season = Season.Summer},
            new Month {Name = "August", Season = Season.Summer},
            new Month {Name = "September", Season = Season.Autumn},
            new Month {Name = "October", Season = Season.Autumn},
            new Month {Name = "November", Season = Season.Autumn},
            new Month {Name = "December", Season = Season.Winter},
        };

    public void part1()
    {
        while (true)
        {
            Console.WriteLine("\nВаш выбор:");
            Console.WriteLine("1 - Выбрать последовательность месяцев с длиной строки названия равной заданному числу n\n");
            Console.WriteLine("2 - Выбрать только летние и зимние месяцы, а также вывести названия месяцев в алфавитном порядке\n");
            Console.WriteLine("3 - Подсчитать количество месяцев, содержащих в названии букву «u» и длиной имени не менее 4-х символов\n");
            Console.WriteLine("0 - Выход");

            int choice = InputFunc.ReadInt("\nВведите номер пункта: \n", 0, 3);

            switch (choice)
            {
                case 1:
                    {
                        MonthsWithLength();
                        break;
                    }
                case 2:
                    {
                        MonthsSummerAndWinter();
                        break;
                    }
                case 3:
                    {
                        MounthWithCharU();
                        break;
                    }
                case 0:
                    return;
            }
        }
    }

    public void MonthsWithLength()
    {
        // Выбрать последовательность месяцев с длиной строки названия равной 
        // заданному числу n
        Console.WriteLine("Выбрать последовательность месяцев с длиной строки названия равной заданному числу n");

        int length = InputFunc.ReadInt("Введите число length (от 3 до 9): ", 3, 9);

        var monthsWithLength = from month in months
                               where month.Length == length
                               select month;

        foreach (var mounth in monthsWithLength)
        {
            Console.WriteLine(mounth);
        }
    }

    public void MonthsSummerAndWinter()
    {
        // Выбрать только летние и зимние месяцы,
        // а также вывести названия месяцев в алфавитном порядке
        Console.WriteLine("Выбрать только летние и зимние месяцы, а также вывести названия месяцев в алфавитном порядке");

        var monthsSummerAndWinter = monthsObjects.Where(m => m.Season == Season.Summer || m.Season == Season.Winter);

        foreach (var monthOfSummerAndWinter in monthsSummerAndWinter.OrderBy(m => m.Name))
        {
            Console.WriteLine($"{monthOfSummerAndWinter.Name} - {monthOfSummerAndWinter.Season}");
        }
    }
    
    public void MounthWithCharU()
    {
        // Подсчитать количество месяцев, содержащих в названии букву «u» и 
        // длиной имени не менее 4-х символов
        Console.WriteLine("Подсчитать количество месяцев, содержащих в названии букву «u» и длиной имени не менее 4-х символов");

        int count = 0;

        var mounthWithCharU = months
        .Where(m => m.Contains('u') && m.Length >= 4);

        foreach (var m in mounthWithCharU)
        {
            count += 1;
            Console.WriteLine(m);
        }
        Console.WriteLine($"Количество месяцев, содержащих в названии букву «u» и длиной имени не менее 4-х символов: {count}");
    }
}