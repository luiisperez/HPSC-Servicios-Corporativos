using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Objetos
{
    public class UsuarioRegistrar
    {
        public Empleado emp;
        public String codigohexadecimal;
        public int intentos = 3;
        public Cliente cli;

        public UsuarioRegistrar(Empleado _emp, String _codigo)
        {
            this.emp = _emp;
            this.codigohexadecimal = _codigo;
        }

        public UsuarioRegistrar(Cliente _cli, String _codigo)
        {
            this.cli = _cli;
            this.codigohexadecimal = _codigo;
        }
    }
}