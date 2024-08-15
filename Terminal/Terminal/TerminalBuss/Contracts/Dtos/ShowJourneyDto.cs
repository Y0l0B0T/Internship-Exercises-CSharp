using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Terminal.TerminalBuss.Contracts.Dtos
{
    public class ShowJourneyDto
    {
        public int Id { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public DateTime JourneyDate { get; set; }
        public int AvailableCapacity { get; set; }
    }
}