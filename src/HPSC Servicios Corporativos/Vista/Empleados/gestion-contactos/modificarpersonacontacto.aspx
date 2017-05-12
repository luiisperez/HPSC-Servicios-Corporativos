<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modificarpersonacontacto.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Empleados.gestion_contactos.modificarpersonacontacto" %>

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
    <form id="formulario" runat="server">
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
                    <a class="navbar-brand" href="/Vista/Empleados/administracionHPSC.aspx">Centro administrativo de HPSC Servicios Corporativos</a>
                </div>
                <!-- Top Menu Items -->
                <ul class="nav navbar-right top-nav">
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"></i> <%=emp.nombre%> <%=emp.apellido%><b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="/Vista/Registro/modificardatosempleado.aspx"><i class="fa fa-fw fa-gear"></i> Actualizar datos</a>
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
                        <li id="zonausuarios" runat="server">
                        
                        </li>
                        <li id="zonaclientes" runat="server">
                            
                        </li>
                        <li id="zonaproductos" runat="server">
                            
                        </li>
                        <li id="zonaequipos" runat="server">
                            
                        </li>
                        <li id="zonacontratos" runat="server">
                            
                        </li>
                        <li id="zonaasignacionservicios" runat="server">
                            
                        </li>
                        <li id="zonapersonascontacto" runat="server">
                            
                        </li>
                        <li id="zonaincidentes" runat="server">
                             
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
                                Modificar equipo
                            </h1>
                        </div>
                    </div>
                    <div class="row">
                    <link rel="stylesheet" href="../../plugins/datatables/dataTables.bootstrap.css">

                       <div class="col-xs-12">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-12" style="margin-top:10px;margin-left:50px">
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Nombre: </label>
				                            <input type="text" class="form-control" id="nombre" runat="server" onblur="validarnombre()" maxlength="50" style="width:70%;height:30px">
                                        </div>
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Apellido: </label>
				                            <input type="text" class="form-control" id="apellido" runat="server" onblur="validarapellido()" maxlength="50" style="width:70%;height:30px">
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Correo: </label>
				                            <input type="text" class="form-control" id="correo" runat="server" onblur="validarcorreo()" maxlength="50" style="width:70%;height:30px">
                                        </div>
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Teléfono local: </label>
				                            <input type="text" class="form-control" id="telflocal" runat="server" onblur="validarlocal()" maxlength="18" style="width:70%;height:30px">
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Teléfono móvil: </label>
				                            <input type="text" class="form-control" id="telfmovil" runat="server" onblur="validarmovil()" maxlength="18" style="width:70%;height:30px">
                                        </div>
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Estatus: </label>
				                            <asp:DropDownList ID="estatus" runat="server" class="form-control" style="width:70%;height:30px">
                                                <asp:ListItem>Activo</asp:ListItem>
                                                <asp:ListItem>Eliminado</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                        <div class="col-xs-6">
                                            <label style="text-align:right">Clientes:  </label>
                                            <asp:DropDownList ID="listadoclientes" runat="server" Height="30px" Width="70%" class="form-control"></asp:DropDownList>
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
                                #cancelar {
                                    background-color: red;
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
                                <asp:updatepanel runat="server">
                                    <ContentTemplate>
                                        <div class="col-xs-6">
                                            <asp:Button ID="aceptar" runat="server" Text="Aceptar" CssClass="btn-success" OnClick="aceptar_Click" />
                                        </div>
                                        <div class="col-xs-6">
                                            <asp:Button ID="cancelar" runat="server" Text="Cancelar" CssClass="btn-success" OnClick="cancelar_Click"/>
                                        </div>
                                    </ContentTemplate>
                                </asp:updatepanel>
                        </div>
                        <!-- /.box -->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.container-fluid -->

            </div>
            <!-- /#page-wrapper -->
        <!-- /#wrapper -->


        <script>
            function validateEmail(email) {
                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(email);
            }

            function validarcorreo(sender, args) {
                var email = document.getElementById('<%=correo.ClientID%>').value;
                if (email != '') {
                    if (!validateEmail(email)) {
                        alert(email + " no es un correo valido");
                        document.getElementById('<%=correo.ClientID%>').value = '';
                    }
                }
            }

            function validarnombre(sender, args) {
                var nombre = document.getElementById('<%=nombre.ClientID%>').value;
                if (/[^a-z0-9 áéíóúñÁÉÍÓÚ]/gi.test(nombre)) {
                    alert("No puede contener caracteres especiales");
                    document.getElementById('<%=nombre.ClientID%>').value = '';
                }
            }

            function validarapellido(sender, args) {
                var nombre = document.getElementById('<%=apellido.ClientID%>').value;
                if (/[^a-z0-9 áéíóúñÁÉÍÓÚ]/gi.test(nombre)) {
                    alert("No puede contener caracteres especiales");
                    document.getElementById('<%=apellido.ClientID%>').value = '';
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


            function validarlocal(sender, args) {
                var nombre = document.getElementById('<%=telflocal.ClientID%>').value;
                if (/[^0-9 -+()#]/gi.test(nombre)) {
                    alert("No tiene formato telefónico");
                    document.getElementById('<%=telflocal.ClientID%>').value = '';
                } else {
                    var pruebaguion = CheckForRepeat(nombre, "-");
                    var pruebamas = CheckForRepeat(nombre, "+");
                    var pruebapder = CheckForRepeat(nombre, "(");
                    var pruebapizq = CheckForRepeat(nombre, ")");
                    var pruebanum = CheckForRepeat(nombre, "#");
                    if ((pruebamas == 1) || (pruebapder == 1) || (pruebapizq == 1) || (pruebaguion == 1) || (pruebanum == 1)) {
                        alert("Existen caracteres especiales consecutivos");
                        document.getElementById('<%=telflocal.ClientID%>').value = '';
                    }
                }
            }

            function validarmovil(sender, args) {
                var nombre = document.getElementById('<%=telfmovil.ClientID%>').value;
                if (/[^0-9 -+()#]/gi.test(nombre)) {
                    alert("No tiene formato telefónico");
                    document.getElementById('<%=telfmovil.ClientID%>').value = '';
                } else {
                    var pruebaguion = CheckForRepeat(nombre, "-");
                    var pruebamas = CheckForRepeat(nombre, "+");
                    var pruebapder = CheckForRepeat(nombre, "(");
                    var pruebapizq = CheckForRepeat(nombre, ")");
                    var pruebanum = CheckForRepeat(nombre, "#");
                    if ((pruebamas == 1) || (pruebapder == 1) || (pruebapizq == 1) || (pruebaguion == 1) || (pruebanum == 1)) {
                        alert("Existen caracteres especiales consecutivos");
                        document.getElementById('<%=telfmovil.ClientID%>').value = '';
                    }
                }
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

