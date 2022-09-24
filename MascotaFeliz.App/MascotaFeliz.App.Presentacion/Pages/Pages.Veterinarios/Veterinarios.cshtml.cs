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
        private readonly IRepositorioVeterinario _repoVeterinario;
        public IEnumerable<Veterinario> listaVeterinarios { get; set; }
        public VeterinariosModel()
        {
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        public void OnGet()//Cuando la página se abre, se llena la lista
        {
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();
        }

        public IActionResult OnPostBorrar(int veterinarioId)//Cuando la página se abre, se llena la lista
        {
            _repoVeterinario.DeleteVeterinario(veterinarioId);
            OnGet();
            return Page();
        }
    }
}
