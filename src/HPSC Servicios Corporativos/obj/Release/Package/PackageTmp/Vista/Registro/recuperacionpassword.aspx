<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperacionpassword.aspx.cs" Inherits="HPSC_Servicios_Corporativos.Vista.Registro.recuperacionpassword" %>

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
    </style>

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
          <li><a class="active" href="/Vista/Index/index.aspx">Inicio</a></li>
        </ul>
         
        <form id="formulario" runat="server">
        <!-- Top content -->
        <div class="top-content">
        	
            <div class="inner-bg">
                <div class="container" >
                	
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1 style="color:white; font-family: 'Raleway-Black'; font-size: 50px;">RECUPERACIÓN DE CONTRASEÑA</h1>
                        </div>
                    </div>
                    <div style="width:40%;margin:0 auto">
                        <asp:RadioButtonList ID="tipousuario" runat="server" Width="100%" RepeatDirection="Horizontal" TextAlign="Right" Font-Names="Raleway-Black"  AutoPostBack="True" style="margin-bottom:-50px;margin-top:25px" ForeColor="White">
                                <asp:ListItem>Empleado</asp:ListItem>
                                <asp:ListItem>Cliente</asp:ListItem>
                                <asp:ListItem>Aliado</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Panel id="formemp" runat="server">
                            <div class="form-box">
	                            <div class="form-bottom" >
                                    <asp:Panel id="mail" runat="server">
				                        <div class="form-group">
				                            <label class="sr-only" for="form-email">Email</label>
				                            <input type="text" name="form-email" placeholder="Correo electrónico..." class="form-email form-control" id="correo" runat="server" onblur="validarcorreo()" maxlength="50">
				                        </div>
                                    </asp:Panel>
                                    <asp:Panel id="hexacode" runat="server" Visible="False">
				                        <div class="form-group">
				                            <label class="sr-only" for="form-user">Usuario</label>
				                            <input type="text" name="form-user" placeholder="Código de verificación..." class="form-user form-control" id="codigohexa" runat="server" onblur="validarcodigo()" maxlength="15">
				                        </div>
                                    </asp:Panel>
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
                                    <asp:Button ID="aceptaremp" runat="server" Text="Aceptar" OnClick="aceptaremp_Click"/>
                                    <asp:Button ID="cancelaremp" runat="server" Text="Cancelar" OnClick="cancelaremp_Click"/>
			                    </div>
                            </div>
                        </asp:Panel>
                       
                    </div>
                </div>
            </div>
            <asp:Panel ID="mensaje" runat="server" Visible="false">
                <div style="text-align:center"><label style="font-family: 'Raleway Medium'; font-style: italic; font-weight: bold; color: #FFFFFF;">*Este código puede tardar un poco en ser enviado a su correo</label></div>            
            </asp:Panel>
        </div>
        

        <script>
            function validateEmail(email) {
                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(email);
            }

            function validarcorreo(sender, args) {
                var email = document.getElementById('<%=correo.ClientID%>').value;
                if (email != '') {
                    if (!validateEmail(email)) {
                        alert(email + " no es un correo valido");
                        document.getElementById('correoemp').value = '';
                    }
                }
            }

            function validarcodigo(sender, args) {
                var nombre = document.getElementById('<%=codigohexa.ClientID%>').value;
                if (/[^a-z0-9 ]/gi.test(nombre)) {
                    alert("No puede contener caracteres especiales");
                    document.getElementById('nombreemp').value = '';
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
