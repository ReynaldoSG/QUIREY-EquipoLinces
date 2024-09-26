using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ExistenciasService
    {
        private  string connection;
        public ExistenciasService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }
                public List<GetExistenciasModel> GetExistencias(GetExistenciasFiltroModel existencia)
                {
                    ArrayList parametros = new ArrayList();
                    ConexionDataAccess dac = new ConexionDataAccess(connection);
                    var lista = new List<GetExistenciasModel>();
                    try
                    {
                        parametros.Add(new SqlParameter { ParameterName = "@pAlmacen", SqlDbType = SqlDbType.Int, Value = existencia.Almacen });
                        DataSet ds = dac.Fill("sp_GetExistencias", parametros);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                lista.Add(new GetExistenciasModel
                                {
                                    Id = int.Parse(row["Id"].ToString()),
                                    Codigo = row["Codigo"].ToString(),
                                    Almacen = row["Almacen"].ToString(),
                                    Cantidad = int.Parse(row["Cantidad"].ToString()),
                                    Usuario = row["UsuarioActualiza"].ToString(),
                                    FechaRegistro = DateTime.Parse(row["FechaRegistro"].ToString()),
                                    FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString())
                                });
                            }
                        }
                        return lista;
                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    
                    
                }

        public string InsertExistencias(InsertExistenciasModel existencia)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetExistenciasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = existencia.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = existencia.Almacen });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Int, Value = existencia.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = existencia.Usuario });

                DataSet ds = dac.Fill("sp_InsertExistencias", parametros);
                 if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public string UpdateExistencias(UpdateExistenciasModel existencia)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetExistenciasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = existencia.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = existencia.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = existencia.Almacen });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Int, Value = existencia.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = existencia.Usuario });
                DataSet ds = dac.Fill("sp_UpdateExistencias", parametros);
                 if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public string DeleteExistencias(DeleteExistenciasModel existencia)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetExistenciasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = existencia.Id });
                DataSet ds = dac.Fill("sp_DeleteExistencias", parametros);
                 if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }
    }
}
