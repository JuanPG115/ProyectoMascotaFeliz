using System;
namespace MascotaFeliz.App.Dominio
{
    public class VisitasPyP
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Temperatura { get; set; }
        public float Peso { get; set; }
        public float FrecuenciaRespiratoria { get; set; }
        public float FrecuenciaCardiaca { get; set; }
        public String EstadoDeAnimo { get; set; }
        public int IdVeterinario { get; set; }
        public String Recomendaciones { get; set; }
    }
}