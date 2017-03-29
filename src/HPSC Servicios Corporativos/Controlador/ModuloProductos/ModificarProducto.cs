using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloProductos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloProductos
{
    public class ModificarProducto:Comando
    {
        Equipo equipo;
        String viejonumero;
        public ModificarProducto(Equipo _equipo, String numequipo)
        {
            this.equipo = _equipo;
            this.viejonumero = numequipo;
        }
        public override void ejecutar()
        {
            try
            {
                DAOProducto basedatos = FabricaDAO.CrearDAOProducto();
                basedatos.Modificar(equipo, viejonumero);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}