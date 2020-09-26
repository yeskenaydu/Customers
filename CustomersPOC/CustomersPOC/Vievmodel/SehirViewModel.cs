using CustomersPOC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomersPOC.Vievmodel
{
    public class SehirViewModel
    {
        public customers customer { get; set; }
        public IEnumerable<city> cityId { get; set; }
        public IEnumerable<district> districtId { get; set; }

    }
}