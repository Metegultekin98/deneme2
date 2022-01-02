using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deneme2.Models
{
    public class Product
    {
        public int ProductId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide a product name", AllowEmptyStrings = false)]
        public string ProductName
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide a color for the product", AllowEmptyStrings = false)]
        public string ProductColor
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Please provide a price for the product", AllowEmptyStrings = false)]
        public int ProductPrice
        {
            get;
            set;
        }
    }
}