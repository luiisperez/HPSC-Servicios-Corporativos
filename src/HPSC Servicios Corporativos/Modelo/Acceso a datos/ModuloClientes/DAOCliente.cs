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