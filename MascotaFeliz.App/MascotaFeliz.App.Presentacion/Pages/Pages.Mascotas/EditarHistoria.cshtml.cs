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
    public class EditarHistoriaModel : PageModel
    {
        private readonly IRepositorioHistoria _repoHistoria;
        [BindProperty]
        public Historia historia { get; set; }

        public EditarHistoriaModel()
        {
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? historiaId)
        {
            if (historiaId.HasValue)
            {
                historia = _repoHistoria.GetHistoria(historiaId.Value);
            }
            else
            {
                return RedirectToPage("./Mascotas");
            }
            return Page();
        }

        public IActionResult OnPost(Historia historia)
        {
            if (ModelState.IsValid)
            {
                _repoHistoria.UpdateHistoria(historia);
            }
            else
            {
                return RedirectToPage("./Mascotas");
            }
            return RedirectToPage("./Mascotas");
        }
    }
}
