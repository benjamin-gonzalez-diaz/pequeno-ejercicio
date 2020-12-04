using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Remoting.Messaging;

namespace pequeno_ejercicio_de_serializacion
{
    [Serializable()]
    class Equipo
    {
        string nombreDelEquipo;
        private bool tipodeequipo { get; set; }  //dice si es nacional o de liga (true es nacional)
      
        private List<perro> PersonasDelEquipo = new List<perro>();
        private List<Equipo> TodosLosEquipos = new List<Equipo>();


        public Equipo(List<perro> equipo, string nombre)
        {
            this.PersonasDelEquipo = equipo;
            this.nombreDelEquipo = nombre;
            this.tipodeequipo = false;
        }
        public Equipo()
        {

        }


        public void AgregarEquipoAlSistema(Equipo team)
        {
            TodosLosEquipos.Add(team);
        }

        public void Guardar_Equipos() //serializa todos los equipos
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("listperros.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, TodosLosEquipos.Count);
            for (int i = 0; i < TodosLosEquipos.Count; i++)
            {
                formatter.Serialize(stream, TodosLosEquipos[i]);

            }
            stream.Close();
        }

        public void Cargar_Equipos() // carga los equipos que habian antes en el programa
        {
            string path_song = @System.IO.Directory.GetCurrentDirectory() + "\\listperros.bin";
            if (File.Exists(path_song))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("listperros.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                int linea = (int)formatter.Deserialize(stream);
                for (int i = 0; i < linea; i++)
                {
                    Equipo obj = (Equipo)formatter.Deserialize(stream);
                    TodosLosEquipos.Add(obj);

                }

                stream.Close();
            }
        }

        public List<Equipo> ObtenerListaEquipos()
        {
            return TodosLosEquipos;
        }

        public string get_nombre()
        {
            return nombreDelEquipo;
        }
        public void Informacion_Del_Equipo()
        {
            if (tipodeequipo)
                Console.WriteLine("el equipo es nacional");
            else
                Console.WriteLine("el equipo es de liga");

            Console.WriteLine("Informacion jugadores: ");
            for (int i = 0; i < PersonasDelEquipo.Count(); i++)
            {
                Console.WriteLine(PersonasDelEquipo[i].Informacion());
            }
        }



        // se podrian agregar funciones para agregar mas jugadores y para despedirlos, con el objetivo de que los equipos sean modificables (lo mismo con los medicos y entrenadores)
        //siempre que se compruebe que cada equipo al participar en un partido tiene almenos lo minimo pedido (15 jugadores, un medico y un entrenador)
    }
}
