using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using RabbitRegister.Model;
using RabbitRegister.Services.RabbitService;
using System.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using RabbitRegister.Services.TrimmService;

namespace RabbitRegister.Pages.Main.Rabbit
{
    public class RabbitProfileModel : PageModel
    {
        private IRabbitService _rabbitService;
        private ITrimmService _trimmService;

        public RabbitProfileModel(IRabbitService rabbitService, ITrimmService trimmservice)
        {
            _rabbitService = rabbitService;
            _trimmService = trimmservice;
        }

        [BindProperty]
        public Model.Rabbit Rabbit { get; set; }

        [BindProperty]
        public Model.Trimm Trimm { get; set; }

        public List<Model.Trimm> TrimmList { get; set; } = new List<Model.Trimm>();

        public IActionResult OnGet(int rabbitRegNo, int originRegNo)
        {
            Rabbit = _rabbitService.GetRabbit(rabbitRegNo, originRegNo);

            if (Rabbit == null)
            {
                return RedirectToPage("/NotFound");
            }

            if (User.Identity.Name == Rabbit.Owner.ToString() || User.Identity.Name == Rabbit.OriginRegNo.ToString() || Rabbit.IsForSale == IsForSale.Ja)
            {
                TrimmList = _trimmService.GetAllTrimmsByRabbit(rabbitRegNo, originRegNo);
                return Page();
            }

            return RedirectToPage("/Account/AccessDenied");         
        }

        public IActionResult OnGetGetAllTrimmsByRabbit(int rabbitRegNo, int originRegNo)
        {
            TrimmList = _trimmService.GetAllTrimmsByRabbit(rabbitRegNo, originRegNo);

            if (TrimmList == null || TrimmList.Count == 0)
            {
                return RedirectToPage("/NotFound");
            }

            if (User.Identity.Name == Rabbit.Owner.ToString() || User.Identity.Name == Rabbit.OriginRegNo.ToString() || Rabbit.IsForSale == IsForSale.Ja)
            {
                return Page();
            }

            return RedirectToPage("/Account/AccessDenied");
        }

    }
}
