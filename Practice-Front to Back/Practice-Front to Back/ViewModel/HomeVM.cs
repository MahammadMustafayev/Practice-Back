using Practice_Front_to_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.ViewModel
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Feature> Features { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImages> ProductImages { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Author> Authors { get; set; }
    }
}
