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

        public IEnumerable<SpeciesAppeared> GetSpecies()
        {
            try
            {

                var query = from s in dbContext.Species
                            join fs in dbContext.FilmsSpecies on s.Id equals fs.SpeciesId
                            select new { s.Id, s.Name } into ap
                            group ap by new { ap.Id, ap.Name } into g
                            select new SpeciesAppeared() { SpeciesId = g.Key.Id, SpeciesName = g.Key.Name, AppearedCount = g.Count() };

                var result = from s in query
                             join sp in dbContext.SpeciesPeople on s.SpeciesId equals sp.SpeciesId
                             select new {s.SpeciesId, s.SpeciesName,s.AppearedCount,sp.PeopleId} into ap
                             group ap by new { ap.SpeciesId, ap.SpeciesName, ap.AppearedCount } into g
                             select new SpeciesAppeared() { SpeciesId = g.Key.SpeciesId, SpeciesName = g.Key.SpeciesName, 
                                 AppearedCount = g.Key.AppearedCount, NumberOfCharacter = g.Count()};

                return result.AsEnumerable<SpeciesAppeared>();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
