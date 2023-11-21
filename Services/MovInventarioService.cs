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
        private  string connection;
        public MovInventarioService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }


         public List<GetMovInventarioModels> GetMovInventario()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovInventarioModels>();
            try
            {
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

        public int InsertMovInventario(InsertMovimientoModels MovInv)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovInventarioModels>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdTipoMov", SqlDbType = SqlDbType.VarChar, Value = MovInv.IdTipoMov });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.VarChar, Value = MovInv.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.VarChar, Value = MovInv.UsuarioActualiza });
                
                DataSet ds = dac.Fill("sp_InsertMovimientosInv", parametros);
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
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
        }
        public int UpdateMovIntentario(UpdateMovimientoInvModel MovInv)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovInventarioModels>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = MovInv.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pTipoMov", SqlDbType = SqlDbType.Int, Value = MovInv.IdTipoMov });
                parametros.Add(new SqlParameter { ParameterName = "@pIdAlmacen", SqlDbType = SqlDbType.Int, Value = MovInv.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = MovInv.IdAlmacen });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = MovInv.Estatus });
                DataSet ds = dac.Fill("sp_UpdateMov_Inventario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetMovInventarioModels
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdTipoMov = row["TipoMovimiento"].ToString(),
                            IdAlmacen = row["Almacen"].ToString(),
                            Estatus = row["Estatus"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString(),
                        });
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
        }

          public int DeleteMovInventario(DeleteMovimientoInvModel MovInv)
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
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
        }



    }
}
