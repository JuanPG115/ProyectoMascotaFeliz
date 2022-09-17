using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Persistencia;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class EditarDuenoModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;
        [BindProperty]
        public Dueno dueno { get; set; }
        public String nombrePage;
        public EditarDuenoModel()
        {
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? duenoId)
        {
            if (duenoId.HasValue)
            {
                dueno = _repoDueno.GetDueno(duenoId.Value);
                nombrePage = "Editar dueño";
            }
            else
            {
                nombrePage = "Agregar una nuevo dueño";
                dueno = new Dueno();
            }
            if (dueno == null)
            {
                return RedirectToPage("./Duenos");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (dueno.Id > 0)
            {
                nombrePage = "Editar dueño";

                _repoDueno.UpdateDueno(dueno);
            }
            else
            {
                _repoDueno.AddDueno(dueno);
                nombrePage = "Agregar un nuevo dueno";
            }
            return RedirectToPage("./Duenos");
        }
    }
}
