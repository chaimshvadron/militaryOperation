namespace Military_control_system
{
    class Aman
    {
        public Database Database;
        public Aman(Database database)
        {
            Database = database;
        }

        public int mostDangerousTerrorist()
        {
            int Score = 0;
            int IdTerrorist = 1;
            for (int id = 1; id < Database.databaseTerrorist.Count; id++)
            {

                Terrorist terrorist = Database.databaseTerrorist[id];
                Console.WriteLine(terrorist.Name + " " + terrorist.QualityScore() + " " + terrorist.Rank);
                if (terrorist.IsAlive && terrorist.QualityScore() > Score)
                {
                    IdTerrorist = id;
                    Score = terrorist.QualityScore();
                    // Console.WriteLine($"terrorist name: {terrorist.Name}  ====== Quality Score: {terrorist.QualityScore()}");
                }
            }
            return IdTerrorist;
        }

        public int mostInformation()
        {
            int IdTerrorist = 1;
            for (int id = 1; id < Database.databaseIntelligence.Count; id++)
            {
                Terrorist terrorist = Database.databaseTerrorist[id];
                if (terrorist.IsAlive && Database.databaseIntelligence[id].Count > Database.databaseIntelligence[IdTerrorist].Count)
                {
                    IdTerrorist = id;
                    Console.WriteLine($"terrorist name: {terrorist.Name}  ====== Intelligence: {Database.databaseIntelligence[id].Count}");
                }
            }
            return IdTerrorist;
        }

    }

    class IntelInformation
    {
        public int Id;
        public string LastLocation;
        public DateTime Timestamp = DateTime.UtcNow;
        public IntelInformation(int IdTerrorist, string lastLocation)
        {
            Id = IdTerrorist;
            LastLocation = lastLocation;
        }

    }

    class Attack_Management
    {
        string OfficerName;
        public Database Database;
        public Force Force;
        public Attack_Management(Database database, string officerName, Force force)
        {
            OfficerName = officerName;
            Database = database;
            Force = force;

        }


        public void AttackExecution(int terroristId)
        {
            DateTime time = DateTime.Now;
            Terrorist Terrorist = Database.GetTerroristBiId(terroristId);
            IntelInformation LatestIntelligence = Database.LatestInformation(terroristId);
            string target = LatestIntelligence.LastLocation;

            foreach (AttackSystem attackSystem in Force.attackSystems)
            {
                if (attackSystem.TargetTypeAndWeapon.ContainsKey(target))
                {
                    bool attac = attackSystem.ExecuteStrike(target);
                    if (attac)
                    {
                        Terrorist.IsAlive = false;
                        PrintSuccessMessage(target, time, Terrorist);
                        return;
                    }
                }
            }
            Console.WriteLine("No suitable weapon system found!! ");

        }

        public void PrintSuccessMessage(string target, DateTime time, Terrorist terrorist)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");
            Console.WriteLine("     Attack successfully carried out");
            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("time     : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(time);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Location           : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(target);

            terrorist.Print();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");

            Console.ResetColor();
        }

    }

    public abstract class AttackSystem
    {
        public string Name { get; }
        public int AmmunitionCapacity { get; set; }
        public int FuelSupply { get; set; }
        protected Random random = new();

        public AttackSystem(string name, int ammunitionCapacity, int fuelSupply)
        {
            Name = name;
            AmmunitionCapacity = ammunitionCapacity;
            FuelSupply = fuelSupply;
        }

        public void AddFuel(int fuel)
        {
            FuelSupply += fuel;
            Console.WriteLine($"{fuel} units of fuel added.");
            Console.WriteLine($"Total fuel now: {FuelSupply}");
        }
        public void AddAmmunition(int ammunition)
        {
            AmmunitionCapacity += ammunition;
            Console.WriteLine($"{ammunition} units of ammunition added.");
            Console.WriteLine($"Total ammunition now: {AmmunitionCapacity}");
        }
        public bool CanStrike(int fuel, int ammunition)
        {
            Console.WriteLine($"Total fuel: {FuelSupply}");
            Console.WriteLine($"Total ammunition: {AmmunitionCapacity}");

            if (AmmunitionCapacity > ammunition && FuelSupply > fuel)
            {
                Console.WriteLine($"System is {Name} ready to strike: ammunition and fuel levels are sufficient.");
                return true;
            }
            else
            {
                Console.WriteLine("System cannot strike: insufficient ammunition or fuel.");
                return false;
            }
        }

        public bool YaelAgainstTarget(string target)
        {
            if (TargetTypeAndWeapon.ContainsKey(target)) return true;
            return false;
        }

        public void Report()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"--- Strike Report for {Name} ---");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Fuel Available: {FuelSupply}");
            Console.WriteLine($"Ammunition Available: {AmmunitionCapacity}");

            foreach (var target_Weapon in TargetTypeAndWeapon)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($" - target: {target_Weapon.Key} - Weapon: {target_Weapon.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"==============================");
            Console.ResetColor();
        }

        abstract public bool ExecuteStrike(string target);
        abstract public Dictionary<string, string> TargetTypeAndWeapon { get; set; }
    }


    public class FighterJetF16 : AttackSystem
    {
        public string Pilot { get; }
        public override Dictionary<string, string> TargetTypeAndWeapon { get; set; } = new Dictionary<string, string>
        {
            { "Crowded Market", "AIM-120 AMRAAM" },
            { "Mosque", "GBU-12 Paveway II" },
            { "Abandoned Military Base", "AGM-84 Harpoon" }
        };

        public FighterJetF16(string name, int ammunitionCapacity, int fuelSupply, string pilot) : base(name, ammunitionCapacity, fuelSupply)
        {
            Pilot = pilot;
        }

        public override bool ExecuteStrike(string target)
        {
            int fuel = random.Next(150, 300);
            int ammunition = random.Next(1, 3);

            if (!CanStrike(fuel, ammunition)) return false;
            AmmunitionCapacity -= ammunition;
            FuelSupply -= fuel;
            Console.WriteLine($"F16 {Name} dropped {TargetTypeAndWeapon[target]} bomb on target.");
            Console.WriteLine($"Remaining ammo: {AmmunitionCapacity}");
            Console.WriteLine($"Remaining fuel: {FuelSupply}");
            return true;
        }
    }

    public class Drone : AttackSystem
    {
        public override Dictionary<string, string> TargetTypeAndWeapon { get; set; } = new Dictionary<string, string>
        {
            { "Rooftop", "AGM-114 Hellfire" },
            { "Dark Alley", "Laser-guided Mini Missile" },
            { "Highway", "Precision-guided Small Bomb" }
        };

        public Drone(string name, int ammunitionCapacity, int fuelSupply) : base(name, ammunitionCapacity, fuelSupply) { }

        public override bool ExecuteStrike(string target)
        {
            int fuel = random.Next(50, 100);
            int ammunition = random.Next(1, 3);

            if (!CanStrike(fuel, ammunition)) return false;
            AmmunitionCapacity -= ammunition;
            FuelSupply -= fuel;
            Console.WriteLine($"Drone {Name} dropped {TargetTypeAndWeapon[target]} bomb on target.");
            Console.WriteLine($"Remaining ammo: {AmmunitionCapacity}");
            Console.WriteLine($"Remaining fuel: {FuelSupply}");
            return true;
        }
    }

    public class Artillery : AttackSystem
    {
        public override Dictionary<string, string> TargetTypeAndWeapon { get; set; } = new Dictionary<string, string>
        {
            { "Car", "155mm High-Explosive Shell" },
            { "House", "GPS-guided Excalibur Shell" },
            { "Warehouse", "Airburst Fragmentation Shell" }
        };

        public Artillery(string name, int ammunitionCapacity, int fuelSupply) : base(name, ammunitionCapacity, fuelSupply) { }

        public override bool ExecuteStrike(string target)
        {
            int fuel = random.Next(10, 80);
            int ammunition = random.Next(3, 40);

            if (!CanStrike(fuel, ammunition)) return false;
            AmmunitionCapacity -= ammunition;
            FuelSupply -= fuel;
            Console.WriteLine($"Artillery {Name} dropped {TargetTypeAndWeapon[target]} bomb on target.");
            Console.WriteLine($"Remaining ammo: {AmmunitionCapacity}");
            Console.WriteLine($"Remaining fuel: {FuelSupply}");
            return true;
        }
    }
    class ControlSystem
    {
        Database database;
        Aman aman;
        Force force;
        Attack_Management attack_Management;
        public ControlSystem(Organization organization, Organization organizationEnemy, string officerName)
        {
            database = new();
            initialization.InitializeDatabase(database, organizationEnemy);

            aman = new(database);
            force = new(organization, initialization.initializationAttackSystem());
            attack_Management = new(database, officerName, force);
        }

        public void IntelligenceAnalysis()
        {
            int IdTerrorist = aman.mostInformation();
            Terrorist terrorist = database.GetTerroristBiId(IdTerrorist);

            Console.WriteLine(" ======= The terrorist with the most intelligence =======");
            terrorist.Print();

        }
        public void AttackAvailability()
        {
            force.PrintReport();
        }

        public void TargetPrioritization()
        {
            int IdTerrorist = aman.mostDangerousTerrorist();
            Terrorist terrorist = database.GetTerroristBiId(IdTerrorist);

            Console.WriteLine(" ======= The most dangerous terrorist =======");
            terrorist.Print();

        }

        public void AttackExecution()
        {
            int IdTerrorist = aman.mostDangerousTerrorist();
            attack_Management.AttackExecution(IdTerrorist);

        }

        public void StatusDatabase()
        {
            Console.WriteLine();
            foreach (var item in database.databaseTerrorist)
            {
                Console.WriteLine(item.Key);
                item.Value.Print();
                Console.WriteLine("====================");
                foreach (var item2 in database.databaseIntelligence[item.Key])
                {

                    Console.WriteLine($"Last Location:{item2.LastLocation}   ====   Timestamp: {item2.Timestamp}");

                }
                Console.WriteLine("====================");
            }
        }

    }
    class Database
    {
        public Dictionary<int, Terrorist> databaseTerrorist = new(); // ID של מחבל 
        public Dictionary<int, List<IntelInformation>> databaseIntelligence = new(); // ID של מחבל  ןמודיעין


        public int AddTerrorist(Terrorist terrorist)
        {
            int id = databaseTerrorist.Count + 1;
            databaseTerrorist.Add(id, terrorist);
            return id;
        }

        public void AddIntelligence(int id, IntelInformation intelInformation)
        {
            if (!databaseIntelligence.ContainsKey(id))
            {
                databaseIntelligence.Add(id, new List<IntelInformation>());
            }
            databaseIntelligence[id].Add(intelInformation);
        }

        public Terrorist GetTerroristBiId(int id)
        {
            return databaseTerrorist[id];
        }

        public IntelInformation LatestInformation(int id)
        {
            List<IntelInformation> ListIntelligence = databaseIntelligence[id];
            IntelInformation LatestInformation = ListIntelligence[0];
            foreach (IntelInformation information in ListIntelligence)
            {
                if (information.Timestamp > LatestInformation.Timestamp)
                {
                    LatestInformation = information;
                }
            }
            return LatestInformation;
        }

    }
    class Force
    {
        public List<AttackSystem> attackSystems = new();
        Organization Organization;
        public Force(Organization organization, List<AttackSystem> attack)
        {
            foreach (AttackSystem item in attack)
            {
                attackSystems.Add(item);
            }
            Organization = organization;
        }

        public void PrintReport()
        {
            int Available = 0;
            foreach (AttackSystem attack in attackSystems)
            {
                if (attack.FuelSupply > 0 && attack.AmmunitionCapacity > 0)
                {
                    Available += 1;
                    attack.Report();
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"The number of available weapon systems is: {Available} out of {attackSystems.Count}");
            Console.ResetColor();
        }

    }
    class Force
    {
        public List<AttackSystem> attackSystems = new();
        Organization Organization;
        public Force(Organization organization, List<AttackSystem> attack)
        {
            foreach (AttackSystem item in attack)
            {
                attackSystems.Add(item);
            }
            Organization = organization;
        }

        public void PrintReport()
        {
            int Available = 0;
            foreach (AttackSystem attack in attackSystems)
            {
                if (attack.FuelSupply > 0 && attack.AmmunitionCapacity > 0)
                {
                    Available += 1;
                    attack.Report();
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"The number of available weapon systems is: {Available} out of {attackSystems.Count}");
            Console.ResetColor();
        }

    }
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
    public class Organization
    {
        public string EstablishmentDate, CurrentCommander, Name; // Date of establishment of the organization and current commander
        public Organization(string name, string establishmentDate, string currentCommander)
        {
            EstablishmentDate = establishmentDate;
            CurrentCommander = currentCommander;
            Name = name;
            Print();
        }

        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n =====================>> {Name} <<=====================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    The organization was created successfully.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    Date of establishment: {EstablishmentDate}");
            Console.WriteLine($"    Current census: {CurrentCommander}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" =============================================\n");
            Console.ResetColor();
        }
    }

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
                    "gun" or "Pistol" or "Grenade" => 2,
                    "AK-47" or "M16" or "Sniper" => 3,
                    "RPG" or "Explosives" => 4,
                    "Machine Gun" => 5,
                    _ => 1
                };
            }
            return QualityScore * Rank;
        }

        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"======= Tourist Information =======");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Name: {Name}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Rank: {Rank}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Is Alive: {IsAlive}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Weapons:");
            foreach (var weapon in Weapons)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($" - {weapon}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Organization Name: {Organization.Name}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"==========================");
            Console.ResetColor();
        }

    }
        class Program
    {
        static void Main(string[] args)
        {
            Organization Hamas = new("Hamas", "1987.12.10", "Yahya Sinwar");
            Organization Idf = new("IDF", "1948.5.26", "Herzi Halevi");

            Console.WriteLine("Enter your name.");
            string officerName = Console.ReadLine();

            ControlSystem controlSystem = new(Idf,Hamas, officerName);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Control system activated\n");
            Console.ResetColor();
            
            new Menu(controlSystem).MenuActivation();
        }   
    }  


}
