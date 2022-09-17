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

    public class DetalleMascotaModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        public Mascota mascota { get; set; }

        public DetalleMascotaModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int mascotaId)
        {
            mascota = _repoMascota.GetMascota(mascotaId);
            if (mascota == null)
            {
                return RedirectToPage("./Mascotas");
            }
            else
            {
                return Page();
            }
        }
    }
}
