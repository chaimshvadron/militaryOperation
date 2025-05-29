namespace MilitaryControlSystem
{
    public abstract class AttackSystem
    {
        public string Name { get; }
        public int AmmunitionCapacity { get; set; }
        public int FuelSupply { get; set; }
        public Dictionary<string, string> TargetTypeAndWeapon { get; set; }

        public AttackSystem(string name, int ammunitionCapacity, int fuelSupply, Dictionary<string, string> targetTypeAndWeapon)
        {
            this.Name = name;
            this.AmmunitionCapacity = ammunitionCapacity;
            this.FuelSupply = fuelSupply;
            this.TargetTypeAndWeapon = targetTypeAndWeapon;
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
            return AmmunitionCapacity > ammunition && FuelSupply > fuel;
        }

        public bool YaelAgainstTarget(string target)
        {
            return TargetTypeAndWeapon.ContainsKey(target);
        }

        abstract public bool ExecuteStrike(string target, int fuel, int ammunition);
    }
}