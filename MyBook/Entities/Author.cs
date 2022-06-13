using System;
using System.Collections.Generic;

namespace Registration.Entities{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public String? BirthDate { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();

        public virtual ICollection<ImgLink> ImgLinks { get; set; } = new List<ImgLink>();
    }
    
}