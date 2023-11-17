using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Model;
using RabbitRegister.Services.TrimmService;

namespace RabbitRegister.Pages.Main.Trimm
{
    public class EditTrimmModel : PageModel
    {
        private ITrimmService _trimmService;

        public EditTrimmModel(ITrimmService trimmService)
        {
            _trimmService = trimmService;
        }

        [BindProperty]
        public TrimmDTO TrimmDTO { get; set; }


        public IActionResult OnGet(int id, int originRegNo, int rabbitRegNo)
        {
            var existingTrimm = _trimmService.GetTrimm(id, originRegNo, rabbitRegNo);

            if (existingTrimm == null)
            {
                return NotFound();
            }

            TrimmDTO = new TrimmDTO
            {
                Id = existingTrimm.Id,
                OriginRegNo = existingTrimm.OriginRegNo,
                RabbitRegNo = existingTrimm.RabbitRegNo,
                Date = existingTrimm.Date,
                TimeUsed = existingTrimm.TimeUsed,
                HairLengthByDayNinety = existingTrimm.HairLengthByDayNinety,
                WoolDensity = existingTrimm.WoolDensity,
                FirstSortmentWeight = existingTrimm.FirstSortmentWeight,
                SecondSortmentWeight = existingTrimm.SecondSortmentWeight,
                DisposableWoolWeight = existingTrimm.DisposableWoolWeight,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _trimmService.UpdateTrimmAsync(TrimmDTO, TrimmDTO.Id, TrimmDTO.OriginRegNo, TrimmDTO.RabbitRegNo);
            return RedirectToPage("/Main/Rabbit/RabbitProfile", new { TrimmDTO.OriginRegNo, TrimmDTO.RabbitRegNo });
        }
    }
}
