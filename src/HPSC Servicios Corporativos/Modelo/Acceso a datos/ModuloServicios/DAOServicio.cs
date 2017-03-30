using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios
{
    public class DAOServicio:DAO
    {
        public void Agregar(Servicio newserv)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                String identificador = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_cantdias, SqlDbType.Int, Convert.ToString(newserv.cantdias), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_canthoras, SqlDbType.Int, Convert.ToString(newserv.canthoras), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_disponibilidad, SqlDbType.VarChar, "Disponible", false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_feriados, SqlDbType.Int, Convert.ToString(newserv.feriado_si_no), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_id, SqlDbType.VarChar, identificador, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_nivelserv, SqlDbType.VarChar, newserv.nivelservicio, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_tiemporesp, SqlDbType.Int, Convert.ToString(newserv.tiemporespuesta), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_tiposerv, SqlDbType.VarChar, newserv.tiposervicio, false));
                EjecutarStoredProcedure(RecursoDAO_Servicio.ProcedimientoAgregarServicio, listaParametro);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}