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
    public class EditarMascotaModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        [BindProperty]
        public Mascota mascota { get; set; }
        public String nombrePage;
        public EditarMascotaModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? mascotaId)
        {
            if (mascotaId.HasValue)
            {
                mascota = _repoMascota.GetMascota(mascotaId.Value);
                nombrePage = "Editar una mascota";
            }
            else
            {
                nombrePage = "Agregar una nueva mascota";
                mascota = new Mascota();
            }
            if (mascota == null)
            {
                return RedirectToPage("./Mascotas");
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
            if (mascota.Id > 0)
            {
                nombrePage = "Editar una mascota";

                _repoMascota.UpdateMascota(mascota);
            }
            else
            {
                _repoMascota.AddMascota(mascota);
                nombrePage = "Agregar una nueva msacota";
            }
            return RedirectToPage("./Mascotas");
        }
    }
}
