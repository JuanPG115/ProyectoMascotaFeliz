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
    public class EditarVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario _repoVeterinario;
        [BindProperty]
        public Veterinario veterinario { get; set; }
        public String nombrePage;
        public EditarVeterinarioModel()
        {
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? veterinarioId)
        {
            if (veterinarioId.HasValue)
            {
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId.Value);
                nombrePage = "Editar un veterinario";
            }
            else
            {
                nombrePage = "Agregar una nuevo veterinario";
                veterinario = new Veterinario();
            }
            if (veterinario == null)
            {
                return RedirectToPage("./Veterinarios");
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
            if (veterinario.Id > 0)
            {
                nombrePage = "Editar un veterinario";

                _repoVeterinario.UpdateVeterinario(veterinario);
            }
            else
            {
                _repoVeterinario.AddVeterinario(veterinario);
                nombrePage = "Agregar una nuevo veterinario";
            }
            return RedirectToPage("./Veterinarios");
        }
    }
}

