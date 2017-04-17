using HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloUsuarios;
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

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos
{
    public class DAOEmpleado:DAO
    {
        public void Agregar(Empleado e)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(e.contrasena);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_correo, SqlDbType.VarChar, e.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_nombre, SqlDbType.VarChar, e.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_apellido, SqlDbType.VarChar, e.apellido, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_usuario, SqlDbType.VarChar, e.usuario, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_contrasena, SqlDbType.VarChar, sb.ToString(), false));
                EjecutarStoredProcedure(RecursoDAO_Usuario.ProcedimientoAgregarEmpleado, listaParametro);
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

        public void Modificar(Empleado e)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(e.contrasena);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_correo, SqlDbType.VarChar, e.correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_nombre, SqlDbType.VarChar, e.nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_apellido, SqlDbType.VarChar, e.apellido, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_usuario, SqlDbType.VarChar, e.usuario, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_contrasena, SqlDbType.VarChar, sb.ToString(), false));
                EjecutarStoredProcedure(RecursoDAO_Usuario.ProcedimientoModificarEmpleado, listaParametro);
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

        public Empleado ConsultarEmpleado(String user)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_usuario, SqlDbType.VarChar, user, false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Usuario.ProcedimientoConsultarEmpleado, parametro);
                Empleado empconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        empconsultado = FabricaObjetos.CrearEmpleado(
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
                return empconsultado;
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

        public Empleado ConsultarEmpleadoCorreo(String correo)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_correo, SqlDbType.VarChar, correo, false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Usuario.ProcedimientoConsultarEmpleadoCorreo, parametro);
                Empleado empconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        empconsultado = FabricaObjetos.CrearEmpleado(
                                            row["e_correo"].ToString(),
                                            row["e_nombre1"].ToString(),
                                            row["e_apellido1"].ToString(),
                                            row["e_usuario"].ToString(),
                                            row["e_password"].ToString(),
                                            row["e_fk_rol"].ToString()
                                        );
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return empconsultado;
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

        public void Eliminar(Empleado emp)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_correo, SqlDbType.VarChar, emp.correo, false));
                EjecutarStoredProcedure(RecursoDAO_Usuario.ProcedimientoEliminarEmpleado, parametro);
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
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_correo, SqlDbType.VarChar, correo, false));
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_contrasena, SqlDbType.VarChar, pwd, false));
                EjecutarStoredProcedure(RecursoDAO_Usuario.ProcedimientoCambiarPwdEmpleado, parametro);
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

        public List<Empleado> ConsultarEmpleados()
        {
            List<Empleado> empleados = FabricaObjetos.CrearListaEmpleados();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Usuario.ProcedimientoConsultarEmpleados, parametro);
                Empleado empconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        empconsultado = FabricaObjetos.CrearEmpleado(
                                             row[0].ToString(),
                                             row[1].ToString(),
                                             row[2].ToString(),
                                             row[3].ToString(),
                                             row[4].ToString(),
                                             row[5].ToString()
                                         );
                        empleados.Add(empconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return empleados;
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

        public List<Rol> ConsultarRoles()
        {
            List<Rol> roles = FabricaObjetos.CrearListaRoles();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Usuario.ProcedimientoConsultarRoles, parametro);
                Rol rol = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        rol = FabricaObjetos.CrearRol(
                                             row[0].ToString(),
                                             row[1].ToString(),
                                             row[2].ToString()
                                         );
                        roles.Add(rol);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return roles;
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

        public void AsignarRol(String correo, String rol)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_correo, SqlDbType.VarChar, correo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Usuario.emp_rol, SqlDbType.Int, rol, false));
                EjecutarStoredProcedure(RecursoDAO_Usuario.ProcedimientoAgregarRolEmpleado, listaParametro);
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