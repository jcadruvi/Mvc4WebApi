using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.WebApi.Model;

namespace Mvc4.WebApi.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private static readonly StoreRepository _instance = new StoreRepository();
        public static StoreRepository Instance { get { return _instance; } }
        private static IList<Store> _stores;
        static StoreRepository()
        {
        }
        private StoreRepository()
        {
            _stores = new List<Store>();
            _stores.Add(new Store
            {
                RetailerId = 1,
                RetailerName = "Frys",
                Id = 1,
                Name = "Store 1",
                Number = "1",
                City = "Las Vegas",
                State = "NV",
                DistrictId = 2,
                DistrictName = "Nevada",
                TerritoryId = 4,
                TerritoryName = "Las Vegas",
                Sales = (decimal)100.00,
                Latitude = 1,
                Longitude = 2
            });
            _stores.Add(new Store
            {
                RetailerId = 1,
                RetailerName = "Best Buy",
                Id = 2,
                Name = "Store 2",
                Number = "2",
                City = "San Jose",
                State = "CA",
                DistrictId = 1,
                DistrictName = "Bay Area",
                TerritoryId = 2,
                TerritoryName = "San Jose",
                Sales = (decimal)200.00,
                Latitude = 10,
                Longitude = 20
            });
            _stores.Add(new Store
            {
                RetailerId = 1,
                RetailerName = "Best Buy",
                Id = 3,
                Name = "Store 3",
                Number = "3",
                City = "San Jose",
                State = "CA",
                DistrictId = 1,
                DistrictName = "Bay Area",
                TerritoryId = 2,
                TerritoryName = "San Jose",
                Sales = (decimal)300.00,
                Latitude = 30,
                Longitude = 40
            });
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
        public IEnumerable<Store> GetStores()
        {
            return _stores;
        }
        public void UpdateStore(Store store)
        {
            var updateStore = _stores.First(s => s.Id == store.Id);
            if (updateStore != null)
            {
                updateStore.City = store.City;
                updateStore.Name = store.Name;
                updateStore.Number = store.Number;
                updateStore.DistrictId = store.DistrictId;
                updateStore.Latitude = store.Latitude;
                updateStore.Longitude = store.Longitude;
                updateStore.RetailerId = store.RetailerId;
                updateStore.Sales = store.Sales;
                updateStore.State = store.State;
                updateStore.TerritoryId = store.TerritoryId;  
            }
        }
    }
}
