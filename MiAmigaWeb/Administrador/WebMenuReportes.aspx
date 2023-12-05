<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdministrador.Master" AutoEventWireup="true" CodeBehind="WebMenuReportes.aspx.cs" Inherits="MiAmigaWeb.Administrador.WebMenuReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="row">
            <div class="col-10">
                 <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte por tipo de denuncia" Onclick="btnGenerarReporte_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnGenerarReporteDenuncia" runat="server" Text="Generar lista de Denunciantes" OnClick="btnGenerarReporteDenuncia_Click"  CssClass="btn btn-primary" />
                 <asp:Button ID="btnGenerarReporteSupervisor" runat="server" Text="Generar lista de Supervisores" OnClick="btnGenerarReporteSupervisor_Click"  CssClass="btn btn-primary" />    
            </div>
        </div>
    </form>
</asp:Content>
