using System;
using System.Collections.Generic;

namespace PrototypeApi.Models
{
    public partial class FilmsSpecies
    {
        public int FilmId { get; set; }
        public int SpeciesId { get; set; }

        public virtual Films Film { get; set; }
        public virtual Species Species { get; set; }
    }
}
