using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HardwareStore.WebUI.Models;
using HardwareStore.Library;
using Microsoft.AspNetCore.Mvc.Rendering;
using HardwareStore.Library.Interfaces;
using Microsoft.Extensions.Logging;


namespace HardwareStore.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        public ILocationRepo LocRepo { get; set; }
        public ICustomerRepository CusRepo { get; set; }
        public IProductsRepository ProdRepo { get; set; }
        public IOrdersRepository OrdRepo { get; set; }
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILocationRepo locationRepo, ICustomerRepository customerRepo, IProductsRepository productsRepo, IOrdersRepository ordersRepo, ILogger<OrdersController> logger)
        {
            LocRepo = locationRepo;
            CusRepo = customerRepo;
            ProdRepo = productsRepo;
            OrdRepo = ordersRepo;
            _logger = logger;
        }

        // GET: Orders
        public ActionResult Index()
        {
            IEnumerable<Order> orders = OrdRepo.GetOrders();
            var ViewModels = orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                OrderTime=o.OrderTime,
                LocationId=o.LocationId,
                CustomerId=o.CustomerId,
                OrderTotal=o.OrderTotal
            });
            return View(ViewModels);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<OrderItem> items = OrdRepo.GetItemsByOrderId(id);
            var ViewModels = items.Select(i => new OrderItemViewModel
            {
                OrderId=i.OrderId,
                OrderItemNum=i.OrderItemNum,
                QuantityBought=i.QuantityBought,
                ProductId=i.ProductId,
                Price=i.Price
            });
            return View(ViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order()
        {
            try
            {
                Order order = new Order();
                order.OrderTime = DateTime.Now;
                order.LocationId = 2;
                order.CustomerId = 1;
                order.OrderTotal = 23;

                //List<OrderItem> items = new List<OrderItem>();
                OrderItem item1 = new OrderItem();
                item1.OrderItemNum = 1;
                item1.QuantityBought = 4;
                item1.ProductId = 3;
                item1.Price = 5;

                OrderItem item2 = new OrderItem();
                item2.OrderItemNum = 2;
                item2.QuantityBought = 1;
                item2.ProductId = 1;
                item2.Price = 3;

                OrdRepo.AddOrder(order);
                OrdRepo.Save();

                item1.OrderId = OrdRepo.GetLastOrderAdded();
                item2.OrderId = OrdRepo.GetLastOrderAdded();
                OrdRepo.AddOrderItem(item1);
                OrdRepo.AddOrderItem(item2);
                OrdRepo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var ViewModel = new OrderViewModel();
            ViewModel.Locations = LocRepo.GetAllLocations().ToList();
            ViewModel.Customers = CusRepo.GetCustomers().ToList();
            ViewModel.Products = ProdRepo.GetAllProducts().Select(p=>new ProductViewModel(p)).ToList();
            return View(ViewModel);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel collection)
        {
            try
            {
                var order = new Order()
                {
                    OrderTime = DateTime.Now
                };
                order.LocationId = collection.LocationId;
                order.CustomerId = collection.CustomerId;
                order.OrderTotal = 0;
                for (var i = 0; i < collection.Products.Count; i++)
                {
                    if (collection.Products[i].Checked)
                    {
                        order.OrderTotal += collection.Products[i].Price * collection.AmountItems[i].QuantityBought;
                    }
                }
                order.Items = new List<OrderItem>();

                var orderItem = new OrderItem();

                //adding order items
                for(var i=0; i<collection.Products.Count;i++)
                {
                    if(collection.Products[i].Checked)
                    {
                        orderItem.QuantityBought =collection.AmountItems[i].QuantityBought;
                        orderItem.OrderItemNum = i;
                        orderItem.ProductId = collection.Products[i].ProductId;
                        orderItem.Price = collection.Products[i].Price;
                        order.OrderItems.Add(orderItem);
                    }
                }

                OrdRepo.AddOrder(order);
                foreach(var item in order.OrderItems)
                {
                    OrdRepo.AddOrderItem(item);
                }

                return RedirectToAction(nameof(Index));
            }
        
            catch
            {
               return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orders/Edit/5
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

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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