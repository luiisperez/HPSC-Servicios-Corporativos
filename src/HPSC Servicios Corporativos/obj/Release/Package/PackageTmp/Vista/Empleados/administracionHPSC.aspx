<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administracionHPSC.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Empleados.administracionHPSC" %>

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
    </style>
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
                        <li id="cerrarsesion" style="margin-left:20px">
                            <form id="cerrar" runat="server" >
                                <asp:ScriptManager runat="server" ID="sm" EnablePageMethods="true">
                                </asp:ScriptManager>
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

        <div id="page-wrapper">

            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12" style="margin-top:-20px">
                        <h1 class="page-header" style="font-family:Raleway-Black">
                            <B>Bienvenido <%=emp.nombre%> <%=emp.apellido%></B>
                        </h1>
                    </div>
                </div>
                <!-- /.row -->
                <div class="row">
                    <div class="col-lg-12" style="margin-top:-40px">
                        <h3 class="page-header" style="font-family:Raleway-Black">
                            <B>Cantidad de casos registrados: </B>
                        </h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-folder-open fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge" id="casosregistrados" runat="server"></div>
                                        <div>Casos registrados</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="panel panel-yellow">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-wrench fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge" id="casosatendidos" runat="server"></div>
                                        <div>Casos atendidos</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-times-circle fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge" id="casosnoatendidos" runat="server"></div>
                                        <div>Casos sin atender</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-check-circle fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge" id="casosresueltos" runat="server"></div>
                                        <div>Casos resueltos</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                <!-- /.row -->

                
                <!-- /.row -->

                <div class="row">
                    <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-long-arrow-right fa-fw"></i> Cantidad de casos por tipo de servicio</h3>
                            </div>
                            <div class="panel-body">
                                <div id="pie-tipo"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-long-arrow-right fa-fw"></i> Cantidad de casos por urgencia</h3>
                            </div>
                            <div class="panel-body">
                                <div id="pie-urgencia"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><i class="fa fa-long-arrow-right fa-fw"></i> Cantidad de casos por impacto</h3>
                            </div>
                            <div class="panel-body">
                                <div id="pie-impacto"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->

            </div>
            <!-- /.container-fluid -->

        </div>
        </div>
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
    <script type="text/javascript">

       <%-- function validarnumequipo(sender, args) {
            if (document.getElementById('<%=numequipo.ClientID %>').value != "") {

                var num = document.getElementById('<%=numequipo.ClientID %>').value;
                PageMethods.FillFields(num, onSucess, onError);

                function onSucess(result) {
                    if (result === "No existe el número de producto colocado, por favor verifique") {
                        alert(result);
                        document.getElementById('<%=numequipo.ClientID %>').value = "";
                    } else {
                        var separar = result.split(";");
                        document.getElementById('<%=categoria.ClientID%>').value = separar[1];
                        document.getElementById('<%=marca.ClientID%>').value = separar[2];
                        document.getElementById('<%=modelo.ClientID%>').value = separar[3];

                    }
                }

                function onError(result) {
                    alert('Ha ocurrido un error, intente nuevamente');
                    document.getElementById('<%=numequipo.ClientID %>').value = "";
                }
            }
        }--%>
    </script>
    <script>
        var data = [
          { y: '2014', a: 50 }
            ],
        config = {
            data: data,
            xkey: 'y',
            ykeys: ['a'],
            labels: ['Casos'],
            fillOpacity: 0.6,
            hideHover: 'auto',
            behaveLikeLine: true,
            resize: true,
            pointFillColors: ['#ffffff'],
            pointStrokeColors: ['black'],
            lineColors: ['#337AB7']
        };
            Morris.Donut({
                element: 'pie-urgencia',
                data: [<%= dataurgencia%>]
            });
            Morris.Donut({
                element: 'pie-tipo',
                data: [<%= datatipo%>]
            });
            Morris.Donut({
                element: 'pie-impacto',
                data: [<%= dataimpacto%>]
            });
    </script>
</body>

</html>
