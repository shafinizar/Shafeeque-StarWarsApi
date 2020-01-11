using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrototypeApi.Core;

namespace PrototypeApi.Controllers
{  
    [ApiController]
    public class PrototypeController : ControllerBase
    {
        readonly IPrototypeCore prototypeCore;
        public PrototypeController(IPrototypeCore prototypeCore)
        {
            this.prototypeCore = prototypeCore;
        }

        [HttpGet]
        [Route("api/Prototype/GetLongestMovie")]
        public string GetLongestMovie()
        {
            return prototypeCore.GetLongestOpeningCrawlMovie();
        }

        [HttpGet]
        [Route("api/Prototype/GetMostAppearedPerson")]
        public List<string> GetMostAppearedPerson()
        {
            return prototypeCore.GetMostAppearedPerson();
        }
    }
}