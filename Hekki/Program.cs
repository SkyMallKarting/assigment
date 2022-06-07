using Hekki;

List<int> numbersKarts = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8};
var pilots = SheetWorker.Test();

    Console.WriteLine("Введите, что бы рассчитать следующий этап");
    //Console.ReadKey();
    Race.Start(pilots, numbersKarts, 0);
    Console.WriteLine("________________________________________");
    Race.Start(pilots, numbersKarts, 1);
    Console.WriteLine("________________________________________");
    Race.Start(pilots, numbersKarts, 2);
    Console.WriteLine("________________________________________");
    Console.WriteLine("________________________________________");
    foreach (var item in pilots)
    {
        System.Console.WriteLine(item.GetInfo());
    }
    Console.WriteLine();

  