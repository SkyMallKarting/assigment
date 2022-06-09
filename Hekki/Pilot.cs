namespace Hekki
{
    class Pilot 
    {
        private string _name;
        private int[] _usedKarts = new int[3]; 
        public string Name {get {return _name;} init {_name = value;}}
        public Pilot(string name)
        {
            Name = name;
        }

        public void AddNumberKart(int numberKart, int numberRace)
        {
            _usedKarts[numberRace] = numberKart;
        }

        public static bool IsCanBeAdd(Pilot pilot, int number)
        {
            if (pilot._usedKarts.Contains(number))
                return false;
            return true;
        }

        public string GetNumberKartByRace(int numberRace)
        {
            return _usedKarts[numberRace].ToString();
        }
    }
}