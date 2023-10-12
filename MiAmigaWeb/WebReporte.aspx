<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSupervisor.Master" AutoEventWireup="true" CodeBehind="WebReporte.aspx.cs" Inherits="MiAmigaWeb.WebReporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo para el fondo */
        body {
            background-color: #a06dc7;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        /* Estilo para el contenedor transparente */
        .form-container {
            background-color: rgba(255, 255, 255, 0.8); /* Fondo transparente */
            padding: 20px;
            border-radius: 10px;
        }

        /* Estilo para los controles dentro del contenedor */
        .form-group {
            margin-bottom: 15px;
        }

        .form-box {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .center-text {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <form id="form1" runat="server">
            <div>
                <section class="conter-header">
                    <h1 style="text-align:center">Registro de Casos</h1>
                </section>
                <section>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="container">                           
                                <!--Txt-->
                                <div class="form-group">
                                    <asp:Label runat="server">Descripcion:</asp:Label>
                                    <asp:TextBox ID="txt_Descripcion" runat="server"  CssClass="form-box"></asp:TextBox>
                                </div>
                                <!--FinTxt-->
                                <!--Txt-->
                              <div class="form-group">
                                    <asp:Label runat="server">Seleccionar archivo de Imagen:</asp:Label>
                                    <asp:FileUpload ID="Up_Imagen" runat="server" CssClass="form-box" />
                              </div>
                                <!--FinTxt-->
                                <!--Txt-->
                                 <div class="form-group">
                                    <asp:Label runat="server">Seleccionar archivo de Audio:</asp:Label>
                                    <asp:FileUpload ID="Up_Audio" runat="server" CssClass="form-box" />
                                 </div>
                                <!--FinTxt-->                                                 
                                <div class="form-group text-center">
                                    <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn-insert" Onclick ="btnInsert_Click" />
                                </div>
                            </div>
                        </div>
                        <!--Datagrid-->
                        <div class="col-md-9">
                            <div class="datagrid-container">
                                <div class="box-body">
                                    <asp:GridView ID="gridData" runat="server" CssClass="gridview table table-bordered table-striped dataTable dtr-inline collapsed" />
                                </div>
                            </div>
                        </div>
                        <!--DatagridFin-->
                    </div>
                </section>
            </div>
        </form>
    </main>
    <script>
         function ConfirmDelete() {
             return confirm('¿Estás seguro de que deseas eliminar este elemento?');
         }
    </script>
</asp:Content>
