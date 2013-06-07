using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.ServiceStack.ServiceModel.Request;
using Mvc4.ServiceStack.ServiceModel.Response;
using Mvc4.WebApi.Repository;

namespace Mvc.WebApi.Service
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
