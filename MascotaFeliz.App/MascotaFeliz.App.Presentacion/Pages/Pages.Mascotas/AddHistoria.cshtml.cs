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
    public class AddHistoriaModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioHistoria _repoHistoria;
        public Mascota mascota { get; set; }
        public Historia historia { get; set; }

        public AddHistoriaModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? mascotaId, int? historiaId)
        {
                if (mascotaId.HasValue)
                {

                    this.mascota = _repoMascota.GetMascota(mascotaId.Value);
                    Console.WriteLine(mascota.Id);
                    historia = new Historia();
                    //nombrePage = "Editar una mascota";
                }
                /*else
                {
                    nombrePage = "Agregar una nueva mascota";
                    mascota = new Mascota();
                }*/
                if (mascota == null)
                {
                    return RedirectToPage("./Mascotas");
                }
                else
                {
                    return Page();
                }

        }

        public IActionResult OnPost(Mascota mascota, Historia historia)
        {
            Console.WriteLine("xd" + mascota.Id + " " + historia.FechaInicial);
            if (ModelState.IsValid)
            {


                _repoMascota.AsignarHistoria(mascota.Id, historia);
                Console.WriteLine("xd" + mascota.Id + " " + historia.FechaInicial);


                return RedirectToPage("./Mascotas");
            }
            else
            {
                return Page();
            }
        }
    }
}
