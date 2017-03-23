﻿using HPSC_Servicios_Corporativos.Modelo.Comun;
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

        public void Agregar(Equipo newequipo)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_categoria, SqlDbType.VarChar, newequipo.categoria, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_marca, SqlDbType.VarChar, newequipo.marca, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_modelo, SqlDbType.VarChar, newequipo.modelo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_numequipo, SqlDbType.VarChar, newequipo.numeroequipo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Equipo.eq_serial, SqlDbType.VarChar, newequipo.serial, false));
                EjecutarStoredProcedure(RecursoDAO_Equipo.ProcedimientoAgregarEquipo, listaParametro);
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

        public List<Equipo> ConsultarEquiposLibres()
        {
            DataTable tablaDeDatos;
            List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Equipo.ProcedimientoConsultarEquiposLibres, parametro);
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
                        equipos.Add(equipoconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return equipos;
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

        public List<Equipo> ConsultarEquiposTodos()
        {
            DataTable tablaDeDatos;
            List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Equipo.ProcedimientoConsultarTodosEquipos, parametro);
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
                        equipos.Add(equipoconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return equipos;
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