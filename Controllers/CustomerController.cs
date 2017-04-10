using Microsoft.AspNetCore.Mvc;
using treinoAppCore.Services;
using treinoAppCore.Models;

namespace treinoAppCore.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository = null;
        public CustomerController(ICustomerRepository pICustomerRepository)
        {
            this._customerRepository = pICustomerRepository;
        }
        public IActionResult Index()
        {
            var listCustomer = this._customerRepository.GetAllCustomers();

            return View(listCustomer);
        }

        public IActionResult IndexPartial()
        {
            var listCustomers = this._customerRepository.GetAllCustomers();

            return View("IndexPartialView", listCustomers);
        }

        public IActionResult IndexViewComponent()
        {
            var listCustomers = this._customerRepository.GetAllCustomers();

            return View("IndexViewComponent", listCustomers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                this._customerRepository.AddCustomer(customer);
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Edit(int? ident)        
        {
            Customer customer = _customerRepository.GetCustomerIdent(ident);

            if(customer==null)
            {
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(Customer customer)
        {
            if(ModelState.IsValid)
            {
                this._customerRepository.EditCustomer(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public IActionResult Delete(int? ident)
        {
            Customer customer = _customerRepository.GetCustomerIdent(ident);

            if(customer==null)
            {
                return RedirectToAction("Index");
            }
            
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(Customer customer)
        {
            this._customerRepository.DeleteCustomer(customer);
            
            return RedirectToAction("Index");
        }
    }
}