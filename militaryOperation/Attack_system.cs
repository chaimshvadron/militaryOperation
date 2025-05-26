namespace Military_control_system
{
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
}