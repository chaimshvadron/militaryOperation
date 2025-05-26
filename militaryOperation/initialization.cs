namespace Military_control_system
{
    static class initialization
    {
        public static List<AttackSystem> initializationAttackSystem()
        {
            var f16_1 = new FighterJetF16("Falcon One", 12, 900, "Captain A");
            var f16_2 = new FighterJetF16("Falcon Two", 10, 850, "Captain B");
            var f16_3 = new FighterJetF16("Falcon Three", 15, 950, "Captain C");

            var drone_1 = new Drone("Predator Alpha", 6, 400);
            var drone_2 = new Drone("Predator Beta", 8, 450);

            var artillery_1 = new Artillery("Cannon X", 120, 300);
            var artillery_2 = new Artillery("Cannon Y", 140, 350);


            return new() { artillery_1, artillery_2, drone_1, drone_2, f16_1, f16_2, f16_3 };

        }

        public static void InitializeDatabase(Database db, Organization organizations)
        {
            var terrorists = GenerateTerrorists(organizations);
            PopulateDatabaseWithTerroristsAndIntel(terrorists, db);

        }

        public static List<Terrorist> GenerateTerrorists(Organization organizations)
        {
            var names = new List<string> { "Ali", "Khalid", "Yusuf", "Hassan", "Omar", "Sami", "Nabil", "Zayd", "Tariq", "Bilal" };
            var weaponsPool = new List<string> { "AK-47", "Pistol", "RPG", "Knife", "Sniper", "Explosives", "Grenade", "Machine Gun" };

            var random = new Random();
            var list = new List<Terrorist>();

            for (int i = 0; i < 10; i++)
            {
                string name = names[random.Next(names.Count)];
                int rank = random.Next(1, 6);
                bool isAlive = true;

                var weapons = new List<string>();
                int weaponCount = random.Next(1, 4);
                while (weapons.Count < weaponCount)
                {
                    string weapon = weaponsPool[random.Next(weaponsPool.Count)];
                    if (!weapons.Contains(weapon))
                        weapons.Add(weapon);
                }

                list.Add(new Terrorist(name, rank, isAlive, weapons, organizations));
            }

            return list;
        }
        public static void PopulateDatabaseWithTerroristsAndIntel(List<Terrorist> terrorists, Database db)
        {
            var random = new Random();
            var possibleLocations = new List<string>
            {
                "Car", "House", "Yard", "Warehouse", "Rooftop", "Dark Alley", "Highway", "Crowded Market", "Mosque",
                "Abandoned Military Base"
            };
            // "Forest", "Cave", "Gas Station", "Train Station", "Grocery Store", "Local Clinic",
            // "Abandoned School", "Refugee Camp", "River", "Boat", "Open Field", "Police Station", "Garage",
            // "Underground Parking", "Government Building", "Side Road", "Main Junction", "Abandoned Airstrip", "Aircraft Hangar"

            foreach (var terrorist in terrorists)
            {
                int id = db.AddTerrorist(terrorist);

                int intelCount = random.Next(1, 21);
                for (int i = 0; i < intelCount; i++)
                {
                    string location = possibleLocations[random.Next(possibleLocations.Count)];
                    var intel = new IntelInformation(id, location);
                    db.AddIntelligence(id, intel);
                }
            }
        }

    }
}