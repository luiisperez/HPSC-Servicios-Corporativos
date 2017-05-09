using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes;
using HPSC_Servicios_Corporativos.Modelo.Comun;
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

        public List<Incidente> ConsultarIncidentes(String id)
        {
            DataTable tablaDeDatos;
            List<Incidente> listado = FabricaObjetos.CrearListaIncidentes();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_correo, SqlDbType.VarChar, id, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Incidentes.ProcedimientoConsultarIncidentesPorCliente, parametro);
                Incidente consultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        if ((row[4].ToString().Equals("")) && (row[5].ToString().Equals("")))
                        {
                            consultado = FabricaObjetos.CrearIncidente(
                                                row[0].ToString(),
                                                Convert.ToDateTime(row[1].ToString()),
                                                Convert.ToDateTime(row[2].ToString()),
                                                Convert.ToDateTime(row[3].ToString()),
                                                new DateTime(),
                                                new DateTime(),
                                                row[6].ToString(),
                                                row[7].ToString(),
                                                row[8].ToString(),
                                                row[9].ToString(),
                                                row[10].ToString(),
                                                row[11].ToString(),
                                                row[12].ToString(),
                                                row[13].ToString(),
                                                row[14].ToString(),
                                                row[15].ToString(),
                                                row[16].ToString(),
                                                row[17].ToString(),
                                                row[18].ToString(),
                                                row[19].ToString()
                                            );
                        }
                        else if ((!row[4].ToString().Equals("")) && (row[5].ToString().Equals("")))
                        {
                            consultado = FabricaObjetos.CrearIncidente(
                                                row[0].ToString(),
                                                Convert.ToDateTime(row[1].ToString()),
                                                Convert.ToDateTime(row[2].ToString()),
                                                Convert.ToDateTime(row[3].ToString()),
                                                Convert.ToDateTime(row[4].ToString()),
                                                new DateTime(),
                                                row[6].ToString(),
                                                row[7].ToString(),
                                                row[8].ToString(),
                                                row[9].ToString(),
                                                row[10].ToString(),
                                                row[11].ToString(),
                                                row[12].ToString(),
                                                row[13].ToString(),
                                                row[14].ToString(),
                                                row[15].ToString(),
                                                row[16].ToString(),
                                                row[17].ToString(),
                                                row[18].ToString(),
                                                row[19].ToString()
                                            );
                        }
                        else if ((row[4].ToString().Equals("")) && (!row[5].ToString().Equals("")))
                        {
                            consultado = FabricaObjetos.CrearIncidente(
                                                row[0].ToString(),
                                                Convert.ToDateTime(row[1].ToString()),
                                                Convert.ToDateTime(row[2].ToString()),
                                                Convert.ToDateTime(row[3].ToString()),
                                                new DateTime(),
                                                Convert.ToDateTime(row[5].ToString()),
                                                row[6].ToString(),
                                                row[7].ToString(),
                                                row[8].ToString(),
                                                row[9].ToString(),
                                                row[10].ToString(),
                                                row[11].ToString(),
                                                row[12].ToString(),
                                                row[13].ToString(),
                                                row[14].ToString(),
                                                row[15].ToString(),
                                                row[16].ToString(),
                                                row[17].ToString(),
                                                row[18].ToString(),
                                                row[19].ToString()
                                            );
                        }
                        else
                        {
                            consultado = FabricaObjetos.CrearIncidente(
                                                row[0].ToString(),
                                                Convert.ToDateTime(row[1].ToString()),
                                                Convert.ToDateTime(row[2].ToString()),
                                                Convert.ToDateTime(row[3].ToString()),
                                                Convert.ToDateTime(row[4].ToString()),
                                                Convert.ToDateTime(row[5].ToString()),
                                                row[6].ToString(),
                                                row[7].ToString(),
                                                row[8].ToString(),
                                                row[9].ToString(),
                                                row[10].ToString(),
                                                row[11].ToString(),
                                                row[12].ToString(),
                                                row[13].ToString(),
                                                row[14].ToString(),
                                                row[15].ToString(),
                                                row[16].ToString(),
                                                row[17].ToString(),
                                                row[18].ToString(),
                                                row[19].ToString()
                                            );
                        }
                        listado.Add(consultado);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }
                return listado;
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

        public List<Incidente> ConsultarIncidentesTodos()
        {
            DataTable tablaDeDatos;
            List<Incidente> listado = FabricaObjetos.CrearListaIncidentes();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Incidentes.ProcedimientoConsultarIncidentesTodos, parametro);
                Incidente consultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        if ((row[4].ToString().Equals("")) && (row[5].ToString().Equals("")))
                        {
                            consultado = FabricaObjetos.CrearIncidente(
                                                row[0].ToString(),
                                                Convert.ToDateTime(row[1].ToString()),
                                                Convert.ToDateTime(row[2].ToString()),
                                                Convert.ToDateTime(row[3].ToString()),
                                                new DateTime(),
                                                new DateTime(),
                                                row[6].ToString(),
                                                row[7].ToString(),
                                                row[8].ToString(),
                                                row[9].ToString(),
                                                row[10].ToString(),
                                                row[11].ToString(),
                                                row[12].ToString(),
                                                row[13].ToString(),
                                                row[14].ToString(),
                                                row[15].ToString(),
                                                row[16].ToString(),
                                                row[17].ToString(),
                                                row[18].ToString(),
                                                row[19].ToString()
                                            );
                        }
                        else if ((!row[4].ToString().Equals("")) && (row[5].ToString().Equals("")))
                        {
                            consultado = FabricaObjetos.CrearIncidente(
                                                row[0].ToString(),
                                                Convert.ToDateTime(row[1].ToString()),
                                                Convert.ToDateTime(row[2].ToString()),
                                                Convert.ToDateTime(row[3].ToString()),
                                                Convert.ToDateTime(row[4].ToString()),
                                                new DateTime(),
                                                row[6].ToString(),
                                                row[7].ToString(),
                                                row[8].ToString(),
                                                row[9].ToString(),
                                                row[10].ToString(),
                                                row[11].ToString(),
                                                row[12].ToString(),
                                                row[13].ToString(),
                                                row[14].ToString(),
                                                row[15].ToString(),
                                                row[16].ToString(),
                                                row[17].ToString(),
                                                row[18].ToString(),
                                                row[19].ToString()
                                            );
                        }
                        else if ((row[4].ToString().Equals("")) && (!row[5].ToString().Equals("")))
                        {
                            consultado = FabricaObjetos.CrearIncidente(
                                                row[0].ToString(),
                                                Convert.ToDateTime(row[1].ToString()),
                                                Convert.ToDateTime(row[2].ToString()),
                                                Convert.ToDateTime(row[3].ToString()),
                                                new DateTime(),
                                                Convert.ToDateTime(row[5].ToString()),
                                                row[6].ToString(),
                                                row[7].ToString(),
                                                row[8].ToString(),
                                                row[9].ToString(),
                                                row[10].ToString(),
                                                row[11].ToString(),
                                                row[12].ToString(),
                                                row[13].ToString(),
                                                row[14].ToString(),
                                                row[15].ToString(),
                                                row[16].ToString(),
                                                row[17].ToString(),
                                                row[18].ToString(),
                                                row[19].ToString()
                                            );
                        }
                        else
                        {
                            consultado = FabricaObjetos.CrearIncidente(
                                                row[0].ToString(),
                                                Convert.ToDateTime(row[1].ToString()),
                                                Convert.ToDateTime(row[2].ToString()),
                                                Convert.ToDateTime(row[3].ToString()),
                                                Convert.ToDateTime(row[4].ToString()),
                                                Convert.ToDateTime(row[5].ToString()),
                                                row[6].ToString(),
                                                row[7].ToString(),
                                                row[8].ToString(),
                                                row[9].ToString(),
                                                row[10].ToString(),
                                                row[11].ToString(),
                                                row[12].ToString(),
                                                row[13].ToString(),
                                                row[14].ToString(),
                                                row[15].ToString(),
                                                row[16].ToString(),
                                                row[17].ToString(),
                                                row[18].ToString(),
                                                row[19].ToString()
                                            );
                        }
                        listado.Add(consultado);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                }
                return listado;
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

        public void ActualizarFechaAtencion(string fechaatencion, String id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fechaatencion, SqlDbType.DateTime, fechaatencion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_id, SqlDbType.VarChar, id, false));
                EjecutarStoredProcedure(RecursoDAO_Incidentes.ProcedimientoActualizarFechaAtencion, listaParametro);
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

        public void ActualizarFechaConclusion(string fechaconclu, String id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fechafinservicio, SqlDbType.DateTime, fechaconclu, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_id, SqlDbType.VarChar, id, false));
                EjecutarStoredProcedure(RecursoDAO_Incidentes.ProcedimientoActualizarFechaConclusion, listaParametro);
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

        public void ActualizarEmpEstImpUrg(String emp, String est, String imp, String urg, String id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_empleado, SqlDbType.VarChar, emp, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_estatus, SqlDbType.VarChar, est, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_impacto, SqlDbType.VarChar, imp, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_urgencia, SqlDbType.VarChar, urg, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_id, SqlDbType.VarChar, id, false));
                EjecutarStoredProcedure(RecursoDAO_Incidentes.ProcedimientoActualizarEmpEstImpUrg, listaParametro);
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

        public void ActualizarAliEstImpUrg(String ali, String est, String imp, String urg, String id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_fk_aliado, SqlDbType.VarChar, ali, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_estatus, SqlDbType.VarChar, est, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_impacto, SqlDbType.VarChar, imp, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_urgencia, SqlDbType.VarChar, urg, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.i_id, SqlDbType.VarChar, id, false));
                EjecutarStoredProcedure(RecursoDAO_Incidentes.ProcedimientoActualizarAliEstImpUrg, listaParametro);
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

        public void AnadirActividad(String actividad, String inicio, String fin, String empleado, String id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.ac_tipo, SqlDbType.VarChar, actividad, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.ac_inicio, SqlDbType.DateTime, inicio, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.ac_fin, SqlDbType.DateTime, fin, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.ac_fk_empleado, SqlDbType.VarChar, empleado, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.ac_fk_incidente, SqlDbType.VarChar, id, false));
                EjecutarStoredProcedure(RecursoDAO_Incidentes.ProcedimientoAnadirActividad, listaParametro);
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

        public List<Actividad> ConsultarActividades(String id)
        {
            DataTable tablaDeDatos;
            List<Actividad> listado = FabricaObjetos.CrearListaActividades();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.ac_fk_incidente, SqlDbType.VarChar, id, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Incidentes.ProcedimientoConsultarActividades, parametro);
                Actividad actconsultada = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        actconsultada = FabricaObjetos.CrearActividad(
                                            row[0].ToString(),
                                            row[1].ToString(),
                                            Convert.ToDateTime(row[2].ToString()),
                                            Convert.ToDateTime(row[3].ToString()),
                                            row[4].ToString() + " " + row[5].ToString()
                                        );
                        listado.Add(actconsultada);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return listado;
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

        public void EliminarActividad(string idact)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Incidentes.ac_id, SqlDbType.Int, idact, false));
                EjecutarStoredProcedure(RecursoDAO_Incidentes.ProcedimientoEliminarActividad, listaParametro);
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