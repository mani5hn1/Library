using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QALibrary.Models
{
    [MetadataType(typeof(Book.Metadata))]
    public partial class Book
    {
        public class Metadata
        {
            [DisplayName("Book Name")]
            public string BookName { get; set; }

            [DisplayFormat(DataFormatString = "{0:c}")]
            public decimal Price { get; set; }
        }
    }
}