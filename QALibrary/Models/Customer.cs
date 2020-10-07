using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QALibrary.Models
{
    public class Customer
    {
        public string Name { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [DisplayName("Company Address")]
        public string CompanyAddress { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        [DisplayName("Post Code")]
        [RegularExpression("^([A-PR-UWYZ0-9][A-HK-Y0-9][AEHMNPRTVXY0-9]?[ABEHMNPRVWXY0-9]? {0,1}[0-9][ABD-HJLN-UW-Z]{2}|GIR 0AA)$", ErrorMessage = "You must enter a valid postcode")]
        public string PostCode { get; set; }

        [Required]
        [DisplayName("Account Number")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "You must enter a valid account number")]
        public string AccountNumber { get; set; }
    }
}