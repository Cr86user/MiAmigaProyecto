using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Model
{
    public class Persona:BaseModel
    {
     

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Ci { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public char Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public byte Imagen { get; set; }
        public Persona(int id, string nombre, string primerApellido, string segundoApellido, string ci, string direccion, string telefono, char genero, DateTime fechaNacimiento, byte imagen,byte estado, DateTime fechaRegistro, DateTime fechaActualizacion)
            :base(estado,fechaRegistro,fechaActualizacion)
        {
            Id = id;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Ci = ci;
            Direccion = direccion;
            Telefono = telefono;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Imagen = imagen;
        }
        public Persona()
        {

        }

        public Persona(string nombre, string primerApellido, string segundoApellido, string ci, string direccion, string telefono, char genero, DateTime fechaNacimiento, byte imagen)
        {
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Ci = ci;
            Direccion = direccion;
            Telefono = telefono;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Imagen = imagen;
        }
        public Persona(string nombre, string primerApellido, string segundoApellido, string ci, string direccion, string telefono, char genero, DateTime fechaNacimiento, byte imagen,byte estado,DateTime fechaRegistro, DateTime fechaActualizacion) : this(nombre,primerApellido,segundoApellido,ci,direccion,telefono,genero,fechaNacimiento,imagen)
        {
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Ci = ci;
            Direccion = direccion;
            Telefono = telefono;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            Imagen = imagen;
        }
        public Persona(string nombre, string primerApellido, string segundoApellido, string ci, string direccion, string telefono, char genero, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Ci = ci;
            Direccion = direccion;
            Telefono = telefono;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
