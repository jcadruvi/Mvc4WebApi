using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc4.WebApi.ServiceModel.Request
{
    public class StoreRequest
    {
        public int? RetailerId { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? OrgLevelId { get; set; }
        public int? SubOrgLevelId { get; set; }
    }
}
