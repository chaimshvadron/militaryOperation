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
            Dictionary<string, int> weaponScores = new Dictionary<string, int>
                {
                    { "knife", 1 },
                    { "gun", 2 }, { "Pistol", 2 }, { "Grenade", 2 },
                    { "AK-47", 3 }, { "M16", 3 }, { "Sniper", 3 },
                    { "RPG", 4 }, { "Explosives", 4 },
                    { "Machine Gun", 5 }
                };

            foreach (string Weapon in Weapons)
            {

                if (weaponScores.TryGetValue(Weapon, out int score))
                {
                    QualityScore += score;
                }
            }
            return QualityScore * Rank;
        }

    }
}