using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Model
{
    public class Caso:BaseModel
    {
       

        public byte Id { get; set; }
        public int NumeroCaso { get; set; }
        public string Descripcion { get; set; }
        public byte Imagen { get; set; }
        public byte Audio { get; set; }
        public string EstadoCaso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaReapertura { get; set; } 
        public byte IdDenunciante { get; set; }
        public byte IdSupervisor { get; set; }

        public Caso(byte id, int numeroCaso, string descripcion, byte imagen, byte audio, string estadoCaso, DateTime fechaInicio, DateTime fechaCierre, DateTime fechaReapertura, byte idDenunciante, byte idSupervisor, DateTime fechaRegistro, DateTime fechaActualizacion, byte estado)
            : base(estado,fechaRegistro,fechaActualizacion)
        {
            Id = id;
            NumeroCaso = numeroCaso;
            Descripcion = descripcion;
            Imagen = imagen;
            Audio = audio;
            EstadoCaso = estadoCaso;
            FechaInicio = fechaInicio;
            FechaCierre = fechaCierre;
            FechaReapertura = fechaReapertura;
            IdDenunciante = idDenunciante;
            IdSupervisor = idSupervisor;
        }

        public Caso(int numeroCaso, string descripcion, byte imagen, byte audio, string estadoCaso, DateTime fechaInicio, DateTime fechaCierre, DateTime fechaReapertura, byte idDenunciante, byte idSupervisor)
        {
            NumeroCaso = numeroCaso;
            Descripcion = descripcion;
            Imagen = imagen;
            Audio = audio;
            EstadoCaso = estadoCaso;
            FechaInicio = fechaInicio;
            FechaCierre = fechaCierre;
            FechaReapertura= fechaReapertura;
            IdDenunciante = idDenunciante;
            IdSupervisor = idSupervisor;
        }
    }
}
