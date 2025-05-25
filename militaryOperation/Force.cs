namespace Military_control_system
{
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
    
}