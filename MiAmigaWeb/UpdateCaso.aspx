<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSupervisor.Master" AutoEventWireup="true" CodeBehind="UpdateCaso.aspx.cs" Inherits="MiAmigaWeb.UpdateCaso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div>
            <section class="conter-header">
                <h1 style="text-align:center">Asignacion de Supervisores</h1>
            </section>
            <section>
                <div class="row">
                    <div class="col-md-3">
                        <div class="container">
                            <!-- ComboBox (DropDownList) -->
                           <asp:DropDownList ID="ddlSupervisores" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>                  
                    <div class="col-md-6">
                        <div class="box-body">
                            <asp:Button ID="btnUpdate" Text="Modificar" runat="server" class="btn btn-sm btn-info" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </form>
</asp:Content>
