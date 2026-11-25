using BucketListTravel.Services.DTOs;
using BucketListTravel.Services.Interfaces;
using BucketListTravel.ViewModels.Common;
using BucketListTravel.ViewModels.Destinations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
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

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1)
            {
                page = 1;
            }

            var userId = GetCurrentUserId();

            PagedResultDto<GetAllDestinationsDto> pagedDestinations =
                await _destinationService.GetAllDestinationsAsync(userId, page, DestinationsPerPage);

            int totalPages = (int)Math.Ceiling(pagedDestinations.TotalCount / (double)DestinationsPerPage);

            if (totalPages > 0 && page > totalPages)
            {
                return RedirectToAction(nameof(Index), new { page = totalPages });
            }

            var viewModel = new PaginatedViewModel<AllDestinationsIndexViewModel>
            {
                Items = MapToViewModels(pagedDestinations.Items),
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

            var destinations = await _destinationService.GetMyDestinationsAsync(userId);

            return View(MapToViewModels(destinations));
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDestinationViewModel viewModel)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

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

            await _destinationService.CreateDestinationAsync(createDto, userId);
            return RedirectToAction(nameof(Manage));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

            var destination = await _destinationService.GetDestinationByIdAsync(id, userId);

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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDestinationViewModel viewModel)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

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

            var result = await _destinationService.UpdateDestinationAsync(updateDto, userId);

            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Manage));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSelected(IEnumerable<int> selectedIds)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

            if (selectedIds == null || !selectedIds.Any())
            {
                return RedirectToAction(nameof(Manage));
            }

            await _destinationService.DeleteRangeAsync(selectedIds, userId);

            return RedirectToAction(nameof(Manage));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var userId = GetCurrentUserId();

            DestinationDetailsDto? destination = await _destinationService.GetDestinationDetailsAsync(id, userId);

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
