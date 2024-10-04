using FeastBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FeastBox.Data;
using Microsoft.EntityFrameworkCore;

namespace FeastBox.Controllers
{
    [Authorize(Roles = "Admin")] // التأكد من أن هذه العمليات يمكن الوصول إليها فقط بواسطة الـ Admin
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // عرض قائمة العملاء
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // عرض تفاصيل عميل معين
        public IActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c => c.Orders) // تضمين الطلبات المرتبطة بالعميل
                .FirstOrDefault(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }


        // عرض فورم لإضافة عميل جديد
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // إضافة عميل جديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // عرض فورم لتعديل بيانات عميل
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // تحديث بيانات عميل
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // حذف عميل
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
