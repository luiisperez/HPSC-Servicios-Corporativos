using HPSC_Servicios_Corporativos.Modelo.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class EnviarConfirmacion:Comando
    {
        String correo;
        public String codigohexadecimal;
        static Random random = new Random();
        public EnviarConfirmacion(String _correo)
        {
            this.correo = _correo;
        }
        private static String GenerarHexadecimal(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }
        public override void ejecutar()
        {
            try
            {
                codigohexadecimal = GenerarHexadecimal(8);
                Mail cmd = new Mail();
                cmd.EnviarCorreo(correo, codigohexadecimal);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}