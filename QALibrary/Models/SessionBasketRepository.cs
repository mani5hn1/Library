using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QALibrary.Models
{
    public class SessionBasketRepository : IBasketRepository
    {
        public Basket GetBasket()
        {
            Basket basket = HttpContext.Current.Session["basket"] as Basket;
            if (basket == null)
            {
                basket = new Basket();
                HttpContext.Current.Session["basket"] = basket;
            }

            return basket;
        }
    }
}