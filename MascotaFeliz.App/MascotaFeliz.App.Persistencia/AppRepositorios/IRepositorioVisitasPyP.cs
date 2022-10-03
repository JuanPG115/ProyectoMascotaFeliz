using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisitasPyP
    {
        IEnumerable<VisitasPyP> GetAllVisitas(int idVisita);
        VisitasPyP AddVisita(VisitasPyP visita);
        Historia AsignarHistoria(int idVisita, int idHistoria);
        VisitasPyP AsignarVeterinario(int idVisita, int idVeterinario);
        VisitasPyP GetVisitaPorVeterinario(int idVeterinario);
        void DeleteVisitas(int idHistoria);
        IEnumerable<VisitasPyP> GetVisitasPorFiltro(string filtro);
        VisitasPyP GetVisita(int idVisita);
        VisitasPyP UpdateVisita(VisitasPyP visita);
        void DeleteVisita(int idVisita);
        /*VisitasPyP UpdateVisita(VisitasPyP visita);
        
        VisitasPyP GetVisitas(int idVisita);
        */
    }
}