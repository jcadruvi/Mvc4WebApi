using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc4.WebApi.Models
{
    public class StoreViewModel
    {
        public int RetailerId { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public int? OrgLevelId { get; set; }
        public int? SubOrgLevelId { get; set; }
    }
}