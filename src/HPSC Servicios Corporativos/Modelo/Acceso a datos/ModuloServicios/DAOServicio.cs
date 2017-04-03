using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos;
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

        public List<Servicio> ConsultarServicios()
        {
            DataTable tablaDeDatos;
            List<Servicio> servicios = FabricaObjetos.CrearListaServicios();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoConsultarServicios, parametro);
                Servicio servconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        String feriado = "";
                        if (row[4].ToString().Equals("1"))
                        {
                            feriado = "Sí";
                        }else
                        {
                            feriado = "No";
                        }
                        servconsultado = FabricaObjetos.CrearServicio(
                                            row[0].ToString(),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            Int32.Parse(row[3].ToString()),
                                            feriado,
                                            Int32.Parse(row[5].ToString()),
                                            Int32.Parse(row[6].ToString()),
                                            row[7].ToString()
                                        );
                        servicios.Add(servconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return servicios;
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

        public void Modificar(Servicio newserv)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                if (newserv.feriado.Equals("Sí"))
                {
                    newserv.feriado_si_no = 1;
                }
                else
                {
                    newserv.feriado_si_no = 0;
                }
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_cantdias, SqlDbType.Int, Convert.ToString(newserv.cantdias), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_canthoras, SqlDbType.Int, Convert.ToString(newserv.canthoras), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_disponibilidad, SqlDbType.VarChar, newserv.disponibilidad, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_feriados, SqlDbType.Int, Convert.ToString(newserv.feriado_si_no), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_id, SqlDbType.VarChar, Convert.ToString(newserv.identificador), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_nivelserv, SqlDbType.VarChar, newserv.nivelservicio, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_tiemporesp, SqlDbType.Int, Convert.ToString(newserv.tiemporespuesta), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_tiposerv, SqlDbType.VarChar, newserv.tiposervicio, false));
                EjecutarStoredProcedure(RecursoDAO_Servicio.ProcedimientoModificarServicio, listaParametro);
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

        public Servicio ConsultarServicio(String id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_id, SqlDbType.VarChar, id, false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoConsultarServicio, parametro);
                Servicio servconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        String feriado = "";
                        if (row[4].ToString().Equals("1"))
                        {
                            feriado = "Sí";
                        }
                        else
                        {
                            feriado = "No";
                        }
                        servconsultado = FabricaObjetos.CrearServicio(
                                            row[0].ToString(),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            Int32.Parse(row[3].ToString()),
                                            feriado,
                                            Int32.Parse(row[5].ToString()),
                                            Int32.Parse(row[6].ToString()),
                                            row[7].ToString()
                                        );
                        return servconsultado;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return servconsultado;
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

        public void EliminarServicio(String id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_id, SqlDbType.VarChar, id, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoEliminarServicio, parametro);
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

        public void AsignarServicio(String servicio, String serial, String fechaini, String fechafin)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                String identificador = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_id, SqlDbType.VarChar, identificador, false));
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_id, SqlDbType.VarChar, servicio, false));
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_serial, SqlDbType.VarChar, serial, false));
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_fechaini, SqlDbType.Date, fechaini,  false));
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_fechafin, SqlDbType.Date, fechafin, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoAsignarServicio, parametro);
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

        public List<Servicio> ConsultarServiciosPorEquipo(String serial)
        {
            DataTable tablaDeDatos;
            List<Servicio> servicios = FabricaObjetos.CrearListaServicios();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_serial, SqlDbType.VarChar, serial, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcediminetoConsultarEquiposServicio, parametro);
                Servicio servconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        String feriado = "";
                        String estatus = "";
                        if (row["FERIADO"].ToString().Equals("1"))
                        {
                            feriado = "Sí";
                        }
                        else
                        {
                            feriado = "No";
                        }
                        if (Convert.ToDateTime(row["FECHAFIN"].ToString()) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            estatus = "Caducado";
                        }
                        else
                        {
                            estatus = "Vigente";
                        }
                        servconsultado = FabricaObjetos.CrearServicio(
                                            row["IDSERVICIO"].ToString(),
                                            row["NIVELSERV"].ToString(),
                                            row["TIPOSERV"].ToString(),
                                            Int32.Parse(row["TIEMPORESP"].ToString()),
                                            feriado,
                                            Int32.Parse(row["DIAS"].ToString()),
                                            Int32.Parse(row["HORAS"].ToString()),
                                            Convert.ToDateTime(row["INICIO"].ToString()),
                                            Convert.ToDateTime(row["FECHAFIN"].ToString()),
                                            estatus,
                                            row["ID"].ToString()
                                            
                                        );
                        servicios.Add(servconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return servicios;
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

        public void EliminarServicioAsignado(String id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_id, SqlDbType.VarChar, id, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoEliminarServicioAsignado, parametro);
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