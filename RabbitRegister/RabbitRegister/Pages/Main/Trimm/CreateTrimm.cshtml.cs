using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Model;
using RabbitRegister.Services.RabbitService;
using RabbitRegister.Services.TrimmService;

namespace RabbitRegister.Pages.Main.Trimm
{
    public class CreateTrimmModel : PageModel
    {
        private readonly ITrimmService _trimmService;
        private IRabbitService _rabbitService;

        //private readonly ITrimmService _trimmService;

        public CreateTrimmModel(ITrimmService trimmService, IRabbitService rabbitService)
        {
            _trimmService = trimmService;
            _rabbitService = rabbitService;

        }

        [BindProperty]
        public TrimmDTO trimmCreateDTO { get; set; } = new TrimmDTO();
        //[BindProperty]
        //public Model.Rabbit Rabbit { get; set; }

        public void OnGet(int originRegNo, int rabbitRegNo)
        {
            trimmCreateDTO.OriginRegNo = originRegNo;
            trimmCreateDTO.RabbitRegNo = rabbitRegNo;
        }      


        public async Task<IActionResult> OnPostAsync(int originRegNo, int rabbitRegNo)
        {
            if (ModelState.IsValid)
            {
                // Hent Rabbit fra databasen baseret på rabbitRegNo og originRegNo
                var rabbit = _rabbitService.GetRabbit(originRegNo, rabbitRegNo);

                // Opdater RabbitRegNo og OriginRegNo i trimmCreateDTO
                trimmCreateDTO.OriginRegNo = originRegNo;
                trimmCreateDTO.RabbitRegNo = rabbitRegNo;

                // Opret Trimm ved hjælp af TrimmService
                await _trimmService.AddTrimmAsync(trimmCreateDTO, rabbit);

                // Omdiriger til RabbitProfile siden
                return RedirectToPage("/Main/Rabbit/RabbitProfile", new { originRegNo, rabbitRegNo });
            }

            // Hvis modeltilstanden ikke er gyldig, vis formularsiden igen med fejlmeddelelser
            return Page();
        }        
    }
}
