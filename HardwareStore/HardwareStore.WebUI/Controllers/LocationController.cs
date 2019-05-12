using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using HardwareStore.Library.Interfaces;
using HardwareStore.Library;
using HardwareStore.WebUI.Models;

namespace HardwareStore.WebUI.Controllers
{
    public class LocationController : Controller
    {
        public ILocationRepo LocRepo { get; set; }
        public ICustomerRepository CusRepo { get; set; }
        public IProductsRepository ProdRepo { get; set; }
        public IOrdersRepository OrdRepo { get; set; }

        public LocationController(ILocationRepo locationRepo, ICustomerRepository customerRepo, IProductsRepository productsRepo, IOrdersRepository ordersRepo)
        {
            LocRepo = locationRepo;
            CusRepo = customerRepo;
            ProdRepo = productsRepo;
            OrdRepo = ordersRepo;
        }
        /*public LocationController(ILocationRepo repo) => 
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));*/
        
        // GET: Location
        public ActionResult Index()
        {
            IEnumerable<Library.Location> locationList = LocRepo.GetAllLocations().ToList();

            /*var viewModels = locationList.Select(s=>new LocationViewModel
            {
                LocationId=s.LocationId,
                LocationName=s.Name
            }
                ).ToList();*/
            IEnumerable<LocationViewModel> viewModels = locationList.Select(x => new LocationViewModel
            {
                LocationId = x.LocationId,
                LocationName=x.Name,
                Address=x.Address
            });
            /*var locationModels=locationList.Select(s=>new LocationViewModel
            {

            }*/
            return View(viewModels);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            /*
            IEnumerable<Library.Order> OrderList = LocRepo.GetOrderHistoryByLocation(1);
            //maybe add location repo here
            var viewModels = OrderList.Select(o => new OrderViewModel
            {
                OrderId=o.OrderId,

            });*/
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
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

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}