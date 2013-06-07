using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.ServiceStack.ServiceModel.Request;
using Mvc4.ServiceStack.ServiceModel.Response;

namespace Mvc.WebApi.Service
{
    public interface IStoreService
    {
        void DeleteStore(int id);
        IEnumerable<StoreResponse> GetStores();
        void UpdateStore(StoreRequest store);
    }
}
