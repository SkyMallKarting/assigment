using ClosedXML.Excel;
using System.Diagnostics;
namespace Hekki
{
    class SheetWorker 
    {
        const string _path = "C:\\Users\\ProDesk\\Desktop\\Stuff(Документы)\\Соревнования\\соревы больше 12.xlsx";
        const int keyRow = 3;
        public static IXLWorksheet GetWorkSheet()
        {
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

            return ws1;
        }

        private static List<IXLCell> GetIndexsByValue(IXLWorksheet workSheet, string value)
        {
            var cells = workSheet.Row(keyRow).Search(value);
            return cells.ToList();
        }

        public static List<string> ReadNames(IXLWorksheet workSheet)
        {
            var namesCells = GetIndexsByValue(workSheet, "Имя");
            List<string> pilotNames = new List<string>();
            int row = namesCells[0].Address.RowNumber;
            int column = namesCells[0].Address.ColumnNumber; 

            for (int i = row + 1; i < workSheet.Column(column).LastCellUsed().Address.RowNumber + 1; i++)
            {
                pilotNames.Add(workSheet.Cell(i, column).GetValue<string>());
            }
            return pilotNames;
        }
    }
}