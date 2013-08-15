using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Mvc4.WebApi.Models;
using Mvc4.WebApi.Model;
using Mvc4.WebApi.Api.Request;
using Mvc4.WebApi.Api.Response;

namespace Mvc4.WebApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<StoreEditRequest, Store>()
                .IgnoreAllNonExisting();
            Mapper.CreateMap<Store, StoreResponse>()
                .IgnoreAllNonExisting();
            Mapper.CreateMap<Store, StoreListResponse>()
                .IgnoreAllNonExisting();

            Mapper.AssertConfigurationIsValid();
        }
    }
}