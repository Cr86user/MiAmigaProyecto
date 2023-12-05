<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSupervisor.Master" AutoEventWireup="true" CodeBehind="WebVerCaso.aspx.cs" Inherits="MiAmigaWeb.Supervisor.WebVerCaso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://www.bing.com/api/maps/mapcontrol?callback=loadMap" async defer></script>

<script type="text/javascript">
    var map;
    var pin;
    var txtLatitude;
    var txtLongitude;

    function loadMap() {
        map = new Microsoft.Maps.Map(document.getElementById('mapContainer'), {
            credentials: 'Apa57c1xOrdhQocxLvY5bCdwj07SN7tU4LBEMtPICJK2Q1UHO-bfhq0v2x9clMPE',
            zoom: 10
        });

        Microsoft.Maps.Events.addHandler(map, 'click', function (e) {
            var location = e.location;
            var latitudValor = location.latitude.toFixed(6);
            var longitudValor = location.longitude.toFixed(6);

            updateCoordinates(latitudValor, longitudValor);
        });

        txtLatitude = document.getElementById('<%=txt_latitude.ClientID%>');
        txtLongitude = document.getElementById('<%=txt_longitude.ClientID%>');

        txtLatitude.addEventListener('input', updateMap);
        txtLongitude.addEventListener('input', updateMap);
        txtLatitude.addEventListener('change', updateMap);
        txtLongitude.addEventListener('change', updateMap);

        updateMap();
    }

    function updateMap() {
        var latitude = parseFloat(txtLatitude.value);
        var longitude = parseFloat(txtLongitude.value);

        if (!isNaN(latitude) && !isNaN(longitude)) {
            var location = new Microsoft.Maps.Location(latitude, longitude);

            updateCoordinates(latitude.toFixed(6), longitude.toFixed(6));

            if (pin) {
                map.entities.remove(pin);
            }

            pin = new Microsoft.Maps.Pushpin(location);
            map.entities.push(pin);

            // Centrar el mapa en la ubicación del pin
            map.setView({
                center: location,
                zoom: 10
            });
        }
    }

    function updateCoordinates(latitude, longitude) {
        txtLatitude.value = latitude;
        txtLongitude.value = longitude;
    }
</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div id="mapContainer" style="width:600px; height:400px"></div>
                </div>
                <div class="col-md-6">
                    <div class="table-responsive" style="max-height: 300px; overflow-y: auto; max-width: auto;margin-left: 40px;">
                        <asp:GridView ID="GridData" runat="server" CssClass="table table-bordered table-striped table-dark table-sm">
                            <Columns>                            
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <%--neurologico y sistema nervioso--%>
            <div class="row">
                <div class="col-md-6 offset-md-6">
                    <div class="form-group">
                        <asp:TextBox ID="txt_latitude" runat="server" CssClass="form-control" style="visibility:hidden"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 offset-md-6">
                    <div class="form-group">
                        <asp:TextBox ID="txt_longitude" runat="server" CssClass="form-control" style="visibility:hidden"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
