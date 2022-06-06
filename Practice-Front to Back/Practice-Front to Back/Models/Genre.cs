using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public List<Product> Products { get; set; }
    }
}
