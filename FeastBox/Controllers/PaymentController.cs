using Microsoft.AspNetCore.Mvc;

namespace FeastBox.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult Payment(decimal totalAmount)
        {
            ViewBag.TotalAmount = totalAmount;
            return View();
        }
        [HttpPost]
        public IActionResult ProcessPayment(string cardNumber, string expiryDate, string cvv)
        {
            
            return RedirectToAction("PaymentSuccess");
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }

    }
}
