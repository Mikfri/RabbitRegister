using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Model;
using RabbitRegister.Services.ProductService;

namespace RabbitRegister.Pages.Main.Product
{
    public class CreateYarnModel : PageModel
    {
		private IProductService _yarnService;

		public CreateYarnModel(IProductService productService)
		{
			_yarnService = productService;
		}

		[BindProperty]
		public Yarn Yarn { get; set; } = new Yarn();

		public IActionResult OnGet()
		{
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(Yarn yarn)
		{
			await _yarnService.AddYarnAsync(yarn);
			return RedirectToPage("GetAllYarn");
		}
	}
}
