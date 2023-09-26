using MiAmigaDAO.Inteface;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAmigaDAO.Implementacion
{
    public class CasoImpl : BaseImplcs, ICaso
    {
        public int Delete(Caso t)
        {
            query = @"UPDATE Caso SET estado = 0, fechaActualizacion = CURRENT_TIMESTAMP
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Caso Get(byte id)
        {
            Caso t = null;
            query = @"SELECT id,nro,descripcion,imagen,audio,estadoCaso,fechaInicio,fechaCierre,fechaReapertura,ISNULL(fechaActualizacion, CURRENT_TIMESTAMP)
                    FROM Caso
                    WHERE id =@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Caso(
                                 byte.Parse(table.Rows[0][0].ToString()),
                                 int.Parse(table.Rows[0][1].ToString()),
                                 table.Rows[0][2].ToString(),
                                 byte.Parse(table.Rows[0][3].ToString()),
                                 byte.Parse(table.Rows[0][4].ToString()),
                                 table.Rows[0][5].ToString(),
                                 DateTime.Parse(table.Rows[0][6].ToString()),
                                 DateTime.Parse(table.Rows[0][7].ToString()),
                                 DateTime.Parse(table.Rows[0][8].ToString()),
                                 byte.Parse(table.Rows[0][9].ToString()),
                                 byte.Parse(table.Rows[0][10].ToString()),
                                 DateTime.Parse(table.Rows[0][11].ToString()),
                                 DateTime.Parse(table.Rows[0][12].ToString()),
                                 byte.Parse(table.Rows[0][13].ToString()));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return t;
        }

        public void GetDate()
        {
            query = @"SELECT id, nombre
                    FROM Persona
                    WHERE estado = 1";
            SqlCommand command = CreateBasicCommand(query);
            SqlDataAdapter da = new SqlDataAdapter(command);
            try
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Insert(Caso t)
        {
            query = @"INSERT INTO Caso(nro,descripcion,imagen,audio,estadoCaso,fechaInicio,fechaCierre,fechaReapertura,idDenunciante,idSupervisor)
                    VALUES (@nro,@descripcion,@imagen,@audio,@estadoCaso,@fechaInicio,@fechaCierre,@fechaReapertura,@idDenunciante,@idSupervisor)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue(@"nro", t.NumeroCaso);
            command.Parameters.AddWithValue(@"descripcion", t.Descripcion);
            command.Parameters.AddWithValue(@"imagen", t.Imagen);
            command.Parameters.AddWithValue(@"audio", t.Audio);
            command.Parameters.AddWithValue(@"estadoCaso", t.EstadoCaso);
            command.Parameters.AddWithValue(@"fechaInicio", t.FechaInicio);
            command.Parameters.AddWithValue(@"fechaCierre", t.FechaCierre);
            command.Parameters.AddWithValue(@"fechaReapertura", t.FechaReapertura);
            command.Parameters.AddWithValue(@"idDenunciante", 1);
            command.Parameters.AddWithValue(@"idSupervisor", 1);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT C.nro, C.descripcion, C.imagen, C.audio, C.estadoCaso, C.fechaInicio, C.fechaCierre, C.fechaReapertura, D.codDenunciante, S.codSupervisor, S.fechaRegistro, S.fechaActualizacion
                    FROM Caso C
                    INNER JOIN Denunciante D ON D.idPersona = C.idDenunciante
                    INNER JOIN Supervisor S ON S.idPersona = C.idSupervisor
                    WHERE c.estado = 1
                    ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Update(Caso t)
        {
            query = @"UPDATE Caso SET nro = @nro, descripcion = @descripcion, imagen = @imagen, audio = @audio, estadoCaso = @estadoCaso, fechaInicio = @fechaInicio, fechaCierre = @fechaCierre, fechaReapertura = @fechaReapertura, idDenunciante = @idDenunciante, idSupervisor = @idSupervisor
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nro", t.NumeroCaso);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@imagen", t.Imagen);
            command.Parameters.AddWithValue("@audio", t.Audio);
            command.Parameters.AddWithValue("@estadoCaso", t.EstadoCaso);
            command.Parameters.AddWithValue("@fechaInicio", t.FechaInicio );
            command.Parameters.AddWithValue("@fechaCierre", t.FechaCierre);
            command.Parameters.AddWithValue("@fechaReapertura", t.FechaReapertura);
            command.Parameters.AddWithValue("@idDenunciante", t.IdDenunciante);
            command.Parameters.AddWithValue("@idSupervisor", t.IdSupervisor);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
