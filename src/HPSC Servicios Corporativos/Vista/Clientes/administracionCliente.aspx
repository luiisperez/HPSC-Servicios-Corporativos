<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administracionCliente.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Clientes.administracionCliente" %>

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
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/sb-admin.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="css/plugins/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script src="/Empleados/js/cargadorMenu.js"></script>
</head>

<body>

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
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"></i> <%= cliente.nombre %><b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            <a href="/Vista/Registro/modificardatoscliente.aspx"><i class="fa fa-fw fa-gear"></i> Actualizar datos</a>
                        </li>
                        <li class="divider"></li>
                        <li id="cerrarsesion" style="margin-left:20px">
                            <form id="cerrar" runat="server" >
                                <asp:LinkButton ID="sesioncerrar" runat="server" ForeColor="Black" Font-Underline="false" OnClick="sesioncerrar_Click"><i class="fa fa-fw fa-power-off"></i> Cerrar sesión</asp:LinkButton>
                            </form>
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

       

    </div>
    <!-- /#wrapper -->

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="js/plugins/morris/raphael.min.js"></script>
    <script src="js/plugins/morris/morris.min.js"></script>
    <script src="js/plugins/morris/morris-data.js"></script>

</body>

</html>
