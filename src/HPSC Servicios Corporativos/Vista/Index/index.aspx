<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Index.index" %>

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
<!-- Alternate Body Classes: .modern and .vintage -->

<body id="page-top">
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
                    <li>
                        <button type="button" id="btn-login" class="page-scroll" onclick="document.getElementById('login').style.display='block'"  style="height:35px; text-align:center; line-height: 8px; background-color: #507389; margin-left: 15px; border-radius: 5px">Inicio de sesión o registrese</button>
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
            <div class="HPSC">HPSC Servicios Corporativos</div>
            <hr class="colored">
            <div class="brand-name-subtext">Servicios de soporte y soluciones informáticas</div>
        </div>
        <div class="scroll-down">
            <a class="btn page-scroll" href="#about"><i class="fa fa-angle-down fa-fw"></i></a>
        </div>
    </header>
    <section id="about">
        <div class="container text-center wow fadeIn">
            <div class="row">
                <div class="col-lg-12">
                    <h2>Sobre nosotros</h2>
                    <p>HPSC Servicios Corporativos es una empresa especializada en Servicios de Tecnologías de Información, 
                       aliada con los principales fabricantes de la industria de la tecnología, y con un portafolio de s
                       ervicios orientados al cliente y adaptados al entorno económico actual, haciendo especial énfasis en la calidad y 
                       excelencia del servicio.
                    </p>
                    <hr class="colored">
                </div>
                <div class="row content-row">
                    <div class="col-lg-12">
                        <div class="about-carousel">
                            <div class="item">
                                <img src="assets/img/about_us/mision.jpg" class="img-responsive" alt="" id="mision" >
                                <div class="caption">
                                    <h3 style="color:white">Misión</h3>
                                    <hr class="colored-small">
                                    <p style="color:white; font-size: medium; margin:8px; text-align: center;">Proveer servicios de tecnologías de información que contribuyan
                                                                                                               al desarrollo del potencial de negocios de nuestros clientes y asociados</p>
                                </div> 
                            </div>
                            <div class="item">
                                <img src="assets/img/about_us/vision.jpg" class="img-responsive" alt="" id="vision">
                                <div class="caption">
                                    <h3 style="color:white">Visión</h3>
                                    <hr class="colored-small">
                                    <p style="color:white; font-size: medium; margin:8px; text-align: center;">Posicionarnos como la mejor empresa proveedora de servicios de tecnologías 
                                                                                                               de información en Venezuela, a través de estrategias de desarrollo profesional, 
                                                                                                               económico y social que beneficien a nuestros clientes, accionistas, empleados y asociados</p>
                                </div>
                            </div>
                            <div class="item">
                                <img src="assets/img/about_us/valores.jpg" class="img-responsive" alt="" id="valores">
                                <div class="caption">
                                    <h3 style="color:white">Valores</h3>
                                    <hr class="colored-small">
                                    <p style="color:white; font-size: medium; margin:8px; text-align: center;">Los valores que nos representan son el respeto, la tolerancia,
                                                                                                               el compromiso, la responsabilidad, la puntualidad, la excelencia,
                                                                                                               la disciplina y la perseverancia</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </section>
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
                                <img src="assets/img/logos-clientes/aguilarlawyer.jpg" alt="">
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
    <footer class="footer" style="background-image: url('assets/img/bgfooter.jpg')">
        <div class="container text-center">
            <div class="row">
                <div class="col-md-6 contact-details">
                    <h4 style="color:white" id="telefono"><i class="fa fa-phone" style="color:white"></i> Teléfono(s)</h4>
                    <p style="color:white">+58 (212) 6194641 / (212) 2410477</p>
                </div>
                <div class="col-md-6 contact-details">
                    <h4 style="color:white"><i class="fa fa-map-marker" style="color:white"></i> Visítenos</h4>
                    <p style="color:white">
                        <a target="_blank" href="https://www.google.co.ve/maps/place/Edificio+Andr%C3%A9s+German+Otero,+Caracas,+Miranda/@10.4983869,-66.7902003,18z/data=!3m1!4b1!4m5!3m4!1s0x8c2a577208f8ce03:0xd2aafcfd0ddb836e!8m2!3d10.4984837!4d-66.7894939" style="color:white" id="mapa" onmouseover="hoverMapa()">
                        Edificio Andrés German Otero
                        <br style="color:white">Caracas, Miranda</a>
                </div>
            </div>
            <div class="row social">
                <div class="col-lg-12">
                    <ul class="list-inline">
                        <li><a href="https://plus.google.com/105791488798181839131"><i class="fa fa-google-plus fa-fw fa-2x"></i></a>
                        </li>
                        <li><a href="https://twitter.com/hpsc_servcorp"><i class="fa fa-twitter fa-fw fa-2x"></i></a>
                        </li>
                        <li><a href="https://www.linkedin.com/company-beta/10392786/"><i class="fa fa-linkedin fa-fw fa-2x"></i></a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="row copyright">
                <div class="col-lg-12">
                    <p class="small">HPSC Servicios Corporativos &copy; </p>
                </div>
            </div>
        </div>
    </footer>

    

    <!-- Login Modal -->
    <style>
        /* Full-width input fields */
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

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

        .acceptbtn {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
            border-radius: 5px;
            white-space: normal;
        }

        /* Extra styles for the cancel button */
        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
            border-radius: 5px;
            white-space: normal;
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

        .rbl input[type="radio"]
        {
           margin-left: 12px;
           margin-right: 3px;
        }
    </style>

    <div id="login" class="modal">
      <!-- Modal Content -->
      <form id="formlogin" class="modal-content animate" runat="server">
        <div style="font-family: 'Raleway-Black'; font-size: 35px; text-align:center; margin: 10px auto 0px auto">
          <b>Inicio de sesión</b>
        </div>

        <div class="containe">
          <label style="font-family: 'Raleway-Black'"><b>Tipo de usuario:</b></label>
          <asp:RadioButtonList ID="tipousuario" runat="server" Width="463px" RepeatDirection="Horizontal" CssClass="rbl" Font-Names="Raleway-Black" Font-Size="Medium" RepeatLayout="Flow">
                <asp:ListItem>Empleado</asp:ListItem>
                <asp:ListItem>Cliente</asp:ListItem>
                <asp:ListItem>Aliado</asp:ListItem>
          </asp:RadioButtonList>
          <br />
            <br />
          <label style="font-family: 'Raleway-Black'"><b>Usuario</b></label>
          <input type="text" id="usuario" placeholder="Nombre de usuario" name="User" required oninvalid="alert('El campo de usuario no puede estar vacío');">

          <label style="font-family: 'Raleway-Black'"><b>Contraseña</b></label>
          <input type="password" id="password" placeholder="Contraseña" name="Password" required oninvalid="alert('El campo de contraseña no puede estar vacío')">
          <%--<button type="submit" style="font-family: 'Raleway-Black'">Ingresar</button>--%>
          <asp:ScriptManager runat="server" ID="sm">
          </asp:ScriptManager>
          <asp:updatepanel runat="server">
              <ContentTemplate>
                   <asp:Button ID="aceptaremp" runat="server" Text="Ingresar" class="acceptbtn" style="font-family: 'Raleway-Black'" OnClick="aceptaremp_Click" />
              </ContentTemplate>
          </asp:updatepanel>
        </div>

        <div class="col-md-12" style="background-color:#f1f1f1;padding: 16px">
              <div class="col-md-4">
                <button type="button" onclick="document.getElementById('login').style.display='none'" class="cancelbtn" style="font-family: 'Raleway-Black'">Cancelar</button>
              </div>        
              <div class="col-md-4">
                <span class="psw" style="font-family: 'Raleway-Black'; white-space: normal; ">¿Olvido su <a href="/Vista/Registro/recuperacionpassword.aspx">contraseña?</a></span>
              </div>        
              <div class="col-md-4">
                <span class="psw" style="font-family: 'Raleway-Black'; white-space: normal; font-size: large;"><a href="/Vista/Registro/registro.aspx">Presione aquí para registrarse</a></span>
              </div>            
        </div>
        <div class="small-container">
         
        </div>
      </form>
    </div>

    <script>
        // Get the modal
        var modal = document.getElementById('login');

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
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

<script>
    <!-- Accion Hover en la seccion de numero de mapa y email -->
        $('#mapa').hover(function () {
            $('#mapa').stop(true).animate({ opacity: 0.5 }, 20);
        },function () {
            $('#mapa').stop(true).animate({ opacity: 1 }, 20);
        });

        $('#correo').hover(function () {
            $('#correo').stop(true).animate({ opacity: 0.5 }, 20);
        },function () {
            $('#correo').stop(true).animate({ opacity: 1 }, 20);
        });

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

</html>
