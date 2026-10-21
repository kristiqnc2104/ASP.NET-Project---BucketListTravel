using BucketListTravel.Services.DTOs;
using BucketListTravel.Services.Interfaces;
using BucketListTravel.ViewModels.Destinations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static BucketListTravel.Common.UIConstants;
using static BucketListTravel.Common.ViewModelValidation;

namespace BucketListTravel.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var destinations = await _destinationService.GetAllDestinationsAsync();
            return View(MapToViewModels(destinations));
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var destinations = await _destinationService.GetAllDestinationsAsync();
            return View(MapToViewModels(destinations));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _destinationService.GetAllCategoriesAsync();
            var viewModel = new CreateDestinationViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDestinationViewModel viewModel)
        {
            if (viewModel.CategoryId > 0 && !await _destinationService.CategoryExistsAsync(viewModel.CategoryId))
            {
                ModelState.AddModelError(nameof(viewModel.CategoryId), ViewModelDestinationCategoryNotFoundErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                var categories = await _destinationService.GetAllCategoriesAsync();
                viewModel.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
                return View(viewModel);
            }

            var createDto = new CreateDestinationDto
            {
                Name = viewModel.Name,
                Country = viewModel.Country,
                Description = viewModel.Description,
                ImageUrl = viewModel.ImageUrl,
                CategoryId = viewModel.CategoryId
            };

            await _destinationService.CreateDestinationAsync(createDto);
            return RedirectToAction(nameof(Manage));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var destination = await _destinationService.GetDestinationByIdAsync(id);
            if (destination == null)
            {
                return NotFound();
            }
            var categories = await _destinationService.GetAllCategoriesAsync();
            var viewModel = new EditDestinationViewModel
            {
                Id = destination.Id,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description,
                ImageUrl = destination.ImageUrl,
                CategoryId = destination.CategoryId,
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDestinationViewModel viewModel)
        {
            if (viewModel.CategoryId > 0 && !await _destinationService.CategoryExistsAsync(viewModel.CategoryId))
            {
                ModelState.AddModelError(nameof(viewModel.CategoryId), ViewModelDestinationCategoryNotFoundErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                var categories = await _destinationService.GetAllCategoriesAsync();
                viewModel.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
                return View(viewModel);
            }

            var updateDto = new UpdateDestinationDto
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Country = viewModel.Country,
                Description = viewModel.Description,
                ImageUrl = viewModel.ImageUrl,
                CategoryId = viewModel.CategoryId
            };

            var result = await _destinationService.UpdateDestinationAsync(updateDto);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSelected(IEnumerable<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                return RedirectToAction(nameof(Manage));
            }

            await _destinationService.DeleteRangeAsync(selectedIds);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            DestinationDetailsDto? destination = await _destinationService.GetDestinationDetailsAsync(id);

            if (destination == null)
            {
                return NotFound();
            }


            DestinationDetailsViewModel destinationDetailsViewModel = new DestinationDetailsViewModel
            {
                Id = destination.Id,
                Name = destination.Name,
                Country = destination.Country,
                Description = destination.Description,
                ImageUrl = destination.ImageUrl ?? DefaultImageUrl,
                CategoryName = destination.CategoryName,
                IsInBucketList = destination.IsInBucketList
            };

            return View(destinationDetailsViewModel);
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
