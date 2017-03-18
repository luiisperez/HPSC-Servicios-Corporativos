<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modificardatoscliente.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Registro.modificardatoslcliente" %>

<!DOCTYPE html>
<html lang="en">

    <head>

        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="icon" href="/Vista/Common/img/hpsc-logo.ico" type="image/x-icon">
        <title>HPSC Servicios Corporativos</title>

        <!-- CSS -->
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500">
        <link rel="stylesheet" href="assetos/bootstrap/css/bootstrap.min.css">
        <link rel="stylesheet" href="assetos/font-awesome/css/font-awesome.min.css">
		<link rel="stylesheet" href="assetos/css/form-elements.css">
        <link rel="stylesheet" href="assetos/css/style.css">

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

        <!-- Favicon and touch icons -->
        <link rel="shortcut icon" href="assetos/ico/favicon.png">
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assetos/ico/apple-touch-icon-144-precomposed.png">
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assetos/ico/apple-touch-icon-114-precomposed.png">
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assetos/ico/apple-touch-icon-72-precomposed.png">
        <link rel="apple-touch-icon-precomposed" href="assetos/ico/apple-touch-icon-57-precomposed.png">

    </head>

    <body style="background-image:url('assets/img/registro-bg.jpg')">
         
         <style>
            ul {
                list-style-type: none;
                margin: 0;
                padding: 0;
                overflow: hidden;
                background-color: #333;
            }

            li {
                float: left;
            }

            li a {
                display: block;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

            li a:hover:not(.active) {
                background-color: #111;
            }

            .active {
                background-color: #507389;
            }
        </style>

        <ul>
          <li><a class="active" href="javascript:history.back()">Retroceder</a></li>
        </ul>


        <form id="formulario" runat="server">
        <!-- Top content -->
        <div class="top-content">
        	
            <div class="inner-bg">
                <div class="container" >
                	
                     <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1 style="color:white; font-family: 'Raleway Black'; font-size: 50px;">MODIFICACIÓN DE DATOS</h1>
                        </div>
                    </div>
                    <div style="width:40%;margin:0 auto">
                       <asp:Panel id="cliform" runat="server" style="margin-bottom:-50px;margin-top:25px">
                             <div class="form-box">
	                             <div class="form-bottom" >
				                    <div class="form-group">
				                        <label class="sr-only" for="form-email">Email</label>
				                        <input type="text" name="form-email" placeholder="Correo electrónico..." class="form-email form-control" id="correocli" runat="server" onblur="validarcorreocli()" maxlength="50">
				                    </div>
				                    <div class="form-group">
				                        <label class="sr-only" for="form-company=name">Company name</label>
				                        <input type="text" name="form-company-name" placeholder="Nombre de la empresa..." class="form-first-name form-control" id="nombrecli" runat="server" onblur="validarnombrecli()" maxlength="50">
				                    </div>
				                    <div class="form-group">
				                        <label class="sr-only" for="form-last-name">Location</label>
				                        <input type="text" name="form-location" placeholder="Ubicación..." class="form-last-name form-control" id="direccioncli" runat="server" onblur="validardireccioncli()" maxlength="250">
				                    </div>
				                    <div class="form-group">
				                        <label class="sr-only" for="form-user">Usuario</label>
				                        <input type="text" name="form-user" placeholder="Usuario..." class="form-user form-control" id="usuariocli" runat="server" onblur="validarusuariocli()" maxlength="15">
				                    </div>
				                    <div class="form-group">
				                        <label class="sr-only" for="form-password">Contrasena</label>
				                        <input type="password" name="form-password" placeholder="Contraseña..." class="form-password form-control" id="contrasenacli" runat="server" onblur="validarcontrasenacli()" maxlength="50">
				                    </div>
				                    <div class="form-group">
				                        <label class="sr-only" for="form-val-password">VerificarContrasena</label>
				                        <input type="password" name="form-val-password" placeholder="Verificar contraseña..." class="form-val-password form-control" id="contrasenavalcli" runat="server" onblur="validarvalcontrasenacli()" maxlength="50">
				                    </div>
                                    <%--=========================Estilo del boton aceptar=========================--%>
                                    <style>
                                        #aceptarcli {
	                                        height: 50px;
                                            margin: 0;
                                            padding: 0 20px;
                                            vertical-align: middle;
                                            background: #4CAF50;
                                            border: 0;
                                            font-family: 'Roboto', sans-serif;
                                            font-size: 16px;
                                            font-weight: 300;
                                            line-height: 50px;
                                            color: #fff;
                                            -moz-border-radius: 4px; -webkit-border-radius: 4px; border-radius: 4px;
                                            text-shadow: none;
                                            -moz-box-shadow: none; -webkit-box-shadow: none; box-shadow: none;
                                            -o-transition: all .3s; -moz-transition: all .3s; -webkit-transition: all .3s; -ms-transition: all .3s; transition: all .3s;
                                        }

                                        #aceptarcli:hover { opacity: 0.6; color: #fff; }

                                        #aceptarcli:active { outline: 0; opacity: 0.6; color: #fff; -moz-box-shadow: none; -webkit-box-shadow: none; box-shadow: none; }

                                        #aceptarcli:focus { outline: 0; opacity: 0.6; background: #4CAF50; color: #fff; }

                                        #aceptarcli:active:focus, #aceptarcli.active:focus { outline: 0; opacity: 0.6; background: #4CAF50; color: #fff; }
                                    </style>
                                    <%--=========================Estilo del boton cancelar=========================--%>
                                    <style>
                                        #cancelarcli {
	                                        height: 50px;
                                            margin: 0;
                                            padding: 0 20px;
                                            vertical-align: middle;
                                            background: red;
                                            border: 0;
                                            font-family: 'Roboto', sans-serif;
                                            font-size: 16px;
                                            font-weight: 300;
                                            line-height: 50px;
                                            color: #fff;
                                            -moz-border-radius: 4px; -webkit-border-radius: 4px; border-radius: 4px;
                                            text-shadow: none;
                                            -moz-box-shadow: none; -webkit-box-shadow: none; box-shadow: none;
                                            -o-transition: all .3s; -moz-transition: all .3s; -webkit-transition: all .3s; -ms-transition: all .3s; transition: all .3s;
                                        }

                                        #cancelarcli:hover { opacity: 0.6; color: #fff; }

                                        #cancelarcli:active { outline: 0; opacity: 0.6; color: #fff; -moz-box-shadow: none; -webkit-box-shadow: none; box-shadow: none; }

                                        #cancelarcli:focus { outline: 0; opacity: 0.6; background: red; color: #fff; }

                                        #cancelarcli:active:focus, #cancelarcli.active:focus { outline: 0; opacity: 0.6; background: red; color: #fff; }
                                    </style>
                                    <asp:Button ID="aceptarcli" runat="server" Text="Modificar" OnClick="aceptarcli_Click"/>
                                    <asp:Button ID="cancelarcli" runat="server" Text="Cancelar" OnClick="cancelarcli_Click"/>
                                    <a href="#" onclick="document.getElementById('indicacion').style.display='block'" id="normas" style="margin-left:60px;color:white">Instrucciones</a>
			                    </div>
                            </div>
                        </asp:Panel>
                       
                    </div>
                </div>
            </div>
            
        </div>
        

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
                } else {
                    var pruebapuntos = CheckForRepeat(nombre, ".");
                    var pruebacoma = CheckForRepeat(nombre, ",");
                    var pruebaguion = CheckForRepeat(nombre, "-");
                    var pruebacomilla = CheckForRepeat(nombre, "'");
                    var pruebaand = CheckForRepeat(nombre, "&");
                    if ((pruebacoma == 1) || (pruebapuntos == 1) || (pruebaand == 1) || (pruebaguion == 1) || (pruebacomilla == 1)) {
                        alert("Existen caracteres especiales consecutivos");
                        document.getElementById('nombrecli').value = '';
                    }
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

            function validarvalcontrasenacli(sender, args) {
                var nombre = document.getElementById('<%=contrasenavalcli.ClientID%>').value;
                if (nombre === document.getElementById('<%=contrasenacli.ClientID%>').value) {

                } else {
                    alert("Las contraseñas no coinciden");
                    document.getElementById('contrasenavalcli').value = '';
                }
            }
        </script>



        <!-- Javascript -->
        <script src="assetos/js/jquery-1.11.1.min.js"></script>
        <script src="assetos/bootstrap/js/bootstrap.min.js"></script>
        <script src="assetos/js/jquery.backstretch.min.js"></script>
        <script src="assetos/js/scripts.js"></script>
        
        <!--[if lt IE 10]>
            <script src="assetos/js/placeholder.js"></script>
        <![endif]-->
        </form>

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
                margin:0 auto;
            }

            /* Modal Content/Box */
            .modal-content {
                background-color: #fefefe;
                margin: 5% auto 15% auto; /* 5% from the top, 15% from the bottom and centered */
                border: 1px solid #888;
                width: 30%; /* Could be more or less, depending on screen size */
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
          <form class="modal-content animate">
            <div style="font-family: 'Raleway'; font-size: 35px; text-align:center; margin: 10px auto 0px auto">
              <h3 style="font-family: 'Raleway Black';">Indicaciones</h3>
              <div style="margin-left:50px;margin-top:40px;margin-bottom:40px;margin-right:50px">
                  <p style="text-align:justify; font-size: medium; color:black"> • Nombre de Usuario no mayor a 15 caracteres.</p>
                  <p style="text-align:justify; font-size: medium; color:black"> • Contraseña mínimo 8 caracteres.</p>
                  <p style="text-align:justify; font-size: medium; color:black"> • Contraseña debe contener caracteres numéricos.</p>
                  <p style="text-align:justify; font-size: medium; color:black"> • Contraseña debe contener caracteres en mayúscula y minúscula.</p>
                  <p style="text-align:justify; font-size: medium; color:black"> • Contraseña debe contener al menos uno de los siguientes caracteres especiales  !#$%&'()*+,-./:;<=>?@[\]^_`{|}~</p>
              </div>
            </div>
            <div class="containe" style="background-color:#f1f1f1">
              <button type="button" onclick="document.getElementById('indicacion').style.display='none'" class="cancelbtn" style="font-family: 'Raleway ExtraBold'">Cancelar</button>
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

            $('#normas').hover(function () {
                $('#normas').stop(true).animate({ opacity: 0.5 }, 20);
            }, function () {
                $('#normas').stop(true).animate({ opacity: 1 }, 20);
            });

        </script>
    </body>

</html>