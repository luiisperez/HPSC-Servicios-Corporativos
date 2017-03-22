using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloEquipos
{
    public class DAOEquipo:DAO
    {
        public Equipo ConsultarEquipoSerial(String serial)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_serial, SqlDbType.VarChar, serial, false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Equipo.ProcedimientoConsultarEquipoSerial, parametro);
                Equipo equipoconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        equipoconsultado = FabricaObjetos.CrearEquipo(
                                            row[0].ToString(),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            row[3].ToString(),
                                            row[4].ToString(),
                                            row[5].ToString()
                                        );
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return equipoconsultado;
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

        public Equipo ConsultarEquipoNumero(String numequipo)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_numequipo, SqlDbType.VarChar, numequipo, false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Equipo.ProcedimientoConsultarEquipoNumero, parametro);
                Equipo equipoconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        equipoconsultado = FabricaObjetos.CrearEquipo(
                                            row[0].ToString(),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            row[3].ToString(),
                                            row[4].ToString(),
                                            row[5].ToString()
                                        );
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return equipoconsultado;
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