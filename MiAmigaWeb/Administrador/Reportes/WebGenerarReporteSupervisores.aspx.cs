﻿using iTextSharp.text.pdf;
using iTextSharp.text;
using MiAmigaDAO.Implementacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiAmigaWeb.Administrador.Reportes
{
    public partial class WebGenerarReporteSupervisores : System.Web.UI.Page
    {
        SupervisorImpl ImplSupervisor;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            SelectSupervisores();
        }
        void SelectSupervisores()
        {
            try
            {
                ImplSupervisor = new SupervisorImpl();
                DataTable dt = ImplSupervisor.MostrarSupervisores();

                DataTable table = new DataTable("Supervisores");
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Primer apellido", typeof(string));
                table.Columns.Add("Segundo Apellido", typeof(string));
                table.Columns.Add("Carnet de identidad", typeof(string));
                table.Columns.Add("Genero", typeof(string));
                table.Columns.Add("Estado", typeof(string));
                table.Columns.Add("Fecha y hora", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                gridData.DataSource = table;
                gridData.DataBind();
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    string id = dt.Rows[i][0].ToString();
                    gridData.Rows[i].Attributes["data-id"] = id;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            ExportReportByPDF();
        }
        void ExportReportByPDF()
        {         
            // Obtener los datos desde la capa de acceso a datos
            SupervisorImpl ImplSupervisor= new SupervisorImpl();
            DataTable dt = ImplSupervisor.MostrarSupervisoresImprimir();

            // Crear un documento PDF
            Document doc = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            // Estilo de fuente para títulos y datos
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font dataFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Título del documento
            Paragraph title = new Paragraph("Informe de Supervisores", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);


            // Tipo de rango de IMC del informe
            Paragraph tipoDiabetes = new Paragraph("Supervisores: ", dataFont);
            tipoDiabetes.Alignment = Element.ALIGN_RIGHT;
            doc.Add(tipoDiabetes);

            // Fecha del informe
            Paragraph date = new Paragraph("Fecha: " + DateTime.Now.ToString(), dataFont);
            date.Alignment = Element.ALIGN_RIGHT;
            doc.Add(date);

            // Agregar espacio en blanco
            doc.Add(new Paragraph("\n"));

            // Crear la tabla para el PDF
            PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
            pdfTable.WidthPercentage = 100;
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.DefaultCell.BackgroundColor = new BaseColor(240, 240, 240);

            // Encabezados de columna
            foreach (DataColumn column in dt.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName, dataFont));
                headerCell.BackgroundColor = new BaseColor(51, 153, 255);
                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable.AddCell(headerCell);
            }

            // Agregar datos a la tabla
            foreach (DataRow row in dt.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), dataFont));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }
            }
            // Agregar la tabla al documento
            doc.Add(pdfTable);

            // Cerrar el documento PDF
            doc.Close();

            // Descargar el archivo PDF generado
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=ReporteSupervisores.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
    }
}