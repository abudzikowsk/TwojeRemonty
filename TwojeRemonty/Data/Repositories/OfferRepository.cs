﻿using System;
using System.Linq;
using TwojeRemonty.Data.Entity;

namespace TwojeRemonty.Data.Repositories
{
	public class OfferRepository
	{
        private readonly ApplicationDbContext context;

        public OfferRepository(ApplicationDbContext context)
		{
            this.context = context;
        }

        public List<Offer> GetByUserId(string userId)
        {
            return context.Offers.Where(o => o.UserId == userId).ToList(); 
        }

        public void Add(Offer offer)
        {
            context.Offers.Add(offer);
            context.SaveChanges();
        }
	}
}
