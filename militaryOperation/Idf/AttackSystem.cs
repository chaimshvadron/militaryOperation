namespace MilitaryControlSystem
{
    public abstract class AttackSystem
    {
        public string Name { get; }
        public int AmmunitionCapacity { get; set; }
        public int FuelSupply { get; set; }
        public Dictionary<string, string> TargetTypeAndWeapon { get; set; }

        public AttackSystem(string Name, int AmmunitionCapacity, int FuelSupply, Dictionary<string, string> TargetTypeAndWeapon)
        {
            this.Name = Name;
            this.AmmunitionCapacity = AmmunitionCapacity;
            this.FuelSupply = FuelSupply;
            this.TargetTypeAndWeapon = TargetTypeAndWeapon;
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