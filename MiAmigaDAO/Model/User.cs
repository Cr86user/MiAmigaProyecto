using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Model
{
    public class User:Persona
    {
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string Rol { get; set; }
        public User(byte id, string nombre, string primerApellido, string segundoApellido, string ci, string direccion, string telefono, char genero, DateTime fechaNacimiento, byte imagen, byte estado, DateTime fechaRegistro, DateTime fechaActualizacion, string nombreUsuario, string correo, string contrasenia, string rol)
                       : base(nombre, primerApellido, segundoApellido, ci, direccion, telefono, genero, fechaNacimiento, imagen, estado, fechaRegistro, fechaActualizacion)
        {
            NombreUsuario = nombreUsuario;
            Correo = correo;
            Contrasenia = contrasenia;
            Rol = rol;
        }
        public User(string nombreUsuario, string correo, string contrasenia, string rol)
        {
            NombreUsuario = nombreUsuario;
            Correo = correo;
            Contrasenia = contrasenia;
            Rol = rol;
        }
    }
}
