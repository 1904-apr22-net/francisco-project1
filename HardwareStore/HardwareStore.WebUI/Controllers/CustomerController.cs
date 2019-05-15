using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HardwareStore.Library;
using HardwareStore.Library.Interfaces;
using HardwareStore.WebUI.Models;

namespace HardwareStore.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        public ILocationRepo LocRepo { get; set; }
        public ICustomerRepository CusRepo { get; set; }
        public IProductsRepository ProdRepo { get; set; }
        public IOrdersRepository OrdRepo { get; set; }

        public CustomerController(ILocationRepo locationRepo, ICustomerRepository customerRepo, IProductsRepository productsRepo, IOrdersRepository ordersRepo)
        {
            LocRepo = locationRepo;
            CusRepo = customerRepo;
            ProdRepo = productsRepo;
            OrdRepo = ordersRepo;
        }
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<Library.Customer> customerList = CusRepo.GetCustomers().ToList();
            IEnumerable<CustomerViewModel> viewModels = customerList.Select(x => new CustomerViewModel
            {
                CustomerId=x.CustId,
                FName=x.FirstName,
                LName=x.LastName,
                Phone=x.PhoneNumber,
                DefaultLocationId=x.DefaultStoreId
            });

            return View(viewModels);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<Order> orders = CusRepo.GetOrderHistoryByCustomer(id);
            var ViewModels = orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                OrderTime = o.OrderTime,
                LocationId = o.LocationId,
                CustomerId = o.CustomerId,
                OrderTotal = o.OrderTotal
            });
            return View(ViewModels);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var viewModel = new CustomerViewModel
            {
                Locations=LocRepo.GetAllLocations().ToList()
            };
            return View(viewModel);
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customer)
        {
            try
            {
                var newCustomer = new Customer
                {
                    FirstName = customer.FName,
                    LastName=customer.LName,
                    PhoneNumber=customer.Phone,
                    DefaultStoreId=customer.DefaultLocationId
                };
                CusRepo.AddCustomer(newCustomer);
                CusRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index)); 
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //TODO: Add view for delete

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = CusRepo.GetCustomerById(id);
            var viewModel = new CustomerViewModel
            {
                CustomerId = customer.CustId,
                FName = customer.FirstName,
                LName = customer.LastName,
                Phone = customer.PhoneNumber,
                DefaultLocationId = customer.DefaultStoreId
            };
            return View(viewModel);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CusRepo.DeleteCustomer(id);
                CusRepo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}