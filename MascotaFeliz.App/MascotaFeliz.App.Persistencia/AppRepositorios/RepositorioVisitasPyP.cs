using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisitasPyP : IRepositorioVisitasPyP
    {
        /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//

        public RepositorioVisitasPyP(AppContext appContext)
        {
            _appContext = appContext;
        }

        public VisitasPyP AddVisita(VisitasPyP visita)
        {
            var visitaAdicionado = _appContext.VisitasPyP.Add(visita);
            _appContext.SaveChanges();
            return visitaAdicionado.Entity;
        }

        public void DeleteVisita(int idVisita)
        {
            var visitaEncontrado = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisita);
            if (visitaEncontrado == null)
                return;
            _appContext.VisitasPyP.Remove(visitaEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<VisitasPyP> GetAllVisitas(int idHistoria)
        {
            var visitas = GetAllVisitas_();

            if (visitas != null)  //Si se tienen saludos
            {
                if (idHistoria > 0) // Si el filtro tiene algun valor
                {
                    visitas = visitas.Where(v => v.Historia.Id == idHistoria);
                }
            }
            return visitas;
        }

        public void DeleteVisitas(int idHistoria)
        {
            IEnumerable<VisitasPyP> visitas = _appContext.VisitasPyP.Where(v => v.Historia.Id == idHistoria);
            _appContext.VisitasPyP.RemoveRange(visitas);
            _appContext.SaveChanges();

        }

        public Historia AsignarHistoria(int idVisita, int idHistoria)
        {
            var visitaEncontrado = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisita);
            if (visitaEncontrado != null)
            {
                var historiaEncontrado = _appContext.Historias.FirstOrDefault(h => h.Id == idHistoria);
                if (historiaEncontrado != null)
                {
                    visitaEncontrado.Historia = historiaEncontrado;
                    _appContext.SaveChanges();
                }
                return historiaEncontrado;
            }
            return null;
        }

        public VisitasPyP AsignarVeterinario(int idVisita, int idVeterinario)
        {
            var visitaEncontrado = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisita);
            if (visitaEncontrado != null)
            {
                var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
                if (veterinarioEncontrado != null)
                {
                    visitaEncontrado.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return visitaEncontrado;
            }
            return null;
        }
        public IEnumerable<VisitasPyP> GetVisitasPorFiltro(String filtro)
        {
            var visitas = GetAllVisitas_(); // Obtiene todos los saludos
            if (visitas != null)  //Si se tienen saludos
            {
                if (filtro != null) // Si el filtro tiene algun valor
                {
                    visitas = visitas.Where(v => v.Fecha.ToString().Contains(filtro));
                }
            }
            return visitas;
        }

        public IEnumerable<VisitasPyP> GetAllVisitas_()
        {
            return _appContext.VisitasPyP.Include("Historia").Include("Veterinario"); ;
        }

        public VisitasPyP GetVisitaPorVeterinario(int idVeterinario)
        {
            return _appContext.VisitasPyP.Include("Veterinario").FirstOrDefault(v => v.Veterinario.Id == idVeterinario);
        }

        public VisitasPyP GetVisita(int idVisita)
        {
            return _appContext.VisitasPyP.Include("Veterinario").FirstOrDefault(v => v.Id == idVisita);
        }

        public VisitasPyP UpdateVisita(VisitasPyP visita)
        {
            var visitaEncontrado = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == visita.Id);
            if (visitaEncontrado != null)
            {
                visitaEncontrado.Fecha = visita.Fecha;
                visitaEncontrado.Temperatura = visita.Temperatura;
                visitaEncontrado.Peso = visita.Peso;
                visitaEncontrado.FrecuenciaRespiratoria = visita.FrecuenciaRespiratoria;
                visitaEncontrado.FrecuenciaCardiaca = visita.FrecuenciaCardiaca;
                visitaEncontrado.EstadoDeAnimo = visita.EstadoDeAnimo;
                visitaEncontrado.Recomendaciones = visita.Recomendaciones;
                visitaEncontrado.Veterinario = visita.Veterinario;
                _appContext.SaveChanges();
            }
            return visitaEncontrado;
        }

    }
}