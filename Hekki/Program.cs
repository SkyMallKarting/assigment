using Hekki;
using System.Diagnostics;

List<int> numbersKarts = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8};
List<Pilot> pilots = new List<Pilot>();

var workBook = SheetWorker.GetWorkBook();
var workSheet = workBook.Worksheet(1);
var pilotsNames = SheetWorker.ReadNames(workSheet);

foreach (var pilotName in pilotsNames)
    pilots.Add(new Pilot(pilotName));

Race.Start(pilots, numbersKarts, 0, workSheet);

Race.Start(pilots, numbersKarts, 1, workSheet);

Race.Start(pilots, numbersKarts, 2, workSheet);

workBook.Save();

StarEx("C:\\Users\\ProDesk\\Desktop\\Stuff(Документы)\\Соревнования\\соревыБольше12.xlsx");
void StarEx(string f)
{
        ProcessStartInfo startInfo = new ProcessStartInfo();
       startInfo.FileName = "C:\\Program Files\\Microsoft Office\\root\\Office16\\EXCEL.EXE";
       startInfo.Arguments = f;
       Process.Start(startInfo);    
}
  