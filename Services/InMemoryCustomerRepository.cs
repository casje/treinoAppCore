using System.Linq;
using System.Collections.Generic;
using treinoAppCore.Models;

namespace treinoAppCore.Services
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private List<Customer> _listCustomers = new List<Customer>();

        public InMemoryCustomerRepository()
        {
            _listCustomers.Add( new Customer{Ident = 1, FirstName = "Cláudio",   LastName = "Alves",    PhoneNumber = "9804-3341", EmailAddress = "claudio@gmail.com"});
            _listCustomers.Add( new Customer{Ident = 2, FirstName = "Juliana",   LastName = "de Avila", PhoneNumber = "3245-8821", EmailAddress = "juliana@gmail.com"});
            _listCustomers.Add( new Customer{Ident = 3, FirstName = "Allana",    LastName = "de Avila", PhoneNumber = "9952-3731", EmailAddress = "allana@gmail.com"});
            _listCustomers.Add( new Customer{Ident = 4, FirstName = "Gabriel",   LastName = "Lapa",     PhoneNumber = "4232-6631", EmailAddress = "gabriel@gmail.com"});
            _listCustomers.Add( new Customer{Ident = 5, FirstName = "Guilherme", LastName = "Silva",    PhoneNumber = "9875-5528", EmailAddress = "gui-alfenas@hotmail.com"});
            _listCustomers.Add( new Customer{Ident = 6, FirstName = "Julia",     LastName = "Santos",   PhoneNumber = "9774-2058", EmailAddress = "julia@hotmail.com"});
        }

        public void AddCustomer(Customer customer)
        {
            customer.Ident = (this._listCustomers.Count>0 ? this._listCustomers.Max(c => c.Ident) : 0) + 1;
            
            
            this._listCustomers.Add(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this._listCustomers;
        }

        public Customer GetCustomerIdent(int? ident)
        {
            Customer customer = null;

            if(ident.HasValue && ident.Value>0)
            {
                customer = _listCustomers.Find(c => c.Ident == ident.Value);
            }

            return customer;
        }

        public void EditCustomer(Customer customer)
        {
            int indexPosition = _listCustomers.FindIndex(c => c.Ident == customer.Ident);

            if(indexPosition>=0){
                _listCustomers[indexPosition] = customer;
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            int indexPosition = _listCustomers.FindIndex(c => c.Ident == customer.Ident);

            if(indexPosition>=0){
                _listCustomers.RemoveAt(indexPosition);
            }
        }
    }
}