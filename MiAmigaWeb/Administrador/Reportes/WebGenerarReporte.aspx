<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdministrador.Master" AutoEventWireup="true" CodeBehind="WebGenerarReporte.aspx.cs" Inherits="MiAmigaWeb.Administrador.WebGenerarReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   


                  <form id="form1" runat="server">
          <div class="row">
               <div class="col-10">
                     <div class="container">
                         <div class="container">
                          <asp:DropDownList ID="ddlTipoDenuncia" runat="server" CssClass="form-control">
                              <asp:ListItem Text="Violencia" Value="Violencia" />
                              <asp:ListItem Text="Psicologica" Value="Psicologica" />
                              <asp:ListItem Text="Acoso" Value="Acoso" />
                              <asp:ListItem Text="Abuso" Value="Abuso" />
                              <asp:ListItem Text="Genero" Value="Genero" />
                          </asp:DropDownList>               
                          </div>
                         <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" Onclick="btnGenerarReporte_Click" CssClass="btn btn-primary" />
                         <asp:Button ID="btnImprimirReporte" runat="server" Text="Imprimir Reporte" OnClick="btnImprimirReporte_Click"  CssClass="btn btn-primary" />
                     </div>
                 </div>
          </div>       
          <div class="row">
               <div class="col-12">
                      <div class="box-body">
                         <asp:GridView ID="gridData" runat="server" CssClass="gridview table table-bordered table-striped dataTable dtr-inline collapsed" />
                     </div>  
                 </div>
          </div>
           <!--Datagrid-->
            
<!--DatagridFin-->
      </form>







      






</asp:Content>
