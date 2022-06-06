using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool? IsPoster  { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
