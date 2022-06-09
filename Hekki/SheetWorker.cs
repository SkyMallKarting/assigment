using ClosedXML.Excel;
using System.Diagnostics;
namespace Hekki
{
    class SheetWorker 
    {
        const string _path = "C:\\Users\\ProDesk\\Desktop\\Stuff(Документы)\\Соревнования\\соревыБольше12.xlsx";
        const int keyRow = 3;
        private static int _rowsInGroup = 8;
        
        public static XLWorkbook GetWorkBook()
        {
            CloseExcelIfOpened();
            var wbook = new XLWorkbook(_path);
            return wbook;
        }

        public static List<IXLCell> GetIndexsByValue(IXLWorksheet workSheet, string value)
        {
            var cells = workSheet.Row(keyRow).Search(value);
            return cells.ToList();
        }

        public static List<string> ReadNames(IXLWorksheet workSheet)
        {
            var namesCellsToRead = SheetWorker.GetIndexsByValue(workSheet, "Имя");
            List<string> pilotNames = new List<string>();
            int row = namesCellsToRead[0].Address.RowNumber;
            int column = namesCellsToRead[0].Address.ColumnNumber; 

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

        public static void WriteValueInColumn(IXLWorksheet workSheet, List<Pilot> group, int row, int column, int numberRace)
        {
            int rowIndexToStart = workSheet.Column(column).LastCellUsed().Address.RowNumber + 1;
            

            List<Pilot> fullGroup = new(group);
            if (fullGroup.Count < 8)
                fullGroup = AddEmptysInGroup(group);
            foreach (var pilot in fullGroup)
            {
                if (pilot.Name == "1")
                {
                    workSheet.Cell(rowIndexToStart, column).SetValue(pilot.Name).RichText.SetFontColor(XLColor.White);
                    workSheet.Cell(rowIndexToStart, column - 2).SetValue(pilot.Name).RichText.SetFontColor(XLColor.White);
                    rowIndexToStart++;
                    continue;
                }
                workSheet.Cell(rowIndexToStart, column).Value = pilot.Name;
                workSheet.Cell(rowIndexToStart, column - 2).Value = pilot.GetNumberKartByRace(numberRace);
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

        public static void CleanColumns(IXLWorksheet workSheet, int column, int rowIndexToStart)
        {
            //workSheet.Range()
            int lastIndex = rowIndexToStart + _rowsInGroup;


            workSheet.Column(column).Cells($"{rowIndexToStart}:100").Clear(XLClearOptions.Contents);
            workSheet.Column(column - 2).Cells($"{rowIndexToStart}:100").Clear(XLClearOptions.Contents);
            
        }
    }
}