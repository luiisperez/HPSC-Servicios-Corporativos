using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador
{
    /// <summary>
    /// Clase abstracta Commando, todos los comandos deben heredar de ella
    /// </summary>
    /// Su parametro de entrada es un Generico, es decir puede recibir cualquier objeto
    /// </typeparam>
    abstract public class Comando
    {

        /// <summary>
        /// Metodo que se encarga de ejecutar una accion.
        /// </summary>
        /// <returns>
        /// Retorna cualquier tipo de objeto dependiendo de como sea implementado
        /// </returns>
        abstract public void ejecutar();
    }
}