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
    public class DetalleVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario _repoVeterinario;
        public Veterinario veterinario { get; set; }

        public DetalleVeterinarioModel()
        {
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int veterinarioId)
        {
            veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
            if (veterinario == null)
            {
                return RedirectToPage("./Veterinarios");
            }
            else
            {
                return Page();
            }
        }
    }
}
