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

        public void OnGet(int rabbitRegNo, int originRegNo)
        {
            trimmCreateDTO.RabbitRegNo = rabbitRegNo;
            trimmCreateDTO.OriginRegNo = originRegNo;
        }
        //public async Task<IActionResult> OnPostAsync(int rabbitRegNo, int originRegNo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var rabbit = _rabbitService.GetRabbit(rabbitRegNo, originRegNo);

        //    await _trimmService.AddTrimmAsync(trimmCreateDTO, rabbit);
        //    return RedirectToPage("RabbitProfile");
        //}


        public async Task<IActionResult> OnPostAsync(int rabbitRegNo, int originRegNo)
        {
            if (ModelState.IsValid)
            {
                // Hent Rabbit fra databasen baseret på rabbitRegNo og originRegNo
                var rabbit = _rabbitService.GetRabbit(rabbitRegNo, originRegNo);

                // Opdater RabbitRegNo og OriginRegNo i trimmCreateDTO
                trimmCreateDTO.RabbitRegNo = rabbitRegNo;
                trimmCreateDTO.OriginRegNo = originRegNo;

                // Opret Trimm ved hjælp af TrimmService
                await _trimmService.AddTrimmAsync(trimmCreateDTO, rabbit);

                // Omdiriger til RabbitProfile siden
                return RedirectToPage("/Main/Rabbit/RabbitProfile", new { rabbitRegNo, originRegNo });
            }

            // Hvis modeltilstanden ikke er gyldig, vis formularsiden igen med fejlmeddelelser
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    //Denne del kigger på brugerens INPUT er korrekt udført.NB: IKKE om kanin med samme ID eksistere
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    var existingTrimm = _trimmService.GetTrimm(trimmCreateDTO.RabbitRegNo, RabbitCreateDto.OriginRegNo);

        //    var rabbit = _rabbitService.GetRabbit(rabbitRegNo, originRegNo);

        //    await _trimmService.AddTrimmAsync(trimmCreateDTO, rabbit);
        //    return RedirectToPage("GetAllRabbits");
        //}
    }
}
