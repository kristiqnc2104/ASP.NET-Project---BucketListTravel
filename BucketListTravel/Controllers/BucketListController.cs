using BucketListTravel.Services.DTOs;
using BucketListTravel.Services.Interfaces;
using BucketListTravel.ViewModels.BucketListEntries;
using BucketListTravel.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using static BucketListTravel.Common.UIConstants;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BucketListTravel.Controllers
{
    [Authorize]
    public class BucketListController : Controller
    {
        private readonly IBucketListService _bucketListService;

        public BucketListController(IBucketListService bucketListService)
        {
            _bucketListService = bucketListService;
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

            IEnumerable<BucketListEntryDto> bucketListEntriesDtos = await _bucketListService.GetAllAsync(userId);

            IEnumerable<AllBucketListEntriesIndexViewModel> allBucketListEntriesIndexViewModels = bucketListEntriesDtos
                .Select(entry => new AllBucketListEntriesIndexViewModel
                {
                    Id = entry.Id,
                    DestinationId = entry.DestinationId,
                    DestinationName = entry.DestinationName,
                    Country = entry.Country,
                    ImageUrl = entry.ImageUrl ?? DefaultImageUrl,
                    CategoryName = entry.CategoryName,
                    Status = entry.Status.ToString(),
                    PlannedDate = entry.PlannedDate?.ToString("yyyy-MM-dd"),
                    Notes = entry.Notes,
                    DateAdded = entry.DateAdded.ToString("yyyy-MM-dd")
                });


            return View(allBucketListEntriesIndexViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

            BucketListEntryForEditDto? entry = await _bucketListService.GetForEditAsync(id, userId);

            if (entry == null)
            {
                return NotFound();
            }

            EditBucketListEntryViewModel viewModel = new EditBucketListEntryViewModel
            {
                Id = entry.Id,
                DestinationName = entry.DestinationName,
                Status = entry.Status,
                PlannedDate = entry.PlannedDate,
                Notes = entry.Notes
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBucketListEntryViewModel viewModel)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }


            UpdateBucketListEntryDto dto = new UpdateBucketListEntryDto
            {
                Id = viewModel.Id,
                Status = viewModel.Status,
                PlannedDate = viewModel.PlannedDate,
                Notes = viewModel.Notes
            };

            bool updated = await _bucketListService.UpdateAsync(dto, userId);
            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int destinationId)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

            if (destinationId <= 0)
            {
                return BadRequest();
            }

            bool isAdded = await _bucketListService.AddAsync(destinationId, userId);

            if (!isAdded)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int destinationId)
        {
            var userId = GetCurrentUserId();

            if (userId == null)
            {
                return Challenge();
            }

            if (destinationId <= 0)
            {
                return BadRequest();
            }

            bool isRemoved = await _bucketListService.RemoveAsync(destinationId, userId);

            if (!isRemoved)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
