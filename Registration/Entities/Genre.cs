﻿using System.Collections.Generic;

namespace Registration.Entities
{
    public partial class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}