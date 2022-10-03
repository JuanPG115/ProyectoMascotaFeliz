using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascotas();
        Mascota AddMascota(Mascota veterinario);
        Mascota UpdateMascota(Mascota mascota);
        Mascota DeleteHistoria(int IdHistoria);
        void DeleteMascota(int idMascota);
        Veterinario AsignarVeterinario(int idMascota, int idVeterinario);
        Dueno AsignarDueno(int idMascota, int idDueno);
        Historia AsignarHistoria(int idMascota, Historia historia);
        Mascota GetMascota(int idMascota);
        IEnumerable<Mascota> GetMascotasPorFiltro(string filtro);
        Mascota GetMascotaPorVeterinario(int idVeterinario);
        Mascota GetMascotaPorDueno(int idDueno);
    }
}