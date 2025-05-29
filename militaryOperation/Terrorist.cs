namespace MilitaryControlSystem
{
    public class Terrorist
    {
        public string Name;
        public int Rank;
        public bool IsAlive;
        public List<string> Weapons;
        public Organization Organization;
        public Terrorist(string name, int rank, bool status, List<string> weaponList, Organization organization)
        {
            Name = name;
            Rank = rank;
            IsAlive = status;
            Weapons = weaponList;
            Organization = organization;
        }

        public int QualityScore()
        {
            int QualityScore = 0;
            foreach (string Weapon in Weapons)
            {
                QualityScore += Weapon switch
                {
                    "knife" => 1,
                    "gun" or "Pistol" or "Grenade"=> 2,
                    "AK-47" or "M16" or "Sniper" => 3,
                    "RPG" or "Explosives"=> 4,
                    "Machine Gun" => 5,
                    _ => 1
                };
            }
            return QualityScore * Rank;
        }

    }
}