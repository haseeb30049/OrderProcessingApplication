using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderProcessingApplication.DAL;
using OrderProcessingApplication.Models;
using System.Diagnostics;

namespace OrderProcessingApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<OrderData> model = new List<OrderData>();
            model = _db.OrderData.ToList();
            return View(model);
        }

        public IActionResult Setup(int? id)
        {
            OrderData model = new OrderData();
            if (id!=null)
            {
                model = _db.OrderData.Find(id);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Setup(OrderData data)
        {
            if (data.ID == 0)
            {
                if (data.Amount >= 100 && data.CustomerType == "Loyal")
                {
                    var discount = data.Amount * 0.10;
                    data.Discount = discount;
                }
                _db.Add(data);
            }
            else
            {
                var dbData = _db.OrderData.Find(data.ID);
                dbData.CustomerName = data.CustomerName;
                dbData.CustomerType = data.CustomerType;
                dbData.PhoneNumber = data.PhoneNumber;
                dbData.Email = data.Email;
                dbData.Amount = data.Amount;
                if (data.Amount >= 100 && data.CustomerType == "Loyal")
                {
                    var discount = data.Amount * 0.10;
                    dbData.Discount = discount;
                }
                _db.Entry(dbData).State = EntityState.Modified;
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var order = _db.OrderData.Find(id);
            _db.Entry(order).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
