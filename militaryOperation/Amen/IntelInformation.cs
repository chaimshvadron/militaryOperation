namespace MilitaryControlSystem
{   
    class IntelInformation
    {
        public int Id;
        public string LastLocation;
        public DateTime Timestamp = DateTime.UtcNow;
        public IntelInformation(int IdTerrorist, string lastLocation)
        {
            Id = IdTerrorist;
            LastLocation = lastLocation;
        }
        
    }
    
}