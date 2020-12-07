
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace pequeno_ejercicio_de_serializacion
{
    class ejecucion
    {
        public ejecucion()
        {
            //hola nico, para el miercoles me podrias ayudar, con el examen?
            List<perro> listaperros = new List<perro>();
            Console.WriteLine("crear un perro [1]:  ");
            Console.WriteLine("Cargar un perro [2]:  ");
            Console.WriteLine("crear 10 pérros [3]:  ");
            Console.WriteLine("cargar lista de perros [4]:  ");
            int Opcion = Convert.ToInt32(Console.ReadLine());
            Equipo saveEquipos = new Equipo();
            saveEquipos.Cargar_Equipos();
            if (Opcion == 1)
            {

                Console.WriteLine("ingrese el nombre del perro");
                string nommbre = Console.ReadLine();
                Console.WriteLine("ingrese la edad del perro");
                int edead = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("ingrese el peso del perro");
                double peseo = Convert.ToDouble(Console.ReadLine());
                perro mascota = new perro(nommbre, true, edead, peseo);
                mascota.MostrarInfo();
                Console.WriteLine("serializando");
                BinaryFormatter formatter = new BinaryFormatter();
                Stream miStream = new FileStream("perro.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(miStream, mascota);
                miStream.Close();
                Console.ReadKey();
                Console.Clear();

            }
            else if (Opcion == 2)
            {
                Console.WriteLine("deserealizando");
                BinaryFormatter formateador = new BinaryFormatter();
                Stream miStream = new FileStream("perro.bin", FileMode.Open, FileAccess.Read, FileShare.None);
                perro miperro = (perro)formateador.Deserialize(miStream);
                miStream.Close();
                Console.WriteLine("deserealizacion del perro");
                miperro.MostrarInfo();
                Console.ReadKey();

            }
            else if (Opcion == 3)
            {
                Console.WriteLine("Nombre de la lista: ");
                string nombrelista = Console.ReadLine();
                for (int k = 0; k < 3; k++)
                {
                    Console.WriteLine("ingrese el nombre del perro");
                    string nommbre = Console.ReadLine();
                    Console.WriteLine("ingrese la edad del perro");
                    int edead = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("ingrese el peso del perro");
                    double peseo = Convert.ToDouble(Console.ReadLine());
                    perro mascota = new perro(nommbre, true, edead, peseo);
                    listaperros.Add(mascota);
                    Console.Clear();

                }

                Equipo equipocreado = new Equipo(listaperros, nombrelista);
                Console.WriteLine("Equipo creado con exito");
                saveEquipos.AgregarEquipoAlSistema(equipocreado);

                saveEquipos.Guardar_Equipos();
                Thread.Sleep(2000);
                Console.Clear();

            }
            else if (Opcion == 4)
            {
                if (saveEquipos.ObtenerLista().Count != 0)
                {
                    Console.WriteLine("de que lista quiere ver la informacion");
                    for (int i = 0; i < saveEquipos.ObtenerLista().Count; i++)
                    {
                        Console.WriteLine(i + 1 + ") " + saveEquipos.ObtenerLista()[i].get_nombre());
                    }
                    string Resp = Console.ReadLine();
                    int equipoelegido;
                    Int32.TryParse(Resp, out equipoelegido);
                    while (equipoelegido == 0 && equipoelegido < saveEquipos.ObtenerLista().Count)
                    {
                        Console.WriteLine("ingrese un numero valido");
                        Resp = Console.ReadLine();
                        Int32.TryParse(Resp, out equipoelegido);
                    }
                    saveEquipos.ObtenerLista()[equipoelegido - 1].Informacion_Del_Equipo();

                    Thread.Sleep(5000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("no hay una lista en el sistema");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
    }
}
