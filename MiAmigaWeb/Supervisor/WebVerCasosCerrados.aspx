<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSupervisor.Master" AutoEventWireup="true" CodeBehind="WebVerCasosCerrados.aspx.cs" Inherits="MiAmigaWeb.Supervisor.WebVerCasosCerrados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-12">
                <div class="table-responsive" style="max-height: 300px; overflow-y: auto; max-width: auto;">
                    <asp:GridView ID="GridData" runat="server" CssClass="table table-bordered table-striped table-dark table-sm">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:Button ID="btnAtras" runat="server" Text="Volver" CssClass="btn btn-secondary" Onclick="btnAtras_Click"/>
    </form>
</asp:Content>
