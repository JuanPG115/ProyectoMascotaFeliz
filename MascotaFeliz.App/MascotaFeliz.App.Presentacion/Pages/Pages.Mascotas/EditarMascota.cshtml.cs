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
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioDueno _repoDueno;
        public Veterinario veterinario { get; set; }
        public Dueno dueno { get; set; }
        [BindProperty]
        public Mascota mascota { get; set; }
        public IEnumerable<Veterinario> listaVeterinarios { get; set; }
        public IEnumerable<Dueno> listaDuenos { get; set; }
        public String nombrePage;
        public EditarMascotaModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? mascotaId)
        {
            listaDuenos = _repoDueno.GetAllDuenos();
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
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
        public IActionResult OnPost(Mascota mascota, int duenoId, int veterinarioId)
        {

            if (ModelState.IsValid)
            {
                dueno = _repoDueno.GetDueno(duenoId);
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                if (mascota.Id > 0)
                {
                    nombrePage = "Editar una mascota";
                    mascota.Veterinario = veterinario;
                    mascota.Dueno = dueno;
                    _repoMascota.UpdateMascota(mascota);
                }
                else
                {
                    nombrePage = "Agregar una nueva mascota";
                    _repoMascota.AddMascota(mascota);
                    _repoMascota.AsignarDueno(mascota.Id, dueno.Id);
                    _repoMascota.AsignarVeterinario(mascota.Id, veterinario.Id);

                }
                return RedirectToPage("./Mascotas");
            }
            else{
                return Page();
            }
        }
    }
}
