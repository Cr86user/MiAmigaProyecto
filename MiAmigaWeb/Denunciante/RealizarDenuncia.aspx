<%@ Page Title="" Language="C#" MasterPageFile="~/SiteDenunciante.Master" AutoEventWireup="true" CodeBehind="RealizarDenuncia.aspx.cs" Inherits="MiAmigaWeb.Denunciante.RealizarDenuncia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body, html {
            height: 100%;
            margin: 0;
            padding: 0;
            background-color: rgba(255, 192, 203, 0.7); /* Color rosa en formato RGBA */
        }

        .container {
            background-color: rgba(255, 192, 203, 0.7); /* Color rosa en formato RGBA */
            text-align: center;
            padding: 20px;
             background-color: rgba(255, 192, 203, 0.7); /* Color rosa en formato RGBA */
        }

        .white-text {
            color: white;
        }

        #mapContainer {
            width: 1100px;
            height: 500px;
            border: 1px solid #ccc;
        }
    </style>

    <div class="container d-flex justify-content-center align-items-center vh-100">
        <form id="form1" runat="server" class="w-100">


            <section class="conter-header">
                <h1 style="text-align:center">Registro de Denunciantes</h1>
            </section>          
            <section>
                <div class="row">
                    <div class="col-md-3">
                        <div class="container">
                            <div class="container">
                                <asp:DropDownList ID="ddlTipoDenuncia" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Violencia" Value="Violencia" />
                                    <asp:ListItem Text="Psicologica" Value="Psicologica" />
                                    <asp:ListItem Text="Acoso" Value="Acoso" />
                                    <asp:ListItem Text="Abuso" Value="Abuso" />
                                    <asp:ListItem Text="Genero" Value="Genero" />
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlCasos" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <asp:Button ID="btnDenunciar" runat="server" Text="Denunciar" OnClick="btnDenunciar_Click" CssClass="btn btn-warning" />
                            <div class="form-group" style="visibility:hidden">
                                <asp:Label runat="server" CssClass="white-text">Latitud :</asp:Label>
                            </div>
                           
                            <div class="form-group" style="visibility:hidden">
                                <asp:Label runat="server" CssClass="white-text">Longitud :</asp:Label>
                            </div>
                            
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly="true" style="display:none;"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </section>
        </form>
    </div>
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
</asp:Content>
