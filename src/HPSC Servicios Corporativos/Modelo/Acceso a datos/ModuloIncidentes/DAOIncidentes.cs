﻿using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloIncidentes
{
    public class DAOIncidentes:DAO
    {
        public List<Feriado> ConsultarFeriados()
        {
            DataTable tablaDeDatos;
            List<Feriado> feriados = FabricaObjetos.CrearListaFeriados();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Incidentes.ProcedimientoConsultarFeriados, parametro);
                Feriado feriadoconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        feriadoconsultado = FabricaObjetos.CrearFeriado(
                                            row[1].ToString(),
                                            Int32.Parse(row[2].ToString()),
                                            Int32.Parse(row[3].ToString())
                                        );
                        feriados.Add(feriadoconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return feriados;
            }
            catch (SqlException ex)
            {
                ExcepcionesHPSC exc = new ExcepcionesHPSC("Error 001: Ha ocurrido un error a nível de base de datos, si el error persiste por favor comuníquese con el administrador", ex);
                throw exc;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesHPSC exc = new ExcepcionesHPSC("Error 101: Ha ocurrido un error con una referencia nula internamente, si el error persiste por favor comuníquese con el administrador", ex);
                throw exc;
            }
            catch (ArgumentNullException ex)
            {
                ExcepcionesHPSC exc = new ExcepcionesHPSC("Error 231: Ha ocurrido un error con un argumento nulo, si el error persiste por favor comuníquese con el administrador", ex);
                throw exc;
            }
            catch (Exception ex)
            {
                ExcepcionesHPSC exc = new ExcepcionesHPSC("Error 404: Ha ocurrido un error desconocido, si el error persiste por favor comuníquese con el administrador", ex);
                throw exc;
            }
        }

        public void Agregar(Incidente incidente)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                var atencion = incidente.fechaatencion.ToString();
                var finservicio = incidente.fechafinservicio.ToString();
                if (incidente.fechaatencion == new DateTime())
                {
                    atencion = null;
                }
                if (incidente.fechafinservicio == new DateTime())
                {
                    finservicio = null;
                }
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_descripcionbreve, SqlDbType.VarChar, incidente.descripcion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_direccionincidente, SqlDbType.VarChar, incidente.direccion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_estatus, SqlDbType.VarChar, incidente.estatus, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fecha, SqlDbType.DateTime, incidente.fecharegistro.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fechaatencion, SqlDbType.DateTime, incidente.fecharegistro.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fechacompromiso, SqlDbType.DateTime, incidente.fechacompromiso.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fechafinservicio, SqlDbType.DateTime, incidente.fecharegistro.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fecharequerida, SqlDbType.DateTime, incidente.fecharequerida.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_aliado, SqlDbType.VarChar, incidente.aliado, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_cliente, SqlDbType.VarChar, incidente.cliente, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_contrato, SqlDbType.VarChar, incidente.contrato, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_empleado, SqlDbType.VarChar, incidente.empleado, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_equipo, SqlDbType.VarChar, incidente.equipo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_personal_contacto1, SqlDbType.VarChar, incidente.contacto1, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_personal_contacto2, SqlDbType.VarChar, incidente.contacto2, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_servicio, SqlDbType.VarChar, incidente.servicio, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_id, SqlDbType.VarChar, incidente.id, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_impacto, SqlDbType.VarChar, incidente.impacto, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_tiposervicio, SqlDbType.VarChar, incidente.tiposerv, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_urgencia, SqlDbType.VarChar, incidente.urgencia, false));
                EjecutarStoredProcedure(RecursoDAO_Incidentes.ProcedimientoAgregarIncidente, listaParametro);
            }
            catch (SqlException ex)
            {
                ExcepcionesHPSC exc = new ExcepcionesHPSC("Error 001: Ha ocurrido un error a nível de base de datos, si el error persiste por favor comuníquese con el administrador", ex);
                throw exc;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesHPSC exc = new ExcepcionesHPSC("Error 101: Ha ocurrido un error con una referencia nula internamente, si el error persiste por favor comuníquese con el administrador", ex);
                throw exc;
            }
            catch (ArgumentNullException ex)
            {
                ExcepcionesHPSC exc = new ExcepcionesHPSC("Error 231: Ha ocurrido un error con un argumento nulo, si el error persiste por favor comuníquese con el administrador", ex);
                throw exc;
            }
            catch (Exception ex)
            {
                ExcepcionesHPSC exc = new ExcepcionesHPSC("Error 404: Ha ocurrido un error desconocido, si el error persiste por favor comuníquese con el administrador", ex);
                throw exc;
            }
        }
    }
}