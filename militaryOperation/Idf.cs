namespace MilitaryOperation.Models
{
    public class Idf
    {
        public DateTime EstablishmentDate { get; set; }
        public string CurrentChiefOfStaff { get; set; }
        public List<AttackOptions> listOfAttackOptions;
    }
}
