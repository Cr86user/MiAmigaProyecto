<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="MiAmigaWeb.WebLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <style>
    body {
        font-family: Arial, sans-serif;
        margin: 0;
        padding: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        background-color: #e8a4ec;
    }

    .login-box {
        width: 300px;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        padding: 20px;
        text-align: center;
          background-color: #ff94f5; /* Cambia este color al que desees */
        border-radius: 8px;
        padding: 20px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Opcional: sombra alrededor del recuadro */
    }

    h1 {
        text-align: center;
        margin-top: 0;
        color: #a04d9d;
    }

    .form-group {
        margin-bottom: 15px;
        text-align: left;
    }

    .form-control {
        width: calc(100% - 24px);
        padding: 8px 12px;
        font-size: 16px;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
        display: block;
        margin: 0 auto;
    }

    .btn-primary {
        background-color: #fb6d66;
        color: #fff;
        border: none;
        padding: 10px 20px;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s;
        width: 100%;
        display: block;
    }

    .btn-primary:hover {
        background-color: #0056b3;
    }

    .btn-link {
        color: #007bff;
        text-decoration: none;
        border: none;
        background-color: transparent;
        cursor: pointer;
        transition: color 0.3s;
    }

    .btn-link:hover {
        color: #0056b3;
    }

    .logo-container {
        text-align: center;
        margin-bottom: 20px;
    }

    .logo-container i {
        color: #ae1a87;
        font-size: 3rem;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="formLogin" runat="server">
        <div class="login-container">
            <div class="login-box">
                <div class="logo-container">
                    <!-- Icono de "Iniciar Sesión" usando Font Awesome -->
                    <i class="fas fa-sign-in-alt"></i>
                </div>
                <h1>LOGIN</h1>
                <div class="form-group">
                    <asp:Label runat="server">Login :</asp:Label>
                    <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server">Password :</asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnIngresar" Text="Ingresar" runat="server" Onclick="btnIngresar_Click1" CssClass="btn btn-primary" />
                </div>
                <div style="text-align: center;">
                    <button type="button" class="btn btn-link">Olvidé Contraseña</button>
                    <button type="button" class="btn btn-link">Registrar</button>
                </div>
                <asp:Label ID="lblError" style="color:red; text-align: center; display: block; margin-top: 10px;" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</asp:Content>
