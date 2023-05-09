using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Services.TrimmingService;

namespace RabbitRegister.Pages.Main.Trimming
{
    public class CreateTrimmingModel : PageModel
    {
        private ITrimmingService _trimmingService;
        public CreateTrimmingModel(ITrimmingService trimmingService)
        {
            _trimmingService = trimmingService;
        }

        [BindProperty]
        public Model.Trimming Trimming { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    _trimmingService.AddTrimming(Trimming);
        //        return RedirectToPage("GetAllTrimming");
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _trimmingService.AddTrimmingAsync(Trimming);
            return RedirectToPage("GetAllTrimming");
        }
    }
}
