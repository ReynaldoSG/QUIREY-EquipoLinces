using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class DetalleMovimientoService
    {
        private  string connection;
        public DetalleMovimientoService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }
                public List<GetDetalleMovimientoModel> GetDetalleMovimiento()
                {
                    ArrayList parametros = new ArrayList();
                    ConexionDataAccess dac = new ConexionDataAccess(connection);
                    var lista = new List<GetDetalleMovimientoModel>();
                    try
                    {
                        DataSet ds = dac.Fill("sp_GetDetalleMovimiento", parametros);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                lista.Add(new GetDetalleMovimientoModel
                                {
                                    Id = int.Parse(row["Id"].ToString()),
                                    NombreMovimiento = row["NombreMovimiento"].ToString(),
                                    Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                                    Costo = decimal.Parse(row["Costo"].ToString()),
                                    FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString()),
                                    Estatus = row["Estatus"].ToString(),
                                    UsuarioActualiza = row["UsuarioActualiza"].ToString()
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

        public int InsertDetalleMovimiento(InsertDetalleMovimientoModel detalleMovimiento)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleMovimientoModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdMovimiento", SqlDbType = SqlDbType.Int, Value = detalleMovimiento.IdMovimiento });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = detalleMovimiento.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Int, Value = detalleMovimiento.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pCosto", SqlDbType = SqlDbType.Decimal, Value = detalleMovimiento.Costo });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza",SqlDbType= SqlDbType.Int,Value= detalleMovimiento.UsuarioActualiza});

                DataSet ds = dac.Fill("sp_InsertDetalleMovimiento", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleMovimientoModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NombreMovimiento = row["NombreMovimiento"].ToString(),
                            Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                            Costo = decimal.Parse(row["Costo"].ToString()),
                            FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString()),
                            Estatus = row["Estatus"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString()
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

        public int UpdateDetalleMovimiento(UpdateDetalleMovimientoModel detalleMovimiento)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleMovimientoModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = detalleMovimiento.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdMovimiento", SqlDbType = SqlDbType.Int, Value = detalleMovimiento.IdMovimiento});
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = detalleMovimiento.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Int, Value = detalleMovimiento.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pCosto", SqlDbType = SqlDbType.Decimal, Value = detalleMovimiento.Costo });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = detalleMovimiento.Estatus });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = detalleMovimiento.UsuarioActualiza });
                DataSet ds = dac.Fill("sp_UpdateDetalleMovimiento", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleMovimientoModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NombreMovimiento = row["NombreMovimiento"].ToString(),
                            Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                            Costo = decimal.Parse(row["Costo"].ToString()),
                            FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString()),
                            Estatus = row["Estatus"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString()
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

        public int DeleteDetalleMovimiento(DeleteDetalleMovimientoModel detalleMovimiento)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleMovimientoModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = detalleMovimiento.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleMovimiento", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleMovimientoModel
                        {
                            Id = int.Parse(row["Id"].ToString())
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
