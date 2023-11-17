using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Model;
using RabbitRegister.Services.BreederService;
using RabbitRegister.Services.RabbitService;
using RabbitRegister.Utilities;
using System.Diagnostics;
using System.Drawing;

namespace RabbitRegister.Pages.Main.Rabbit
{
    [Authorize(Policy = "BreederOnly")]
    public class EditRabbitModel : PageModel
    {
        private readonly IRabbitService _rabbitService;
        private readonly ImageHelper _imageHelper;


        public EditRabbitModel(IRabbitService rabbitService, ImageHelper imageHelper)
        {
            _rabbitService = rabbitService;
            _imageHelper = imageHelper;
        }

        [BindProperty]
        public RabbitDTO RabbitDTO { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public IActionResult OnGet(int originRegNo, int rabbitRegNo)
        {
            var existingRabbit = _rabbitService.GetRabbit(originRegNo, rabbitRegNo);

            if (existingRabbit == null)
            {
                return NotFound();
            }

            if (User.Identity.Name != existingRabbit.Owner.ToString())
            {
                return Forbid();
            }

            // Kopier data fra eksisterende Rabbit til RabbitDTO
            RabbitDTO = new RabbitDTO
            {
                Owner = existingRabbit.Owner,
                RabbitRegNo = existingRabbit.RabbitRegNo,
                OriginRegNo = existingRabbit.OriginRegNo,
                Name = existingRabbit.Name,
                Race = existingRabbit.Race,
                Color = existingRabbit.Color,
                Sex = existingRabbit.Sex,
                DateOfBirth = existingRabbit.DateOfBirth,
                Weight = existingRabbit.Weight,
                Rating = existingRabbit.Rating,
                DeadOrAlive = existingRabbit.DeadOrAlive,
                IsForSale = existingRabbit.IsForSale,
                SuitableForBreeding = existingRabbit.SuitableForBreeding,
                CauseOfDeath = existingRabbit.CauseOfDeath,
                Comments = existingRabbit.Comments,
                ImageString = existingRabbit.ImageString,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(RabbitDTO rabbitDTO, int originRegNo, int rabbitRegNo)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Hvis der er et nyt billede, upload og opdater stien i RabbitDTO
            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Gem billedet og opdater stien i RabbitDTO
                string imagePath = await _imageHelper.SaveImageAsync(ImageFile);
                rabbitDTO.ImagePath = imagePath;

                var existingRabbit = _rabbitService.GetRabbit(originRegNo, rabbitRegNo);
                if (!string.IsNullOrEmpty(existingRabbit.ImagePath))
                {
                    ImageHelper.TestDeleteImage(existingRabbit.ImagePath);
                }
            }

            await _rabbitService.UpdateRabbitAsync(rabbitDTO, originRegNo, rabbitRegNo);
            return RedirectToPage("GetAllRabbits");
        }
    }
}
