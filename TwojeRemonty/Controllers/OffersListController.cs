using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TwojeRemonty.Data.Repositories;
using TwojeRemonty.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwojeRemonty.Controllers
{
    public class OffersListController : Controller
    {
        private readonly OfferRepository offerRepository;

        public OffersListController(OfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }
        // GET: /<controller>/
        public IActionResult Index(string search)
        {
            var offerList = new List<OfferViewModel>();
            var offers = offerRepository.GetAll(search);

            foreach(var offer in offers)
            {
                var viewModel = new OfferViewModel
                {
                    City = offer.City,
                    Description = offer.Description,
                    Id = offer.Id,
                    LowerPrice = offer.LowerPrice,
                    UpperPrice = offer.UpperPrice,
                    Photo = offer.Photo,
                    Specialization = offer.Specialization,
                    Tittle = offer.Tittle
                };

                offerList.Add(viewModel);
            }
            return View(new OffersListViewModel { OffersList = offerList, Search = search });

            
        }



    }
}

