using BucketListTravel.Data;
using BucketListTravel.Data.Models;
using BucketListTravel.Services.DTOs;
using BucketListTravel.Services.Interfaces;
using BucketListTravel.ViewModels.Destinations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BucketListTravel.Common.UIConstants;

namespace BucketListTravel.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _destinationService.GetAllDestinationsAsync();
            return View(MapToViewModels(destinations));
        }

        public async Task<IActionResult> Manage()
        {
            var destinations = await _destinationService.GetAllDestinationsAsync();
            return View(MapToViewModels(destinations));
        }





        private static IEnumerable<AllDestinationsIndexViewModel> MapToViewModels(
    IEnumerable<GetAllDestinationsDto> dtos)
        {
            return dtos.Select(d => new AllDestinationsIndexViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Country = d.Country,
                ImageUrl = d.ImageUrl ?? DefaultImageUrl,
                CategoryName = d.CategoryName,
                IsInBucketList = d.IsInBucketList
            });
        }
    }
}
