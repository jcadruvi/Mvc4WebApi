using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc4.WebApi.Models
{
    public class StoreEditRequest
    {
        public int? RetailerId { get; set; }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public int? DistrictId { get; set; }
        public int? TerritoryId { get; set; }
    }
}