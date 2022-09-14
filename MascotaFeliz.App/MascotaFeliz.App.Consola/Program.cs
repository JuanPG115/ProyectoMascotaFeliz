using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            //MASCOTAS |-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|

            Console.WriteLine("Mascotas \n");
            var mascota = new Mascota
            {
                Nombre = "Billss",
                Color = "Morgan",
                Especie = "Gato",
                Raza = "Siames",
            };
            AddMascota(mascota);
            //deleteMascota(6);
            /*getMascota(5);
            getAllMascotas();
            var mascotita = new Mascota
            {
                Id = 4,
                Nombre = "Pelusa",
                Color = "blanco",
                Especie = "gato",
                Raza = "siames"
            };
            updateMascota(mascotita);
            deleteMascota(3);
            Console.WriteLine("\n FILTRO \n");
            getMascotasPorFiltro("D");*/

            //DUEÑOS |-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|

            /*Console.WriteLine("Dueños \n");
             var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "Caramelo",
                Apellidos = "Rodriguez",
                Direccion = "Bajo un puente",
                Telefono = "1234567891",
                Correo = "juansinmiedo@gmail.com"
            };
            AddDueno(dueno);
            getDueno(6);
            getAllDuenos();
            
            var dueno = new Dueno
            {
                Id = 1,
                Nombres = "Maradona",
                Apellidos = "Gomez",
                Direccion = "2352353",
                Telefono = "1241244",
                Correo = "maradoa@gmail.com"
            };
            updateDueno(dueno);
            deleteDueno(2);
            Console.WriteLine("\n FILTRO \n");
            getDuenosPorFiltro("J");*/

            //VETERINARIOS |-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|

            /*Console.WriteLine("Veterinarios \n");
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Nombres = "Pedritoooooo",
                Apellidos = "Alimaña",
                Direccion = "Bajo un puente",
                Telefono = "1234567891",
                TarjetaProfesional = "19989381922"
            };
            AddVeterinario(veterinario);
            getVeterinario(11);
            getAllVeterinarios();
            
            var veterinario = new Veterinario
            {
                Id = 5,
                Nombres = "Maradona",
                Apellidos = "Gomez",
                Direccion = "2352353",
                Telefono = "1241244",
                TarjetaProfesional = "1241244"
            };
            updateVeterinario(veterinario);
            deleteVeterinario(1006);
            Console.WriteLine("\n FILTRO \n");
            getVeterinariosPorFiltro("P");*/

        }

        //METODOS VETERINARIO ----------------------------------------------------------------------------------

        private static void AddVeterinario(Veterinario veterinario)
        {
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void getVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
        }

        private static void getAllVeterinarios()
        {
            IEnumerable<Veterinario> veterinarios = _repoVeterinario.GetAllVeterinarios();

            foreach (var veterinario in veterinarios)
            {
                Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
            }
        }

        private static void updateVeterinario(Veterinario veterinario)
        {
            _repoVeterinario.UpdateVeterinario(veterinario);
        }

        private static void deleteVeterinario(int id)
        {
            _repoVeterinario.DeleteVeterinario(id);
        }

        private static void getVeterinariosPorFiltro(string filtro)
        {

            IEnumerable<Veterinario> veterinarios = _repoVeterinario.GetVeterinariosPorFiltro(filtro);

            foreach (var veterinario in veterinarios)
            {
                Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
            }
        }


        //METODOS DUEÑOS ----------------------------------------------------------------------------------

        private static void AddDueno(Dueno dueno)
        {
            _repoDueno.AddDueno(dueno);
        }

        private static void getDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
        }

        private static void getAllDuenos()
        {
            IEnumerable<Dueno> duenos = _repoDueno.GetAllDuenos();

            foreach (var dueno in duenos)
            {
                Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo + "\n");
            }
        }

        private static void updateDueno(Dueno dueno)
        {
            _repoDueno.UpdateDueno(dueno);
        }

        private static void deleteDueno(int id)
        {
            _repoDueno.DeleteDueno(id);
        }

        private static void getDuenosPorFiltro(string filtro)
        {

            IEnumerable<Dueno> duenos = _repoDueno.GetDuenosPorFiltro(filtro);

            foreach (var dueno in duenos)
            {
                Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo + "\n");
            }
        }

        //METODOS MASCOTA ----------------------------------------------------------------------------------

        private static void AddMascota(Mascota mascota)
        {
            _repoMascota.AddMascota(mascota);
        }

        private static void getMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);

            Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
        }

        private static void getAllMascotas()
        {
            IEnumerable<Mascota> mascotas = _repoMascota.GetAllMascotas();

            foreach (var mascota in mascotas)
            {
                Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza + "\n");
            }

        }

        private static void updateMascota(Mascota mascota)
        {

            _repoMascota.UpdateMascota(mascota);

        }

        private static void deleteMascota(int id)
        {
            _repoMascota.DeleteMascota(id);
        }

        private static void getMascotasPorFiltro(string filtro)
        {

            IEnumerable<Mascota> mascotas = _repoMascota.GetMascotasPorFiltro(filtro);

            foreach (var mascota in mascotas)
            {
                Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza + "\n");
            }
        }

    }
}
