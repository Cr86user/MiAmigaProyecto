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
    public class CasoImpl : BaseImpl, ICaso
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
        public DataTable SelecDenunciantePorCaso(int id)
        {
            query= @"SELECT C.id,P.nombre AS 'Nombre',P.primerApellido'Primer apellido',P.segundoApellido AS 'Segundo apellido',P.ci AS 'Carnet de identidad',P.telefono AS 'Telefono',P.direccion AS Direccion
                    FROM Caso C
                    INNER JOIN Denunciante DE ON C.idDenunciante = DE.idPersona
                    INNER JOIN Persona P ON P.id = DE.idPersona
                    WHERE C.id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Caso GetUbicacion(int id)
        {
            Caso c = null;
            query = @"SELECT id,latitud,longitud
                    FROM Caso
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                     c = new Caso(int.Parse(table.Rows[0][0].ToString()),
                          table.Rows[0][1].ToString(),
                            table.Rows[0][2].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            return c;   
        }
        public Caso GetSupervisor(int id)
        {
            Caso t = null;
            query = @"SELECT id, idSupervisor
                    FROM Caso
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    Caso caso = new Caso(
                         int.Parse(table.Rows[0][0].ToString()),
                          int.Parse(table.Rows[0][1].ToString())
                        );
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return t;
        }

        public Caso Get(int id)
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
                    byte[] bytesImagen = (byte[])table.Rows[0][3]; // Obtener datos de la imagen como byte[]
                    byte[] bytesAudio = (byte[])table.Rows[0][4]; // Obtener datos del audio como byte[]

                    Caso caso = new Caso(
                        
                        byte.Parse(table.Rows[0][0].ToString()),
                        int.Parse(table.Rows[0][1].ToString()),
                        table.Rows[0][2].ToString(),
                        bytesImagen,                       
                        table.Rows[0][5].ToString(),
                        DateTime.Parse(table.Rows[0][6].ToString()),
                        DateTime.Parse(table.Rows[0][7].ToString()),
                        DateTime.Parse(table.Rows[0][8].ToString()),
                        byte.Parse(table.Rows[0][9].ToString()),
                        byte.Parse(table.Rows[0][10].ToString()),
                        DateTime.Parse(table.Rows[0][11].ToString()),
                        DateTime.Parse(table.Rows[0][12].ToString()),
                        byte.Parse(table.Rows[0][13].ToString())
                    );


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
            query = @"INSERT INTO Caso(nro,descripcion,imagen,estadoCaso,latitud,longitud,idDenunciante,idSupervisor)
                    VALUES (@nro,@descripcion,@imagen,'Abierto',@latitud,@longitud,@idDenunciante,@idSupervisor)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue(@"nro", t.NumeroCaso);
            command.Parameters.AddWithValue(@"descripcion", t.Descripcion);
            command.Parameters.AddWithValue(@"imagen", t.Imagen);
            command.Parameters.AddWithValue(@"latitud", t.Latitud);
            command.Parameters.AddWithValue(@"longitud", t.Longitud);
            command.Parameters.AddWithValue(@"idDenunciante", t.IdDenunciante);
            command.Parameters.AddWithValue(@"idSupervisor", 2018); 
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
            query = @"SELECT C.id,C.nro, C.descripcion, C.imagen, C.estadoCaso, C.fechaInicio, C.fechaCierre, C.fechaReapertura, D.codDenunciante, S.codSupervisor, S.fechaRegistro, S.fechaActualizacion
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
        public DataTable SelectCasoId(int id)
        {
            query = @"SELECT C.id,C.nro, C.descripcion, C.imagen, C.audio, C.estadoCaso, C.fechaInicio, C.fechaCierre, C.fechaReapertura, D.codDenunciante, S.codSupervisor, S.fechaRegistro, S.fechaActualizacion
                    FROM Caso C
                    INNER JOIN Denunciante D ON D.idPersona = C.idDenunciante
                    INNER JOIN Supervisor S ON S.idPersona = C.idSupervisor
                    WHERE c.estado = 1 AND D.idPersona = @idPersona
                    ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona", id);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateSupervisor(Caso t)
        {
            query = @"UPDATE Caso SET idSupervisor = @idSupervisor
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
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
        public int Update(Caso t)
        {
            query = @"UPDATE Caso SET nro = @nro, descripcion = @descripcion, imagen = @imagen, estadoCaso = @estadoCaso, fechaCierre = @fechaCierre, fechaReapertura = @fechaReapertura, idDenunciante = @idDenunciante, idSupervisor = @idSupervisor
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nro", t.NumeroCaso);
            command.Parameters.AddWithValue("@descripcion", t.Descripcion);
            command.Parameters.AddWithValue("@imagen", t.Imagen);           
            command.Parameters.AddWithValue("@estadoCaso", t.EstadoCaso);    
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
        public int UpdateEstado(Caso t)
        {
            query = @"UPDATE Caso SET estadoCaso = 'Cerrado'
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@estadoCaso", t.EstadoCaso);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateOcupacion(Caso c)
        {
            query = @"UPDATE Supervisor SET ocupacion = 'Asignado'
                    WHERE idPersona = @idPersona";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona", c.IdSupervisor);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateEstadoCaso(int id)
        {
            query = @"UPDATE Caso SET estadoCaso = 'Cerrado'
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable listaSupervisor()
        {
            query = @"SELECT idPersona,codSupervisor
                    FROM Supervisor
                    WHERE ocupacion = 'Disponible' AND codSupervisor != 'No asignado'";
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
        public DataTable MostrarCasosPorTipoDenuncia(string tipoDenuncia)
        {
            query = @"SELECT
                        D.id,
                        P.nombre AS 'Nombre',
                        P.primerApellido AS 'Primer apellido',
	                    P.segundoApellido AS 'Segundo apellido',
	                    P.ci AS 'Carnet de identidad',
	                    P.telefono AS 'Telefono',
                        D.tipo AS 'Tipo de denuncia',
                        D.estadoDenuncia AS 'Estado de la denuncia',
                        FORMAT(D.fechaRegistro, 'yyyy-MM-dd HH:mm') AS 'Fecha y hora'
                    FROM
                        Denuncia D
                    RIGHT JOIN
                        Denunciante DE ON D.idDenunciante = DE.idPersona
                    RIGHT JOIN
                        Persona P ON P.id = DE.idPersona
                    WHERE
                        D.estado = 1 AND D.tipo = @tipoDenuncia";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@tipoDenuncia", tipoDenuncia);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                  
        public DataTable MostrarCasosPorTipoDenunciaImprimir(string tipoDenuncia)
        {
            query = @"SELECT                       
                        P.nombre AS 'Nombre',
                        P.primerApellido AS 'Primer apellido',
	                    P.segundoApellido AS 'Segundo apellido',
	                    P.ci AS 'Carnet de identidad',
	                    P.telefono AS 'Telefono',
                        D.tipo AS 'Tipo de denuncia',
                        D.estadoDenuncia AS 'Estado de la denuncia',
                        FORMAT(D.fechaRegistro, 'yyyy-MM-dd HH:mm') AS 'Fecha y hora'
                    FROM
                        Denuncia D
                    INNER JOIN
                        Denunciante DE ON D.idDenunciante = DE.idPersona
                    INNER JOIN
                        Persona P ON P.id = DE.idPersona
                    WHERE
                        D.estado = 1 AND D.tipo = @tipoDenuncia";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@tipoDenuncia", tipoDenuncia);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
