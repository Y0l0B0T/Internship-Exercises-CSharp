using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terminal.Buses;

namespace Terminal.Journeys;

public class Journey
{
    public Bus Bus { get; }
    public string OriginCity { get; }
    public string DestinationCity { get; }
    public DateTime JourneyDate { get; }
    public int PricePerTicket { get; }
    public int AvailableCapacity { get; set; }

    public Journey(Bus bus, string origincity, string destinationcity, DateTime journeydate, int priceperticket, int availablecapacity)
    {
        Bus = bus;
        OriginCity = origincity;
        DestinationCity = destinationcity;
        JourneyDate = journeydate;
        PricePerTicket = priceperticket;
        AvailableCapacity = availablecapacity;
    }
}
