using System;
using Microsoft.AspNetCore.Identity;

namespace TwojeRemonty.Data.Entity
{
	public class Offer
	{
        public int Id { get; set; }
        public string UserId { get; set; }
        public Specializations Specialization { get; set; }
        public string City { get; set; }
        public decimal LowerPrice { get; set; }
        public decimal UpperPrice { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Tittle { get; set; }

        public IdentityUser User { get; set; }
    }
}

