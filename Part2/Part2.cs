public class Part2
{
    public void part2()
    {
        List<Data> dates = new List<Data>
        {
            new Data {Year = 2024, Month = 1, Day = 15},
            new Data {Year = 2023, Month = 2, Day = 28},
            new Data {Year = 2024, Month = 3, Day = 28},
            new Data {Year = 2000, Month = 3, Day = 20},
            new Data {Year = 2100, Month = 4, Day = 14},
            new Data {Year = 2024, Month = 6, Day = 5},
            new Data {Year = 2024, Month = 1, Day = 19},
            new Data {Year = 2025, Month = 12, Day = 4},
            new Data {Year = 2024, Month = 5, Day = 12},
            new Data {Year = 2024, Month = 8, Day = 2},
            new Data {Year = 2024, Month = 10, Day = 9},
            new Data {Year = 1, Month = 1, Day = 1},
            new Data {Year = 9999, Month = 12, Day = 31},
            new Data {Year = 2024, Month = 12, Day = 1},
            new Data {Year = 2024, Month = 11, Day = 30},
            new Data {Year = 2024, Month = 1, Day = 15},
            new Data {Year = 2024, Month = 2, Day = 29},
            new Data {Year = 2023, Month = 2, Day = 28},
            new Data {Year = 2000, Month = 3, Day = 31},
            new Data {Year = 2100, Month = 4, Day = 14},

        };

        while (true)
        {
            Console.WriteLine("\nВаш выбор:");
            Console.WriteLine("1 - Вывести список дат для заданного года");
            Console.WriteLine("2 - Вывести список дат для заданного месяца");
            Console.WriteLine("3 - Вывести количество дат в определѐнном диапазоне");
            Console.WriteLine("4 - Вывести максимальную дату");
            Console.WriteLine("5 - Вывести первую дату для заданного дня");
            Console.WriteLine("6 - Вывести упорядоченный список дат");
            Console.WriteLine("0 - Выход");

            int choice = InputFunc.ReadInt("\nВведите номер пункта: \n", 0, 6);

            switch (choice)
            {
                case 1:
                    {
                        ListOfDatesForYear(dates);
                        break;
                    }
                case 2:
                    {
                        ListOfDatesForMonth(dates);
                        break;
                    }
                case 3:
                    {
                        DatesInRange(dates);
                        break;
                    }
                case 4:
                    {
                        MaxDate(dates);
                        break;
                    }
                case 5:
                    {
                        DateWithDay(dates);
                        break;
                    }
                case 6:
                    {
                        DatesOrderBy(dates);
                        break;
                    }
                case 0:
                    return;
            }
        }
    }

    public void ListOfDatesForYear(List<Data> dates)
    {
        // Вывести список дат для заданного года
        Console.WriteLine("Вывести список дат для заданного года");

        int year = InputFunc.ReadInt("Введите год (целое число до 2025): ", 1, 2025);

        var ListOfDatesForYear = from date in dates
                                 where date.Year == year
                                 select date;

        var datesList = ListOfDatesForYear.ToList();

        if (datesList.Any()) // Проверяем, есть ли даты
        {
            foreach (var date in datesList)
            {
                Console.WriteLine($"{date.Day}.{date.Month}.{date.Year}");
            }
        }
        else
        {
            Console.WriteLine($"В {year} году нет дат в списке.");
        }
    }
    
    public void ListOfDatesForMonth(List<Data> dates)
    {
        // Вывести список дат в заданном месяце
        Console.WriteLine("Вывести список дат для заданного месяца");
        int month = InputFunc.ReadInt("Введите месяц: ", 1, 12);

        var ListOfDatesForMonth = dates
        .Where(d => d.Month == month)
        .ToList();

        if (ListOfDatesForMonth.Count > 0)
        {
            foreach (var date in ListOfDatesForMonth)
            {
                Console.WriteLine($"{date.Day}.{date.Month}.{date.Year}");
            }
        }
        else
        {
            Console.WriteLine($"В месяце {month} нет дат в списке.");
        }
    }

    public void DatesInRange(List<Data> dates)
    {
        // Вывести количество дат в определѐнном диапазоне
        Console.WriteLine("Вывести количество дат в определѐнном диапазоне");

        int startYear = InputFunc.ReadInt("Введите начальный год: ", 1, 9999);
        int endYear = InputFunc.ReadInt("Введите конечный год: ", 1, 9999);

        if (startYear > endYear)
        {
            Console.WriteLine("Ошибка: начальный год не может быть больше конечного!");
            return;
        }

        var datesInRange = dates
            .Where(d => d.Year >= startYear && d.Year <= endYear)
            .ToList();

        Console.WriteLine($"\nКоличество дат в диапазоне {startYear}-{endYear}: {datesInRange.Count}");

        if (datesInRange.Any())
        {
            Console.WriteLine("Список дат:");
            foreach (var date in datesInRange.OrderBy(d => d.Year).ThenBy(d => d.Month).ThenBy(d => d.Day))
            {
                Console.WriteLine($"  {date.Day:00}.{date.Month:00}.{date.Year}");
            }
        }
        else
        {
            Console.WriteLine("В указанном диапазоне нет дат.");
        }
    }

    public void MaxDate(List<Data> dates)
    {
        // Вывести максимальную дату
        Console.WriteLine("Вывести максимальную дату");

        var MaxDate = dates
        .OrderBy(d => d.Year)
        .ThenBy(d => d.Month)
        .ThenBy(d => d.Day)
        .Last();

        Console.WriteLine($"{MaxDate.Day}.{MaxDate.Month}.{MaxDate.Year}");
    }

    public void DateWithDay(List<Data> dates)
    {
        // Вывести первую дату для заданного дня
        Console.WriteLine("Вывести первую дату для заданного дня");

        int day = InputFunc.ReadInt("Введите день: ", 1, 31);

        var dateWithDay = dates
        .Where(d => d.Day == day)
        .First();

        Console.WriteLine($"{dateWithDay.Day}.{dateWithDay.Month}.{dateWithDay.Year}");
    }
    
    public void DatesOrderBy(List<Data> dates)
    {
        // Вывести упорядоченный список дат (пользователь выбирает, по возрастанию или по убыванию)
        Console.WriteLine("Вывести упорядоченный список дат (пользователь выбирает, по возрастанию или по убыванию)");

        int choice = InputFunc.ReadInt("Введите упорядочить список по возрастанию - 1, по убыванию - 0: ", 0, 1);

        var datesOrderBy = from date in dates
                           orderby date.Year, date.Month, date.Day
                           select date;

        switch (choice)
        {
            case 1:
                {
                    foreach (var date in datesOrderBy) Console.WriteLine($"{date.Day}.{date.Month}.{date.Year}");
                    break;
                }
            case 0:
                {
                    foreach (var date in datesOrderBy.Reverse()) Console.WriteLine($"{date.Day}.{date.Month}.{date.Year}");
                    break;
                }
        }
    }
}