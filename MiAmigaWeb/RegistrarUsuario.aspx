<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="MiAmigaWeb.RegistrarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <style>
        body {
            background-color: rgba(255, 192, 203, 0.7); /* Color rosa en formato RGBA */
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        .container {
            margin-top: 50px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-box {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .datepicker {
            width: calc(100% - 24px); /* Considera el padding del datepicker */
        }

        .btn-insert {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn-insert:hover {
            background-color: #45a049;
        }

        .btn-cancelar {
            padding: 10px 20px;
            background-color: #f44336;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn-cancelar:hover {
            background-color: #db4436;
        }

        h1 {
            text-align: center;
        }
        
    </style>
        <form id="form1" runat="server">
    <section class="conter-header">
        <h1 style="text-align:center">Registro de Denunciantes</h1>
        
    </section>
    <section>
        <div class="row">
            <div class="col-md-12">
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
                                 <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" Onclick="btnCancelar_Click" />       
                     </div>
                </div>
            </div>
        </div>       
    </section>
</form>
</body>
     <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
 <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js"></script>
 <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</html>
