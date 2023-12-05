<%@ Page Title="" Language="C#" MasterPageFile="~/SiteDenunciante.Master" AutoEventWireup="true" CodeBehind="AbrirNuevoCaso.aspx.cs" Inherits="MiAmigaWeb.Denunciante.AbrirNuevoCaso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
        font-family: Arial, sans-serif;
        background-color: rgba(255, 192, 203, 0.7); /* Color rosa en formato RGBA */
    }

    .container {
        margin-top: 50px;
        background-color: rgba(255, 192, 203, 0.7); /* Color rosa en formato RGBA */
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        padding: 20px;
    }

    .form-group {
        margin-bottom: 20px;
    }

    .form-control {
        width: 100%;
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    .btn-insert {
        background-color: #007bff;
        color: #fff;
        border: none;
        padding: 10px 20px;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s;
    }

    .btn-insert:hover {
        background-color: #0056b3;
    }

    .datagrid-container {
        margin-top: 20px;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    .box-body {
        padding: 20px;
    }

    .table {
        width: 100%;
        border-collapse: collapse;
    }

    .table th,
    .table td {
        padding: 8px;
        border: 1px solid #ccc;
    }

    .table th {
        background-color: #f5f5f5;
        font-weight: bold;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <script type="text/javascript" src="https://www.bing.com/api/maps/mapcontrol?callback=loadMap" async defer></script>
<style>
    .container {
        background-color: rgba(255, 255, 255, 0.7);
        text-align: center;
        padding: 20px;
    }
    .white-text {
        color: white;
    }
</style>
<script type="text/javascript">
    var map;
    var pin;

    function loadMap() {
        map = new Microsoft.Maps.Map(document.getElementById('mapContainer'), {
            credentials: '<%= "Ah7d7nVBAlUhzBrBwcFM1CozkSVzzE77DBarlxH9hnzD6Y6RL4G5m1DWktD9IFml" %>',
            center: new Microsoft.Maps.Location(-17.3895, -66.1568),
            zoom: 10
        });

        Microsoft.Maps.Events.addHandler(map, 'click', function (e) {
            var latitud = document.getElementById('<%=txt_latitude.ClientID%>');
            var longitud = document.getElementById('<%=txt_longitude.ClientID%>');

            var location = e.location;
            var latitudValor = location.latitude.toFixed(6);
            var longitudValor = location.longitude.toFixed(6);

            latitud.value = latitudValor;
            longitud.value = longitudValor;

            if (pin) {
                map.entities.remove(pin);
            }

            pin = new Microsoft.Maps.Pushpin(location);
            map.entities.push(pin);
        });
    }
</script>
  <form id="form1" runat="server">

    <div class="container">
        <section class="conter-header">
            <h1 style="text-align:center">Registro de Casos</h1>
        </section>
         <section>
             <div id="mapContainer" style="width:500px; height:500px">
             </div>
         </section>
        <section>
            <div class="row">
                <div class="col-md-12">
                    <div class="container">
                        <div class="form-group">
                            <asp:Label runat="server">Descripcion:</asp:Label>
                            <asp:TextBox ID="txt_Descripcion" runat="server" CssClass="form-box"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server">Seleccionar archivo de Imagen:</asp:Label>
                            <asp:FileUpload ID="Up_Imagen" runat="server" CssClass="form-box" />
                        </div>
                       <div class="form-group" style="visibility:hidden">
                             <asp:TextBox ID="txt_latitude" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                        <div class="form-group" style="visibility:hidden">
                            <asp:TextBox ID="txt_longitude" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button ID="btnInsert" Text="Insertar" runat="server" CssClass="btn btn-insert" OnClick="btnInsert_Click" />
                        </div>
                    </div>
                    <div class="datagrid-container">
                        <div class="box-body">
                            <asp:GridView ID="gridData" runat="server" CssClass="table" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</form>  
    <script>
         function ConfirmDelete() {
             return confirm('¿Estás seguro de que deseas eliminar este elemento?');
         }
    </script>
</asp:Content>
