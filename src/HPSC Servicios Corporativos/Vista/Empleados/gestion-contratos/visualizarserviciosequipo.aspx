<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visualizarserviciosequipo.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Empleados.gestion_asignacion_servicios.visualizarserviciosequipo" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <style>
        header .HPSC {
            font-family:Raleway-Black;
            font-size: 3em;
            font-weight: 900;
            line-height: 1.6em;
            display: inline-block;
            font-size: 300%;
         }
        @font-face{
            font-family: "Raleway-Black";
            src: url("/Vista/Common/Raleway-Black.ttf");
            url("/Vista/Common/Raleway-Black.ttf");
        }
        @font-face{
            font-family: "Raleway-Semibold";
            src: url("/Vista/Common/Raleway-SemiBold.ttf");
            url("/Vista/Common/Raleway-SemiBold.ttf");
        }
        @font-face{
            font-family: "Raleway-Medium";
            src: url("/Vista/Common/Raleway-Medium.ttf");
            url("/Vista/Common/Raleway-Medium.ttf");
        }
    </style>

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
                                Lista de servicios por equipo
                            </h1>
                        </div>
                        <div class="col-md-12" style="margin-top:10px;margin-bottom:50px">
                            <div class="col-xs-6">
                                <label style="text-align:right">Serial: </label>
                                <input list="listado_seriales" name="listado" runat="server" id="equipoinput" style="height:30px; width:70%" autocomplete="off" class="form-control">
                                <datalist id="listado_seriales" runat="server">
                                                
                                </datalist>
                            </div>
                            <div class="col-xs-6">
                                <style>
                                        #aceptar {
                                            background-color: #4CAF50;
                                            color: white;
                                            margin: 8px 0;
                                            margin-left:-30%;
                                            border: none;
                                            cursor: pointer;
                                            margin-top:22px;
                                            width: 125px;
                                            height: 35px;
                                            border-radius: 10px;
                                            font-family: 'Raleway-Semibold';
                                        }
                                    </style>
                                    <asp:Button ID="aceptar" runat="server" Text="Aceptar" CssClass="btn-success" OnClick="aceptar_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            
                        </div>
                    </div>
                    <div class="row">
                    <link rel="stylesheet" href="../../plugins/datatables/dataTables.bootstrap.css">

                    <div class="col-xs-12">
                        <div class="box">
                            <div class="box-body">
                                <div class="table-responsive"> 
                                    <table id="tabla" class="table table-bordered table-striped table-hover dt-responsive">
                                        <thead>
                                            <tr>
                                                <th style="width:120px">Identificador del contrato</th>
                                                <th style="width:200px">Identificador del servicio</th>
                                                <th style="width:150px">Estatus</th>
                                                <th style="width:130px">Fecha de inicio</th>
                                                <th style="width:120px">Fecha de finalización</th>
                                            </tr>
                                        </thead>
                                            <tbody id="contenidotabla">
                                                 <asp:Repeater ID="repPeople" runat="server" OnItemCommand="repPeople_ItemCommand">
                                                    <ItemTemplate>
                                                            <tr id="<%# Eval("identificadorservicioequipo") %>">
                                                                <td><asp:Label ID="identificador" runat="server" Text='<%# Eval("identificadorservicioequipo") %>' ReadOnly="True" BorderStyle="None" /></td>
                                                                <td><asp:Label ID="id" runat="server" Text='<%# Eval("identificador") %>' ReadOnly="True" BorderStyle="None" /> <i class="fa fa-info-circle" title="Datos del servicio:
- Nivel de servicio: <%# Eval("nivelservicio") %> <%# Eval("canthoras") %> hora(s) X <%# Eval("cantdias") %> día(s)
- Tipo de servicio: <%# Eval("tiposervicio") %>
- Tiempo de respuesta: <%# Eval("tiemporespuesta") %> hora(s)
- ¿Incluye feriados?: <%# Eval("feriado") %>"></i>
                                                                </td>
                                                                <td><%# Eval("estatus") %></td>
                                                                <td><%# Convert.ToDateTime(Eval("fechaini")).ToString("dd/MM/yyyy") %></td>
                                                                <td><%# Convert.ToDateTime(Eval("fechafin")).ToString("dd/MM/yyyy") %></td>
                                                            </tr>              
                                                    </ItemTemplate>
                                                 </asp:Repeater>
                                            </tbody>  
                                        <tfoot>
                                            <tr>
                                                <th>Identificador del contrato</th>
                                                <th>Identificador del servicio</th>
                                                <th>Estatus</th>
                                                <th>Fecha de inicio</th>
                                                <th>Fecha de finalización</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
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
    <script>table = $('#tabla').DataTable();</script>
    
<script>
    $(document).keydown(function (event) {
        if (event.keyCode == 123) {
            return false;
        }
        else if (event.ctrlKey && event.shiftKey && event.keyCode == 73) {
            return false;  //Prevent from ctrl+shift+i
        }
    });

    $(document).on("contextmenu", function (e) {
        e.preventDefault();
    }); //PREVIENE F12, CTRL+SHIFT+I Y CLICK DERECHO
</script>
</body>

</html>
