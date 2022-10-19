using ConsoleApp7._8;

internal class Program
{
    private static void Main()
    {
        Repository repository = new Repository();
        repository.CreateFileName();

       bool menu = true;
       repository.ShowText();

       while (menu)
       {
           switch (Console.ReadLine())
           {
               case "1":
                   Console.Clear();
                   repository.ShowAllLines();
                   repository.ShowText();
                   break;
               case "2":
                   Console.Clear();
                   repository.FileWriter();
                   repository.ShowText();
                   break;
                case "3":
                   Console.Clear();
                   Console.Write("Введите ID = ");
                   repository.FileReaderByKey(int.Parse(Console.ReadLine()));
                   repository.ShowText();
                   break;
                case "4":
                    Console.Clear();
                    repository.OrderByWorker();
                    repository.ShowText();
                    break;
                case "5":
                    Console.Clear();
                    Console.Write("Введите ID удаляемого сотрудника = ");
                    repository.DelitedLineByKey(int.Parse(Console.ReadLine()));
                    repository.ShowText();
                    break;
                case "6":
                    Console.Clear();
                    repository.ShowLineDate();
                    repository.ShowText();
                    break;
                default:
                   menu = false;
                   Console.WriteLine("Завершение работы...");
                   break;
           }
       }
    }
}