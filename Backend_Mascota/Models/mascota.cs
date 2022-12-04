using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend_Mascota.Models
{
    public class mascota
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string descripcion { get; set; }

        public mascota() { }
        public mascota(int ID, string Nombre, int Edad, string Descripcion) {
            id = ID;
            nombre = Nombre;
            edad = Edad;
            descripcion = Descripcion;
        }
        public mascota(string Nombre, int Edad, string Descripcion)
        {
            
            nombre = Nombre;
            edad = Edad;
            descripcion = Descripcion;
        }
    }
}