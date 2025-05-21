namespace MilitaryOperation.Models
{
    public class Idf
    {
        public DateTime EstablishmentDate { get; set; }
        public string CurrentChiefOfStaff { get; set; }
        public List<AttackOptions> ListOfAttackOptions;

        public Idf(DateTime establishmentDate, string currentChiefOfStaff, List<AttackOptions> listOfAttackOptions)
        {
            EstablishmentDate = establishmentDate;
            CurrentChiefOfStaff = currentChiefOfStaff;
            ListOfAttackOptions = listOfAttackOptions;
        }
    }
}
