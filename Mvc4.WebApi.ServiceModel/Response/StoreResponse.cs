using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc4.ServiceStack.ServiceModel.Response
{
    public class StoreResponse
    {
        public int? RetailerId { get; set; }
        public string RetailerName { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? OrgLevelId { get; set; }
        public string OrgLevelName { get; set; }
        public int? SubOrgLevelId { get; set; }
        public string SubOrgLevelName { get; set; }
    }
}
