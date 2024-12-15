using RestuarantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantManagementSystem.People
{
    public class Receptionist : Employee
    {
        public bool CreateReservation(Reservation reservation)
        {
            Console.WriteLine("Reservation created successfully.");
            return true;
        }

        public List<Customer> SearchCustomer(string name)
        {
            // Search logic
            return new List<Customer>();
        }
    }

}
