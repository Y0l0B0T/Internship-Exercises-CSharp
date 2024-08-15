using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terminal.Buses;
using Terminal.Customers;
using Terminal.Journeys;
using Terminal.TerminalBuss.Contracts.Dtos;
using Terminal.Ticket;

namespace Terminal.Ticket.TerminalBuss;

public class TerminalBus
{
    private readonly List<Customer> _customers;
    private readonly List<Bus> _buses;
    private readonly List<Journey> _journeys;
    private readonly List<Ticket> _tickets;


    public void RegisterCustomer(string firstname, string lastname, string phonenumber, int nationalcode)
    {
        if (_customers.Any(customer => customer.NationalCode == nationalcode))
            return;
        _customers.Add(new Customer(firstname, lastname, phonenumber, nationalcode));
    }


    public void RegisterBus(string licensePlate, BusType type, int capacity)
    {
        if (_buses.Any(bus => bus.LicensePlate == licensePlate))
            return;
        _buses.Add(new Bus(licensePlate, type, capacity));
    }



    public void RegisterJourney(int busId, string origincity, string destinationcity, DateTime journeydate, int priceperticket, int availablecapacity)
    {
        var bus = _buses[busId - 1];
        _journeys.Add(new Journey(bus, origincity, destinationcity, journeydate, priceperticket, availablecapacity));
    }


    public void SellingTicket(int customerId, int journeyId, TicketType type)
    {
        var customer = _customers[customerId - 1];
        var journey = _journeys[journeyId - 1];
        if (journey.AvailableCapacity <= 0 && DateTime.Now > journey.JourneyDate)
            return;
        _tickets.Add(new Ticket(customer, journey, type));
        journey.AvailableCapacity -= 1;
        IncomePriceBus(type, journey);
    }

    private static void IncomePriceBus(TicketType type, Journey journey)
    {
        if (type == TicketType.reserve)
        {
            journey.Bus.TotalSales += journey.PricePerTicket * 3 / 10;
        }
        journey.Bus.TotalSales += journey.PricePerTicket;
    }

    public void CancelTicket(int nationalcode, int journeyId, TicketType type)
    {
        var ticket = _tickets.Find(_ => _.Customer.NationalCode == nationalcode);
        var journey = _journeys[journeyId - 1];
        journey.AvailableCapacity += 1;
        Refunded(type, journey);
    }

    private static void Refunded(TicketType type, Journey journey)
    {
        var refund = 0;
        if (journey.JourneyDate > DateTime.Now)
        {
            if (type == TicketType.buy)
            {
                refund = journey.PricePerTicket * 8 / 10;
                journey.Bus.TotalSales -= refund;
            }
            return;
        }
        refund = journey.PricePerTicket;
        journey.Bus.TotalSales -= refund;
    }

    public List<ShowJourneyDto> ShowJourneys()
    {
        return _journeys.Select((journey, index) => new ShowJourneyDto
        {
            Id = index + 1,
            OriginCity = journey.OriginCity,
            DestinationCity = journey.DestinationCity,
            JourneyDate = journey.JourneyDate,
            AvailableCapacity = journey.AvailableCapacity
        }).ToList();
    }



    public List<ShowBusDto> ShowBuses()
    {
        return _buses.Select((bus, index) => new ShowBusDto
        {
            Id = index + 1,
            TotalSales = bus.TotalSales,
            LicensePlate = bus.LicensePlate,
            Type = bus.Type,
            Capacity = bus.Capacity
        }).ToList();
    }
    public List<ShowBusDto> ShowBusOrderedByTotalSales()
    {
        return _buses.OrderByDescending(_ => _.TotalSales).Select((bus, index) => new ShowBusDto
        {
            Id = index + 1,
            TotalSales = bus.TotalSales,
            LicensePlate = bus.LicensePlate,
            Type = bus.Type,
            Capacity = bus.Capacity
        }).ToList();
    }


    public List<ShowCustomerDto> ShowCustomers()
    {
        return _customers.Select((customer, index) => new ShowCustomerDto
        {
            Id = index + 1,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            NationalCode = customer.NationalCode
        }).ToList();
    }

    public void CityWithMostIncomingPassenger()
    => _journeys.GroupBy(_ => _.DestinationCity).Select(_ => new
    {
        City = _.Key,
        PassengerCount = _.Sum(_ => _.Bus.Capacity)
    }).OrderByDescending(_ => _.PassengerCount).Select(_ => _.City).FirstOrDefault();




    public void CityWithMostOutGoingPassenger()

    => _journeys.GroupBy(_ => _.OriginCity).Select(_ => new
    {
        City = _.Key,
        PassengerCount = _.Sum(_ => _.Bus.Capacity)
    }).OrderByDescending(_ => _.PassengerCount).Select(_ => _.City).FirstOrDefault();








}