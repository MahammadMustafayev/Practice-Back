using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double  CostPrice { get; set; }
        public double DiscountPrice { get; set; }
        public string InfoText { get; set; }
        public string Desc { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
        public List<ProductImages> ProductImages { get; set; }
    }
}
