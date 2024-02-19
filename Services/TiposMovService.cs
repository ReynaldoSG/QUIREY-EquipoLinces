using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class TiposMovService
    {
        private  string connection;
        public TiposMovService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }


    public List<GetTiposMovModel> GetTiposMov()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTiposMovModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetTiposMov", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTiposMovModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["NombreMovimiento"].ToString(),
                            Tipo = int.Parse(row["TipoMovimiento"].ToString()),
                            Usuario = row["UsuarioActualiza"].ToString(),
                            FechaAct = DateTime.Parse(row["FechaActualiza"].ToString()),
                            FechaReg = DateTime.Parse(row["FechaRegistro"].ToString()),
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


        public int InsertTiposMov(InsertTiposMovModel tipomov)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTiposMovModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pNombreMov",SqlDbType= SqlDbType.VarChar,Value= tipomov.Nombre});
                parametros.Add(new SqlParameter{ParameterName = "@pTipoMov",SqlDbType= SqlDbType.Int,Value= tipomov.Tipo});
                parametros.Add(new SqlParameter{ParameterName = "@pUsuarioActualiza",SqlDbType= SqlDbType.Int,Value= tipomov.Usuario});
                DataSet ds = dac.Fill("sp_InsertTiposMov", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTiposMovModel
                        {
                            Nombre = row["NombreMovimiento"].ToString(),
                            Tipo = int.Parse(row["TipoMovimiento"].ToString()),
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

        public int UpdateTiposMov(UpdateTiposMovModel tipomov)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTiposMovModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pId",SqlDbType= SqlDbType.Int,Value= tipomov.Id});
                parametros.Add(new SqlParameter{ParameterName = "@pNombreMov",SqlDbType= SqlDbType.VarChar,Value= tipomov.Nombre});
                parametros.Add(new SqlParameter{ParameterName = "@pTipoMov",SqlDbType= SqlDbType.Int,Value= tipomov.Tipo});
                parametros.Add(new SqlParameter{ParameterName = "@pUsuarioActualiza",SqlDbType= SqlDbType.Int,Value= tipomov.Usuario});
                DataSet ds = dac.Fill("sp_UpdateTiposMov", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTiposMovModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["NombreMovimiento"].ToString(),
                            Tipo = int.Parse(row["TipoMovimiento"].ToString()),
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

        public int DeleteTiposMov(DeleteTiposMovModel Articulo)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTiposMovModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pId",SqlDbType = SqlDbType.Int, Value = Articulo.Id});
                DataSet ds =dac.Fill("sp_DeleteTiposMov",parametros);
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTiposMovModel
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
