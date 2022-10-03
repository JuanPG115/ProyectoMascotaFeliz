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
    public class AddVisitasPyPModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioVisitasPyP _repoVisita;
        private readonly IRepositorioHistoria _repoHistoria;
        [BindProperty]
        public Mascota mascota { get; set; }
        [BindProperty]
        public Historia historia { get; set; }
        public VisitasPyP visita { get; set; }
        public Veterinario veterinario { get; set; }
        public IEnumerable<Veterinario> listaVeterinarios { get; set; }

        public AddVisitasPyPModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
            this._repoVisita = new RepositorioVisitasPyP(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? historiaId)
        {
            //mascota = _repoMascota.GetMascota(mascotaId.Value);
            historia = _repoHistoria.GetHistoria(historiaId.Value);

            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
            visita = new VisitasPyP();
            if (!historiaId.HasValue)
            {
                return RedirectToPage("./Mascotas");
            }
            return Page();
        }

        public IActionResult OnPost(VisitasPyP visita, int veterinarioId, int historiaId)

        {

            if (ModelState.IsValid)
            {
                historia = _repoHistoria.GetHistoria(historiaId);
                _repoVisita.AddVisita(visita);
                _repoVisita.AsignarVeterinario(visita.Id, veterinarioId);
                _repoVisita.AsignarHistoria(visita.Id, historiaId);
                return RedirectToPage("./Mascotas");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
