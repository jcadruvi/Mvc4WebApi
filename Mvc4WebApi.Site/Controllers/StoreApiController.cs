using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Mvc4.ServiceStack.Dto.Request;
using Mvc4.ServiceStack.Dto.Response;
using Mvc4.WebApi.Models;

namespace Mvc4.WebApi.Controllers
{
    public class StoreApiController : ApiController
    {
        private IEnumerable<StoreResponse> _stores;

        [HttpDelete]
        public void Delete([ModelBinder] StoreRequest store)
        {
            
        }

        public StoreResponse GetStore([ModelBinder] StoreRequest store)
        {
            return (from s in Stores()
                    where s.Id == store.Id
                    select s).First();
        }

        public IEnumerable<KeyValuePair<string, string>> GetOrgLevels()
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();

            response.Add(new KeyValuePair<string, string>("1", "Bay Area"));
            response.Add(new KeyValuePair<string, string>("2", "Los Angelos"));
            response.Add(new KeyValuePair<string, string>("3", "San Diego"));

            return response;
        }

        public IEnumerable<KeyValuePair<string, string>> GetRetailers()
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

        public IEnumerable<StoreResponse> GetStores()
        {
            return Stores();
        }

        public IEnumerable<KeyValuePair<string, string>> GetSubOrgLevels([ModelBinder] SubOrgLevelRequest request)
        {
            ICollection<KeyValuePair<string, string>> response = new Collection<KeyValuePair<string, string>>();

            switch (request.OrgLevelId)
            {
                case 1:
                    response.Add(new KeyValuePair<string, string>("1", "San Fransisco"));
                    response.Add(new KeyValuePair<string, string>("2", "San Jose"));
                    response.Add(new KeyValuePair<string, string>("3", "Oakland"));
                    break;
                case 2:
                    response.Add(new KeyValuePair<string, string>("4", "Los Angelos"));
                    response.Add(new KeyValuePair<string, string>("5", "Glendale"));
                    response.Add(new KeyValuePair<string, string>("6", "Simi Valley"));
                    break;
                case 3:
                    response.Add(new KeyValuePair<string, string>("7", "San Diego"));
                    response.Add(new KeyValuePair<string, string>("8", "Oceanside"));
                    response.Add(new KeyValuePair<string, string>("9", "Escondido"));
                    break;
            }

            return response;
        }

        public object Post(StoreRequest store)
        {
            return null;
        }

        private IEnumerable<StoreResponse> Stores()
        {
            ICollection<StoreResponse> response = new Collection<StoreResponse>();
            response.Add(new StoreResponse
            {
                RetailerId = 1,
                RetailerName = "Best Buy",
                Id = 1,
                Name = "Store 1",
                Number = "1",
                City = "San Jose",
                State = "CA",
                OrgLevelId = 1,
                OrgLevelName = "1 - Bay Area",
                SubOrgLevelId = 2,
                SubOrgLevelName = "2 - San Jose"
            });
            response.Add(new StoreResponse
            {
                RetailerId = 1,
                RetailerName = "Best Buy",
                Id = 2,
                Name = "Store 2",
                Number = "2",
                City = "San Jose",
                State = "CA",
                OrgLevelId = 1,
                OrgLevelName = "1 - Bay Area",
                SubOrgLevelId = 2,
                SubOrgLevelName = "2 - San Jose"
            });
            response.Add(new StoreResponse
            {
                RetailerId = 1,
                RetailerName = "Best Buy",
                Id = 3,
                Name = "Store 3",
                Number = "3",
                City = "San Jose",
                State = "CA",
                OrgLevelId = 1,
                OrgLevelName = "1 - Bay Area",
                SubOrgLevelId = 2,
                SubOrgLevelName = "2 - San Jose"
            });
            return response;
        } 
    }
}
