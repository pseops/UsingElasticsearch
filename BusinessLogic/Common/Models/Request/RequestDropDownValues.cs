using System.Collections.Generic;

namespace BusinessLogic.Common.Models.Request
{
    public class RequestDropDownValues
    {
        public string CurrentFilter { get; set; }
        public int Size { get; set; }
        public IEnumerable<string> HolidayYear { get; set; }
        public IEnumerable<string> RegionName { get; set; }
        public IEnumerable<string> WeekNumber { get; set; }
        public IEnumerable<string> ResponsibleRevenueManager { get; set; }
        public IEnumerable<string> ParkName { get; set; }
        public IEnumerable<string> AccommTypeName { get; set; }
        public IEnumerable<string> AccommBeds { get; set; }
        public IEnumerable<string> UnitGradeName { get; set; }
        public IEnumerable<string> AccommName { get; set; }
        public IEnumerable<string> KeyPeriodName { get; set; }
    }
}
