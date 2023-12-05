<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdministrador.Master" AutoEventWireup="true" CodeBehind="WebAsignarSupervisor.aspx.cs" Inherits="MiAmigaWeb.WebAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>