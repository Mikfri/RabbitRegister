using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RabbitRegister.Model;
using RabbitRegister.Services.BreederService;
using RabbitRegister.Services.RabbitService;
using RabbitRegister.Utilities;

namespace RabbitRegister.Pages.Main.Rabbit
{
    [Authorize(Policy = "BreederOnly")]
    public class CreateRabbitModel : PageModel
    {
        private readonly IRabbitService _rabbitService;
        private readonly IBreederService _breederService;
        private readonly ImageHelper _imageHelper;


        public CreateRabbitModel(IRabbitService rabbitService, IBreederService breederService, ImageHelper imagehelper)
        {
            _rabbitService = rabbitService;
            _breederService = breederService;
            _imageHelper = imagehelper;
        }

        [BindProperty]
        public RabbitDTO RabbitCreateDto { get; set; } = new RabbitDTO();

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        //public List<SelectListItem> BreederList { get; set; }

        public bool exceptionFound { get; set; }
        public string exceptionText { get; set; }
        


        //public async Task OnGet()
        //{
        //    // Hent en liste over breeders og opret drop-down-listen
        //    var breeders = _breederService.GetBreeders();
        //    BreederList = breeders.Select(b => new SelectListItem
        //    {
        //        Value = b.BreederRegNo.ToString(),
        //        Text = b.BreederRegNo.ToString()
        //    }).ToList();
        //}


        /// <summary>
        /// Forsøger at oprette en kanin, hvis en ikke allerede kanin med samme ID.
        /// Der tjekkes også om brugeren har snydt med race og farve dropdown muligheds betingelserne
        /// </summary>
        /// <returns>Forsøger at tilføje en kanin og returnere avleren til GetAllRabbits</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            //Denne del kigger på brugerens INPUT er korrekt udført.NB: IKKE om kanin med samme ID eksistere
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Nedenstående sikrer der ikke oprettes en fantom-kanin på "GetAllRabbits"
            var existingRabbit = _rabbitService.GetRabbit(RabbitCreateDto.RabbitRegNo, RabbitCreateDto.OriginRegNo);
            if (existingRabbit != null)
            {
                this.exceptionFound = true;
                this.exceptionText = "En kanin med samme ID, findes allerede";
                return Page();
            }

            if (!RabbitCreateDto.Validate())
            {
                exceptionFound = true;
                exceptionText = "Kaninrace og farve, er ikke en gyldig kombination";
                return Page();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                RabbitCreateDto.ImagePath = await _imageHelper.SaveImageAsync(ImageFile);
            }

            int breederRegNoAsInteger = int.Parse(User.Identity.Name);
            var breeder = _breederService.GetBreedByBreederRegNo(breederRegNoAsInteger);

            await _rabbitService.AddRabbitAsync(RabbitCreateDto, breeder);
            return RedirectToPage("GetAllRabbits");
        }

    }
}
