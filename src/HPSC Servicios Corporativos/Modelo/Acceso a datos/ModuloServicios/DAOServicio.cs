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
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_dias, SqlDbType.VarChar, Convert.ToString(newserv.dias), false));
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
                                            row[5].ToString(),
                                            Int32.Parse(row[6].ToString()),
                                            row[7].ToString()
                                        );
                        servconsultado.cantdias = servconsultado.dias.Split(',').Count();
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
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_dias, SqlDbType.VarChar, Convert.ToString(newserv.dias), false));
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
                                            row[5].ToString(),
                                            Int32.Parse(row[6].ToString()),
                                            row[7].ToString()
                                        );
                        servconsultado.cantdias = servconsultado.dias.Split(',').Count();
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

        public void AgregarContrato(List<String> servicios, List<String> seriales, String fechaini, String fechafin, String contrato)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                foreach (String servicio in servicios)
                {
                    foreach (String serial in seriales)
                    {
                        String identificador = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond;
                        parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_id, SqlDbType.VarChar, identificador, false));
                        parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.sv_id, SqlDbType.VarChar, servicio, false));
                        parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_serial, SqlDbType.VarChar, serial, false));
                        parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_fechaini, SqlDbType.Date, fechaini, false));
                        parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_fechafin, SqlDbType.Date, fechafin, false));
                        parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_contrato, SqlDbType.VarChar, "CID-"+contrato, false));
                        tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoAsignarServicio, parametro);
                        parametro.Clear();
                    }
                }
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
                                            row["DIAS"].ToString(),
                                            Int32.Parse(row["HORAS"].ToString()),
                                            Convert.ToDateTime(row["INICIO"].ToString()),
                                            Convert.ToDateTime(row["FECHAFIN"].ToString()),
                                            estatus,
                                            row["ID"].ToString()

                                        );
                        servconsultado.cantdias = servconsultado.dias.Split(',').Count();
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

        public void EliminarContrato(String id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_contrato, SqlDbType.VarChar, id, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoEliminarContrato, parametro); 
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

        public List<Contrato> ConsultarContratos()
        {
            DataTable tablaDeDatos;
            List<Contrato> contratos = FabricaObjetos.CrearListaContratos();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoConsultarContratos, parametro);
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        Contrato contconsultado;
                        contconsultado = FabricaObjetos.CrearContrato(
                                            row[0].ToString(),
                                            row[3].ToString(),
                                            Convert.ToDateTime(row[1].ToString()),
                                            Convert.ToDateTime(row[2].ToString())
                                        );
                        contratos.Add(contconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return contratos;
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

        public List<Equipo> ConsultarEquiposContrato(String id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Equipo> lista = FabricaObjetos.CrearListaEquipos();
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_contrato, SqlDbType.VarChar, id, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoConsultaEquiposContrato, parametro);
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        Equipo eqconsultado;
                        eqconsultado = FabricaObjetos.CrearEquipo(
                                            row[0].ToString(),
                                            "",
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            row[3].ToString()
                                        );
                        lista.Add(eqconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return lista;
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

        public List<Servicio> ConsultarServiciosContrato(String id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Servicio> lista = FabricaObjetos.CrearListaServicios();
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Servicio.eqsv_contrato, SqlDbType.VarChar, id, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Servicio.ProcedimientoConsultaServiciosContrato, parametro);
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
                        Servicio servconsultado;
                        servconsultado = FabricaObjetos.CrearServicio(
                                            row[0].ToString(),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            Int32.Parse(row[3].ToString()),
                                            feriado,
                                            row[6].ToString(),
                                            Int32.Parse(row[5].ToString()),
                                            row[7].ToString()
                                        );
                        servconsultado.cantdias = servconsultado.dias.Split(',').Count();
                        lista.Add(servconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return lista;
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