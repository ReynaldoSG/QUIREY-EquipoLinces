using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class VendedoresService
    {
        private  string connection;
        public VendedoresService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }
    public List<GetVendedoresModel> GetVendedores()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetVendedoresModel>();
            try
            {
                DataSet ds = dac.Fill("dbo.sp_getVendedores", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetVendedoresModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NombreVendedor = row["Vendedor"].ToString(),
                            Sucursal = row["Sucursal"].ToString(),
                            Estatus = row["Estatus"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString(),
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
                public int InsertVendedores(InsertVendedoresModel vendedores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertVendedoresModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pNombreVendedor",SqlDbType= SqlDbType.VarChar,Value= vendedores.NombreVendedor});
                parametros.Add(new SqlParameter{ParameterName = "@pIdSucursal",SqlDbType= SqlDbType.VarChar,Value= vendedores.IdSucursal});
                parametros.Add(new SqlParameter{ParameterName = "@pUsuario",SqlDbType= SqlDbType.Int,Value= vendedores.Usuario});
                DataSet ds = dac.Fill("sp_InsertVendedores", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new InsertVendedoresModel
                        {
                            
                            NombreVendedor = row["NombreVendedor"].ToString(),
                            IdSucursal= int.Parse(row["IdSucursal"].ToString()),
                            Usuario = int.Parse(row["UsuarioActualiza"].ToString()),
                           
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
        
        public int UpdateVendedores(UpdateVendedoresModel vendedores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateVendedoresModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pId",SqlDbType= SqlDbType.Int,Value= vendedores.Id});
                parametros.Add(new SqlParameter{ParameterName = "@pNombreVendedor",SqlDbType= SqlDbType.VarChar,Value= vendedores.NombreVendedor});
                parametros.Add(new SqlParameter{ParameterName = "@pIdSucursal",SqlDbType= SqlDbType.Int,Value= vendedores.IdSucursal});
                parametros.Add(new SqlParameter{ParameterName = "@pUsuario",SqlDbType= SqlDbType.Int,Value= vendedores.Usuario});
                DataSet ds = dac.Fill("sp_UpdateVendedores", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new UpdateVendedoresModel
                        {
                            Id= int.Parse(row["Id"].ToString()),
                            NombreVendedor = row["NombreVendedor"].ToString(),
                            IdSucursal= int.Parse(row["IdSucursal"].ToString()),
                            Usuario = int.Parse(row["UsuarioActualiza"].ToString()),
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
              public int DeleteVendedores(DeleteVendedoresModel vendedores)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteVendedoresModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pId",SqlDbType = SqlDbType.Int, Value = vendedores.Id});
                DataSet ds =dac.Fill("sp_DeleteVendedores",parametros);
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new DeleteVendedoresModel
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