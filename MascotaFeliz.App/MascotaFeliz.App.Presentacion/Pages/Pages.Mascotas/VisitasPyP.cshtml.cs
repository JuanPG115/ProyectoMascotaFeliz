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
    public class VisitasPyPModel : PageModel
    {

        private readonly IRepositorioVisitasPyP _repoVisitas;
        private readonly IRepositorioMascota _repoMascota;
        public IEnumerable<VisitasPyP> listaVisitas { get; set; }
        public readonly IRepositorioHistoria _repoHistoria;
        public string BuscarId { get; set; }
        public Historia historia { get; set; }

        public String nombre = "juan";

        public VisitasPyPModel()
        {
            this._repoVisitas = new RepositorioVisitasPyP(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? historiaId)
        {
            if (historiaId.HasValue)
            {
                historia = _repoHistoria.GetHistoria(historiaId.Value);
                listaVisitas = _repoVisitas.GetAllVisitas(historiaId.Value);
            }
            else
            {
                return RedirectToPage("./Mascotas");
            }
            return Page();
        }

        public IActionResult OnPostBorrar(int historiaId)//Cuando la página se abre, se llena la lista
        {
            _repoMascota.DeleteHistoria(historiaId);
            _repoVisitas.DeleteVisitas(historiaId);
            _repoHistoria.DeleteHistoria(historiaId);
            return RedirectToPage("./Mascotas");
        }

        public IActionResult OnPostBorrarVisita(int visitaId)
        {
            Console.WriteLine(visitaId);
            _repoVisitas.DeleteVisita(visitaId);
            return RedirectToPage("./Mascotas");
        }
    }
}
