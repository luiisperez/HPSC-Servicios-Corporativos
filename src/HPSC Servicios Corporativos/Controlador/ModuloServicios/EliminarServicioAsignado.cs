﻿using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos;
using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Controlador.ModuloServicios
{
    public class EliminarServicioAsignado:Comando
    {
        String id;
        public EliminarServicioAsignado(String _id)
        {
            this.id = _id;
        }
        public override void ejecutar()
        {
            try
            {
                DAOServicio basedatos = FabricaDAO.CrearDAOServicio();
                basedatos.EliminarServicioAsignado(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}