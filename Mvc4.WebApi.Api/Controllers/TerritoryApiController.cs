using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mvc4.WebApi.Api.Controllers
{
    public class TerritoryApiController : ApiController
    {
        [HttpGet]
        /// <summary>
        /// Gets the id and description of all Territories.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Territories(int? districtId)
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();
            if (!districtId.HasValue)
            {
                return null;
            }

            switch (districtId)
            {
                case 1:
                    response.Add(new KeyValuePair<string, string>("1", "San Fransisco"));
                    response.Add(new KeyValuePair<string, string>("2", "San Jose"));
                    response.Add(new KeyValuePair<string, string>("3", "Oakland"));
                    break;
                case 2:
                    response.Add(new KeyValuePair<string, string>("4", "Las Vegas"));
                    response.Add(new KeyValuePair<string, string>("5", "Reno"));
                    break;
                case 3:
                    response.Add(new KeyValuePair<string, string>("7", "San Diego"));
                    response.Add(new KeyValuePair<string, string>("8", "Oceanside"));
                    response.Add(new KeyValuePair<string, string>("9", "Escondido"));
                    break;
            }

            return response;
        }
    }
}
