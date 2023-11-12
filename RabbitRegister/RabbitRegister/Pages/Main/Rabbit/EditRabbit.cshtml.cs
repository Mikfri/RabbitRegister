using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Model;
using RabbitRegister.Services.BreederService;
using RabbitRegister.Services.RabbitService;
using System.Diagnostics;
using System.Drawing;

namespace RabbitRegister.Pages.Main.Rabbit
{
    [Authorize(Policy = "BreederOnly")]
    public class EditRabbitModel : PageModel
    {
        private IRabbitService _rabbitService;

        public EditRabbitModel(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        [BindProperty]
        public RabbitDTO RabbitDTO { get; set; }

        public IActionResult OnGet(int rabbitRegNo, int originRegNo)
        {
            var existingRabbit = _rabbitService.GetRabbit(rabbitRegNo, originRegNo);

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

        public async Task<IActionResult> OnPostAsync(RabbitDTO rabbitDTO, int rabbitRegNo, int originRegNo)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }                     

            await _rabbitService.UpdateRabbitAsync(rabbitDTO, rabbitRegNo, originRegNo);
            return RedirectToPage("GetAllRabbits");
        }
    }
}
