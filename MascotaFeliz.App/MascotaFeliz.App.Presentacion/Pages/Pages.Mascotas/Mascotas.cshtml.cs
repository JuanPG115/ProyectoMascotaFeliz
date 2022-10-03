using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class MascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        public IEnumerable<Mascota> listaMascotas { get; set; }
        public Mascota mascota { get; set; }


        public MascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }

        [BindProperty(SupportsGet = true)]
        public String BuscarId { get; set; }
        public void OnGet()//Cuando la página cshtml se abre, se llena la lista
        {
            listaMascotas = _repoMascota.GetAllMascotas();
            if (!string.IsNullOrEmpty(BuscarId))
            {
                listaMascotas = _repoMascota.GetMascotasPorFiltro(BuscarId);
            }
        }
        public IActionResult OnPostBorrar(int mascotaId)//Cuando la página se abre, se llena la lista
        {
            _repoMascota.DeleteMascota(mascotaId);
            return RedirectToPage("./Mascotas");
        }
    }
}
