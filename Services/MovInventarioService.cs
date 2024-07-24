using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class MovInventarioService
    {
        private string connection;
        public MovInventarioService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<GetMovInventarioModels> GetMovInventario(GetMovInvFiltroModel inventario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovInventarioModels>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@IdAlmacen", SqlDbType = SqlDbType.Int, Value = inventario.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@FechaInicio", SqlDbType = SqlDbType.Date, Value = inventario.FechaInicio });
                parametros.Add(new SqlParameter { ParameterName = "@FechaFin", SqlDbType = SqlDbType.Date, Value = inventario.FechaFin });
                DataSet ds = dac.Fill("sp_GetMovimientosInv", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetMovInventarioModels
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdTipoMov = row["TipoMovimiento"].ToString(),
                            IdAlmacen = row["Almacen"].ToString(),
                            fechaMovimiento = DateTime.Parse(row["FechaMovimiento"].ToString()),
                            Estatus = row["Estatus"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString(),
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

        public List<GetMovInventarioModels> InsertMovInventario(InsertMovimientoModels MovInv)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovInventarioModels>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdTipoMov", SqlDbType = SqlDbType.Int, Value = MovInv.IdTipoMov });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = MovInv.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = MovInv.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pIdDestino", SqlDbType = SqlDbType.Int, Value = MovInv.IdDestino });

                DataSet ds = dac.Fill("sp_InsertMovimientosInv", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetMovInventarioModels
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Mensaje = row["Mensaje"].ToString()
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
        public string UpdateMovIntentario(UpdateMovimientoInvModel MovInv)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovInventarioModels>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = MovInv.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdTipoMov", SqlDbType = SqlDbType.Int, Value = MovInv.IdTipoMov });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = MovInv.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = MovInv.IdAlmacen });
                DataSet ds = dac.Fill("sp_UpdateMov_Inventario", parametros);
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

        public string DeleteMovInventario(DeleteMovimientoInvModel MovInv)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovInventarioModels>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = MovInv.Id });
                DataSet ds = dac.Fill("dbo.sp_DeleteMovInventario", parametros);
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
