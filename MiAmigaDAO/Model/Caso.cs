using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Model
{
    public class Caso:BaseModel
    {
       

        public int Id { get; set; }
        public int NumeroCaso { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public string Latitud {  get; set; }
        public string Longitud { get; set; }
        public string EstadoCaso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaReapertura { get; set; } 
        public int IdDenunciante { get; set; }
        public int IdSupervisor { get; set; }

        public Caso(int id, int numeroCaso, string descripcion, byte[] imagen, string estadoCaso, DateTime fechaInicio, DateTime fechaCierre, DateTime fechaReapertura, int idDenunciante, int idSupervisor, DateTime fechaRegistro, DateTime fechaActualizacion, byte estado)
            : base(estado, fechaRegistro, fechaActualizacion)
        {
            Id = id;
            NumeroCaso = numeroCaso;
            Descripcion = descripcion;
            Imagen = imagen;
            EstadoCaso = estadoCaso;
            FechaInicio = fechaInicio;
            FechaCierre = fechaCierre;
            FechaReapertura = fechaReapertura;
            IdDenunciante = idDenunciante;
            IdSupervisor = idSupervisor;
        }

        public Caso(int numeroCaso, string descripcion, byte[] imagen, string estadoCaso, DateTime fechaInicio, DateTime fechaCierre, DateTime fechaReapertura, int idDenunciante, int idSupervisor)
        {
            NumeroCaso = numeroCaso;
            Descripcion = descripcion;
            Imagen = imagen;           
            EstadoCaso = estadoCaso;
            FechaInicio = fechaInicio;
            FechaCierre = fechaCierre;
            FechaReapertura = fechaReapertura;
            IdDenunciante = idDenunciante;
            IdSupervisor = idSupervisor;
        }
        public Caso(int numeroCaso, string descripcion, byte[] imagen,string latitud,string longitud,int idDenunciante)
        {
            NumeroCaso = numeroCaso;
            Descripcion = descripcion;
            Imagen = imagen;
            Latitud = latitud;
            Longitud = longitud;                  
            IdDenunciante = idDenunciante;
        }
        public Caso(int id, int idSupervisor)
        {
            Id = id;
            IdSupervisor = idSupervisor;
        }
        public Caso(int idSupervisor) 
        {
            IdSupervisor = idSupervisor;
        }
        public Caso(int id, string latitud, string longitud)
        {
            Id = id;
            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
