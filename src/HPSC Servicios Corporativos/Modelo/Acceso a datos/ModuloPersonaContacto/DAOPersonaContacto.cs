using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloPersonaContacto
{
    public class DAOPersonaContacto:DAO
    {
        public void Agregar(PersonaContacto newpersona)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_apellido, SqlDbType.VarChar, newpersona.apellido, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_correo, SqlDbType.VarChar, newpersona.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_nombre, SqlDbType.VarChar, newpersona.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_telflocal, SqlDbType.VarChar, newpersona.telflocal, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_telfmovil, SqlDbType.VarChar, newpersona.telfmovil, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.cli_correo, SqlDbType.VarChar, newpersona.cliente, false));
                EjecutarStoredProcedure(RecursoDAO_PersonaContacto.ProcedimientoAgregarPersonaContacto, listaParametro);
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

        public List<PersonaContacto> ConsultarPersonasContactoPorCliente(String correocliente)
        {
            DataTable tablaDeDatos;
            List<PersonaContacto> listado = FabricaObjetos.CrearListaPersonaContacto();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.cli_correo, SqlDbType.VarChar, correocliente, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_PersonaContacto.ProcedimientoConsultarPersonasContacto, parametro);
                PersonaContacto personaconsultada = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        if (row[4].ToString().Equals(""))
                        {
                            personaconsultada = FabricaObjetos.CrearPersonaContacto(
                                                row[0].ToString(),
                                                row[1].ToString(),
                                                row[2].ToString(),
                                                row[3].ToString(),
                                                "No aplica",
                                                row[5].ToString(),
                                                row[6].ToString()
                                            );
                            listado.Add(personaconsultada);
                        }
                        else
                        {
                            personaconsultada = FabricaObjetos.CrearPersonaContacto(
                                                row[0].ToString(),
                                                row[1].ToString(),
                                                row[2].ToString(),
                                                row[3].ToString(),
                                                row[4].ToString(),
                                                row[5].ToString(),
                                                row[6].ToString()
                                            );
                            listado.Add(personaconsultada);
                        }
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

        public PersonaContacto ConsultarPersonaContacto(String correo)
        {
            DataTable tablaDeDatos;
            PersonaContacto personaconsultada = null;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_correo, SqlDbType.VarChar, correo, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_PersonaContacto.ProcedimientoConsultarPersonaContacto, parametro);
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        personaconsultada = FabricaObjetos.CrearPersonaContacto(
                                            row[0].ToString(),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            row[3].ToString(),
                                            row[4].ToString(),
                                            row[5].ToString(),
                                            row[6].ToString()
                                        );
                        return personaconsultada;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                return null;
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

        public List<PersonaContacto> ConsultarPersonasContactoTodos()
        {
            DataTable tablaDeDatos;
            List<PersonaContacto> listado = FabricaObjetos.CrearListaPersonaContacto();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_PersonaContacto.ProcedimientoConsultarTodasPersonas, parametro);
                PersonaContacto personaconsultada = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        if (row[4].ToString().Equals(""))
                        {
                            personaconsultada = FabricaObjetos.CrearPersonaContacto(
                                                row[0].ToString(),
                                                row[1].ToString(),
                                                row[2].ToString(),
                                                row[3].ToString(),
                                                "No aplica",
                                                row[5].ToString(),
                                                row[6].ToString()
                                            );
                            listado.Add(personaconsultada);
                        }
                        else
                        {
                            personaconsultada = FabricaObjetos.CrearPersonaContacto(
                                                row[0].ToString(),
                                                row[1].ToString(),
                                                row[2].ToString(),
                                                row[3].ToString(),
                                                row[4].ToString(),
                                                row[5].ToString(),
                                                row[6].ToString()
                                            );
                            listado.Add(personaconsultada);
                        }
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

        public void Eliminar(String correo)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_correo, SqlDbType.VarChar, correo, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_PersonaContacto.ProcedimientoEliminarPersonaContacto, parametro);
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

        public void Modificar(PersonaContacto newpersona, String correoviejo)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_apellido, SqlDbType.VarChar, newpersona.apellido, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_correonuevo, SqlDbType.VarChar, newpersona.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_correoviejo, SqlDbType.VarChar, correoviejo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_nombre, SqlDbType.VarChar, newpersona.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_telflocal, SqlDbType.VarChar, newpersona.telflocal, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_telfmovil, SqlDbType.VarChar, newpersona.telfmovil, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.pc_estatus, SqlDbType.VarChar, newpersona.estatus, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_PersonaContacto.cli_correo, SqlDbType.VarChar, newpersona.cliente, false));
                EjecutarStoredProcedure(RecursoDAO_PersonaContacto.ProcedimientoModificarPersonaContacto, listaParametro);
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