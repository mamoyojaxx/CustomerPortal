using Microsoft.AspNetCore.Mvc;
using CustomerPortal.Models;
using CustomerPortal.Data;
using CustomerPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            await app1.Customers.AddAsync(cusObj);
            await app1.SaveChangesAsync();
            return View();
        }

        //method to view customer list
        [HttpGet]
        public async Task<IActionResult> List() {
           var customers = await app1.Customers.ToListAsync();
            return View(customers);
        }

        //method to find customer based on ID
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var cust = await app1.Customers.FindAsync(id);

            return View(cust);
        }

        //method to update records
        [HttpPost]
        public async Task<IActionResult> Update(Customer viewModel)
        {
            var cust = await app1.Customers.FindAsync(viewModel.CustomerID);

            if (cust is not null)
            {
                cust.CustomerName = viewModel.CustomerName;
                cust.CustomerEmail = viewModel.CustomerEmail;
                cust.CustomerPhone = viewModel.CustomerPhone;
                cust.CustomerCity = viewModel.CustomerCity;
                cust.CustomerRegion = viewModel.CustomerRegion;
                cust.isSubscribed = viewModel.isSubscribed;

                await app1.SaveChangesAsync();
            }

            return RedirectToAction("List", "Customer");
        }

        //method to delete records
        [HttpPost]
        public async Task<IActionResult> Delete(Customer viewModel)
        {

            var cust = await app1.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.CustomerID==viewModel.CustomerID);

            if (cust is not null)
            {
                app1.Customers.Remove(viewModel);
                await app1.SaveChangesAsync();
            }

            return RedirectToAction("List", "Customer");
        }
    }
}
