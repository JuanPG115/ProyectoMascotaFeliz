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
    public class DuenosModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;
        public IEnumerable<Dueno> listaDuenos { get; set; }
        public DuenosModel()
        {
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        }
        public void OnGet()//Cuando la página se abre, se llena la lista
        {
            listaDuenos = _repoDueno.GetAllDuenos();
        }
    }
}
