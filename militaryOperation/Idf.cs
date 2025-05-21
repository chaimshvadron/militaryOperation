using MilitaryOperation.AttackManagement;
namespace MilitaryOperation.IdfManagement
{
    public class Idf
    {
        public DateTime EstablishmentDate { get; set; }
        public string CurrentChiefOfStaff { get; set; }
        public List<AttackOptions> listOfAttackOptions;
    }
}
