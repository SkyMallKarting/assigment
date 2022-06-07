using ClosedXML.Excel;
using System.Diagnostics;
namespace Hekki
{
    class SheetWorker 
    {
        
        public static List<Pilot> Test()
        {
            const string _path = "C:\\Users\\ProDesk\\Desktop\\Stuff(Документы)\\Соревнования\\соревы больше 12.xlsx";
            Process[] processCollection = Process.GetProcesses();  
            foreach (Process p in processCollection)  
            {  
                if ( p.ProcessName == "EXCEL")
                {
                    p.Kill();
                }
            }  
            using var wbook = new XLWorkbook(_path);

            var ws1 = wbook.Worksheet(1); 
            const int startIndexInSheet = 4;
            int i = startIndexInSheet;
            while (true)
            {
                if (ws1.Cell("D"+ i.ToString()).GetValue<string>() == "")
                    break;
                i++;
            }
            List<Pilot> pilots = new List<Pilot>();
            for (int j = startIndexInSheet; j < i; j++)
            {
                string name = ws1.Cell("D"+ j.ToString()).GetValue<string>();
                pilots.Add(new Pilot(name));
            }
           // Process.Start("EXCEL.EXE");
           return pilots;
        }
    }
}