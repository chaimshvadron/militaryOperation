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


// Bomb types: 0.5 ton or 1 ton


    // Effective against: buildings


    // Operated by a pilot


    // Up to 8 strikes available


    // Hermes 460 ("Zik") Drone


    // Bomb types vary depending on target: personnel or armored vehicles


    // Effective against: people, vehicles


    // Up to 3 strikes available
}

// 🟦 Strike Options
// The IDF can perform attacks using various strike units, each with different capabilities and targets. All strike types share the following:
// A unique name

// Ammunition capacity (number of strikes remaining)

// Fuel supply

// Type of target they are effective against (e.g., buildings, people, vehicles)


// Subtypes:



// M109 Artillery


// Bomb type: explosive shells


// Effective in: open areas


// Can strike up to 2–3 targets simultaneously, 40 strikes in total.

