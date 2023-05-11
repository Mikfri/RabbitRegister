using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Services.RabbitService;

namespace RabbitRegister.Pages.Main.Rabbit
{
	public class CreateRabbitModel : PageModel
    {
        private IRabbitService _rabbitService;


        public CreateRabbitModel(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        [BindProperty]
        public Model.Rabbit Rabbit { get; set; } = new Model.Rabbit();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Model.Rabbit Rabbit)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _rabbitService.AddRabbitAsync(Rabbit);
            return RedirectToPage("GetAllRabbits");
        }
    }
}
