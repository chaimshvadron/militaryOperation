namespace MilitaryOperation.Models
{
    public class IntelAnalyzer
    {
        public Dictionary<Terrorist, List<IntelInformation>> GroupIntelligenceByTerrorist(List<IntelInformation> intelligenceReports)
        {
            Dictionary<Terrorist, List<IntelInformation>> groupedReports = new();

            foreach (IntelInformation report in intelligenceReports)
            {
                if (!groupedReports.ContainsKey(report.Terrorist))
                {
                    groupedReports[report.Terrorist] = new List<IntelInformation>();
                }
                groupedReports[report.Terrorist].Add(report);
            }

            return groupedReports;
        }

        
        public Terrorist? GetMostReportedTerrorist(List<IntelInformation> IntelInformation)

        {
            int max = 0;
            Terrorist? mostReported = null;

            foreach (KeyValuePair<Terrorist, List<IntelInformation>> group in GroupIntelligenceByTerrorist(IntelInformation))


            {
                if (group.Value.Count > max)
                {
                    max = group.Value.Count;
                    mostReported = group.Key;
                }
            }
            return mostReported;
        }

        public Terrorist? GetMostDangerousTerrorist(List<Terrorist> terroristList)
        {
            if (terroristList == null || terroristList.Count == 0)
                return null;

            Dictionary<string, int> weaponPoints = new()
            {
                {"Knife", 1},
                {"Gun", 2},
                {"M16", 3},
                {"AK47", 3}
            };

            Terrorist? mostDangerous = null;
            int maxQualityScore = 0;

            foreach (var terrorist in terroristList)
            {
                int totalWeaponPoints = 0;
                if (terrorist.WeaponList != null)
                {
                    foreach (var weapon in terrorist.WeaponList)
                    {
                        if (weaponPoints.TryGetValue(weapon, out int points))
                            totalWeaponPoints += points;
                    }
                }
                int qualityScore = terrorist.Rank * totalWeaponPoints;
                if (qualityScore > maxQualityScore)
                {
                    maxQualityScore = qualityScore;
                    mostDangerous = terrorist;
                }
            }
            
            return mostDangerous;
        }

        public void MostDangerousTerrorist(List<Terrorist> terroristList, List<IntelInformation> intelInformationList)
        {
            if (terroristList == null || terroristList.Count == 0 || intelInformationList == null || intelInformationList.Count == 0)
            {
                Console.WriteLine("No data available.");
                return;
            }

            Dictionary<string, int> weaponPoints = new()
            {
                {"Knife", 1},
                {"Gun", 2},
                {"M16", 3},
                {"AK47", 3}
            };

            var grouped = GroupIntelligenceByTerrorist(intelInformationList);
            Terrorist? mostDangerous = null;
            int maxQualityScore = 0;
            IntelInformation? latestIntel = null;

            foreach (var terrorist in terroristList)
            {
                int totalWeaponPoints = 0;
                if (terrorist.WeaponList != null)
                {
                    foreach (var weapon in terrorist.WeaponList)
                    {
                        if (weaponPoints.TryGetValue(weapon, out int points))
                            totalWeaponPoints += points;
                    }
                }
                int qualityScore = terrorist.Rank * totalWeaponPoints;
                if (qualityScore > maxQualityScore)
                {
                    maxQualityScore = qualityScore;
                    mostDangerous = terrorist;
                    if (grouped.TryGetValue(terrorist, out var reports) && reports.Count > 0)
                        latestIntel = reports.OrderByDescending(r => r.Timestamp).First();
                    else
                        latestIntel = null;
                }
            }

            if (mostDangerous != null)
            {
                Console.WriteLine($"Most Dangerous Terrorist: {mostDangerous.Name}");
                Console.WriteLine($"Rank: {mostDangerous.Rank}");
                Console.WriteLine($"Quality Score: {maxQualityScore}");
                Console.WriteLine($"Weapons: {string.Join(", ", mostDangerous.WeaponList ?? new List<string>())}");
                Console.WriteLine($"Latest Known Location: {(latestIntel != null ? latestIntel.LastLocation : "Unknown")}");
            }
            else
            {
                Console.WriteLine("No dangerous terrorist found.");
            }
        }

    }
}