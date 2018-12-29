using System;
using System.Collections.Generic;

namespace GiveNTake.Models {
    public class Product {
        // Primary Key
        public int ProductId { get; set; }

        // Value properties
        public User Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //Navigation properties
        public Category Category { get; set; }
        public City City { get; set; }
        public IList<ProductMedia> Media { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
