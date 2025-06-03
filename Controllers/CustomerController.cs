using Microsoft.AspNetCore.Mvc;
using CustomerPortal.Models;
using CustomerPortal.Data;
using CustomerPortal.Models.Entities;

namespace CustomerPortal.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDBContext app1;

        public CustomerController(AppDBContext app1)
        {
            this.app1 = app1;
        }

        //method to view the addNew Webpage
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }

        //method to send data on the addNew Webpage to the database table
        [HttpPost]
        public async Task <IActionResult> AddNew(AddViewModel viewModel)
        {
            var cusObj = new Customer
            {
                CustomerName = viewModel.CustomerName,
                CustomerEmail = viewModel.CustomerEmail,
                CustomerPhone = viewModel.CustomerPhone,
                CustomerCity = viewModel.CustomerCity,
                CustomerRegion = viewModel.CustomerRegion,
                isSubscribed = viewModel.isSubscribed
            };
            await app1.customers.AddAsync(cusObj);
            await app1.SaveChangesAsync();
            return View();
        }
    }
}
