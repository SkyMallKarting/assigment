using Hekki;

List<int> numbersKarts = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8};
List<Pilot> pilots = new List<Pilot>();
var workBook = SheetWorker.GetWorkBook();
var workSheet = workBook.Worksheet(1);
var pilotsNames = SheetWorker.ReadNames(workSheet);
foreach (var pilotName in pilotsNames)
{
    pilots.Add(new Pilot(pilotName));
}
    //Console.WriteLine("Введите, что бы рассчитать следующий этап");
    //Console.ReadKey();
Race.Start(pilots, numbersKarts, 0, workSheet);

Race.Start(pilots, numbersKarts, 1, workSheet);

Race.Start(pilots, numbersKarts, 2, workSheet);

//Console.WriteLine("________________________________________");
// foreach (var item in pilots)
// System.Console.WriteLine(item.GetInfo());
    
Console.WriteLine();
workBook.Save();
  