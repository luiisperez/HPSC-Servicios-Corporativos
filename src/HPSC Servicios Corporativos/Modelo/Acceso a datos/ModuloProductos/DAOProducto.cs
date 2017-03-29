using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloProductos
{
    public class DAOProducto:DAO
    {
        public void Agregar(Equipo newproducto)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_categoria, SqlDbType.VarChar, newproducto.categoria, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_marca, SqlDbType.VarChar, newproducto.marca, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_modelo, SqlDbType.VarChar, newproducto.modelo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_numproducto, SqlDbType.VarChar, newproducto.numeroequipo, false));
                EjecutarStoredProcedure(RecursoDAO_Producto.ProcedimientoAgregarProducto, listaParametro);
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

        public List<String> ConsultarMarcas()
        {
            DataTable tablaDeDatos;
            List<String> marcas = new List<String>();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Producto.ProcedimientoConsultarMarcas, parametro);
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    marcas.Add(row[0].ToString());
                }
                return marcas;
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

        public List<Equipo> ConsultarProductos()
        {
            DataTable tablaDeDatos;
            List<Equipo> equipos = FabricaObjetos.CrearListaEquipos();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Producto.ProcedimientoConsultarProductos, parametro);
                Equipo equipoconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        equipoconsultado = FabricaObjetos.CrearEquipo(
                                            row[0].ToString(),
                                            row[1].ToString(),
                                            row[2].ToString(),
                                            row[3].ToString()
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

        public void Modificar(Equipo newproducto, String oldnumeq)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_categoria, SqlDbType.VarChar, newproducto.categoria, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_marca, SqlDbType.VarChar, newproducto.marca, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_modelo, SqlDbType.VarChar, newproducto.modelo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_numproducto, SqlDbType.VarChar, newproducto.numeroequipo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAO_Producto.pr_numproductoviejo, SqlDbType.VarChar, oldnumeq, false));
                EjecutarStoredProcedure(RecursoDAO_Producto.ProcedimientoModificarProducto, listaParametro);
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