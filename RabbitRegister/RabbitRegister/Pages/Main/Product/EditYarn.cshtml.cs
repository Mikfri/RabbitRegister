using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Services.ProductService;

namespace RabbitRegister.Pages.Main.Product
{
    [Authorize(Policy = "BreederOnly")] // kun brugere med "BreederOnly" har tilladelse til at f� adgang til denne side
    public class EditYarnModel : PageModel
    {
        private IProductService _yarnService;

        public EditYarnModel(IProductService productService)
        {
            _yarnService = productService;
        }

        [BindProperty]
        public Model.Yarn Yarn { get; set; } // Property til at binde Yarn-objektet til formularen p� siden

        public IActionResult OnGet(int Id)
        {
            Yarn = _yarnService.GetYarn(Id); // Henter Yarn-objektet med den angivne Id fra ProductService

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _yarnService.UpdateYarnAsync(Yarn, id); // Opdaterer Yarn-objektet med den angivne Id ved hj�lp af ProductService

            // Omdirigerer til en anden side og sender breederRegNo som en rutev�rdi
            return RedirectToPage("GetAllYarn", new { breederRegNo = User.Identity.Name });
        }
    }
}
