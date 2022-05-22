using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using TwojeRemonty.Data.Entity;

namespace TwojeRemonty.Models
{
	public class EditOfferViewModel
	{
        [Required]
        public Specializations Specialization { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Range(1, 100000)]
        public decimal LowerPrice { get; set; }

        [Required]
        [Range(2, 200000)]
        public decimal UpperPrice { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public string Tittle { get; set; }

        [ValidateNever]
        public List<SelectListItem> SpecializationList { get; set; }
    }
}

