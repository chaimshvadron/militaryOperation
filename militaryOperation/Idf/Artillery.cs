namespace MilitaryControlSystem
{
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