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
                    Empleado empConsultado = basedatos.ConsultarEmpleado(user);
                    if ((!empConsultado.contrasena.Equals(password)) || (!empConsultado.usuario.Equals(user)))
                    {
                        throw new NullReferenceException(); //CREAR EXCEPCIONES PROPIAS LUEGO
                    }
                    else if (empConsultado.rol.Equals("-100"))
                    {
                        throw new NullReferenceException(); //CREAR EXCEPCIONES PROPIAS LUEGO
                    }
                    emp = empConsultado;
                }
                else if (tipouser.Equals("Cliente"))
                {
                    DAOCliente basedatos = FabricaDAO.CrearDAOCliente();
                    Cliente cliConsultado = basedatos.ConsultarCliente(user);
                    if ((!cliConsultado.contrasena.Equals(password)) || (!cliConsultado.usuario.Equals(user)))
                    {
                        throw new NullReferenceException(); //CREAR EXCEPCIONES PROPIAS LUEGO
                    }
                    else if (cliConsultado.rol.Equals("-100"))
                    {
                        throw new NullReferenceException(); //CREAR EXCEPCIONES PROPIAS LUEGO
                    }
                    cli = cliConsultado;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}