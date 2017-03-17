<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="postlogin.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Index.postlogin" %>

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
</head>
<!-- Alternate Body Classes: .modern and .vintage -->



<body id="page-top">

    <style>
       
        .show {display:block;}

        .sub-menu-parent { position: relative; }

        .sub-menu { 
          visibility: hidden; /* hides sub-menu */
          opacity: 0;
          position: absolute;
          top: 100%;
          left: 0;
          width: 230px;
          transform: translateY(-2em);
          z-index: -1;
          transition: all 0.3s ease-in-out 0s, visibility 0s linear 0.3s, z-index 0s linear 0.01s;
        }

        .sub-menu-parent:hover .sub-menu {
          visibility: visible; /* shows sub-menu */
          opacity: 1;
          z-index: 1;
          transform: translateY(0%);
          transition-delay: 0s, 0s, 0.3s; /* this removes the transition delay so the menu will be visible while the other styles transition */
        }


    </style>
    <script>
        function privilegiosinsuficientes() {
            alert("No posees los permisos necesarios para acceder a este zona");
        }
    </script>
    <!-- Navigation -->
    <!-- Note: navbar-default and navbar-inverse are both supported with this theme. -->
    <nav class="navbar navbar-inverse navbar-fixed-top navbar-expanded">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">
                    <img src="assets/img/hpsc.png" width="343" height="100" class="img-responsive" alt="">
                </a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li class="hidden">
                        <a class="page-scroll" href="#page-top"></a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#about">Sobre nosotros</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#servicios">Servicios</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#clientesaliados">Cliente y aliados</a>
                    </li>
                    <%--<li>
                        <button onclick="mostrarmenu()" class="dropbtn"><%=emp.nombre+" "+emp.apellido%>Luis Perez</button>
                          <div id="menuempleado" class="dropdown-content">
                            <a style="color:black" href="/Vista/Empleados/administracionHPSC.aspx">Home</a>
                            <a href="#about">About</a>
                            <a href="#contact">Contact</a>
                          </div>
                        <ul>

                        </ul>
                    </li>--%>
                    <li class="sub-menu-parent">
                       <a href="#">Mi cuenta</a>
                       <ul class="sub-menu" style="background-color:#222222">
                         <li id="actdatos" runat ="server" style="margin-left:-20px;margin-top:10px"></li>
                         <li id="zonaempleados" runat="server" style="margin-left:-20px;margin-top:10px"></li>
                         <li id="borrarcta" style="margin-left:-20px;margin-top:10px"><a href="/Vista/Registro/borrarcuenta.aspx" style="color:white">• Eliminar cuenta</a></li>
                         <li id="cerrarsesion" style="margin-left:-20px;margin-top:10px;margin-bottom:10px"><form id="cerrar" runat="server" ><asp:LinkButton ID="Cerrarsesion" runat="server" OnClick="Cerrarsesion_Click">• Cerrar sesión</asp:LinkButton></form></li>
                       </ul>
                     </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
    <header style="background-image: url('assets/img/bg-header-day.jpg');">
        <div class="intro-content">
            <img src="assets/img/hpsc-logo.png" width="200" height="250" class="img-responsive img-centered" alt="">
            <div class="HPSC-name" style="font-family: 'Raleway Black'">HPSC Servicios Corporativos</div>
            <hr class="colored">
            <div class="brand-name-subtext">Aqui puede ir el lema de la empresa</div>
        </div>
        <div class="scroll-down">
            <a class="btn page-scroll" href="#servicios"><i class="fa fa-angle-down fa-fw"></i></a>
        </div>
    </header>
    <section class="bg-gray" id="servicios">
        <div class="container text-center wow fadeIn">
            <div class="row">
                <div class="col-lg-12">
                    <h2>Servicios</h2>
                    <p>Los servicios que ofrecemos están diseñados para facilitar su decisión brindándole a su vez la flexibilidad necesaria
                       para adaptarlo a su entorno tecnológico
                    </p>
                    <hr class="colored">
                </div>
            </div>
            <div class="row content-row">
                <div class="col-lg-12">
                    <div class="about-carousel">
                        <div class="item">
                            <img src="assets/img/servicios/1.jpg" class="img-responsive" alt="" id="soporte" >
                            <div class="caption">
                                <h3 style="color:white">Soporte</h3>
                                <hr class="colored-small">
                                <p style="color:white; font-size: medium; margin:8px; text-align: center;">Cuente con un servicio especializado en el diagnóstico y 
                                                                                      repación de equipos de cómputo, impresión y comunicación, diseñados con la flexibilidad y 
                                                                                      adaptabilidad que su empresa necesita</p>
                            </div>
                        </div>
                        <div class="item">
                            <img src="assets/img/servicios/2.jpg" class="img-responsive" alt="" id="preventivo">
                            <div class="caption">
                                <h3 style="color:white">Preventivos</h3>
                                <hr class="colored-small">
                                <p style="color:white; font-size: medium; margin:8px; text-align: center;">Maximice el desempeño de sus equipos y reduzca a su vez la probabilidad
                                                                                      de ocurran fallos inesperados, actuando con un enfoque
                                                                                      proactivo en el mantenimiento de su plataforma
                                </p>
                            </div>
                        </div>
                        <div class="item">
                            <img src="assets/img/servicios/3.jpg" class="img-responsive" alt="" id="profesional">
                            <div class="caption">
                                <h3 style="color:white">Profesionales</h3>
                                <hr class="colored-small">
                                <p style="color:white; font-size: medium; margin:8px; text-align: center;">Contamos con un portafolio de servicios profesionales
                                                                                      que ofrece propuestas de arquitectura y diseño
                                                                                      implementación y administración de soluciones adaptables a su empresa
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="clientesaliados">
        <div class="container text-center wow fadeIn">
            <h2>Clientes y aliados</h2>
            <hr class="colored">
            <p>Aquí presentamos a nuestros clientes que han trabajado previamente con nosotros y nuestros aliados empresariales con quienes contamos como soporte</p>
            <div class="row content-row">
                <div class="col-lg-12">
                    <div class="portfolio-filter">
                        <ul id="filters" class="clearfix">
                            <li>
                                <span class="filter active" data-filter="all">Clientes y aliados</span>
                            </li>
                            <li>
                                <span class="filter" data-filter="clientes">Clientes</span>
                            </li>
                            <li>
                                <span class="filter" data-filter="aliados">Aliados</span>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div id="portfoliolist">
                        <div class="portfolio clientes" data-cat="clientes" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-clientes/aguilar.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Aguilar, Machado, Sosa & Asociados</a>
                                        <span class="text-category">Escritorio Jurídico</span>
                                        <p class="text-category" style="font-size:small">Cliente</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio aliados" data-cat="aliados" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-aliados/hp.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Hewlett Packard</a>
                                        <span class="text-category">Empresa del sector informático</span>
                                        <p class="text-category" style="font-size:small">Aliado</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio clientes" data-cat="clientes" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-clientes/cocacola.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Coca-Cola Venezuela</a>
                                        <span class="text-category">Empresa de bebidas</span>
                                        <p class="text-category" style="font-size:small">Cliente</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio aliados" data-cat="aliados" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-aliados/hpe.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Hewlett Packard Enterprise</a>
                                        <span class="text-category">Empresa de servicios tecnológicos</span>
                                        <p class="text-category" style="font-size:small">Aliado</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio clientes" data-cat="clientes" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-clientes/ford.jpg" alt="" >
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Ford Venezuela</a>
                                        <span class="text-category">Empresa automotriz</span>
                                        <p class="text-category" style="font-size:small">Cliente</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio aliados" data-cat="aliados" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-aliados/microsoft.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Microsoft</a>
                                        <span class="text-category">Empresa de software y hardware</span>
                                        <p class="text-category" style="font-size:small">Aliado</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio clientes" data-cat="clientes" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-clientes/movistar.jpg" alt="" >
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Movistar Venezuela</a>
                                        <span class="text-category">Empresa de telecomunicaciones</span>
                                        <p class="text-category" style="font-size:small">Cliente</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio aliados" data-cat="aliados" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-aliados/mt_2005.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">MT2005</a>
                                        <span class="text-category">Empresa de venta de hardware y servicios</span>
                                        <p class="text-category" style="font-size:small">Aliado</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio clientes" data-cat="clientes" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-clientes/novobanco.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Novo Banco</a>
                                        <span class="text-category">Empresa del sector bancario</span>
                                        <p class="text-category" style="font-size:small">Cliente</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio aliados" data-cat="aliados" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-aliados/excon.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Excon</a>
                                        <span class="text-category">Empresa de soluciones de negocio</span>
                                        <p class="text-category" style="font-size:small">Aliado</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio clientes" data-cat="clientes" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-clientes/polar.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Alimentos Polar</a>
                                        <span class="text-category">Empresa del sector alimenticio</span>
                                        <p class="text-category" style="font-size:small">Cliente</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                        <div class="portfolio aliados" data-cat="aliados" data-toggle="modal">
                            <div class="portfolio-wrapper">
                                <img src="assets/img/logos-aliados/cron.jpg" alt="">
                                <div class="caption">
                                    <div class="caption-text">
                                        <a class="text-title">Cron Sistemas, C.A.</a>
                                        <span class="text-category">Empresa de venta de hardware</span>
                                        <p class="text-category" style="font-size:small">Aliado</p>
                                    </div>
                                    <div class="caption-bg"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="testimonials bg-gray">
        <div class="container wow fadeIn">
            <div class="row">
                <div class="col-lg-10 col-lg-offset-1">
                    <div class="testimonials-carousel">
                        <div class="item">
                            <div class="row">
                                <div class="col-lg-12">
                                    <p class="lead">"Trabajar con HPSC Servicios Corporativos fue una experiencia excelente"</p>
                                    <hr class="colored">
                                    <p class="quote">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reprehenderit, temporibus, laborum, dignissimos doloremque corporis alias nostrum recusandae culpa id quisquam harum impedit sed sunt non obcaecati vero ipsam aut fugit?</p>
                                    <div class="testimonial-info">
                                        <div class="testimonial-img">
                                            <img src="assets/img/testimonios/ford.jpg" width="50" height="50" class="img-circle img-responsive" alt="">
                                        </div>
                                        <div class="testimonial-author">
                                            <span class="name">Nombre del autor</span>
                                            <p class="small">Cargo en la empresa</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="row">
                                <div class="col-lg-12">
                                    <p class="lead">"HPSC Servicios Corporativos ofrece lo mejor a sus clientes"</p>
                                    <hr class="colored">
                                    <p class="quote">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reprehenderit, temporibus, laborum, dignissimos doloremque corporis alias nostrum recusandae culpa id quisquam harum impedit sed sunt non obcaecati vero ipsam aut fugit?</p>
                                    <div class="testimonial-info">
                                        <div class="testimonial-img">
                                            <img src="assets/img/testimonios/mt_2005.jpg" width="50" height="50" class="img-circle img-responsive" alt="">
                                        </div>
                                        <div class="testimonial-author">
                                            <span class="name">Nombre del autor</span>
                                            <p class="small">Cargo en la empresa</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <footer class="footer" style="background-image: url('assets/img/bgfooter.jpg')">
        <div class="container text-center">
            <div class="row">
                <div class="col-md-4 contact-details">
                    <h4 style="color:white" id="telefono"><i class="fa fa-phone" style="color:white"></i> Teléfono</h4>
                    <p style="color:white">555-213-4567</p>
                </div>
                <div class="col-md-4 contact-details">
                    <h4 style="color:white"><i class="fa fa-map-marker" style="color:white"></i> Visítenos</h4>
                    <p style="color:white">
                        <a target="_blank" href="https://www.google.co.ve/maps/place/Edificio+Andr%C3%A9s+German+Otero,+Caracas,+Miranda/@10.4983869,-66.7902003,18z/data=!3m1!4b1!4m5!3m4!1s0x8c2a577208f8ce03:0xd2aafcfd0ddb836e!8m2!3d10.4984837!4d-66.7894939" style="color:white" id="mapa" onmouseover="hoverMapa()">
                        Edificio Andrés German Otero
                        <br style="color:white">Caracas, Miranda</a>
                </div>
                <div class="col-md-4 contact-details">
                    <h4 style="color:white" id="mail"><i class="fa fa-envelope" style="color:white"></i> Correo</h4>
                    <p style="color:white"><a target="_blank" href="mailto:@hotmail.com" style="color:white" id="correo" onmouseover="hoverCorreo()">mail@example.com</a>
                    </p>
                </div>
            </div>
            <div class="row social">
                <div class="col-lg-12">
                    <ul class="list-inline">
                        <li><a href="#"><i class="fa fa-facebook fa-fw fa-2x"></i></a>
                        </li>
                        <li><a href="#"><i class="fa fa-twitter fa-fw fa-2x"></i></a>
                        </li>
                        <li><a href="#"><i class="fa fa-linkedin fa-fw fa-2x"></i></a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="row copyright">
                <div class="col-lg-12">
                    <p class="small">&copy; </p>
                </div>
            </div>
        </div>
    </footer>

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

<script>
    <!-- Accion Hover en la seccion de numero de mapa y email -->
    $('#mapa').hover(function () {
        $('#mapa').stop(true).animate({ opacity: 0.5 }, 20);
    }, function () {
        $('#mapa').stop(true).animate({ opacity: 1 }, 20);
    });

    $('#correo').hover(function () {
        $('#correo').stop(true).animate({ opacity: 0.5 }, 20);
    }, function () {
        $('#correo').stop(true).animate({ opacity: 1 }, 20);
    });

    $('#actdatos').hover(function () {
        $('#actdatos').stop(true).animate({ opacity: 0.5 }, 200);
    }, function () {
        $('#actdatos').stop(true).animate({ opacity: 1 }, 200);
    });

    $('#zonaempleados').hover(function () {
        $('#zonaempleados').stop(true).animate({ opacity: 0.5 }, 200);
    }, function () {
        $('#zonaempleados').stop(true).animate({ opacity: 1 }, 200);
    });

    $('#borrarcta').hover(function () {
        $('#borrarcta').stop(true).animate({ opacity: 0.5 }, 200);
    }, function () {
        $('#borrarcta').stop(true).animate({ opacity: 1 }, 200);
    });

    $('#cerrarsesion').hover(function () {
        $('#cerrarsesion').stop(true).animate({ opacity: 0.5 }, 200);
    }, function () {
        $('#cerrarsesion').stop(true).animate({ opacity: 1 }, 200);
    });
</script>

</html>
