using System;
using TwojeRemonty.Data.Entity;

namespace TwojeRemonty.Models
{
	public class OfferViewModel
	{
        public Specializations Specialization { get; set; }
        public string City { get; set; }
        public decimal LowerPrice { get; set; }
        public decimal UpperPrice { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int Id { get; set; }
        public string Tittle { get; set; }

    }
}

