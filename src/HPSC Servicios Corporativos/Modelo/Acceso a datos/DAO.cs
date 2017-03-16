using HPSC_Servicios_Corporativos.Modelo.Comun;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos
{
    /// <summary>
    /// Clase abstracta que maneja la conexion a la BD
    /// </summary>
    abstract public class DAO
    {
            protected String _connexionString = ConfigurationManager.ConnectionStrings["Conector"].ConnectionString;
            protected SqlConnection conexion { set; get; }
            // El String de conexion se encuentra en el archivo Web.config
            protected SqlCommand comando { set; get; }


            #region Conectar con la Base de Datos
            /// <summary>
            /// Metodo para realizar la conexion a la base de datos
            /// Excepciones posibles: 
            /// SqlException: Excepciones sql
            /// </summary>
            public SqlConnection Conectar()
            {

                try
                {
                    //conexion = Connection.getInstance(_connexionString);
                    conexion = new SqlConnection(_connexionString);
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return conexion;

            }
            #endregion

            #region Desconectar de la Base de Datos
            /// <summary>
            /// Metodo para cerrar la sesion con la base de datos
            /// Excepciones posibles: 
            /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
            /// </summary>
            public void Desconectar()
            {

                try
                {
                    this.conexion.Close();
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public void Desconectar(SqlConnection conec)
            {

                try
                {
                    conec.Close();
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            #endregion

            #region Ejecutar Stored Procedure Parametrizado

            /// <summary>
            /// Metodo para ejecutar un procedimiento almacenado en la bd
            /// </summary>
            /// <param name="parametros">Lista de parametros que se le va a asociar</param>
            /// <param name="query">Cadena con el query a ejecutar</param>
            public List<ResultadoBD> EjecutarStoredProcedure(string query, List<Parametro> parametros)
            {
                try
                {
                    Conectar();
                    List<ResultadoBD> resultados = new List<ResultadoBD>();
                    using (conexion)
                    {

                        comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        AsignarParametros(parametros);
                        if (conexion.State == ConnectionState.Closed)
                        {
                            conexion.Open();
                        }
                        comando.ExecuteNonQuery();
                        if (comando.Parameters != null)
                        {
                            foreach (SqlParameter parameter in comando.Parameters)
                            {
                                if (parameter.Direction.Equals(ParameterDirection.Output))
                                {
                                    ResultadoBD resultado = new ResultadoBD(parameter.ParameterName, parameter.Value.ToString());
                                    resultados.Add(resultado);
                                }
                            }
                            if (resultados != null)
                            {
                                return resultados;
                            }
                        }

                        return null;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Desconectar();
                }
            }

            /// <summary>
            /// Metodo para asignar los parametros a un comando
            /// </summary>
            /// <param name="parametros">Lista de parametros que se le va a asociar</param>
            public void AsignarParametros(List<Parametro> parametros)
            {
                foreach (Parametro parametro in parametros)
                {
                    if (parametro != null && parametro.etiqueta != null && parametro.tipoDato != null &&
                        parametro.esOutput != null)
                    {
                        if (parametro.esOutput)
                        {
                            comando.Parameters.Add(parametro.etiqueta, parametro.tipoDato, 32000);
                            comando.Parameters[parametro.etiqueta].Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            if (parametro.valor != null)
                            {
                                comando.Parameters.Add(new SqlParameter(parametro.etiqueta, parametro.tipoDato, 32000));
                                comando.Parameters[parametro.etiqueta].Value = parametro.valor;
                            }
                            else
                            {
                                throw new ArgumentNullException();
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }

                }
            }

            #endregion

            #region Ejecutar Stored Procedure Multiples Tuplas

            public DataTable EjecutarStoredProcedureTuplas(string query)
            {
                try
                {
                    Conectar();
                    DataTable dataTable = new DataTable();
                    using (conexion)
                    {

                        comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        conexion.Open();
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                        {
                            dataAdapter.Fill(dataTable);
                            System.Diagnostics.Debug.WriteLine(dataAdapter);
                            System.Diagnostics.Debug.WriteLine(dataTable);
                        }

                        return dataTable;
                    }


                }
                catch (SqlException ex)
                {
                    throw ex;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Desconectar();
                }
            }


            /// <summary>
            /// Metodo para ejecutar un procedimiento almacenado en la bd que devuelve un DataTable
            /// </summary>
            /// <param name="parametros">Lista de parametros que se le va a asociar</param>
            /// <param name="query">Cadena con el query a ejecutar</param>
            public DataTable EjecutarStoredProcedureTuplas(string query, List<Parametro> parametros)
            {
                try
                {
                    Conectar();
                    DataTable dataTable = new DataTable();
                    using (conexion)
                    {

                        comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        AsignarParametros(parametros);
                        conexion.Open();
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                        {
                            dataAdapter.Fill(dataTable);
                            System.Diagnostics.Debug.WriteLine(dataAdapter);
                            System.Diagnostics.Debug.WriteLine(dataTable);
                        }

                        return dataTable;
                    }


                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Desconectar();
                }
            }
            #endregion
    }
}