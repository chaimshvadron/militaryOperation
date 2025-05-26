namespace Military_control_system
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


        public IntelInformation? MostDangerousTerrorist(List<IntelInformation> intelInformationList)
        {

            Dictionary<string, int> weaponPoints = new()
            {
                {"Knife", 1},
                {"Gun", 2},
                {"M16", 3},
                {"AK47", 3}
            };

            Dictionary<Terrorist, List<IntelInformation>> grouped = GroupIntelligenceByTerrorist(intelInformationList);
            Terrorist? mostDangerous = null;
            int maxQualityScore = 0;
            IntelInformation? latestIntel = null;

            foreach (KeyValuePair<Terrorist, List<IntelInformation>> pair in grouped)
            {
                Terrorist terrorist = pair.Key;
                List<IntelInformation> reports = pair.Value;
                int totalWeaponPoints = 0;
                if (terrorist.WeaponList != null)
                {
                    foreach (string weapon in terrorist.WeaponList)
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
                    
                    IntelInformation? lastReport = null;
                    foreach (IntelInformation report in reports)
                    {
                        if (lastReport == null || report.Timestamp > lastReport.Timestamp)
                        {
                            lastReport = report;
                        }
                    }
                    latestIntel = lastReport;
                }
            }

            if (mostDangerous != null && latestIntel != null)
            {
                Console.WriteLine($"Most Dangerous Terrorist: {mostDangerous.Name}");
                Console.WriteLine($"Rank: {mostDangerous.Rank}");
                Console.WriteLine($"Quality Score: {maxQualityScore}");
                Console.WriteLine($"Weapons: {string.Join(", ", mostDangerous.WeaponList ?? new List<string>())}");
                Console.WriteLine($"Latest Known Location: {latestIntel.LastLocation}");
            }
            else
            {
                Console.WriteLine("No dangerous terrorist found.");
            }
            return latestIntel;
        }

    }
}