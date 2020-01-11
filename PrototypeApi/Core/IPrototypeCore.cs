using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypeApi.Core
{
    public interface IPrototypeCore
    {
        string GetLongestOpeningCrawlMovie();
        List<string> GetMostAppearedPerson();
    }
}
