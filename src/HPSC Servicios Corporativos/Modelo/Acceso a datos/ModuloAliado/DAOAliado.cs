using HPSC_Servicios_Corporativos.Modelo.Comun;
using HPSC_Servicios_Corporativos.Modelo.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HPSC_Servicios_Corporativos.Modelo.Acceso_a_datos.ModuloAliado
{
    public class DAOAliado:DAO
    {
        public List<Aliado> ConsultarAliados()
        {
            List<Aliado> aliados = FabricaObjetos.CrearListaAliados();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAO_Aliado.ProcedimientoConsultarAliados, parametro);
                Aliado aliconsultado = null;
                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    try
                    {
                        aliconsultado = FabricaObjetos.CrearAliado(
                                             row[0].ToString(),
                                             row[1].ToString(),
                                             row[2].ToString(),
                                             row[3].ToString(),
                                             row[4].ToString(),
                                             row[5].ToString()
                                         );
                        aliados.Add(aliconsultado);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }


                }
                return aliados;
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