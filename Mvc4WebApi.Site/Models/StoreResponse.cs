using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4.WebApi.Models
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
    }
}