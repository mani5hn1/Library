using QALibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QALibrary.Controllers
{
    public class BasketController : Controller
    {
        IBasketRepository basketRepository;
        IBooksRepository dbRepository;

        public BasketController(IBasketRepository basketRepository, IBooksRepository dbRepository)
        {
            this.basketRepository = basketRepository;
            this.dbRepository = dbRepository;
        }
        public BasketController()
            :this(new SessionBasketRepository(), new SQLBooksRepository())
        { }


        public ActionResult Index()
        {
            Basket basket = basketRepository.GetBasket();
            ViewBag.Message = TempData["Message"];
            ViewBag.TotalPrice = basket.GetTotalPrice();
            return View(basket.GetItems());
        }

        public ActionResult Add(int id)
        {
            Book book = dbRepository.GetBookById(id);
            Basket basket = basketRepository.GetBasket();

            basket.AddItem(id, book.BookName, book.Price);

            TempData["message"] = $"Item {book.BookName} added to the basket";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            BasketItem item = basketRepository.GetBasket().GetItemByBookId(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(BasketItem item)
        {
            if(!ModelState.IsValid)
            {
                return View(item);
            }

            Basket basket = basketRepository.GetBasket();
            if (item.Quantity == 0)
            {
                basket.RemoveAllCopiesOfItem(item.ItemId);
            }
            else
            {
                basket.ChangeQuantity(item.ItemId, item.Quantity);
            }
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Remove(int id)
        {
            basketRepository.GetBasket().RemoveAllCopiesOfItem(id);
            return RedirectToAction("Index", "Books");
        }
    }
}