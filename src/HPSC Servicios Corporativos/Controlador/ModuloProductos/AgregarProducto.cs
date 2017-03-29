using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloProductos;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloProductos
{
    public class AgregarProducto:Comando
    {
        Equipo nuevoproducto;

        public AgregarProducto(Equipo _nuevoequipo)
        {
            this.nuevoproducto = _nuevoequipo;
        }
        public override void ejecutar()
        {
            try
            {
                DAOProducto basedatos = FabricaDAO.CrearDAOProducto();
                basedatos.Agregar(nuevoproducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}