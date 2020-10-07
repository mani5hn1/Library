using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QALibrary.Models
{
    public class Basket
    {
        private List<BasketItem> items;

        public Basket()
        {
            items = new List<BasketItem>();
        }

        public IEnumerable<BasketItem> GetItems()
        {
            return items;
        }

        public BasketItem GetItemByBookId(int bookID)
        {
            return items.Find(i => i.ItemId == bookID);
        }

        public decimal GetTotalPrice()
        {
            return items.Sum(i => i.TotalPrice);
        }

        public void AddItem(int bookID, string bookName, decimal price)
        {
            BasketItem item = items.Find(i => i.ItemId == bookID);
            if (item == null)
            {
                // The item isn't in our list yet
                items.Add(new BasketItem(bookID, bookName, price));
            }
            else
            {
                // The item is already in our list
                item.IncrementQuantity();
            }
        }

        public void ChangeQuantity(int bookID, int quantity)
        {
            BasketItem item = items.Find(i => i.ItemId == bookID);
            if (item == null)
            {
                // The item isn't in our list 
                throw new ArgumentException("There is no book with that ID in the basket");
            }
            item.ChangeQuantity(quantity);
        }

        public void RemoveAllCopiesOfItem(int bookID)
        {
            BasketItem item = items.Find(i => i.ItemId == bookID);
            if (item == null)
            {
                // The item isn't in our list 
                throw new ArgumentException("There is no book with that ID in the basket");
            }
            items.Remove(item);
        }

        public void RemoveAllItems()
        {
            items.Clear();
        }
    }
}
