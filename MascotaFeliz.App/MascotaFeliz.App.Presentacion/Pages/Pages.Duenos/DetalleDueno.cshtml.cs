using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class DetalleDuenoModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;
        public Dueno dueno { get; set; }

        public DetalleDuenoModel()
        {
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int duenoId)
        {
            dueno = _repoDueno.GetDueno(duenoId);
            if (dueno == null)
            {
                return RedirectToPage("./Duenos");
            }
            else
            {
                return Page();
            }
        }
    }
}
