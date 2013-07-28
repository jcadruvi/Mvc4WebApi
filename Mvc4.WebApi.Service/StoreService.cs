using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.WebApi.Model;
using Mvc4.WebApi.Repository;

namespace Mvc4.WebApi.Service
{
    public class StoreService : IStoreService
    {
        private IStoreRepository repository;
        public StoreService()
        {
            repository = StoreRepository.Instance;
        }
        public void DeleteStore(int id)
        {
            repository.DeleteStore(id);
        }
        public IEnumerable<Store> GetStores()
        {
            return repository.GetStores();
        }
        public void UpdateStore(Store store)
        {
            repository.UpdateStore(store);
        }
    }
}
