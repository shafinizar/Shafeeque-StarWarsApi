using System;
using System.Collections.Generic;

namespace PrototypeApi.Models
{
    public partial class FilmsCharacters
    {
        public int FilmId { get; set; }
        public int PeopleId { get; set; }

        public virtual Films Film { get; set; }
        public virtual People People { get; set; }
    }
}
