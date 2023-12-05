using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Model
{
    public class Supervisor:Persona
    {
        public string CodSupervisor { get; set; }
        public string Ocupacion { get; set; }

        public Supervisor(int id,string nombre,string primerApellido,string segundoApellido,string ci,string direccion,string telefono,char genero,DateTime fechaNacimiento,byte imagen,byte estado,DateTime fechaRegistro,DateTime fechaActualizacion,string codSupervisor,string ocupacion)
                        :base(nombre,primerApellido,segundoApellido,ci,direccion,telefono,genero,fechaNacimiento,imagen,estado,fechaRegistro,fechaActualizacion)
        {
            CodSupervisor = codSupervisor;
            Ocupacion = ocupacion;
        }
        public Supervisor(string codSupervisor,string ocupacion)
        {
            CodSupervisor = codSupervisor;
            Ocupacion = ocupacion;
        }
        public Supervisor(int id ,string ocupacion) 
        { 
            Ocupacion = ocupacion;
        }

    }
}
