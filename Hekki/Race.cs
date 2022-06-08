using ClosedXML.Excel;
using System.Diagnostics;
namespace Hekki
{
    class Race
    {
        public const int MaxOfKarts = 8;
        private static Random rng = new Random();  
        public static void Start(List<Pilot> pilots, List<int> numbers, int numberRace, IXLWorksheet workSheet)
        {
            List<List<Pilot>> groups = DevideByGroup(pilots, numbers);
            for (int i = 0; i < groups.Count; i++)
            {
                DoAssignmentToGroup(groups[i], numbers, numberRace);
                SheetWorker.WriteValueInColumn(workSheet, groups[i], numberRace);
                System.Console.WriteLine($"Хит {numberRace + 1}, группа {i + 1}");
                foreach (var line in Pilot.GetGroupInfo(groups[i], numberRace))
                {
                    Console.WriteLine(line);
                }
            } 
        }

        private static void DoAssignmentToGroup(List<Pilot> group, List<int> numbersOfKarts, int numberRace)
        {
            List<int> copyNumbersOfKarts = new List<int>();
            CopyList(numbersOfKarts, copyNumbersOfKarts = new List<int>());
            Shuffle(group);
            while (copyNumbersOfKarts.Count > group.Count)  
                copyNumbersOfKarts.RemoveAt(0);
            for (int j = 0; j < group.Count; j++)
            {
                int k = 0;
                while (k < copyNumbersOfKarts.Count)
                {
                    if (Pilot.IsCanBeAdd(group[j], copyNumbersOfKarts[k]))
                    {
                        group[j].AddNumberKart(copyNumbersOfKarts[k], numberRace);
                        copyNumbersOfKarts.RemoveAt(k);
                        //group[j].GetInfo();
                        break;
                    }
                    k++;
                }
            } 
            if (copyNumbersOfKarts.Count > 0)
            {
                for (int i = 0; i < group.Count; i++)
                    group[i].AddNumberKart(0, numberRace);
                DoAssignmentToGroup(group, numbersOfKarts, numberRace);
            }
           //Show(group);
        }

        private static List<List<Pilot>> DevideByGroup(List<Pilot> pilots, List<int> numbersOfKarts)
        {
            Shuffle(pilots);

            List<List<Pilot>> groups = new List<List<Pilot>>();
            int countGroups =  (int)Math.Ceiling((double)pilots.Count / numbersOfKarts.Count);

            for (int i = 0; i < countGroups; i++)
                groups.Add(new List<Pilot>());

            for (int i = 0, j = 0; i < pilots.Count; i++, j++)
            {
                if (j == countGroups)
                    j = 0;
                groups[j].Add(pilots[i]);
            }
            
            return groups;
        }

        private static void Shuffle<T>(IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) 
            {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }

        private static void CopyList<T>(List<T> source, List<T> destination)
        {
            Shuffle(source);
            source.ForEach((item) =>
            {
                destination.Add((item));
            });
        }

        private static void Show(List<Pilot> group)
        {
            foreach (var pilot in group)
            {
                System.Console.WriteLine(pilot.GetInfo());
            }
        }
    }
}