<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="borrarcuenta.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Registro.borrarcuenta" %>

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
                            <h1 style="color:white; font-family: 'Raleway Black'; font-size: 50px;">ELIMINAR CUENTA</h1>
                        </div>
                    </div>
                    <div style="width:40%;margin:0 auto">
                       <asp:Panel id="cliform" runat="server">
                             <div class="form-box">
	                             <div class="form-bottom" >
				                    <div class="form-group">
				                        <label class="sr-only" for="form-password">Contrasena</label>
				                        <input type="password" name="form-password" placeholder="Contraseña..." class="form-password form-control" id="contrasena" runat="server" onblur="validarcontrasenacli()" maxlength="50">
				                    </div>
				                    <div class="form-group">
				                        <label class="sr-only" for="form-val-password">VerificarContrasena</label>
				                        <input type="password" name="form-val-password" placeholder="Verificar contraseña..." class="form-val-password form-control" id="contrasenarepe" runat="server" onblur="validarvalcontrasenacli()" maxlength="50">
				                    </div>
                                    <%--=========================Estilo del boton aceptar=========================--%>
                                    <style>
                                        #aceptaremp {
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

                                        #aceptaremp:hover { opacity: 0.6; color: #fff; }

                                        #aceptaremp:active { outline: 0; opacity: 0.6; color: #fff; -moz-box-shadow: none; -webkit-box-shadow: none; box-shadow: none; }

                                        #aceptaremp:focus { outline: 0; opacity: 0.6; background: #4CAF50; color: #fff; }

                                        #aceptaremp:active:focus, #aceptaremp.active:focus { outline: 0; opacity: 0.6; background: #4CAF50; color: #fff; }
                                    </style>
                                    <%--=========================Estilo del boton cancelar=========================--%>
                                    <style>
                                        #cancelaremp {
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

                                        #cancelaremp:hover { opacity: 0.6; color: #fff; }

                                        #cancelaremp:active { outline: 0; opacity: 0.6; color: #fff; -moz-box-shadow: none; -webkit-box-shadow: none; box-shadow: none; }

                                        #cancelaremp:focus { outline: 0; opacity: 0.6; background: red; color: #fff; }

                                        #cancelaremp:active:focus, #cancelaremp.active:focus { outline: 0; opacity: 0.6; background: red; color: #fff; }
                                    </style>
                                    <asp:Button ID="aceptaremp" runat="server" Text="Eliminar" OnClick="aceptaremp_Click"/>
                                    <asp:Button ID="cancelaremp" runat="server" Text="Cancelar" OnClick="cancelaremp_Click"/>
			                    </div>
                            </div>
                        </asp:Panel>
                       
                    </div>
                </div>
            </div>
            
        </div>
        

        <script>
            function validarcontrasenacli(sender, args) {
                var nombre = document.getElementById('<%=contrasena.ClientID%>').value;
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
                var nombre = document.getElementById('<%=contrasena.ClientID%>').value;
                if (nombre === document.getElementById('<%=contrasenarepe.ClientID%>').value) {

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
    </body>

</html>
