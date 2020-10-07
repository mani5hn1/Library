namespace QALibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int BookID { get; set; }

        [Required]
        [StringLength(50)]
        public string BookName { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [StringLength(300)]
        public string BookDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }

        [StringLength(30)]
        public string Publisher { get; set; }
    }
}
