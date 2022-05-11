using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TwojeRemonty.Data.Entity;
using TwojeRemonty.Data.Repositories;
using TwojeRemonty.Models;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace TwojeRemonty.Controllers
{
    [Authorize]
    public class OffersController : Controller
    {
        private readonly OfferRepository offersRepository;

        public OffersController(OfferRepository offersRepository)
        {
            this.offersRepository = offersRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var offers = offersRepository.GetByUserId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var offersList = new List<OfferViewModel>();
            foreach (var offer in offers)
            {
                var offerViewModel = new OfferViewModel()
                {
                    City = offer.City,
                    Description = offer.Description,
                    LowerPrice = offer.LowerPrice,
                    UpperPrice = offer.UpperPrice,
                    Specialization = offer.Specialization,
                    Photo = offer.Photo
                };

                offersList.Add(offerViewModel);
            }
            return View(offersList);
        }

        public IActionResult Add()
        {
            var values = (Specializations[])Enum.GetValues(typeof(Specializations));
            var specializationSelect = new List<SelectListItem>();
            foreach (var value in values)
            {
                var listItem = new SelectListItem
                {
                    Text = value.ToString(),
                    Value = value.ToString()
                };

                specializationSelect.Add(listItem);
            }
            return View(new AddOfferViewModel {SpecializationList = specializationSelect});
        }

        [HttpPost]
        public IActionResult Add(AddOfferViewModel viewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var newOffer = new Offer
            {
                City = viewModel.City,
                LowerPrice = viewModel.LowerPrice,
                UpperPrice = viewModel.UpperPrice,
                Specialization = viewModel.Specialization,
                Description = viewModel.Description,
                UserId = userId,
                Photo = "TODO"
            };

            offersRepository.Add(newOffer);
            return RedirectToAction("Index");
        }
    }
}

