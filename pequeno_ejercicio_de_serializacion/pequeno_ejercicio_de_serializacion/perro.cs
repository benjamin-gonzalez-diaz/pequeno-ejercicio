using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace pequeno_ejercicio_de_serializacion
{
    [Serializable]
    class perro
    {
        private string Nombre;
        private bool Algo;
        private int Edad;
        private double Peso;

        public perro(string nombre, bool algo, int edad, double peso)
        {
            this.Algo = algo;
            this.Edad = edad;
            this.Nombre = nombre;
            this.Peso = peso;
        }

        public perro()
        {

        }
        public void MostrarInfo()
        {
            Console.WriteLine("el nombre de su perro es: {0}", Nombre);
            Console.WriteLine("verdadero o falso:  {0}", Algo);
            Console.WriteLine("edad de su perro: {0}", Edad);
            Console.WriteLine("peso de su perro: {0}", Peso);
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
        }

        public string Informacion()
        {
            return "Nombre: " + Nombre + "; Edad: " + Edad + "; Peso: " + Peso;
        }
    }
}
