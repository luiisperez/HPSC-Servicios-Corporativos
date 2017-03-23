<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visualizarequipos.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Empleados.gestion_equipos.visualizarequipos" %>

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
                        <li id="zonaequipos" runat="server">
                            
                        </li>
                        <li id="zonacontratos" runat="server">
                            <a href="#"><i class="fa fa-folder-open"></i> Contratos</a>
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
                                Lista de equipos 
                            </h1>
                        </div>
                    </div>
                    <div class="row">
                    <link rel="stylesheet" href="../../plugins/datatables/dataTables.bootstrap.css">

                    <div class="col-xs-12">
                        <div class="box">
                            <div class="box-body">
                                    <table id="tabla" class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>Serial</th>
                                                <th>N° de equipo</th>
                                                <th>Estatus</th>
                                                <th>Categoría</th>
                                                <th style="width:300px">Equipo</th>
                                                <th>Opciones</th>
                                            </tr>
                                        </thead>
                                            <tbody id="contenidotabla">
                                                 <asp:Repeater ID="repPeople" runat="server" OnItemCommand="repPeople_ItemCommand">
                                                    <ItemTemplate>
                                                            <tr id="<%# Eval("serial") %>">
                                                                <td><asp:Label ID="seriaeq" runat="server" Text='<%# Eval("serial") %>' ReadOnly="True" BorderStyle="None" /></td>
                                                                <td><%# Eval("numeroequipo") %></td>
                                                                <td><%# Eval("estatus") %></td>
                                                                <td><%# Eval("categoria") %></td>
                                                                <td><%# Eval("marca") %> <%# Eval("modelo") %></td>
                                                                <td style="text-align:center">
                                                                    <asp:ImageButton ID="Eliminar" runat="server" Text="Eliminar" ImageUrl="~/Vista/Common/img/eliminar.ico" Height="25px" Width="25px" ToolTip="Eliminar equipo" />
                                                                    <asp:ImageButton ID="Modificar" runat="server" Text="Eliminar" ImageUrl="~/Vista/Common/img/modificar.ico" Height="25px" Width="25px" ToolTip="Modificar equipo" />
                                                                </td>
                                                            </tr>              
                                                    </ItemTemplate>
                                                 </asp:Repeater>
                                            </tbody>  
                                        <tfoot>
                                            <tr>
                                                <th>Serial</th>
                                                <th>N° de equipo</th>
                                                <th>Estatus</th>
                                                <th>Categoría</th>
                                                <th>Equipo</th>
                                                <th>Opciones</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>
                    <!-- /.col -->
                </div>

                </div>
                <!-- /.container-fluid -->

            </div>
            <!-- /#page-wrapper -->

        </div>
        <!-- /#wrapper -->


   

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


