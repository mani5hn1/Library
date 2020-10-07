using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QALibrary.Models
{
    public class BasketItem
    {
        public int ItemId { get; set; }

        [DisplayName("Item Name")]
        public string Name { get; set; }

        [Range(0,100)]
        public int Quantity { get; set; }

        private decimal price;

        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0, 100)]
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("value", "Price must not be less than 0");
                }
            }
        }

        [DisplayName("Total Price")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalPrice
        {
            get
            {
                return Quantity * price;
            }
        }

        public BasketItem()
        { }

        public BasketItem(int bookID, string bookName, decimal price)
        {
            ItemId = bookID;
            Name = bookName;
            Price = price;
            Quantity = 1;
        }

        public int IncrementQuantity()
        {
            Quantity++;
            return Quantity;
        }

        public int ChangeQuantity(int newQuantity)
        {
            Quantity = newQuantity;
            return Quantity;
        }
    }
}
