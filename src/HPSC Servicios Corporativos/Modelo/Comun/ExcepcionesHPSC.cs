using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Comun
{
    public class ExcepcionesHPSC:Exception
    {
        private string _Mensaje;
        private Exception _Excepcion;


        /// <summary>
        /// Get y set de mensaje
        /// </summary>
        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }


        /// <summary>
        /// Get y set de excepcion
        /// </summary>
        public Exception Excepcion
        {
            get { return _Excepcion; }
            set { _Excepcion = value; }
        }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion SqlException</param>
        public ExcepcionesHPSC(String mensaje, SqlException inner)
        {
            _Mensaje = mensaje;
            _Excepcion = inner;
        }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion SqlException</param>
        public ExcepcionesHPSC(String mensaje, NullReferenceException inner)
        {
            _Mensaje = mensaje;
            _Excepcion = inner;
        }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion SqlException</param>
        public ExcepcionesHPSC(String mensaje, ArgumentNullException inner)
        {
            _Mensaje = mensaje;
            _Excepcion = inner;
        }


        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="mensaje">Mensaje de la excepcion</param>
        /// <param name="inner">Excepcion SqlException</param>
        public ExcepcionesHPSC(String mensaje, Exception inner)
        {
            _Mensaje = mensaje;
            _Excepcion = inner;
        }
    }
}