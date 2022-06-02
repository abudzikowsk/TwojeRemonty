using System;
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

        public Offer GetByOfferId(int id)
        {
            return context.Offers.SingleOrDefault(o => o.Id == id);
        }

        public void Add(Offer offer)
        {
            context.Offers.Add(offer);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var offer = context.Offers.SingleOrDefault(o => o.Id == id);

            if (offer == null)
            {
                return;
            }

            context.Offers.Remove(offer);
            context.SaveChanges();
        }

        public List<Offer> GetAll(string search)
        {
            var normalizedSearch = search?.ToLower();
            var offers = context.Offers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                offers = offers.Where(o => o.City.ToLower().Contains(normalizedSearch)
                || o.Description.ToLower().Contains(normalizedSearch)
                || o.Tittle.ToLower().Contains(normalizedSearch));
            }

            return offers.ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
	}
}

