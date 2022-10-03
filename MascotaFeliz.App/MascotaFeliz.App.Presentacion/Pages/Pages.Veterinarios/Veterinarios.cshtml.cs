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
    public class VeterinariosModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public String BuscarId { get; set; }
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioVisitasPyP _repoVisitas;
        private readonly IRepositorioMascota _repoMascota;
        public IEnumerable<Veterinario> listaVeterinarios { get; set; }
        public VeterinariosModel()
        {
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoVisitas = new RepositorioVisitasPyP(new Persistencia.AppContext());
        }
        public void OnGet()//Cuando la página se abre, se llena la lista
        {
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
            if (!string.IsNullOrEmpty(BuscarId))
            {
                listaVeterinarios = _repoVeterinario.GetVeterinariosPorFiltro(BuscarId);
            }
        }

        public IActionResult OnPostBorrar(int veterinarioId)//Cuando la página se abre, se llena la lista
        {
            var mascota = _repoMascota.GetMascotaPorVeterinario(veterinarioId);
            var visita = _repoVisitas.GetVisitaPorVeterinario(veterinarioId);

            if (mascota == null && visita == null)
            {
                _repoVeterinario.DeleteVeterinario(veterinarioId);
                OnGet();
            }
            else
            {
                OnGet();
            }
            return Page();
        }
    }
}
