using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TwojeRemonty.Data.Entity;
using TwojeRemonty.Data.Repositories;
using TwojeRemonty.Models;
using Microsoft.AspNetCore.Authorization;
using TwojeRemonty.Services;
using TwojeRemonty.Extensions;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace TwojeRemonty.Controllers
{
    [Authorize]
    public class OffersController : Controller
    {
        private readonly OfferRepository offersRepository;
        private readonly FileService fileService;

        public OffersController(OfferRepository offersRepository, FileService fileService)
        {
            this.offersRepository = offersRepository;
            this.fileService = fileService;
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
                    Photo = offer.Photo,
                    Id = offer.Id,
                    Tittle = offer.Tittle

                };

                offersList.Add(offerViewModel);
            }
            return View(offersList);
        }
        
        public IActionResult Add()
        {
            
            return View(new AddOfferViewModel { SpecializationList = SpecializationsExtensions.ToSelectOptions() });
        }

        [HttpPost]
        public IActionResult Add(AddOfferViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SpecializationList = SpecializationsExtensions.ToSelectOptions();
                return View(viewModel);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var fileName = fileService.SavePicture(viewModel.Photo);

            var newOffer = new Offer
            {
                City = viewModel.City,
                LowerPrice = viewModel.LowerPrice,
                UpperPrice = viewModel.UpperPrice,
                Specialization = viewModel.Specialization,
                Description = viewModel.Description,
                UserId = userId,
                Photo = fileName,
                Tittle = viewModel.Tittle
            };

            offersRepository.Add(newOffer);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var offer = offersRepository.GetByOfferId(id);

            offersRepository.Delete(id);

            fileService.DeletePicture(offer.Photo);

            return RedirectToAction("Index");
        }

        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var offer = offersRepository.GetByOfferId(id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (offer == null)
            {
                return RedirectToAction("Index");
            }

            if(offer.UserId != userId)
            {
                return Unauthorized();
            }

            var viewModel = new EditOfferViewModel
            {
                City = offer.City,
                Description = offer.Description,
                LowerPrice = offer.LowerPrice,
                UpperPrice = offer.UpperPrice,
                Specialization = offer.Specialization,
                Tittle = offer.Tittle,
                SpecializationList = SpecializationsExtensions.ToSelectOptions()
            };

            return View(viewModel);
        }

        [HttpPost("Edit/{id}")]
        public IActionResult Edit(int id, EditOfferViewModel editOfferViewModel)
        {
            if (!ModelState.IsValid)
            {
                editOfferViewModel.SpecializationList = SpecializationsExtensions.ToSelectOptions();
                return View(editOfferViewModel);
            }

            var offer = offersRepository.GetByOfferId(id);

            if (offer == null)
            {
                return RedirectToAction("Index");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(offer.UserId != userId)
            {
                return Unauthorized();
            }

            offer.City = editOfferViewModel.City;
            offer.Description = editOfferViewModel.Description;
            offer.Specialization = editOfferViewModel.Specialization;
            offer.Tittle = editOfferViewModel.Tittle;
            offer.LowerPrice = editOfferViewModel.LowerPrice;
            offer.UpperPrice = editOfferViewModel.UpperPrice;

            offersRepository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
    
