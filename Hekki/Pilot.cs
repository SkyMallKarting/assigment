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

        private int FindEmptyIndex()
        {
            for (int i = 0; i < _usedKarts.Length; i++)
            {
                if (_usedKarts[i] == 0)
                    return i;
            }
            return -1;
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

        public string GetInfo()
        {
            string res = _name;
            for (int i = 0; i < _usedKarts.Length; i++)
            {
                res +=  "\t" + _usedKarts[i];
            }
            return res;
        }

        public static string[] GetGroupInfo(List<Pilot> group, int numberRace)
        {
            string[] groupInfo = new string[group.Count];
            int index = 0;
            foreach (var pilot in group)
            {
                groupInfo[index] = pilot._name + "\t\t\t" + pilot._usedKarts[numberRace].ToString();
                index++;
            }
            return groupInfo;
        }
    }
}