<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdministrador.Master" AutoEventWireup="true" CodeBehind="WebAdminAsignar.aspx.cs" Inherits="MiAmigaWeb.Administrador.WebAdminAsignar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         .body{
     background-color: rgba(255, 192, 203, 0.7); /* Color rosa en formato RGBA */
 }
    </style>
    <div class="body">
     <form id="form1" runat="server">
        <section class="conter-header">
            <h1 style="text-align:center">Asignar a un superviosr</h1>
    
        </section>
        <section>
             <!--Datagrid-->
            <div class="col-md-10">                     
                    <div class="box-body">
                        <asp:GridView ID="gridData" runat="server" CssClass="gridview table table-bordered table-striped dataTable dtr-inline collapsed" />
                    </div>                        
            </div>
            <!--DatagridFin-->
        </section>
    </form>
        </div>
</asp:Content>
