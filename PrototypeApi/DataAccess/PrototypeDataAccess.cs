using Microsoft.Extensions.Configuration;
using PrototypeApi.CustomModel;
using PrototypeApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeApi.DataAccess
{
    [ExcludeFromCodeCoverage]
    public class PrototypeDataAccess: IPrototypeDataAccess
    {
        readonly PrototypeDBContext dbContext;        
        public PrototypeDataAccess(IConfiguration config)
        {
            this.dbContext = new PrototypeDBContext(config["ConnectionString"].ToString());
        }
        public IEnumerable<Films> GetAllFilms()
        {
            try
            {
                return dbContext.Films.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PeopleAppeared> GetMostAppearedPerson()
        {
            try
            {
                var query = from fc in dbContext.FilmsCharacters
                            join p in dbContext.People on fc.PeopleId equals p.Id
                            select new {p.Id,p.Name} into ap
                            group ap by new { ap.Id, ap.Name } into g
                            select new PeopleAppeared() { PeopleId =g.Key.Id, PeopleName = g.Key.Name,AppearedCount = g.Count()};
                return query.AsEnumerable<PeopleAppeared>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
