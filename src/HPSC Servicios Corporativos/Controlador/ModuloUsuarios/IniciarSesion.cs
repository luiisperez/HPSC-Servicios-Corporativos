using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class IniciarSesion:Comando
    {
        String user;
        String password;
        String tipouser;
        public Empleado emp = null;
        public Cliente cli = null;
        public IniciarSesion(String _user, String _password, String _tipouser)
        {
            this.user = _user;
            this.password = _password;
            this.tipouser = _tipouser;
        }

        public override void ejecutar()
        {
            try
            {
                if (tipouser.Equals("Empleado"))
                {
                    DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
                    Empleado empConsutado = basedatos.ConsultarEmpleado(user);
                    if ((!empConsutado.contrasena.Equals(password)) || (!empConsutado.usuario.Equals(user)))
                    {
                        throw new NullReferenceException(); //CREAR EXCEPCIONES PROPIAS LUEGO
                    }
                    emp = empConsutado;
                }
                else if (tipouser.Equals("Cliente"))
                {
                    DAOCliente basedatos = FabricaDAO.CrearDAOCliente();
                    Cliente cliConsutado = basedatos.ConsultarCliente(user);
                    if ((!cliConsutado.contrasena.Equals(password)) || (!cliConsutado.usuario.Equals(user)))
                    {
                        throw new NullReferenceException(); //CREAR EXCEPCIONES PROPIAS LUEGO
                    }
                    cli = cliConsutado;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}