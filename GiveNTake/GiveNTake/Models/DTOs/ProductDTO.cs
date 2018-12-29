using System;
using System.Collections.Generic;
using GiveNTake.Models;

namespace GiveNTake.Controllers {
    public class ProductDTO {
        public int ProductId { get; set; }

        public User Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Category Category { get; set; }
        public Category Subcategory { get; set; }
        public string City { get; set; }
        public IList<ProductMedia> Media { get; set; }
        public DateTime PublishDate { get; set; }
    }
}