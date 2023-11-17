using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Services.RabbitService;

namespace RabbitRegister.Pages.Main.Rabbit
{
    [Authorize(Policy = "BreederOnly")]
    public class DeleteRabbitModel : PageModel
    {
        private IRabbitService _rabbitService;

        public DeleteRabbitModel(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        [BindProperty]
        public Model.Rabbit Rabbit { get; set; }


        public IActionResult OnGet(int originRegNo, int rabbitRegNo)
        {
            Rabbit = _rabbitService.GetRabbit(originRegNo, rabbitRegNo);
            if (Rabbit == null)
            {
                return RedirectToPage("/NotFound");
            }

            if (User.Identity.Name != Rabbit.Owner.ToString())
            {
                return Forbid();
            }

            return Page();
        }

        /// <summary>
        /// Sletter en kanin med den angivne Id - bemærk der mangler exceptions for hvilken Avler som kan slette den
        /// </summary>
        /// <param name="rabbitRegNo">Første nøgle-del for kaninens composite key</param>
        /// <param name="originRegNo">Anden nøgle-del for kaninens composite key</param>
        /// <returns>Omdirigerer til GetAllRabbits med avlerens, Avler-ID</returns>
        public async Task<IActionResult> OnPostAsync(int originRegNo, int rabbitRegNo)
        {
            var existingRabbit = _rabbitService.GetRabbit(originRegNo, rabbitRegNo);

            if (existingRabbit == null)
            {
                return RedirectToPage("/NotFound");
            }

            if (User.Identity.Name != existingRabbit.Owner.ToString())
            {
                return Forbid();
            }

            Model.Rabbit deletedRabbit = await _rabbitService.DeleteRabbitAsync(originRegNo, rabbitRegNo);

            return RedirectToPage("GetAllRabbits");
        }
    }
}
