// Program.cs
class Program
{
    static void Main()
    {
        Console.WriteLine("Запустить Part1 - 1");
        Console.WriteLine("Запустить Part2 - 2");

        int choice = InputFunc.ReadInt("\nВведите номер пункта: \n", 1, 2);

        switch (choice)
        {
            case 1:
                {
                    Part1 part1 = new Part1();
                    part1.part1();

                    break;
                }
            case 2:
                {
                    Part2 part2 = new Part2();
                    part2.part2();
                    break;
                }

        }
    }
}



