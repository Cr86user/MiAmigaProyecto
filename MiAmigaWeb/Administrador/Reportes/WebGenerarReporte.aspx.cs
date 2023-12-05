using MiAmigaDAO.Implementacion;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MiAmigaWeb.Administrador
{
    public partial class WebGenerarReporte : System.Web.UI.Page
    {
        CasoImpl implCaso;
        string salida = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (ddlTipoDenuncia.SelectedIndex != -1)
            {
                TipoDenuncia(ddlTipoDenuncia.SelectedValue.ToString());
            }
            else
            {
               
            }         
        }
        void TipoDenuncia(string tipoDenuncia)
        {
            try
            {
                implCaso = new CasoImpl();
                DataTable dt = implCaso.MostrarCasosPorTipoDenuncia(tipoDenuncia);

                DataTable table = new DataTable("TipoDenuncia");
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Primer apellido", typeof(string));
                table.Columns.Add("Segundo apellido", typeof(string));
                table.Columns.Add("Carnet de identidad", typeof(string));
                table.Columns.Add("Telefono", typeof(string));
                table.Columns.Add("Tipo de denuncia", typeof(string));
                table.Columns.Add("Estado de la denuncia", typeof(string));
                table.Columns.Add("Fecha y hora de la denuncia", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    table.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
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
            ImprimirReporte();
        }

        void ImprimirReporte()
        {
            salida = ddlTipoDenuncia.SelectedValue.ToString();
            CasoImpl implCaso = new CasoImpl();
            DataTable dt = implCaso.MostrarCasosPorTipoDenunciaImprimir(ddlTipoDenuncia.SelectedValue.ToString());

            // Crear un documento PDF con orientación horizontal
            Document doc = new Document(PageSize.A4.Rotate());
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            doc.Open();

            // Estilo de fuente para títulos y datos
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font dataFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Título del documento
            Paragraph title = new Paragraph("Informe de tipo de Denuncias", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Tipo de rango de IMC del informe
            Paragraph tipoDenuncia = new Paragraph("Tipo de Denuncia: " + salida, dataFont);
            tipoDenuncia.Alignment = Element.ALIGN_RIGHT;
            doc.Add(tipoDenuncia);

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
            Response.AddHeader("content-disposition", "attachment; filename=ReporteTipoDenuncia.pdf");
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
    }
}