using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.ServiceStack.Dto.Request;
using Mvc4.ServiceStack.Dto.Response;

namespace Mvc4.WebApi.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private static IList<StoreResponse> _stores;
        static StoreRepository()
        {
            _stores = Stores();
        }
        public void DeleteStore(int id)
        {
            for (int i = 0; i < _stores.Count(); i++)
            {
                if (_stores[i].Id == id)
                {
                    _stores.RemoveAt(i);
                }
            }
        }
        public IEnumerable<StoreResponse> GetStores()
        {
            return _stores;
        }
        private static IList<StoreResponse> Stores()
        {
            IList<StoreResponse> response = new List<StoreResponse>();
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
        public void UpdateStore(StoreRequest store)
        {
            var updateStore = (from s in _stores
                               where s.Id == store.Id
                               select s).First();
            if (updateStore != null)
            {
                updateStore.City = store.City;
                updateStore.Name = store.Name;
                updateStore.Number = store.Number;
                updateStore.OrgLevelId = store.OrgLevelId;
                updateStore.RetailerId = store.RetailerId;
                updateStore.State = store.State;
                updateStore.SubOrgLevelId = store.SubOrgLevelId;
            }
        }
    }
}
