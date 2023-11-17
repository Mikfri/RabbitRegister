using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Services.TrimmService;

namespace RabbitRegister.Pages.Main.Trimm
{
    public class DeleteTrimmModel : PageModel
    {
        private ITrimmService _trimmService;

        
        public DeleteTrimmModel(ITrimmService trimmService)
        {
            _trimmService = trimmService;
        }
       
        [BindProperty]
        public Model.Trimm Trimm { get; set; }

        public IActionResult OnGet(int id, int originRegNo, int rabbitRegNo)
        {
            Trimm = _trimmService.GetTrimm(id, originRegNo, rabbitRegNo);
            return Trimm == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPost(int id, int originRegNo, int rabbitRegNo)
        {
            await _trimmService.DeleteTrimmAsync(id, originRegNo, rabbitRegNo);
            return RedirectToPage("/Main/Rabbit/RabbitProfile", new { originRegNo, rabbitRegNo });
        }
    }
}
