using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc4.WebApi.Model;

namespace Mvc4.WebApi.Service
{
    public interface IStoreService
    {
        void DeleteStore(int id);
        IEnumerable<Store> GetStores();
        void UpdateStore(Store store);
    }
}
