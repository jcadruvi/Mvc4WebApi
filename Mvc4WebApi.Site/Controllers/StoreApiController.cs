using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Mvc4.WebApi.Service;
using Mvc4.WebApi.Model;
using Mvc4.WebApi.Models;

namespace Mvc4.WebApi.Controllers
{
    public class StoreApiController : ApiController
    {
        private IStoreService _storeService;

        public StoreApiController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpDelete]
        public void Delete([ModelBinder] Store store)
        {
            if (store.Id.HasValue)
            {
                _storeService.DeleteStore(store.Id.Value);
            }
        }

        public Store GetStore([ModelBinder] Store store)
        {
            return (from s in _storeService.GetStores()
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

        public IEnumerable<Store> GetStores()
        {
            return _storeService.GetStores();
        }

        public IEnumerable<KeyValuePair<string, string>> GetSubOrgLevels([ModelBinder] SubOrgLevel request)
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

        public object Post(Store store)
        {
            _storeService.UpdateStore(store);
            return null;
        }
    }
}
