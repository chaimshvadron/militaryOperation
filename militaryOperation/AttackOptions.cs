namespace MilitaryOperation.Models
{
    public abstract  class AttackOptions
    {
        public string Name;
        int AmmunitionCapacity, FuelSupply;
        Dictionary<string, string> TargetTypeAndWeapon = new();
        public AttackOptions(string name, int ammunitionCapacity, int fuelSupply)
        {
            Name = name;
            AmmunitionCapacity = ammunitionCapacity;
            FuelSupply = fuelSupply;
        }
        public abstract void Aaaa();
    }

    public class F16FighterJet : AttackOptions
    {

        public F16FighterJet(string name, int ammunitionCapacity, int fuelSupply) : base(name, ammunitionCapacity, fuelSupply){  }

        public override void Aaaa()
        {

        }
        
    }

}
