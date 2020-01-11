using PrototypeApi.CustomModel;
using PrototypeApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeApi.DataAccess
{
   
    public interface IPrototypeDataAccess
    {
        IEnumerable<Films> GetAllFilms();
        IEnumerable<PeopleAppeared> GetMostAppearedPerson();
    }
}
