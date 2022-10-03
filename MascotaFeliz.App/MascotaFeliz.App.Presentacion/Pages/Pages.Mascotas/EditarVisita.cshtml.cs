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


    public class EditarVisitaModel : PageModel
    {
        private readonly IRepositorioVisitasPyP _repoVisitas;
        private readonly IRepositorioVeterinario _repoVeterinario;
        public IEnumerable<Veterinario> listaVeterinarios;
        public Veterinario veterinario { get; set; }
        [BindProperty]
        public VisitasPyP visita{get; set;}

        public EditarVisitaModel()
        {
            this._repoVisitas = new RepositorioVisitasPyP(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? idVisita)
        {
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
            if (idVisita.HasValue)
            {
                visita = _repoVisitas.GetVisita(idVisita.Value);
            }
            else
            {
                return RedirectToPage("./mascotas");
            }
            return Page();
        }

        public IActionResult OnPost(VisitasPyP visita, int veterinarioId)
        {
            if (ModelState.IsValid)
            {
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                Console.WriteLine(veterinario.Nombres);

                visita.Veterinario = veterinario;
                _repoVisitas.UpdateVisita(visita);

            }
            return RedirectToPage("./Mascotas");
        }
    }
}
