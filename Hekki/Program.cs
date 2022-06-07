using Hekki;

List<int> numbersKarts = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8};
List<Pilot> pilots = new List<Pilot>();
var workSheet = SheetWorker.GetWorkSheet();
var pilotsNames = SheetWorker.ReadNames(workSheet);
foreach (var pilotName in pilotsNames)
{
    pilots.Add(new Pilot(pilotName));
}
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

  