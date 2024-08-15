using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Terminal.Customers;

public class Customer
{
    public string FirstName { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }
    public int NationalCode { get; }

    public Customer(string firstname, string lastname, string phonenumber, int nationalcode)
    {
        FirstName = firstname;
        LastName = lastname;
        PhoneNumber = phonenumber;
        NationalCode = nationalcode;
    }
}