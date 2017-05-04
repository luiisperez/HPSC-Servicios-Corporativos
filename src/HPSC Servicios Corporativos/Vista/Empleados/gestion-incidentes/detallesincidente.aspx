﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detallesincidente.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Empleados.gestion_incidentes.detallesincidente" %>

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
    <style>
        label.accordion {
            background-color: #eee;
            color: #444;
            cursor: pointer;
            padding: 18px;
            width: 100%;
            border: none;
            text-align: left;
            outline: none;
            font-size: 15px;
            transition: 0.4s;
        }

        label.accordion.active, label.accordion:hover {
            background-color: #ddd;
        }

        label.accordion:after {
            content: '\002B';
            color: #777;
            font-weight: bold;
            float: right;
            margin-left: 5px;
        }

        label.accordion.active:after {
            content: "\2212";
        }

        div.panel {
            padding: 0 18px;
            background-color: white;
            max-height: 0;
            overflow: hidden;
            transition: max-height 0.2s ease-out;
        }
    </style>
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
                                Datos del incidente <%= incidente %>
                            </h1>
                        </div>
                    </div>
                    <div class="row">
                        <link rel="stylesheet" href="../../plugins/datatables/dataTables.bootstrap.css">

                        <div class="col-xs-12">
                            <div class="box">
                                <div class="box-body">
                                    <label class="accordion" >Datos del incidente</label>
                                    <div class="panel" id="accordion_incidente" runat="server">
                                        <div class=col-lg-12 style=margin-top:20px;font-size:15px> 
                                            <div class=col-md-4> 
                                                <style>
                                                    .padding {
                                                        padding:.5em;
                                                    }
                                                </style>
                                                <label> <u>Fecha de registro: </u></label>
                                                <asp:TextBox ID="fecharegistro" runat="server" class="form-control"  Enabled="False" Height="30px" Width="100%" CssClass="padding"></asp:TextBox>
                                            </div> 
                                            <div class=col-md-4> 
                                                <label> <u>Fecha de compromiso: </u></label>
                                                <asp:TextBox ID="fechacompromiso" runat="server" class="form-control" Enabled="False" Height="30px" Width="100%" CssClass="padding"></asp:TextBox>
                                            </div> 
                                            <div class=col-md-4> 
                                                <label> <u>Fecha de requerida: </u></label>
                                                <asp:TextBox ID="fecharequerida" runat="server" class="form-control" Enabled="False" Height="30px" Width="100%" CssClass="padding"></asp:TextBox>
                                            </div> 
                                        </div> 
                                        <div class=col-lg-12 style=margin-top:20px;font-size:15px> 
                                            <div class=col-md-4> 
                                                <label> <u>Fecha de atención: </u></label>
                                                <input id="fechaatencio" runat="server" type='datetime-local' max="2100-12-31" class="form-control" oninvalid="alert('Debe colocar una fecha de inicio válida');setCustomValidity(' ')">
                                            </div> 
                                            <div class=col-md-4> 
                                                <label> <u>Fecha de conclusión: </u></label>
                                                <input id="fechaconclusion" runat="server" type='datetime-local' max="2100-12-31" class="form-control" oninvalid="alert('Debe colocar una fecha de inicio válida');setCustomValidity(' ')">
                                            </div> 
                                            <div class=col-md-4> 
                                                <style>
                                                    .rbl input[type="radio"]
                                                    {
                                                        margin-left: 10px;
                                                        margin-right: 1px;
                                                    }
                                                </style>
                                                <asp:ScriptManager runat="server" ID="sm">
                                                </asp:ScriptManager> 
                                                <asp:updatepanel runat="server">
                                                    <ContentTemplate>
                                                        <label> <u>Asignado a: </u></label> <asp:RadioButtonList ID="tipoasignado" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="rbl" RepeatLayout="Flow" OnSelectedIndexChanged="tipoasignado_SelectedIndexChanged">
                                                            <asp:ListItem>Empleado</asp:ListItem>
                                                            <asp:ListItem>Aliado</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:DropDownList ID="aliado_empleado" runat="server" class="form-control" Height="30px" Width="100%"> 

                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:updatepanel>
                                            </div> 
                                        </div> 
                                        <div class=col-lg-12 style=margin-top:20px;font-size:15px> 
                                            <div class=col-md-4> 
                                                <label> <u>Estatus: </u></label>
                                                <asp:DropDownList ID="estatus" runat="server" class="form-control" Height="30px" Width="100%">
                                                    <asp:ListItem>Abierto</asp:ListItem>
                                                    <asp:ListItem>Asignado</asp:ListItem>
                                                    <asp:ListItem>En sitio</asp:ListItem>
                                                    <asp:ListItem>Espera de partes</asp:ListItem>
                                                    <asp:ListItem>Monitoreo</asp:ListItem>
                                                    <asp:ListItem>Atendido</asp:ListItem>
                                                    <asp:ListItem>Cancelado</asp:ListItem>
                                                </asp:DropDownList>
                                            </div> 
                                            <div class=col-md-4> 
                                                <label> <u>Impacto: </u></label>
                                                <asp:DropDownList ID="impacto" runat="server" class="form-control" Height="30px" Width="100%">
                                                    <asp:ListItem>Significativo</asp:ListItem>
                                                    <asp:ListItem>Moderado</asp:ListItem>
                                                    <asp:ListItem>Crítico</asp:ListItem>
                                                    <asp:ListItem>Menor</asp:ListItem>
                                                </asp:DropDownList>
                                            </div> 
                                            <div class=col-md-4> 
                                                <label> <u>Urgencia: </u></label>
                                                <asp:DropDownList ID="urgencia" runat="server" class="form-control" Height="30px" Width="100%">
                                                    <asp:ListItem>Crítica</asp:ListItem>
                                                    <asp:ListItem>Alta</asp:ListItem>
                                                    <asp:ListItem>Media</asp:ListItem>
                                                    <asp:ListItem>Baja</asp:ListItem>
                                                </asp:DropDownList>
                                            </div> 
                                        </div> 
                                        <div class=col-lg-12 style=margin-top:20px;font-size:15px> 
                                            <div class=col-md-4> 
                                                <label> <u>Tipo de servicio: </u></label>
                                                <asp:TextBox ID="tiposerv" runat="server" class="form-control" Enabled="False" Height="30px" Width="100%" CssClass="padding"></asp:TextBox>
                                            </div> 
                                        </div> 
                                        <div class=col-lg-12 style=margin-top:20px;font-size:15px;margin-left:15px> 
                                            <label> <u>Dirección: </u></label>
                                            <asp:Label ID="direccion" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                        </div> 
                                        <div class=col-lg-12 style=margin-top:20px;font-size:15px;margin-left:15px> 
                                            <label> <u>Descripción: </u></label>
                                            <asp:Label ID="descripcion" runat="server" Text="Label" Font-Bold="True"></asp:Label>
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
                                        }
                                    </style>
                                    <asp:Button ID="aceptar" runat="server" Text="Aceptar" CssClass="btn-success" OnClick="aceptar_Click" />
                                </div>
                                    </div>

                                    <label class="accordion">Datos del equipo</label>
                                    <div class="panel" id="accordion_equipo" runat="server">

                                    </div>

                                    <label class="accordion">Datos de personas de contacto</label>
                                    <div class="panel" id="accordion_contacto" runat="server">

                                    </div>

                                    <label class="accordion">Datos del servicio</label>
                                    <div class="panel" id="accordion_servicio" runat="server">

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
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd
        }
        if (mm < 10) {
            mm = '0' + mm
        }

        today = yyyy + '-' + mm + '-' + dd;
        document.getElementById("fechaatencion").setAttribute("min", today);
        document.getElementById("fechaconclusion").setAttribute("min", today);
    </script>


    <script>
        var acc = document.getElementsByClassName("accordion");
        var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].onclick = function () {
                this.classList.toggle("active");
                var panel = this.nextElementSibling;
                if (panel.style.maxHeight) {
                    panel.style.maxHeight = null;
                } else {
                    panel.style.maxHeight = panel.scrollHeight + "px";
                }
            }
        }
    </script>

</body>

</html>

