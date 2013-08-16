using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mvc4.WebApi.Api.Controllers
{
    public class RetailerApiController : ApiController
    {
        /// <summary>
        /// Gets the id and description of all Retailers.
        /// </summary>
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> Retailers()
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();
            response.Add(new KeyValuePair<string, string>("1", "Best Buy"));
            response.Add(new KeyValuePair<string, string>("2", "Frys"));
            response.Add(new KeyValuePair<string, string>("3", "Wal Mart"));
            response.Add(new KeyValuePair<string, string>("4", "Target"));
            response.Add(new KeyValuePair<string, string>("5", "Safeway"));
            response.Add(new KeyValuePair<string, string>("6", "Knob Hill"));
            response.Add(new KeyValuePair<string, string>("7", "Luckys"));
            return response;
        }
    }
}
