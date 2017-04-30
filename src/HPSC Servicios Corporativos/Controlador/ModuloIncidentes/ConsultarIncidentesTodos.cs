﻿using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloIncidentes
{
    public class ConsultarIncidentesTodos:Comando
    {
        String id;
        public List<Incidente> listado = FabricaObjetos.CrearListaIncidentes();
        public override void ejecutar()
        {
            try
            {
                DAOIncidentes basedatos = FabricaDAO.CrearDAOIncidente();
                listado = basedatos.ConsultarIncidentesTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}