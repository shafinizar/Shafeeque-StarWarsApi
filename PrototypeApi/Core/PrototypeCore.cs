using PrototypeApi.CustomModel;
using PrototypeApi.DataAccess;
using PrototypeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeApi.Core
{
    public class PrototypeCore : IPrototypeCore
    {
        readonly IPrototypeDataAccess dataAccess;
        public PrototypeCore(IPrototypeDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public string GetLongestOpeningCrawlMovie()
        {
            List<Films> films = dataAccess.GetAllFilms().ToList();           
            var openingCrawl = films.Max(s => s.OpeningCrawl);            
            var longest = films.FirstOrDefault(s => s.OpeningCrawl == openingCrawl);
            return longest.Title;         
        }

        public List<string> GetMostAppearedPerson()
        {
            List<string> characterList = new List<string>();
            List<PeopleAppeared> peopleAppearedList = dataAccess.GetMostAppearedPerson().ToList();
            var mostAppreadCount = peopleAppearedList.Max(s => s.AppearedCount);
            var longest = peopleAppearedList.Where(s => s.AppearedCount == mostAppreadCount);
            foreach(PeopleAppeared p in longest)
            {
                characterList.Add(p.PeopleName);
            }
            return characterList;
        }
        public List<SpeciesAppeared> GetSpecies()
        {
            List<string> characterList = new List<string>();
            List<SpeciesAppeared> speciesList = dataAccess.GetSpecies().ToList();
            var mostAppreadCount = speciesList.Max(s => s.AppearedCount);
            var longest = speciesList.Where(s => s.AppearedCount == mostAppreadCount);
            return longest.ToList();
        }
    }
}
