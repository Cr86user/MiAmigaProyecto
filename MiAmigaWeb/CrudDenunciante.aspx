<%@ Page Title="" Language="C#" MasterPageFile="~/SiteDenunciante.Master" AutoEventWireup="true" CodeBehind="CrudDenunciante.aspx.cs" Inherits="MiAmigaWeb.CrudDenunciante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <section class="conter-header">
        <h1 style="text-align:center">Registro de Denunciantes</h1>
        
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
                            <!--FinTxt-->
                     <!--Txt-->
                             <div class="form-group">
                                <asp:Label runat="server">Seleccionar archivo de Audio:</asp:Label>
                                <asp:FileUpload ID="Up_Imagen" runat="server" CssClass="form-box" />
                             </div>
                            <!--FinTxt-->
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
                                <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn-insert" Onclick="btnInsert_Click"/>
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
