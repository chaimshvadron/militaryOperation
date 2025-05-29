namespace MilitaryControlSystem
{
    public class Force
    {
        public List<AttackSystem> attackSystems = new();
        public Organization Organization;
        public Force(Organization organization, List<AttackSystem> attack)
        {
            foreach (AttackSystem item in attack)
            {
                attackSystems.Add(item);
            }
            Organization = organization;
        }
        
    }
    
}