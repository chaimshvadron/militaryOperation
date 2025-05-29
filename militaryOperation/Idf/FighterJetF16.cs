namespace MilitaryControlSystem
{
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
        { Pilot = pilot;}

        public override bool ExecuteStrike(string target, int fuel, int ammunition)
        {
            if (!CanStrike(fuel, ammunition)) return false;
            AmmunitionCapacity -= ammunition;
            FuelSupply -= fuel;
            return true;
        }
    }
    
}