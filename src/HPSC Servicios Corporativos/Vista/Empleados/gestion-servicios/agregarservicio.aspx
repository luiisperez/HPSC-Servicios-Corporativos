<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarservicio.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Empleados.gestion_servicios.agregarservicio" %>

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
                                Agregar servicio
                            </h1>
                        </div>
                    </div>
                    <div class="row">
                    <link rel="stylesheet" href="../../plugins/datatables/dataTables.bootstrap.css">

                    <div class="col-xs-12">
                        <div class="box">
                            <div class="box-body">
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-12" style="margin-top:10px;margin-left:50px">
                                            <div class="col-xs-6">
                                                <label style="text-align:right">Nivel de servicio: </label>
				                                <input type="text" class="form-control" id="nivelservicio" runat="server" onblur="validarservicio()" maxlength="50" style="width:70%;height:30px">
                                            </div>
                                            <div class="col-xs-6">
                                                <label style="text-align:right">Tipo de servicio: </label>
                                                <asp:DropDownList ID="listadotiposerv" runat="server" class="form-control" Height="30px" Width="70%">
                                                    <asp:ListItem>Soporte reactivo</asp:ListItem>
                                                    <asp:ListItem>Soporte preventivo</asp:ListItem>
                                                    <asp:ListItem>Implementación</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                            <div class="col-xs-6">
                                                <label style="text-align:right">Tiempo de respuesta (horas): </label>
				                                <input type="number" class="form-control" id="tiemporespuesta" runat="server" maxlength="18" min="1" style="width:70%;height:30px" onblur="validartiemporesp()" value="1">
                                            </div>
                                            <div class="col-xs-6">
                                                <label style="text-align:right">¿Incluye días feriados?: </label>
                                                <asp:RadioButtonList ID="feriados_si_no" runat="server" Width="25%" RepeatDirection="Horizontal" TextAlign="Right" style="margin-top:3px">
                                                    <asp:ListItem Value="Si" Selected="True">Sí</asp:ListItem>
                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="margin-top:30px;margin-left:50px">
                                            <div class="col-xs-6">
                                                <label style="text-align:right">Días a la semana: </label>
                                                <asp:CheckBoxList ID="checkdias" runat="server" Height="30px" Width="70%" style="margin-left:25px">
                                                    <asp:ListItem>Lunes</asp:ListItem>
                                                    <asp:ListItem>Martes</asp:ListItem>
                                                    <asp:ListItem>Miércoles</asp:ListItem>
                                                    <asp:ListItem>Jueves</asp:ListItem>
                                                    <asp:ListItem>Viernes</asp:ListItem>
                                                    <asp:ListItem>Sábado</asp:ListItem>
                                                    <asp:ListItem>Domingo</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>
                                            <div class="col-xs-6">
                                                <label style="text-align:right">Cantidad de horas por día: </label>
				                                <input type="number" class="form-control" id="horasdia" runat="server" onblur="validarcantidadhoras()" min="1" maxlength="18" style="width:70%;height:30px" value="1">
                                            </div>
                                        </div>
                                    </div>
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
                                        <asp:updatepanel runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="aceptar" runat="server" Text="Aceptar" CssClass="btn-success" OnClick="aceptar_Click" />
                                            </ContentTemplate>
                                        </asp:updatepanel>
                                    
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
    <script type="text/javascript">

        <%--function validarnumequipo(sender, args) {
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

       function validarservicio(sender, args) {
           var nombre = document.getElementById('<%=nivelservicio.ClientID%>').value;
            if (/[^a-z0-9 áéíóúñÁÉÍÓÚ]/gi.test(nombre)) {
                alert("Existen caracteres especiales no permitidos");
                document.getElementById('<%=nivelservicio.ClientID%>').value = '';
            } else {
                var pruebaespacio = CheckForRepeat(nombre, " ");
                if ((pruebaespacio == 1)) {
                    alert("Existen espacios consecutivos");
                    document.getElementById('<%=nivelservicio.ClientID%>').value = '';
                }
            }
       }

       function validartiemporesp() {
           var variable = document.getElementById('<%=tiemporespuesta.ClientID%>').value;
           if (variable != '') {
               if (variable <= 0) {
                   alert("No puedes colocar numeros negativos o cero");
                   document.getElementById('<%=tiemporespuesta.ClientID%>').value = "1";
               }
           } else {
               document.getElementById('<%=tiemporespuesta.ClientID%>').value = "1";
           }
       }

       <%--function validarcantidaddias() {
           var variable = document.getElementById('<%=diassemana.ClientID%>').value;
           if (variable != '') {
               if (variable <= 0) {
                   alert("No puedes colocar numeros negativos o cero");
                   document.getElementById('<%=diassemana.ClientID%>').value = "1";
               }
           } else {
               document.getElementById('<%=tiemporespuesta.ClientID%>').value = "1";
           }
       }--%>

       function validarcantidadhoras() {
           var variable = document.getElementById('<%=horasdia.ClientID%>').value;
           if (variable != '') {
               if (variable <= 0) {
                   alert("No puedes colocar numeros negativos o cero");
                   document.getElementById('<%=horasdia.ClientID%>').value = "1";
               } else if (variable > 24) {
                   alert("No puedes colorcar mas de 24 horas");
                   document.getElementById('<%=horasdia.ClientID%>').value = "1";
               }
           } else {
               document.getElementById('<%=tiemporespuesta.ClientID%>').value = "1";
           }
       }
       
    </script>

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
</body>

</html>
