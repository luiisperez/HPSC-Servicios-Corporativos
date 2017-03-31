using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class ModificarServicio:Comando
    {
        Servicio nuevoservicio;
        public ModificarServicio(Servicio _nuevoservicio)
        {
            this.nuevoservicio = _nuevoservicio;
        }
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                basedatos.Modificar(nuevoservicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}