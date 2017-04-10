using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using treinoAppCore.Models;
using treinoAppCore.Services;


namespace treinoAppCore.ViewComponents
{

    public class CustomerViewComponent : ViewComponent
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerViewComponent(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(Customer customer)
        {
            //Implementar a regra para permitir somente telefone que iniciam com o digito 9
            if(customer.PhoneNumber.IndexOf('9')<0){
                customer.PhoneNumber = "8" + customer.PhoneNumber.Substring(1, 8);
            }

            return View(customer);
        }
    }
    
}