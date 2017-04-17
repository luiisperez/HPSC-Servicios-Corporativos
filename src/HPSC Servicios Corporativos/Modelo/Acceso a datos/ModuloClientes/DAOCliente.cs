using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloServicios;
using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloClientes
{
    public class DAOCliente:DAO
    {
        public void Agregar(Cliente c)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(c.contrasena);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_correo, SqlDbType.VarChar, c.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_nombre, SqlDbType.VarChar, c.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_direccion, SqlDbType.VarChar, c.direccion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_usuario, SqlDbType.VarChar, c.usuario, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_password, SqlDbType.VarChar, sb.ToString(), false));
                EjecutarStoredProcedure(RecursoDAO_Cliente.ProcedimientoAgregarCliente, listaParametro);
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

        public void Modificar(Cliente c)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(c.contrasena);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_correo, SqlDbType.VarChar, c.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_nombre, SqlDbType.VarChar, c.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_direccion, SqlDbType.VarChar, c.direccion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_usuario, SqlDbType.VarChar, c.usuario, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_password, SqlDbType.VarChar, sb.ToString(), false));
                EjecutarStoredProcedure(RecursoDAO_Cliente.ProcedimientoModificarCliente, listaParametro);
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

        public Cliente ConsultarCliente(String user)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_usuario, SqlDbType.VarChar, user, false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Cliente.ProcedimientoConsultarCliente, parametro);
                Cliente cliconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        cliconsultado = FabricaObjetos.CrearCliente(
                                             row[0].ToString(),
                                             row[1].ToString(),
                                             row[4].ToString(),
                                             row[2].ToString(),
                                             row[3].ToString(),
                                             row[5].ToString()
                                         );
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return cliconsultado;
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

        public Cliente ConsultarClienteCorreo(String correo)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_correo, SqlDbType.VarChar, correo, false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Cliente.ProcedimientoConsultarClienteCorreo, parametro);
                Cliente cliconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        cliconsultado = FabricaObjetos.CrearCliente(
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
                return cliconsultado;
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

        public void Cambiarpwd(String correo, String pwd)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_correo, SqlDbType.VarChar, correo, false));
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_password, SqlDbType.VarChar, pwd, false));
                EjecutarStoredProcedure(RecursoDAO_Cliente.ProcedimientoCambiarPwdCliente, parametro);
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

        public void Eliminar(Cliente cli)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_correo, SqlDbType.VarChar, cli.correo, false));
                EjecutarStoredProcedure(RecursoDAO_Cliente.ProcedimientoEliminarCliente, parametro);
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

        public List<Cliente> ConsultarEmpleados()
        {
            List<Cliente> clientes = FabricaObjetos.CrearListaClientes();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Cliente.ProcedimientoConsultarClientes, parametro);
                Cliente cliconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        cliconsultado = FabricaObjetos.CrearCliente(
                                             row[0].ToString(),
                                             row[1].ToString(),
                                             row[4].ToString(),
                                             row[2].ToString(),
                                             row[3].ToString(),
                                             row[5].ToString()
                                         );
                        clientes.Add(cliconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return clientes;
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

        public List<Equipo> ConsultarEquiposCliente(string correocliente)
        {
            List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_correo, SqlDbType.VarChar, correocliente, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Cliente.ProcedimientoConsultarEquipos, parametro);
                Equipo eqconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        eqconsultado = FabricaObjetos.CrearEquipo(
                                             row[0].ToString(),
                                             row[1].ToString(),
                                             row[2].ToString(),
                                             row[3].ToString(),
                                             row[4].ToString(),
                                             row[6].ToString(),
                                             row[5].ToString()
                                         );
                        equipos.Add(eqconsultado);
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

        public List<Contrato> ConsultarContratos(String correocliente)
        {
            DataTable tablaDeDatos;
            List<Contrato> contratos = FabricaObjetos.CrearListaContratos();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Cliente.cli_correo, SqlDbType.VarChar, correocliente, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Cliente.ProcedimientoConsultarContratos, parametro);
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