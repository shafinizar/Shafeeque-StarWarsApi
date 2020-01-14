using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeApi.CustomModel
{
    public class SpeciesAppeared
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public int AppearedCount { get; set; }
        public int NumberOfCharacter { get; set; }
    }
}
