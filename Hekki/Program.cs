using Hekki;
string[] names = new string[]
{
   "KARLENKO",
"VOLOSHYN",
"MARTOLOG",
"OLIFIRENKO",
"KONDRATENKO",
"KOVALCHUK",
"TIAZHKIY",
"KOPTYEV",
"VOLKOV",
"SEMENEC",
"RUDENKO",
"SHARAPOV",
"BRAZHNIKOV",
"KORDIK",
"FEDORCHUK M.",
"SAVCHUK",
"BUCHINSKIY",
"CHELPAN",
"LUNIN",
"ARHIPOV",
"MARTYNENKO",
"FEDORCHUK A.",
"FEDORCHUK B.",
"NEKIPELOV"
};

List<int> numbersKarts = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8};
List<Pilot> pilots = new(names.Length);
for (int i = 0; i < names.Length; i++)
{
    pilots.Add(new Pilot(names[i]));
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

  