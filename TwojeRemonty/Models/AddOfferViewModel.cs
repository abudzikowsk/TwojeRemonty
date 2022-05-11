using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using TwojeRemonty.Data.Entity;

namespace TwojeRemonty.Models
{
	public class AddOfferViewModel
	{
        public Specializations Specialization { get; set; }
        public string City { get; set; }
        public decimal LowerPrice { get; set; }
        public decimal UpperPrice { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; }

        public List<SelectListItem> SpecializationList { get; set; }
    }
}

