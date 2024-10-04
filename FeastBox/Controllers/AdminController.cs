using FeastBox.Data;
using FeastBox.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FeastBox.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                var orders = _context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.OrderItems)
                    .ToList();

                return View(orders);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while fetching the orders.";
                return View(new List<Order>());
            }
        }

        public IActionResult CreateOrder()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Creating a new customer
                    var customer = new Customer { Name = "Ahmed", Email = "ahmed@example.com", PhoneNumber = "123456789" };

                    if (!_context.Customers.Any(c => c.Email == customer.Email))
                    {
                        _context.Customers.Add(customer);
                        _context.SaveChanges();

                        var order = new Order { OrderDate = DateTime.Now, TotalAmount = 100, CustomerId = customer.CustomerId };
                        _context.Orders.Add(order);
                        _context.SaveChanges();

                        transaction.Commit();
                        TempData["SuccessMessage"] = "The order has been successfully created.";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "This customer already exists.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ViewBag.ErrorMessage = "An error occurred while creating the order.";
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditOrder(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "The order has been successfully updated.";
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while updating the order.";
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                try
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "The order has been successfully deleted.";
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while deleting the order.";
                }
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
