<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Index.registro" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <link rel="icon" href="/Vista/Common/img/hpsc-logo.ico" type="image/x-icon">
    <title>HPSC Servicios Corporativos</title>
    <!-- Bootstrap Core CSS -->
    <link href="assets/css/bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css">
    <!-- Retina.js - Load first for faster HQ mobile images. -->
    <script src="assets/js/plugins/retina/retina.min.js"></script>
    <!-- Font Awesome -->
    <link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- Default Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,100,100italic,300,300italic,400italic,500,500italic,700,700italic,900,900italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Raleway:400,100,200,300,600,500,700,800,900' rel='stylesheet' type='text/css'>
    <!-- Modern Style Fonts (Include these is you are using body.modern!) -->
    <link href='http://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Cardo:400,400italic,700' rel='stylesheet' type='text/css'>
    <!-- Vintage Style Fonts (Include these if you are using body.vintage!) -->
    <link href='http://fonts.googleapis.com/css?family=Sanchez:400italic,400' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Cardo:400,400italic,700' rel='stylesheet' type='text/css'>
    <!-- Plugin CSS -->
    <link href="assets/css/plugins/owl-carousel/owl.carousel.css" rel="stylesheet" type="text/css">
    <link href="assets/css/plugins/owl-carousel/owl.theme.css" rel="stylesheet" type="text/css">
    <link href="assets/css/plugins/owl-carousel/owl.transitions.css" rel="stylesheet" type="text/css">
    <link href="assets/css/plugins/magnific-popup.css" rel="stylesheet" type="text/css">
    <link href="assets/css/plugins/background.css" rel="stylesheet" type="text/css">
    <link href="assets/css/plugins/animate.css" rel="stylesheet" type="text/css">
    <!-- Vitality Theme CSS -->
    <!-- Uncomment the color scheme you want to use. -->
    <link href="assets/css/hpsc.css" rel="stylesheet" type="text/css">
    <!-- <link href="assets/css/vitality-aqua.css" rel="stylesheet" type="text/css"> -->
    <!-- <link href="assets/css/vitality-blue.css" rel="stylesheet" type="text/css"> -->
    <!-- <link href="assets/css/vitality-green.css" rel="stylesheet" type="text/css"> -->
    <!-- <link href="assets/css/vitality-orange.css" rel="stylesheet" type="text/css"> -->
    <!-- <link href="assets/css/vitality-pink.css" rel="stylesheet" type="text/css"> -->
    <!-- <link href="assets/css/vitality-purple.css" rel="stylesheet" type="text/css"> -->
    <!-- <link href="assets/css/vitality-tan.css" rel="stylesheet" type="text/css"> -->
    <!-- <link href="assets/css/vitality-turquoise.css" rel="stylesheet" type="text/css"> -->
    <!-- <link href="assets/css/vitality-yellow.css" rel="stylesheet" type="text/css"> -->
    <!-- IE8 support for HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>
<!-- Alternate Body Classes: .modern and .vintage -->

<body id="page-top">

    <!-- Navigation -->
    <!-- Note: navbar-default and navbar-inverse are both supported with this theme. -->
    <nav class="navbar navbar-inverse navbar-fixed-top navbar-expanded" style="background-color:black; height:100px">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand page-scroll" href="/Vista/Index/index.aspx">
                    <img src="assets/img/hpsc.png" width="343" height="100" class="img-responsive" alt="">
                </a>                       
                <button type="button" class="page-scroll" onclick="document.getElementById('indicacion').style.display='block'"  style="width:150px;height:35px; text-align:center; line-height: 8px; background-color: #507389;margin-left: 500px; border-radius: 5px">Indicaciones</button>

            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
    <br />
    <section class="bg-gray" id="formulario" style="background-image: url('assets/img/registro-bg.jpg');background-size:100% 100vh;background-repeat:no-repeat;height:736px">
        <div class="container text-center wow fadeIn">
            <div class="row">
                <div class="col-lg-12">
                    <h2 style="color:white">Registro</h2>
                </div>
            </div>
            <div class="row content-row" style="margin-left:320px">
                <form style="background-color:lightgray;width:500px;border-radius: 15px;" id="formregistro" runat="server">
                    <div class="col-md-13" >
                        <br />

                        <asp:RadioButtonList ID="tipousuario" runat="server" Width="463px" RepeatDirection="Horizontal" TextAlign="Right" Font-Names="Raleway Black" OnSelectedIndexChanged="tipousuario_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem>Empleado</asp:ListItem>
                            <asp:ListItem>Cliente</asp:ListItem>
                            <asp:ListItem>Aliado</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                    </div>
<%-----------------------------------------INICIO PANEL EMPLEADO--------------------------------------------------------%>
                    <asp:Panel ID="empform" runat="server" Visible="False" style="border-radius: 15px;" Height="350px">
                        <div class="col-md-13" style="background-color:lightgray;margin-top:10px">
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Correo: </label> 
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="correoemp" runat="server" TextMode="Email" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="validarcorreoemp" 
                                        runat="server" 
                                        ClientValidationFunction="validarcorreo" 
                                        ControlToValidate="correoemp"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div style="margin-top:10px">
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Nombre: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="nombreemp" runat="server" TextMode="SingleLine" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="validarnombreemp" 
                                        runat="server" 
                                        ClientValidationFunction="validarnombre" 
                                        ControlToValidate="nombreemp"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Apellido: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="apellidoemp" runat="server" TextMode="SingleLine" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="valapellido" 
                                        runat="server" 
                                        ClientValidationFunction="validarapellido" 
                                        ControlToValidate="apellidoemp"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Usuario: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="usuarioemp" runat="server" TextMode="SingleLine" Width="230px" MaxLength="15"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="valusuario" 
                                        runat="server" 
                                        ClientValidationFunction="validarusuario" 
                                        ControlToValidate="usuarioemp"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Contraseña: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="contrasenaemp" runat="server" TextMode="Password" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="valcontrasena" 
                                        runat="server" 
                                        ClientValidationFunction="validarcontrasena" 
                                        ControlToValidate="contrasenaemp"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Verificar contraseña: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="verificarcontrasenaemp" runat="server" TextMode="Password" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="valvacontrasena" 
                                        runat="server" 
                                        ClientValidationFunction="validarvalcontrasena" 
                                        ControlToValidate="verificarcontrasenaemp"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                        <style>
                            #aceptaremp {
                                background-color: #4CAF50;
                                color: white;
                                padding: 14px 20px;
                                margin: 8px 0;
                                margin-top:-25px;
                                margin-left:-30px;
                                border: none;
                                cursor: pointer;
                                width: 250px;
                                border-bottom-left-radius: 15px;
                                font-family: 'Raleway SemiBold';
                            }
                            #cancelaremp {
                                background-color: red;
                                color: white;
                                padding: 14px 20px;
                                margin: 8px 0;
                                margin-top:-25px;
                                margin-left:-15px;
                                border: none;
                                cursor: pointer;
                                width: 250px;
                                border-bottom-right-radius: 15px;
                                font-family: 'Raleway SemiBold';
                            }
                        </style>
                        <div class="col-lg-12" style="margin-top:30px">
                            <div style="text-align:right" class="col-md-6">
                               <asp:Button ID="aceptaremp" runat="server" Text="Registrar" class="" OnClick="aceptaremp_Click" />
                            </div>
                            <div class="col-md-6" style="text-align:left">
                               <asp:Button ID="cancelaremp" runat="server" Text="Cancelar" class="" OnClick="cancelaremp_Click" />
                            </div>
                        </div>
                        <br /><br /><br /><br /><br /><br /><br /><br /><br />
                    </asp:Panel>
<%-----------------------------------------FIN PANEL EMPLEADO--------------------------------------------------------%>

<%-----------------------------------------INICIO PANEL CLIENTE--------------------------------------------------------%>
                    <asp:Panel ID="cliform" runat="server" Visible="False" Height="350px">
                        <div class="col-md-13" style="background-color:lightgray;margin-top:10px">
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Correo: </label> 
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="correocli" runat="server" TextMode="Email" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="correoval" 
                                        runat="server" 
                                        ClientValidationFunction="validarcorreocli" 
                                        ControlToValidate="correocli"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div style="margin-top:10px">
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Nombre de empresa: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="nombrecli" runat="server" TextMode="SingleLine" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="nombreval" 
                                        runat="server" 
                                        ClientValidationFunction="validarnombrecli" 
                                        ControlToValidate="nombrecli"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Dirección: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="direccioncli" runat="server" TextMode="SingleLine" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="direccionval" 
                                        runat="server" 
                                        ClientValidationFunction="validardireccioncli" 
                                        ControlToValidate="direccioncli"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Usuario: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="usuariocli" runat="server" TextMode="SingleLine" Width="230px" MaxLength="15"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="usuarioval" 
                                        runat="server" 
                                        ClientValidationFunction="validarusuariocli" 
                                        ControlToValidate="usuariocli"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Contraseña: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="contrasenacli" runat="server" TextMode="Password" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="contrasenaval" 
                                        runat="server" 
                                        ClientValidationFunction="validarcontrasenacli" 
                                        ControlToValidate="contrasenacli"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Verificar contraseña: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="contrasenavalcli" runat="server" TextMode="Password" Width="230px" MaxLength="50"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="contrasenavalval" 
                                        runat="server" 
                                        ClientValidationFunction="validarvalcontrasenacli" 
                                        ControlToValidate="contrasenavalcli"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                        <style>
                            #aceptarcli {
                                background-color: #4CAF50;
                                color: white;
                                padding: 14px 20px;
                                margin: 8px 0;
                                margin-top:-25px;
                                margin-left:-30px;
                                border: none;
                                cursor: pointer;
                                width: 250px;
                                border-bottom-left-radius: 15px;
                                font-family: 'Raleway SemiBold';
                            }
                            #cancelarcli {
                                background-color: red;
                                color: white;
                                padding: 14px 20px;
                                margin: 8px 0;
                                margin-top:-25px;
                                margin-left:-15px;
                                border: none;
                                cursor: pointer;
                                width: 250px;
                                border-bottom-right-radius: 15px;
                                font-family: 'Raleway SemiBold';
                            }
                        </style>
                        <div class="col-lg-12" style="margin-top:30px">
                            <div style="text-align:right" class="col-md-6">
                               <asp:Button ID="aceptarcli" runat="server" Text="Registrar" class="" OnClick="aceptarcli_Click" />
                            </div>
                            <div class="col-md-6" style="text-align:left">
                               <asp:Button ID="cancelarcli" runat="server" Text="Cancelar" class="" OnClick="cancelarcli_Click" />
                            </div>
                        </div>
                        <br /><br /><br /><br /><br /><br /><br /><br /><br />
                    </asp:Panel>
<%-----------------------------------------FIN PANEL CLIENTE--------------------------------------------------------%>

                    <asp:Panel ID="aliform" runat="server" Visible="False">
                        <div class="col-md-13" style="background-color:lightgray;margin-top:10px">
                            <label style="font-family: 'Raleway Black'">Usuario2: </label> <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>
                </form>
            </div>
        </div>
    </section>

    <script>
        function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }

        function validarcorreo(sender, args) {
            var email = document.getElementById('<%=correoemp.ClientID%>').value;
            if (email != '') {
                if (!validateEmail(email)) {
                    alert(email + " no es un correo valido");
                    document.getElementById('correoemp').value = '';
                }
            }
        }

        function validarnombre(sender, args) {
            var nombre = document.getElementById('<%=nombreemp.ClientID%>').value;
            if (/[^a-z0-9 áéíóúñÁÉÍÓÚ]/gi.test(nombre)) {
                alert("No puede contener caracteres especiales");
                document.getElementById('nombreemp').value = '';
            }
        }

        function validarapellido(sender, args) {
            var nombre = document.getElementById('<%=apellidoemp.ClientID%>').value;
            if (/[^a-z0-9 ]/gi.test(nombre)) {
                alert("No puede contener caracteres especiales");
                document.getElementById('apellidoemp').value = '';
            }
        }

        function validarusuario(sender, args) {
            var nombre = document.getElementById('<%=usuarioemp.ClientID%>').value;
            if (/[^a-z0-9]/gi.test(nombre)) {
                alert("No puede contener caracteres especiales");
                document.getElementById('usuarioemp').value = '';
            }
        }

        function validarcontrasena(sender, args) {
            var nombre = document.getElementById('<%=contrasenaemp.ClientID%>').value;
            if (nombre.length >= 8) {
                if (nombre.match(new RegExp("[a-z]"))) {
                    if (nombre.match(new RegExp("[A-Z]"))) {
                        if (/\d/.test(nombre)) {
                            if (nombre.match(new RegExp(/[~`!#$%\^&*+=\-\[\]\\';,./{}|\\":<>\?]/))) {

                            } else {
                                alert("La contraseña no posee caracteres especiales");
                                document.getElementById('contrasenaemp').value = '';
                            }
                        } else {
                            alert("La contraseña no posee números");
                            document.getElementById('contrasenaemp').value = '';
                        }
                    } else {
                        alert("La contraseña no posee mayúsculas");
                        document.getElementById('contrasenaemp').value = '';
                    }
                } else {
                    alert("La contraseña no posee minúsculas");
                    document.getElementById('contrasenaemp').value = '';
                }
            } else {
                alert("La contraseña no posee como mínimo 8 caracteres");
                document.getElementById('contrasenaemp').value = '';
            }
        }

        function validarvalcontrasena(sender, args) {
            var nombre = document.getElementById('<%=verificarcontrasenaemp.ClientID%>').value;
            if (nombre === document.getElementById('<%=contrasenaemp.ClientID%>').value) {

            } else {
                alert("Las contraseñas no coinciden");
                document.getElementById('verificarcontrasenaemp').value = '';
            }
        }
    </script>


    <script>
        function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }

        function validarcorreocli(sender, args) {
            var email = document.getElementById('<%=correocli.ClientID%>').value;
            if (email != '') {
                if (!validateEmail(email)) {
                    alert(email + " no es un correo valido");
                    document.getElementById('correocli').value = '';
                }
            }
        }

        function validarnombrecli(sender, args) {
            var nombre = document.getElementById('<%=nombrecli.ClientID%>').value;
            if (/[^a-z0-9 áéíóúñÁÉÍÓÚ '&.,]/gi.test(nombre)) {
                alert("Existen caracteres especiales no permitidos en el nombre");
                document.getElementById('nombrecli').value = '';
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

        function validardireccioncli(sender, args) {
            var nombre = document.getElementById('<%=direccioncli.ClientID%>').value;
            if (/[^a-z0-9 áéíóúñÁÉÍÓÚ '&.,-]/gi.test(nombre)) {
                alert("Existen caracteres especiales no permitidos");
                document.getElementById('direccioncli').value = '';
            } else {
                var pruebapuntos = CheckForRepeat(nombre, ".");
                var pruebacoma = CheckForRepeat(nombre, ",");
                var pruebaguion = CheckForRepeat(nombre, "-");
                var pruebacomilla = CheckForRepeat(nombre, "'");
                var pruebaand = CheckForRepeat(nombre, "&");
                if ((pruebacoma == 1) || (pruebapuntos == 1) || (pruebaand == 1) || (pruebaguion == 1) || (pruebacomilla == 1)) {
                    alert("Existen caracteres especiales consecutivos");
                    document.getElementById('direccioncli').value = '';
                }
            }
        }

        function validarusuariocli(sender, args) {
            var nombre = document.getElementById('<%=usuariocli.ClientID%>').value;
            if (/[^a-z0-9]/gi.test(nombre)) {
                alert("No puede contener caracteres especiales");
                document.getElementById('usuariocli').value = '';
            }
        }

        function validarcontrasenacli(sender, args) {
            var nombre = document.getElementById('<%=contrasenacli.ClientID%>').value;
            if (nombre.length >= 8) {
                if (nombre.match(new RegExp("[a-z]"))) {
                    if (nombre.match(new RegExp("[A-Z]"))) {
                        if (/\d/.test(nombre)) {
                            if (nombre.match(new RegExp(/[~`!#$%\^&*+=\-\[\]\\';,./{}|\\":<>\?]/))) {

                            } else {
                                alert("La contraseña no posee caracteres especiales");
                                document.getElementById('contrasenacli').value = '';
                            }
                        } else {
                            alert("La contraseña no posee números");
                            document.getElementById('contrasenacli').value = '';
                        }
                    } else {
                        alert("La contraseña no posee mayúsculas");
                        document.getElementById('contrasenacli').value = '';
                    }
                } else {
                    alert("La contraseña no posee minúsculas");
                    document.getElementById('contrasenacli').value = '';
                }
            } else {
                alert("La contraseña no posee como mínimo 8 caracteres");
                document.getElementById('contrasenacli').value = '';
            }
        }

        function validarvalcontrasena(sender, args) {
            var nombre = document.getElementById('<%=contrasenavalcli.ClientID%>').value;
            if (nombre === document.getElementById('<%=contrasenacli.ClientID%>').value) {

            } else {
                alert("Las contraseñas no coinciden");
                document.getElementById('contrasenavalcli').value = '';
            }
        }
    </script>
    
    <!-- Indicaciones Modal -->
    <style>

        /* Set a style for all buttons */
        button {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
            border-radius: 5px;
        }

        /* Extra styles for the cancel button */
        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
            border-radius: 5px;
        }

        /* Center the image and position the close button */
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
            position: relative;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        .containe {
            padding: 16px;
        }

        .small-container {
            padding: 8px;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }

        /* The Modal (background) */
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
            padding-top: 60px;
        }

        /* Modal Content/Box */
        .modal-content {
            background-color: #fefefe;
            margin: 5% auto 15% auto; /* 5% from the top, 15% from the bottom and centered */
            border: 1px solid #888;
            width: 80%; /* Could be more or less, depending on screen size */
        }

        /* The Close Button (x) */
        .close {
            position: absolute;
            right: 25px;
            top: 0;
            color: #000;
            font-size: 35px;
            font-weight: bold;
        }

        .close:hover,
        .close:focus {
            color: red;
            cursor: pointer;
        }

        /* Add Zoom Animation */
        .animate {
            -webkit-animation: animatezoom 0.6s;
            animation: animatezoom 0.6s
        }
        @-webkit-keyframes animatezoom {
            from {-webkit-transform: scale(0)} 
            to {-webkit-transform: scale(1)}
        }
    
        @keyframes animatezoom {
            from {transform: scale(0)} 
            to {transform: scale(1)}
        }

        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
               display: block;
               float: none;
            }
            .cancelbtn {
               width: 100%;
            }
        }
    </style>

    <div id="indicacion" class="modal">
      <!-- Modal Content -->
      <form class="modal-content animate" action="/action_page.php">
        <div style="font-family: 'Raleway Black'; font-size: 35px; text-align:center; margin: 10px auto 0px auto">
          <h3>Indicaciones</h3>
          <div style="margin-left:50px;margin-top:40px;margin-bottom:40px">
              <p style="text-align:justify"> • Nombre de Usuario no mayor a 15 caracteres.</p>
              <p style="text-align:justify"> • Contraseña mínimo 8 caracteres.</p>
              <p style="text-align:justify"> • Contraseña debe contener caracteres numéricos.</p>
              <p style="text-align:justify"> • Contraseña debe contener caracteres en mayúscula y minúscula.</p>
              <p style="text-align:justify"> • Contraseña debe contener al menos uno de los siguientes caracteres especiales  !#$%&'()*+,-./:;<=>?@[\]^_`{|}~</p>
          </div>
        </div>
        <div class="containe" style="background-color:#f1f1f1">
          <button type="button" onclick="document.getElementById('indicacion').style.display='none'" class="cancelbtn" style="font-family: 'Raleway ExtraBold'">Cancelar</button>
        </div>
      </form>
    </div>

    <div id="verificarcodigo" class="modal">
      <!-- Modal Content -->
      <form class="modal-content animate" action="/action_page.php">
        <div style="font-family: 'Raleway Black'; font-size: 35px; text-align:center; margin: 10px auto 0px auto">
          <h3>Indicaciones</h3>
          <div style="margin-left:50px;margin-top:40px;margin-bottom:40px">
              <p style="text-align:justify"> • Pon tu codigo</p>
              
          </div>
        </div>
        <div class="containe" style="background-color:#f1f1f1">
          <button type="button" onclick="document.getElementById('verificarcodigo').style.display='none'" class="cancelbtn" style="font-family: 'Raleway ExtraBold'">Cancelar</button>
        </div>
      </form>
    </div>

    <script>
        // Get the modal
        var modal = document.getElementById('indicacion');

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
        
        
    </script>

    <script type="text/javascript">
        function openModal() {
            $('#validarcodigo').modal('show');
        }
    </script>

    <!-- Core Scripts -->
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap/bootstrap.min.js"></script>
    <!-- Plugin Scripts -->
    <script src="assets/js/plugins/jquery.easing.min.js"></script>
    <script src="assets/js/plugins/classie.js"></script>
    <script src="assets/js/plugins/cbpAnimatedHeader.js"></script>
    <script src="assets/js/plugins/owl-carousel/owl.carousel.js"></script>
    <script src="assets/js/plugins/jquery.magnific-popup/jquery.magnific-popup.min.js"></script>
    <script src="assets/js/plugins/background/core.js"></script>
    <script src="assets/js/plugins/background/transition.js"></script>
    <script src="assets/js/plugins/background/background.js"></script>
    <script src="assets/js/plugins/jquery.mixitup.js"></script>
    <script src="assets/js/plugins/wow/wow.min.js"></script>
    <script src="assets/js/contact_me.js"></script>
    <script src="assets/js/plugins/jqBootstrapValidation.js"></script>
    <!-- Vitality Theme Scripts -->
    <script src="assets/js/vitality.js"></script>




</body>

</html>
