using ClosedXML.Excel;
using System.Diagnostics;
namespace Hekki
{
    class SheetWorker 
    {
        const string _path = "C:\\Users\\ProDesk\\Desktop\\Stuff(Документы)\\Соревнования\\соревы больше 12.xlsx";
        const int keyRow = 3;
        public static XLWorkbook GetWorkBook()
        {
            CloseExcelIfOpened();
            var wbook = new XLWorkbook(_path);
            return wbook;
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

        private static void CloseExcelIfOpened()
        {
            Process[] processCollection = Process.GetProcesses();  
            foreach (Process p in processCollection)  
            {  
                if ( p.ProcessName == "EXCEL")
                {
                    p.Kill();
                }
            }  
        }

        public static void WriteValueInColumn(IXLWorksheet workSheet, List<Pilot> group, int numberRace)
        {
            var namesCells = GetIndexsByValue(workSheet, "Пилоты");
            int row = namesCells[numberRace].Address.RowNumber;
            int column = namesCells[numberRace].Address.ColumnNumber; 
            int rowIndexToStart = workSheet.Column(column).LastCellUsed().Address.RowNumber + 1;
            List<Pilot> fullGroup = new(group);
            if (fullGroup.Count < 8)
                fullGroup = AddEmptysInGroup(group);
            foreach (var pilot in fullGroup)
            {
                if (pilot.Name == "1")
                {
                    //workSheet.Cell(rowIndexToStart, column).SetValue(pilot.Name).RichText.SetFontColor(XLColor.White);
                    workSheet.Cell(rowIndexToStart, column).SetValue(pilot.Name).RichText.SetFontColor(XLColor.White);
                    rowIndexToStart++;
                    continue;
                }
                workSheet.Cell(rowIndexToStart, column).Value = pilot.Name;
                rowIndexToStart++;
            }
        }
        
        private static List<Pilot> AddEmptysInGroup(List<Pilot> group)
        {
            while (group.Count < 8)
            {
                group.Add(new Pilot("1"));
            }
            return group;
        }
    }
}