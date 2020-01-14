using FakeItEasy;
using PrototypeApi.Controllers;
using PrototypeApi.Core;
using PrototypeApi.CustomModel;
using PrototypeApi.DataAccess;
using PrototypeApi.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace PrototypeTest.UniTest
{
    public class PrototypeUnitTest
    {
        readonly IPrototypeCore prototypeCore;
        readonly IPrototypeDataAccess dataAccess;
        readonly PrototypeController controller;
        public PrototypeUnitTest()
        {
            dataAccess = A.Fake<IPrototypeDataAccess>();
            this.prototypeCore = new PrototypeCore(dataAccess);
            controller = new PrototypeController(prototypeCore);
        }

        [Fact]
        public void GetLongestMovie()
        {
            var filmsList = A.CollectionOfFake<Films>(10);
            filmsList[0].OpeningCrawl = "a series of bbbbbb";
            filmsList[0].Title = "new movie";                       
            A.CallTo(() => dataAccess.GetAllFilms()).Returns(filmsList);
            var movie = controller.GetLongestMovie();
            Assert.NotNull(movie);
        }
        [Fact]
        public void GetMostAppearedPerson()
        {
            var peopleAppearedList = A.CollectionOfFake<PeopleAppeared>(10);
            peopleAppearedList[0].PeopleName = "Name 1";
            peopleAppearedList[0].PeopleId = 1;
            peopleAppearedList[0].AppearedCount = 5;
            peopleAppearedList[1].PeopleName = "Name 2";
            peopleAppearedList[1].PeopleId = 1;
            peopleAppearedList[1].AppearedCount = 4;
            A.CallTo(() => dataAccess.GetMostAppearedPerson()).Returns(peopleAppearedList);
            var personName = controller.GetMostAppearedPerson();            
            Assert.IsType<List<string>>(personName);
        }

        [Fact]
        public void GetSpecies()
        {
            var appearedList = A.CollectionOfFake<SpeciesAppeared>(10);
            appearedList[0].SpeciesName = "Name 1";
            appearedList[0].SpeciesId = 1;
            appearedList[0].AppearedCount = 3;
            appearedList[0].NumberOfCharacter = 2;
            appearedList[1].SpeciesName = "Name 1";
            appearedList[1].SpeciesId = 1;
            appearedList[1].AppearedCount = 5;
            appearedList[1].NumberOfCharacter = 2;
            A.CallTo(() => dataAccess.GetSpecies()).Returns(appearedList);
            var personName = controller.GetSpecies();
            Assert.IsType<List<SpeciesAppeared>>(personName);
        }
    }
}
