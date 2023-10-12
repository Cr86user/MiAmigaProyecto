﻿using MiAmigaDAO.Implementacion;
using MiAmigaDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb
{
    public partial class WebReporte : System.Web.UI.Page
    {
        Caso c;
        CasoImpl implCaso;
        byte id;
        protected void Page_Load(object sender, EventArgs e)
        {
            load();
            Select();
        }
       
        
         

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int numero = ObtenerSiguienteNumero();
            byte[] imagenBytes = ConvertirABytes(Up_Imagen.PostedFile);

            // Convertir el archivo de audio a un arreglo de bytes
            byte[] audioBytes = ConvertirABytes(Up_Audio.PostedFile);
            try
            {
                Caso c = new Caso(numero, txt_Descripcion.Text, imagenBytes, audioBytes);
                CasoImpl casoImpl = new CasoImpl();
                casoImpl.Insert(c);
                Select();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int ObtenerSiguienteNumero()
        {
            int contador = 0;
            contador++;
            return contador;
        }
        private byte[] ConvertirABytes(HttpPostedFile file)
        {
            using (BinaryReader reader = new BinaryReader(file.InputStream))
            {
                return reader.ReadBytes(file.ContentLength);
            }
        }
    
           
        void Select()
        {
            try
            {
                implCaso = new CasoImpl();
                DataTable dt = implCaso.Select();

                DataTable table = new DataTable("Caso");
                table.Columns.Add("Caso Numero", typeof(string));
                table.Columns.Add("Descripcion", typeof(string));
                table.Columns.Add("Imagen", typeof(string));
                table.Columns.Add("Audio", typeof(string));
                table.Columns.Add("Estado del caso", typeof(string));
                table.Columns.Add("Fecha Cuando el caso se inicio", typeof(string));
                table.Columns.Add("Fecha Cuando el caso se cerro", typeof(string));
                table.Columns.Add("Fecha Cuando el caso se reaperturo", typeof(string));
                table.Columns.Add("Codigo del denunciante", typeof(string));
                table.Columns.Add("Codigo del supervisor", typeof(string));

                table.Columns.Add("Editar", typeof(string));
                table.Columns.Add("Eliminar", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                }
                gridData.DataSource = table;
                gridData.DataBind();
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    string up = " <a class='btn btn-sm btn-info' href='UpdateCaso.aspx?id=" + id + "&type=U'> <i class='fas fa-edit' style='color:#000000;'> </i>  </a> ";
                    string del = " <a class='btn btn-sm btn-danger' href='WebReporte.aspx?id=" + id + "&type=D' onclick='return ConfirmDelete();'> <i class='fas fa-trash' style='background:#FF0000;'> </i>  </a> ";



                    gridData.Rows[i].Cells[10].Text = up;
                    gridData.Rows[i].Cells[11].Text = del;                    
                    gridData.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void load()
        {
            try
            {
                string type = Request.QueryString["type"];

                if (type == "D")
                {
                    Delete();
                    Select();                 
                }
               else
                {

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        void Delete()
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implCaso = new CasoImpl();
                    c = implCaso.Get(id);
                    if (c != null)
                    {
                        implCaso.Delete(c);

                        Select();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        void EstadoCaso()
        {
            id = byte.Parse(Request.QueryString["id"]);
            if (id > 0)
            {
                try
                {
                    implCaso = new CasoImpl();
                    c = implCaso.Get(id);
                    if (c != null)
                    {
                        implCaso.UpdateEstado(c);

                        Select();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}