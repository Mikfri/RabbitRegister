using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Pages.Main.LogIn;
using RabbitRegister.Model;
using RabbitRegister.Services.RabbitService;
using RabbitRegister.Services.BreederService;
using Microsoft.AspNetCore.Authorization;

namespace RabbitRegister.Pages.Main.Rabbit
{
    [Authorize(Policy = "BreederOnly")]
    public class GetAllRabbitsModel : PageModel
    {
        private IRabbitService _rabbitService;

        public GetAllRabbitsModel(IRabbitService rabbitService)
        {
            _rabbitService = rabbitService;
        }

        [BindProperty(SupportsGet = true)]
        public int BreederRegNo { get; set; }

        public List<Model.Rabbit>? Rabbits { get; private set; }

        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public int MinRating { get; set; }

        [BindProperty]
        public int MaxRating { get; set; }

        /// <summary>
        /// Henter kaniner baseret p� den angivne handling og brugerens avler-ID
        /// </summary>
        /// <param name="action">"Handling" Bestemmer hvordan kaninerne filtreres ved brug af LINQ og Lamda</param>
        /// <returns>GetOwnedAliveRabbits som standard, eller en af de andre metoder via Filter knappen</returns>
        public IActionResult OnGet(string action)
        {
            int breederRegNo = int.Parse(User.Identity.Name);

            if (action == "OwnedDeadRabbits")
            {
                Rabbits = _rabbitService.GetOwnedDeadRabbits(breederRegNo);
            }          
            else if (action == "AllRabbitsWithConnectionsToMe")
            {
                Rabbits = _rabbitService.GetAllRabbitsWithConnectionsToMe(breederRegNo);
            }
            else if (action == "NotOwnedRabbitsWithMyBreederRegNo")
            {
                Rabbits = _rabbitService.GetNotOwnedRabbitsWithMyBreederRegNo(breederRegNo);
            }           
            else
            {
                Rabbits = _rabbitService.GetOwnedAliveRabbits(breederRegNo);
            }

            return Page();
        }

        /// <summary>
        /// En s�gefunktion som s�ger efter kaninens navn
        /// </summary>
        /// <returns>Returnere kaniner med samme bogstavs sekvens som brugeren indtaster</returns>
        //public IActionResult OnPostSearchByName()
        //{
        //    Rabbits = _rabbitService.SearchByName(SearchString).ToList();
        //    return Page();
        //}

        public IActionResult OnPostSearchByName()
        {
            var breederRegNo = int.Parse(User.Identity.Name);
            Rabbits = _rabbitService.SearchByName(SearchString, breederRegNo).ToList();
            return Page();
        }

        public IActionResult OnPostRatingFilter(int? maxRating, int? minRating)
        {
            int breederRegNo = int.Parse(User.Identity.Name);

            Rabbits = _rabbitService.RatingFilter(breederRegNo, maxRating, minRating).ToList();

            return Page();
        }

    }
}
