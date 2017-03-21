using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloClientes
{
    public class ConsultarEquiposCliente:Comando
    {
        String correocliente;
        public List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
        public ConsultarEquiposCliente(String _correo)
        {
            this.correocliente = _correo;
        }
        public override void ejecutar()
        {
            try
            {
                DAOCliente basedatos = FabricaDAO.CrearDAOCliente();
                equipos = basedatos.ConsultarEquiposCliente(correocliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}