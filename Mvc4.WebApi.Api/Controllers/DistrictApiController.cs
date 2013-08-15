using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mvc4.WebApi.Api.Controllers
{
    public class DistrictApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> Districts()
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();

            response.Add(new KeyValuePair<string, string>("1", "Bay Area"));
            response.Add(new KeyValuePair<string, string>("2", "Nevada"));
            response.Add(new KeyValuePair<string, string>("3", "San Diego"));

            return response;
        }
    }
}
