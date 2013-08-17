using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4.WebApi.Api.Response
{
    public class StoreResponse
    {
        public int? RetailerId { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? DistrictId { get; set; }
        public int? TerritoryId { get; set; }
        public decimal? Sales { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}