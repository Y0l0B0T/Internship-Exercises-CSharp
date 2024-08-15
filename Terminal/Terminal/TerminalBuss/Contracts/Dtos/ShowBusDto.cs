using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terminal.Buses;

namespace Terminal.TerminalBuss.Contracts.Dtos
{
    public class ShowBusDto
    {
        public int Id { get; set; }
        public int TotalSales { get; set; }
        public string LicensePlate { get; set; }
        public BusType Type { get; set; }
        public int Capacity { get; set; }
    }
}