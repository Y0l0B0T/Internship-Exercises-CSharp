using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Terminal.Buses;

public class Bus
{
    public string LicensePlate { get; }
    public BusType Type { get; }
    public int Capacity { get; }
    public int TotalSales { get; set; }

    public Bus(string licenseplate, BusType type, int capacity)
    {
        LicensePlate = licenseplate;
        Type = type;
        Capacity = capacity;
    }
    public void UpdateSales(int price)
    {
        TotalSales += price;
    }
}
public enum BusType
{
    Eco = 1,
    Vip
}