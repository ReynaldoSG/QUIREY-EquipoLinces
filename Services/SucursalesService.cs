using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class SucursalesService
    {
        private  string connection;
        public SucursalesService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertSucursales(InsertSucursalesModel sucursal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetSucursalesModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = sucursal.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.VarChar, Value = sucursal.Usuario });
                DataSet ds = dac.Fill("sp_InsertSucursales", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetSucursalesModel
                        {
                            Nombre = row["NombreSucursal"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString()
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

        public List<GetSucursalesModel> GetSucursales()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetSucursalesModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetSucursales", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetSucursalesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["NombreSucursal"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString(),
                            FechaAct = DateTime.Parse(row["FechaActualiza"].ToString()),
                            FechaReg = DateTime.Parse(row["FechaRegistro"].ToString())
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

        public int UpdateSucursales(UpdateSucursalesModel sucursal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetSucursalesModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = sucursal.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = sucursal.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.VarChar, Value = sucursal.Usuario });
                DataSet ds = dac.Fill("sp_UpdateSucursales", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetSucursalesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["NombreSucursal"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString()
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

        public int DeleteSucursales(DeleteSucursalesModel sucursal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetAlmacenesModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = sucursal.Id });
                DataSet ds = dac.Fill("sp_DeleteSucursales", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetAlmacenesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
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
