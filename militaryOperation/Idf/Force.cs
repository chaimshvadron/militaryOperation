namespace MilitaryControlSystem
{
    public class Force
    {
        public List<AttackSystem> militaryAssets;
        public Organization Organization;
        public Force(Organization organization, List<AttackSystem> attack)
        {
            militaryAssets = attack;
            Organization = organization;
        }
        
    }
    
}