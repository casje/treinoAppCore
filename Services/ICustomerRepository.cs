using System.Collections.Generic;
using treinoAppCore.Models;

namespace treinoAppCore.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        Customer GetCustomerIdent(int? ident);
        void EditCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        
    }
}