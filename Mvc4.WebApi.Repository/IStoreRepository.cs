using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.WebApi.ServiceModel.Request;
using Mvc4.WebApi.ServiceModel.Response;

namespace Mvc4.WebApi.Repository
{
    public interface IStoreRepository
    {
        void DeleteStore(int id);
        IEnumerable<StoreResponse> GetStores();
        void UpdateStore(StoreRequest store);
    }
}
