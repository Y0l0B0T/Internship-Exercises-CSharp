using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terminal.Customers;
using Terminal.Journeys;

namespace Terminal.Ticket;

public class Ticket
{
    public Customer Customer;
    public Journey Journey;
    public TicketType Type;

    public Ticket(Customer customer, Journey journey, TicketType type)
    {
        Customer = customer;
        Journey = journey;
        Type = type;
    }
}








public enum TicketType
{
    buy = 1,
    reserve
}