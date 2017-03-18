using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloUsuarios
{
    public class ValidacionDatos
    {
        public bool verificarusuarioemp(String usuario)
        {
            DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
            Empleado empConsultado = basedatos.ConsultarEmpleado(usuario);
            if (empConsultado == null)
            {
                return false;
            }
            return true;
        }

        public bool verificarcorreoemp(String correo)
        {
            DAOEmpleado basedatos = FabricaDAO.CrearDAOEmpleado();
            Empleado empConsultado = basedatos.ConsultarEmpleadoCorreo(correo);
            if ((empConsultado == null) || (empConsultado.rol.Equals("4")))
            {
                return false;
            }
            return true;
        }

        public bool validarrecaptcha(String _response)
        {
            string Response = _response;//Getting Response String Append to Post Method
            bool Valid = false;
            //Request to Google Server
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create
            (" https://www.google.com/recaptcha/api/siteverify?secret=" + RecursosModuloUsuarios.SecretKeyreCAPTCHA + "&response=" + Response);
            try
            {
                //Google recaptcha Response
                using (WebResponse wResponse = req.GetResponse())
                {

                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        reCaptchaV2 data = js.Deserialize<reCaptchaV2>(jsonResponse);// Deserialize Json

                        Valid = Convert.ToBoolean(data.success);
                    }
                }

                return Valid;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }


        public bool validarcontrasenahash(String contrasena, String hash)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(contrasena);
            byte[] hashing = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashing.Length; i++)
            {
                sb.Append(hashing[i].ToString("X2"));
            }
            if (sb.ToString().Equals(hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String calcularhash(String contrasena)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(contrasena);
            byte[] hashing = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashing.Length; i++)
            {
                sb.Append(hashing[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}