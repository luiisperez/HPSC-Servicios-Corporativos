<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperacionpassword.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Registro.recuperacionpassword" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <meta name="description" content="">
    <meta name="author" content="">
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
    <script src='https://www.google.com/recaptcha/api.js'></script>
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
                <form style="background-color:lightgray;width:495px;height:250px;border-radius: 15px;" id="formregistro" runat="server">
                            <br />
                        <div class="col-md-13" style="background-color:lightgray;margin-top:10px">
                            <div style="margin-top:10px">
                                <div class="col-md-13" >
                                    <asp:RadioButtonList ID="tipousuario" runat="server" Width="463px" RepeatDirection="Horizontal" TextAlign="Right" Font-Names="Raleway Black" AutoPostBack="True">
                                        <asp:ListItem>Empleado</asp:ListItem>
                                        <asp:ListItem>Cliente</asp:ListItem>
                                        <asp:ListItem>Aliado</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                </div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';">Correo: </label> 
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="correo" runat="server" TextMode="Email" Width="230px" MaxLength="30" AutoPostBack="True"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="CustomValidator1" 
                                        runat="server" 
                                        ClientValidationFunction="validarcodigo" 
                                        ControlToValidate="codigohexa"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                                <div style="text-align:right;" class="col-md-5">
                                    <label style="font-family: 'Raleway Black';margin-top:-7px">Código de verificación: </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="codigohexa" runat="server" Width="230px" Enabled="False"></asp:TextBox>
                                    <asp:CustomValidator 
                                        ID="validarcodigo" 
                                        runat="server" 
                                        ClientValidationFunction="validarcodigo" 
                                        ControlToValidate="codigohexa"
                                        ErrorMessage="CustomValidator">
                                    </asp:CustomValidator>
                                </div>
                            </div>
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
                                margin-left:-15px;
                                border: none;
                                cursor: pointer;
                                width: 495px;
                                border-bottom-left-radius: 15px;
                                border-bottom-right-radius: 15px;
                                font-family: 'Raleway SemiBold';
                            }
                        </style>
                        <div class="col-lg-12" style="margin-top:27px; height: 39px;">
                           <asp:Button ID="aceptaremp" runat="server" Text="Aceptar" OnClick="aceptaremp_Click"  />
                        </div>
                </form>
            </div>
        </div>
        
        <div style="text-align:center"><label style="font-family: 'Raleway Medium'; font-style: italic; font-weight: bold; color: #FFFFFF;">*Este código puede tardar un poco en ser enviado</label></div>

    </section>
    <script>
        function validarcodigo(sender, args) {
            var nombre = document.getElementById('<%=codigohexa.ClientID%>').value;
            if (/[^a-z0-9 ]/gi.test(nombre)) {
                alert("No puede contener caracteres especiales");
                document.getElementById('nombreemp').value = '';
            }
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
