using System.Collections.Generic;

namespace GiveNTake.Models {
    public class Category {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IList<Category> Subcategories { get; set; }
        public Category ParentCategory { get; set; }
    }
}