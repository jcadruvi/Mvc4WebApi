using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc4.WebApi.Model
{
    public class Store
    {
        public int? RetailerId { get; set; }
        public string RetailerName { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int? TerritoryId { get; set; }
        public string TerritoryName { get; set; }
    }
}
