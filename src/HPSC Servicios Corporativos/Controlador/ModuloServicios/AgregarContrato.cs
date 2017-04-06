using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class AgregarContrato:Comando
    {
        List<String> seriales;
        List<String> servicios;
        String fechaini;
        String fechafin;
        String contrato;
        public AgregarContrato(List<String> _servicios, List<String> _seriales, String _fechaini, String _fechafin, String _contrato)
        {
            this.seriales = _seriales;
            this.servicios = _servicios;
            this.fechafin = _fechafin;
            this.fechaini = _fechaini;
            this.contrato = _contrato;
        }
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                basedatos.AgregarContrato(servicios, seriales, fechaini, fechafin, contrato);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}