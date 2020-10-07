using QALibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QALibrary.Controllers
{
    public class CheckoutController : Controller
    {
        IBasketRepository repository;

        public CheckoutController(IBasketRepository repository)
        {
            this.repository = repository;
        }
        public CheckoutController()
            : this(new SessionBasketRepository())
        { }


        public ActionResult Index()
        {
            Basket basket = repository.GetBasket();
            if (basket.GetItems().Count() == 0)
            {
                return RedirectToAction("Index", "Books");
            }

            ViewBag.TotalPrice = basket.GetTotalPrice();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            Basket basket = repository.GetBasket();

            ViewBag.TotalPrice = basket.GetTotalPrice();
            ViewBag.LastDigits = customer.AccountNumber.Substring(customer.AccountNumber.Length - 4);

            basket.RemoveAllItems();

            return View("Confirmation");
        }
    }
}