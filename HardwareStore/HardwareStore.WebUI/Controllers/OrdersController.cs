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

            /*var order = OrdRepo.GetOrderById(id);
            order.OrderItems = OrdRepo.GetItemsByOrderId(id).ToList();
            var ViewModels = new OrderViewModel(order);*/
            return View(ViewModels);

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
                        //int selectedVal = collection.SelectedAmount;
                        //collection.AmountItems[i].QuantityBought = selectedVal;
                        order.OrderTotal += collection.Products[i].Price * collection.NumItems[i];
                        //order.OrderTotal += collection.Products[i].Price * collection.AmountItems[i].QuantityBought ?? default(int); //fails because null orderitems, amount items
                    }
                }
                order.OrderItems = new List<OrderItem>();

                //var orderItem = new OrderItem();

                int count = 0;
                //adding order items
                for(var i=0; i<collection.Products.Count;i++)
                {
                    if(collection.Products[i].Checked)
                    {
                        try
                        {
                            count++;
                            var orderItem = new OrderItem(collection.NumItems[i]); //quantity check
                            //var orderItem = new OrderItem(collection.AmountItems[i].QuantityBought ?? default(int));
                            orderItem.OrderItemNum = count;
                            orderItem.ProductId = collection.Products[i].ProductId; //check
                            orderItem.Price = collection.Products[i].Price; //check
                            order.OrderItems.Add(orderItem);
                        }
                        //orderItem.QuantityBought =collection.AmountItems[i].QuantityBought ?? default(int);
                       catch(ArgumentOutOfRangeException e)
                        {
                            _logger.LogTrace(e, "Order item of quantity <1 not added to DB");
                        }
                    }
                }

                OrdRepo.AddOrder(order);
                OrdRepo.Save();
                int orderId = 0;
                foreach(var item in order.OrderItems)
                {
                    orderId=OrdRepo.GetLastOrderAdded();
                    item.OrderId = orderId;
                    OrdRepo.AddOrderItem(item);
                }
                OrdRepo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var viewModel = collection;
                return View(viewModel);
            }
            /*
            catch
            {
                return RedirectToAction(nameof(Index));
            }*/
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