namespace MilitaryControlSystem
{
    public class Organization
    {
        public string EstablishmentDate, CurrentCommander, Name; // Date of establishment of the organization and current commander
        public Organization(string name, string establishmentDate, string currentCommander)
        {
            EstablishmentDate = establishmentDate;
            CurrentCommander = currentCommander;
            Name = name;
            this.Print();
        }
    }
}