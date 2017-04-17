<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarincidente.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Clientes.gestion_incidentes.agregarincidente" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    
    <link rel="icon" href="/Vista/Common/img/hpsc-logo.ico" type="image/x-icon">
    <title>HPSC Servicios Corporativos</title>

    <!-- Bootstrap Core CSS -->
    <link href="/Vista/Empleados/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="/Vista/Empleados/css/sb-admin.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="/Vista/Empleados/css/plugins/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="/Vista/Empleados/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body>
    <form id ="form" runat="server">
        <div id="wrapper">

            <!-- Navigation -->
            <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                <a class="navbar-brand" href="/Vista/Clientes/administracionCliente.aspx">Zona administrativa para clientes</a>
                </div>
                <!-- Top Menu Items -->
                <ul class="nav navbar-right top-nav">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"></i> <%=cliente.nombre%> <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="/Vista/Registro/modificardatoscliente.aspx"><i class="fa fa-fw fa-gear"></i> Actualizar datos</a>
                            </li>
                            <li class="divider"></li>
                            <li id="cerrarsesion" style="">
                                <asp:LinkButton ID="sesioncerrar" runat="server" ForeColor="Black" Font-Underline="false" OnClick="sesioncerrar_Click"><i class="fa fa-fw fa-power-off"></i> Cerrar sesión</asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                </ul>
                <!-- Sidebar Menu Items - These collapse to the responsive navigation menu on small screens -->
                <script>
                    function privilegiosinsuficientes() {
                        alert("No posees los permisos necesarios para acceder a este zona");
                    }
                </script>
                <div class="collapse navbar-collapse navbar-ex1-collapse">
                    <ul class="nav navbar-nav side-nav">
                        <li id="zonaequipos" runat="server">
                            <a href="javascript:;" data-toggle="collapse" data-target="#equipos" id="equipment" runat="server"><i class="fa fa-laptop"></i> Equipos <i class="fa fa-fw fa-caret-down"></i></a>
                            <ul id="equipos" class="collapse">
                               <li> 
                                    <a id="visualizarequipos" href="/Vista/Clientes/gestion-equipos/misequipos.aspx">Visualizar</a>
                               </li> 
                               <li>
                                     <a href="/Vista/Clientes/gestion-equipos/solicitarequipo.aspx">Solicitar equipo</a>
                               </li>  
                            </ul>  
                        </li>
                        <li id="zonacontratos" runat="server">
                            <a href="/Vista/Clientes/gestion-contratos/miscontratos.aspx"><i class="fa fa-folder-open"></i> Contratos</a>
                        </li>
                        <li id="zonacontactos" runat="server">
                            <a href="javascript:;" data-toggle="collapse" data-target="#contactos" id="contact" runat="server"><i class="fa fa-user"></i> Personal de contacto <i class="fa fa-fw fa-caret-down"></i></a>
                            <ul id="contactos" class="collapse">
                               <li> 
                                    <a href="/Vista/Clientes/gestion-contactos/personalcontacto.aspx">Agregar</a>
                               </li> 
                               <li>
                                     <a href="/Vista/Clientes/gestion-contactos/visualizarpersonascontacto.aspx">Visualizar</a>
                               </li>  
                            </ul>  
                        </li>
                        <li id="zonaincidentes" runat="server">
                            <a href="#"><i class="fa fa fa-warning"></i> Incidentes</a>
                        </li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </nav>

            <div id="page-wrapper" style="width:98%">

                <div id="contenedor" class="container-fluid" style="height:100%; width:95%">

                    <!-- Page Heading -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">
                                Reportar incidente
                            </h1>
                        </div>
                    </div>
                    <div class="row">
                    <link rel="stylesheet" href="../../plugins/datatables/dataTables.bootstrap.css">

                    <div class="col-xs-12">
                        <div class="box">
                            <div class="box-body">
                                <h3 style="margin-top:5px; margin-bottom:10px">Detalles del incidente</h3>
                                <div class="row">
                                    <div class="col-md-12" style="margin-top:10px;margin-left:50px">
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Seriales:  </label>
                                            <input list="listado_equipos" name="numequipo" runat="server" id="numequipo" style="height:30px; width:70%" autocomplete="off" class="form-control" onblur="validarnumequipo()">
                                            <datalist id="listado_equipos" runat="server">
                                                
                                            </datalist>
                                            <asp:TextBox ID="correo" runat="server" Height="0px" Width="0px" BorderStyle="None"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Detalles del contrato <i class="fa fa-info-circle" id="info"></i></label>
                                            <asp:TextBox ID="idservicio" runat="server" Height="0px" Width="0px" BorderStyle="None"></asp:TextBox>
                                            <asp:TextBox ID="idcontrato" runat="server" Height="0px" Width="0px" BorderStyle="None"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Impacto: </label>
                                            <asp:DropDownList ID="impacto" runat="server" style="height:30px; width:70%" class="form-control">
                                                <asp:ListItem>Significativo</asp:ListItem>
                                                <asp:ListItem>Moderado</asp:ListItem>
                                                <asp:ListItem>Crítico</asp:ListItem>
                                                <asp:ListItem>Menor</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Urgencia: </label>
                                            <asp:DropDownList ID="urgencia" runat="server" style="height:30px; width:70%" class="form-control">
                                                <asp:ListItem>Crítica</asp:ListItem>
                                                <asp:ListItem>Alta</asp:ListItem>
                                                <asp:ListItem>Media</asp:ListItem>
                                                <asp:ListItem>Baja</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                        <div class="col-xs-12">
                                            <label style="text-align:right">Dirección: </label>
                                            <textarea runat="server" id="direccion" rows="0" cols="50" style="height:150px; width:85%; resize:none" class="form-control"></textarea>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                        <div class="col-xs-12">
                                            <label style="text-align:right">Descripción de incidente: </label>
                                            <textarea runat="server" id="descripcion" rows="10" cols="50" style="height:150px; width:85%; resize:none" class="form-control"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="box-body">
                                <h3 style="margin-top:5px; margin-bottom:10px">Personas de contacto</h3>
                                <div class="row">
                                    <div class="col-md-12" style="margin-top:10px;margin-left:50px">
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Correo del contacto principal: </label>
				                            <input type="text" class="form-control" id="correoprincipal" runat="server" onblur="validarcorreo()" maxlength="50" style="width:70%;height:30px">
                                        </div>
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Nombre completo: </label>
				                            <input type="text" class="form-control" id="nombrepricipal" runat="server" maxlength="50" style="width:70%;height:30px" disabled="disabled">
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Correo del contacto secundario: </label>
				                            <input type="text" class="form-control" id="correosecundario" runat="server" onblur="validarcorreosec()" maxlength="50" style="width:70%;height:30px">
                                        </div>
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Nombre completo: </label>
				                            <input type="text" class="form-control" id="nombresecundario" runat="server" maxlength="50" style="width:70%;height:30px" disabled="disabled">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                            <!-- /.box-body -->
                        </div>
                        <div style="margin-top:10px;text-align:center">
                            <style>
                                #aceptar {
                                    background-color: #4CAF50;
                                    color: white;
                                    padding: 14px 20px;
                                    margin: 8px 0;
                                    margin-top:60px;
                                    margin-left:-30px;
                                    border: none;
                                    cursor: pointer;
                                    width: 125px;
                                    border-radius: 15px;
                                    font-family: 'Raleway SemiBold';
                                }
                            </style>
                            <asp:ScriptManager runat="server" ID="sm" EnablePageMethods="true">
                            </asp:ScriptManager>
                            <asp:Button ID="aceptar" runat="server" Text="Aceptar" CssClass="btn-success" OnClick="aceptar_Click" Enabled="False"/>
                        </div>
                        <!-- /.box -->
                    </div>
                    <!-- /.col -->
                </div>

                </div>
                <!-- /.container-fluid -->

            </div>
            <!-- /#page-wrapper -->
        <!-- /#wrapper -->

        <script type="text/javascript">

            function validarnumequipo() {
                if (document.getElementById('<%=numequipo.ClientID %>').value != "") {
                    var num = document.getElementById('<%=numequipo.ClientID %>').value;
                    var correo = document.getElementById('<%=correo.ClientID %>').value;
                    PageMethods.FillFields(num, correo, onSucess, onError);

                    function onSucess(result) {
                        if (result === "No existe el serial colocado, por favor verifique") {
                            alert(result);
                            $('#info').attr('Title', '');
                            document.getElementById('<%=numequipo.ClientID %>').value = "";
                        } else if (result === "No se pudo realizar la búsqueda, por favor intente nuevamente") {
                            alert(result);
                            $('#info').attr('Title', '');
                            document.getElementById('<%=numequipo.ClientID %>').value = "";
                        } else if (result === "No tiene ningún contrato vigente para registrar el incidente") {
                            alert(result);
                            $('#info').attr('Title', '');
                            document.getElementById('<%=numequipo.ClientID %>').value = "";
                        } else {
                            var separar = result.split(";");
                            var mensaje = "Datos del servicio: \n - Nivel de servicio: " + separar[2] + " " + separar[3] + " hora(s) X " + separar[4] + " día(s) \n - Tipo de servicio: " + separar[5] + " \n - Tiempo de respuesta: " + separar[6] + "hora(s) \n - ¿Incluye feriados?: " + separar[7] + " \n - Días de trabajo: " + separar[9];
                            $('#info').attr('Title', mensaje);
                            document.getElementById('<%=idcontrato.ClientID %>').value = separar[8];
                            document.getElementById('<%=idservicio.ClientID %>').value = separar[1];
                            document.getElementById('<%=direccion.ClientID %>').value = separar[10];
                        }
                    }

                    function onError(result) {
                        alert('Ha ocurrido un error, intente nuevamente');
                        $('#info').attr('Title', '');
                        document.getElementById('<%=numequipo.ClientID %>').value = "";
                    }
                } else {
                    $('#info').attr('Title', '');
                }
            }
        </script>
        <script>
            function validateEmail(email) {
                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(email);
            }

            function validarcorreo(sender, args) {
                var email = document.getElementById('<%=correoprincipal.ClientID%>').value;
                if (email != '') {
                    if (!validateEmail(email)) {
                        alert(email + " no es un correo valido");
                        document.getElementById('<%=correoprincipal.ClientID%>').value = '';
                    }
                }
            }

            function validarcorreosec(sender, args) {
                var email = document.getElementById('<%=correosecundario.ClientID%>').value;
                if (email != '') {
                    if (!validateEmail(email)) {
                        alert(email + " no es un correo valido");
                        document.getElementById('<%=correosecundario.ClientID%>').value = '';
                    }
                }
            }

            function CheckForRepeat(originalString, charToCheck) {
                var repeatCount = 0;
                for (var i = 0; i < originalString.length; i++) {
                    if (originalString.charAt(i) == charToCheck) {
                        repeatCount++;
                    } else {
                        repeatCount = 0;
                    }
                    if (repeatCount == 2) {
                        return 1;
                    }
                }
                return 0;
            }
        </script>

   

    </form>
    <!-- jQuery -->
    <script src="/Vista/Empleados/js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="/Vista/Empleados/js/bootstrap.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="/Vista/Empleados/js/plugins/morris/raphael.min.js"></script>
    <script src="/Vista/Empleados/js/plugins/morris/morris.min.js"></script>
    <script src="/Vista/Empleados/js/plugins/morris/morris-data.js"></script>

    <!-- DataTables -->
    <script src="/Vista/Common/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/Vista/Common/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script>table = $('#tabla').DataTable();</script>'
</body>

</html>



