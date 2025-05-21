namespace militaryOperation.Enemy
{
    public class Enemy
    {
        // add
    }

    public class Hamas
    {
        public string DateOfEstablishment, CurrentCommander;
        public List<Terrorist> ListTerrorist { get; } = new();
        public Hamas(string dateOfEstablishment, string currentCensus)
        {
            DateOfEstablishment = dateOfEstablishment;
            CurrentCommander = currentCensus;
        }

        public void AadTerrorist(Terrorist terrorist)
        {
            ListTerrorist.Add(terrorist);
            Console.WriteLine("===== terrorist added successfully ======");
            Console.WriteLine($"Name: {terrorist.Name}");
            Console.WriteLine($"Rank: {terrorist.Rank}");
            Console.WriteLine($"Status: {terrorist.IsAlive}");
        }
    }

    public class Terrorist
    {
        public string Name;
        public int Rank;
        public bool IsAlive;
        public List<string> WeaponList;
        public Terrorist(string name, int rank, bool status, List<string> weaponList)
        {
            Name = name;
            Rank = rank;
            IsAlive = status;
            WeaponList = weaponList;
        }
    }
}