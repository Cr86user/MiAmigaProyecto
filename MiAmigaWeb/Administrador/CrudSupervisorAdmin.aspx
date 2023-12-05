<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdministrador.Master" AutoEventWireup="true" CodeBehind="CrudSupervisorAdmin.aspx.cs" Inherits="MiAmigaWeb.Administrador.CrudSupervisorAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <section class="conter-header">
            <h1 style="text-align:center">Registro de Supervisores</h1>
            <style>
                body {
       font-family: Arial, sans-serif;
       background-color: #f4f4f4;
       color: #333;
       margin: 0;
       padding: 0;
       background-color: rgba(255, 192, 203, 0.7); /* Color rosa en formato RGBA */
   }

   .container {
       margin-top: 20px;
       
   }

   /* Estilos para el encabezado */
   .conter-header {
       background-color: #ac3db5;
       color: #fff;
       padding: 20px 0;
   }

   /* Estilos para los formularios */
   .form-group {
       margin-bottom: 20px;
   }

   .form-box {
       width: 100%;
       padding: 8px;
   }

   /* Estilos para botones */
   .btn-insert {
       width: 100%;
       padding: 10px;
       background-color: #28a745;
       color: #fff;
       border: none;
   }

   /* Estilos para la tabla GridView */
   .gridview {
       margin-top: 20px;
   }
    .row {
   display: flex;
   flex-wrap: wrap;
   justify-content: center;
   }

   .col-md-3 {
       flex: 0 0 100%; /* Establecer ancho al 100% en pantallas pequeñas */
       max-width: 100%;
   }

   .container {
       
       padding: 20px;
       border-radius: 5px;
       box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
       margin-bottom: 20px;
   }

   .form-group {
       margin-bottom: 20px;
   }

   .form-box {
       width: calc(100% - 16px); /* Restar el padding de 8px */
       padding: 8px;
   }
            </style>
        </section>
        <section>
            <div class="row">
                <div class="col-md-3">
                    <div class="container">
                           <!--Txt-->
                                <div class="form-group">
                                    <asp:Label runat="server">Nombres:</asp:Label>
                                    <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-box"></asp:TextBox>
                                </div>
                                <!--FinTxt-->
                           <!--Txt-->
                                <div class="form-group">
                                    <asp:Label runat="server">Primer Apellido:</asp:Label>
                                    <asp:TextBox ID="txt_primerApellido" runat="server" CssClass="form-box"></asp:TextBox>
                                </div>
                                <!--FinTxt-->
                           <!--Txt-->
                                <div class="form-group">
                                    <asp:Label runat="server">Segundo Apellido:</asp:Label>
                                    <asp:TextBox ID="txt_segundoApellido" runat="server" CssClass="form-box"></asp:TextBox>
                                </div>
                                <!--FinTxt-->
                           <!--Txt-->
                                <div class="form-group">
                                    <asp:Label runat="server">Carnet de Identidad:</asp:Label>
                                    <asp:TextBox ID="txt_ci" runat="server" CssClass="form-box"></asp:TextBox>
                                </div>
                                <!--FinTxt-->
                           <!--Txt-->
                                <div class="form-group">
                                    <asp:Label runat="server">Direccion:</asp:Label>
                                    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-box"></asp:TextBox>
                                </div>
                                <!--FinTxt-->
                           <!--Txt-->
                                <div class="form-group">
                                    <asp:Label runat="server">Telefono:</asp:Label>
                                    <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-box"></asp:TextBox>
                                </div>
                                <!--FinTxt-->
                         <!--Txt-->
                        <div class="form-group">
                            <asp:Label runat="server">Género:</asp:Label>
                            <asp:DropDownList ID="ddl_genero" runat="server" CssClass="form-box">
                                <asp:ListItem Text="F" Value="F"></asp:ListItem>
                                <asp:ListItem Text="M" Value="M"></asp:ListItem>
                            </asp:DropDownList>
                                 <!--FinTxt-->
                        </div>
                         <!--Txt-->
                                <div class="form-group">
                                    <asp:Label runat="server">Fecha de Cumpleaños:</asp:Label>
                                    <asp:TextBox ID="txt_fechaCumple" runat="server" TextMode="Date" CssClass="datepicker form-box"></asp:TextBox>
                                </div>                      
                          <h1 style="text-align:center">Registro de Usuario</h1>
                         <!-- Txt -->
                        <div class="form-group">
                            <asp:Label runat="server">Correo:</asp:Label>
                            <asp:TextBox ID="txt_correo" runat="server" CssClass="form-box"></asp:TextBox>
                        </div>
                        <!-- FinTxt -->
                        <!-- Txt -->
                        <div class="form-group">
                            <asp:Label runat="server">Nombre de Usuario:</asp:Label>
                            <asp:TextBox ID="txt_nombreUsuario" runat="server" CssClass="form-box"></asp:TextBox>
                        </div>
                        <!-- FinTxt -->

                        <!-- Txt -->
                        <div class="form-group">
                            <asp:Label runat="server">Contraseña:</asp:Label>
                            <asp:TextBox ID="txt_contrasenia" runat="server" TextMode="Password" CssClass="form-box"></asp:TextBox>
                        </div>
                        <!-- FinTxt -->
                         <div class="form-group text-center">
                                    <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn-insert" OnClick="btnInsert_Click" />
                                </div>
                    </div>
                </div>
            </div>
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