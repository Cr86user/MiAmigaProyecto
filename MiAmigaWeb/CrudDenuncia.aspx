<%@ Page Title="" Language="C#" MasterPageFile="~/SiteDenunciante.Master" AutoEventWireup="true" CodeBehind="CrudDenuncia.aspx.cs" Inherits="MiAmigaWeb.CrudDenuncia" %>
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
                    <asp:Button ID="btnObtenerUbicacion" runat="server" Text="Obtener Ubicación" OnClientClick="return obtenerUbicacion();" OnClick="btnObtenerUbicacion_Click" CssClass="btn btn-primary" />
                     <asp:Button ID="btnDenunciar" runat="server" Text="Denunciar" OnClick="btnDenunciar_Click"  CssClass="btn btn-warning" />
<asp:TextBox ID="txtLatitud" Text="-17.33048870919409" runat="server" CssClass="form-control" ReadOnly="true" style="display:none;"></asp:TextBox>
<asp:TextBox ID="txtLongitud" Text="-66.22542378547564" runat="server" CssClass="form-control" ReadOnly="true" style="display:none;"></asp:TextBox>
<asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly="true" style="display:none;"></asp:TextBox>
                      
 


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
    <script type="text/javascript">
        function obtenerUbicacion() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    var latitud = position.coords.latitude;
                    var longitud = position.coords.longitude;
                    document.getElementById('<%= txtLatitud.ClientID %>').value = latitud;
                document.getElementById('<%= txtLongitud.ClientID %>').value = longitud;
            });
                return false;
            } else {
                alert("Tu navegador no soporta la geolocalización.");
                return false;
            }
        }
    </script>
      <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
 <%-- <script>
      $(document).ready(function () {
          $.getScript("https://maps.googleapis.com/maps/api/js?key=&libraries=places", function () {
              var map = new google.maps.Map(document.getElementById('ModalMapPreview'), {
                  center: { lat: parseFloat($('#<%=txtLatitud.ClientID%>').val()), lng: parseFloat($('#<%=txtLongitud.ClientID%>').val()) },
                  zoom: 18
              });

              var marker = new google.maps.Marker({
                  position: { lat: parseFloat($('#<%=txtLatitud.ClientID%>').val()), lng: parseFloat($('#<%=txtLongitud.ClientID%>').val()) },
                  map: map,
                  draggable: true
              });

              google.maps.event.addListener(marker, 'dragend', function (event) {
                  var lat = event.latLng.lat();
                  var lng = event.latLng.lng();

                  $('#<%=txtLatitud.ClientID%>').val(lat);
                  $('#<%=txtLongitud.ClientID%>').val(lng);
              });

              google.maps.event.addListener(map, 'click', function (event) {
                  var lat = event.latLng.lat();
                  var lng = event.latLng.lng();

                  marker.setPosition({ lat: lat, lng: lng });

                  $('#<%=txtLatitud.ClientID%>').val(lat);
                  $('#<%=txtLongitud.ClientID%>').val(lng);
              });
          });
      });
  </script>--%>
</asp:Content>
