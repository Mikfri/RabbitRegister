using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RabbitRegister.Services.BreederService;
using RabbitRegister.Services.ProductService;
using Microsoft.AspNetCore.Authorization;

namespace RabbitRegister.Pages.Main.Breeder
{
    [Authorize(Roles = "Admin")] // Kun brugere med rollen "Admin" til at f� adgang til denne side
    public class GetAllBreedersModel : PageModel
    {
        private IBreederService _breederService; // Reference til IBreederService, der bruges til at h�ndtere avlerrelaterede metoder osv

        public GetAllBreedersModel(IBreederService breederService)
        {
            _breederService = breederService; // Gemmer en reference til IBreederService, der er injiceret
        }

        public List<Model.Breeder>? Breeders { get; set; } // Egenskab til at gemme en liste over avlere

        public void OnGet()
        {
            Breeders = _breederService.GetBreeders(); // Henter alle avlere fra databasen ved at kalde GetBreeders-metoden p� IBreederService og gemmer dem i Breeders-egenskaben
        }
    }
}
