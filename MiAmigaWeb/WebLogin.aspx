<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSupervisor.Master" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="MiAmigaWeb.WebLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="formLogin" runat="server">
        <div class="container">
            <section class="content-header">
                <h1 style="text-align:center">LOGIN</h1>
            </section>
            <section class="content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-body">
                            <div class="form-group">
                                <asp:Label runat="server">Login :</asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server">Password :</asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="box-body center-align">
                                <asp:Button ID="btnIngresar" Text="Ingresar" runat="server" Onclick ="btnIngresar_Click" CssClass="form-control" />
                            </div>
                            <br />
                            <asp:Label ID="lblError" style="color:red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </form>
</asp:Content>
