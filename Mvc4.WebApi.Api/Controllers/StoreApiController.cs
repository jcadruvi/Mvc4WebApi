﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Mvc4.WebApi.Service;
using Mvc4.WebApi.Model;
using AutoMapper;
using Mvc4.WebApi.Api.Response;
using Mvc4.WebApi.Api.Request;

namespace Mvc4.WebApi.Api.Controllers
{
    public class StoreApiController : ApiController
    {
        private IStoreService _storeService;

        public StoreApiController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpDelete]
        /// <summary>
        /// Delete a Store by the id.
        /// </summary>
        public void Delete([ModelBinder] Store store)
        {
            if (store.Id.HasValue)
            {
                _storeService.DeleteStore(store.Id.Value);
            }
        }

        [HttpGet]
        /// <summary>
        /// Gets a single Store by the id.
        /// </summary>
        public StoreResponse Store(int id)
        {
            Store store = (from s in _storeService.GetStores()
                           where s.Id == id
                           select s).First();
            return Mapper.Map<StoreResponse>(store);
        }

        [HttpGet]
        /// <summary>
        /// Gets all Stores for a list.
        /// </summary>
        public IEnumerable<StoreListResponse> Stores()
        {
            return Mapper.Map<IEnumerable<StoreListResponse>>(_storeService.GetStores());
        }

        [HttpPost]
        /// <summary>
        /// Save a Store.
        /// </summary>
        public void Store(StoreEditRequest store)
        {
            _storeService.UpdateStore(Mapper.Map<Store>(store));
        }
    }
}
