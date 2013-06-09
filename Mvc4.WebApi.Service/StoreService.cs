using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.WebApi.ServiceModel.Request;
using Mvc4.WebApi.ServiceModel.Response;
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
        public IEnumerable<StoreResponse> GetStores()
        {
            return repository.GetStores();
        }
        public void UpdateStore(StoreRequest store)
        {
            repository.UpdateStore(store);
        }
    }
}
