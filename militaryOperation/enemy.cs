namespace militaryOperation.Enemy
{
    public class Enemy
    {
        
    }

    public class Hamas
    {
        public string DateOfEstablishment, CurrentCensus;
        public List<Terrorist> ListTerrorist = new();
        public Hamas(string dateOfEstablishment, string currentCensus)
        {
            DateOfEstablishment = dateOfEstablishment;
            CurrentCensus = currentCensus;
        }
    }

    public class Terrorist
    {
        public string Name;
        public int Rank;
        public bool Status;
        public List<string> WeaponList = new ();
        public Terrorist(string name, int rank, bool status)
        {
            Name = name;
            Rank = rank;
            Status = status;
        }
    }
}