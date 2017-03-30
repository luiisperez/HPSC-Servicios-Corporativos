using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class AgregarServicio:Comando
    {
        Servicio nuevoservicio;
        public AgregarServicio(Servicio _nuevoservicio)
        {
            this.nuevoservicio = _nuevoservicio;
        }
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                basedatos.Agregar(nuevoservicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}