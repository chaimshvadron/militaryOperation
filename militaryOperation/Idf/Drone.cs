namespace MilitaryControlSystem
{
    public class Drone : AttackSystem
    {
        public override Dictionary<string, string> TargetTypeAndWeapon { get; set; } = new()
        {
            { "Rooftop", "AGM-114 Hellfire" },
            { "Dark Alley", "Laser-guided Mini Missile" },
            { "Highway", "Precision-guided Small Bomb" }
        };

        public Drone(string name, int ammunitionCapacity, int fuelSupply) : base(name, ammunitionCapacity, fuelSupply) { }
        public override bool ExecuteStrike(string name, int ammunition, int fuel)
        {
            if (!CanStrike(fuel, ammunition)) return false;
            AmmunitionCapacity -= ammunition;
            FuelSupply -= fuel;
            return true;
        }
    }

}