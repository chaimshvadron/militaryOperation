namespace MilitaryControlSystem
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
        }

        public void AddAmmunition(int ammunition)
        {
            AmmunitionCapacity += ammunition;
        }

        public bool CanStrike(int fuel, int ammunition)
        {

            if (AmmunitionCapacity > ammunition && FuelSupply > fuel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool YaelAgainstTarget(string target)
        {
            if (TargetTypeAndWeapon.ContainsKey(target)) return true;
            return false;
        }

        abstract public bool ExecuteStrike(string target, int fuel, int ammunition);
        abstract public Dictionary<string, string> TargetTypeAndWeapon { get; set; }
    }



 
    public class Artillery : AttackSystem
    {
        public override Dictionary<string, string> TargetTypeAndWeapon { get; set; } = new()
        {
            { "Car", "155mm High-Explosive Shell" },
            { "House", "GPS-guided Excalibur Shell" },
            { "Warehouse", "Airburst Fragmentation Shell" }
        };

        public Artillery(string name, int ammunitionCapacity, int fuelSupply) : base(name, ammunitionCapacity, fuelSupply) { }

        public override bool ExecuteStrike(string target, int fuel, int ammunition)
        {
            if (!CanStrike(fuel, ammunition)) return false;

            AmmunitionCapacity -= ammunition;
            FuelSupply -= fuel;
            return true;
        }
    }
}