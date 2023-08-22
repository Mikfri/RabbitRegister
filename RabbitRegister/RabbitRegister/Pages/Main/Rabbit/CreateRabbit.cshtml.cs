using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RabbitRegister.Model;
using RabbitRegister.Services.BreederService;
using RabbitRegister.Services.RabbitService;

namespace RabbitRegister.Pages.Main.Rabbit
{
    [Authorize(Policy = "BreederOnly")]
    public class CreateRabbitModel : PageModel
    {
        private IRabbitService _rabbitService;
        private IBreederService _breederService;

        public CreateRabbitModel(IRabbitService rabbitService, IBreederService breederService)
        {
            _rabbitService = rabbitService;
            _breederService = breederService;
        }

        [BindProperty]
        public RabbitDTO RabbitCreateDto { get; set; } = new RabbitDTO();

        public List<SelectListItem> BreederList { get; set; }

        public bool exceptionFound { get; set; }
        public string exceptionText { get; set; }
        


        public async Task OnGet()
        {
            // Hent en liste over breeders og opret drop-down-listen
            var breeders = _breederService.GetBreeders();
            BreederList = breeders.Select(b => new SelectListItem
            {
                Value = b.BreederRegNo.ToString(),
                Text = b.BreederRegNo.ToString()
            }).ToList();
        }


        /// <summary>
        /// Fors�ger at oprette en kanin, hvis ikke ID allerede findes
        /// </summary>
        /// <param name="Rabbit">Kanin objekt som skal tilf�jes</param>
        /// <returns>Fors�ger at tilf�je en kanin og returnere avleren til GetAllRabbits med sit Avler-ID</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            //Denne del kigger p� brugerens INPUT er korrekt udf�rt.NB: IKKE om kanin med samme ID eksistere
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Nedenst�ende sikrer der ikke oprettes en fantom-kanin p� "GetAllRabbits"
            var existingRabbit = _rabbitService.GetRabbit(RabbitCreateDto.RabbitRegNo, RabbitCreateDto.BreederRegNo);
            if (existingRabbit != null)
            {
                this.exceptionFound = true;
                this.exceptionText = "En Kanin med samme ID findes allerede";
                return Page();
            }

            var breeder = await _breederService.GetBreederByNameAsync(User.Identity.Name);
            
            await _rabbitService.AddRabbitAsync(RabbitCreateDto, breeder);
            return RedirectToPage("GetAllRabbits", new { breederRegNo = User.Identity.Name });
        }

    }
}
