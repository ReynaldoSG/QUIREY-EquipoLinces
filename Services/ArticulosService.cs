using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ArticulosService
    {
        private  string connection;
        public ArticulosService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }


    public List<GetArticulosModel> GetArticulos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetArticulosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetArticulos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetArticulosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Codigo = row["Codigo"].ToString(),
                            Descripcion = row["Descripcion"].ToString(),
                            UM = int.Parse(row["UnidadMedida"].ToString()),
                            Costo = row["Costo"].ToString(),
                            Precio = row["Precio"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString(),
                            Fecha = DateTime.Parse(row["FechaRegistro"].ToString())
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


        public int InsertArticulos(InsertArticulosModel articulo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetArticulosModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pDescripcion",SqlDbType= SqlDbType.VarChar,Value= articulo.Descripcion});
                parametros.Add(new SqlParameter{ParameterName = "@pUM",SqlDbType= SqlDbType.Int,Value= articulo.UM});
                parametros.Add(new SqlParameter{ParameterName = "@pCosto",SqlDbType= SqlDbType.Decimal,Value= articulo.Costo});
                parametros.Add(new SqlParameter{ParameterName = "@pPrecio",SqlDbType= SqlDbType.Decimal,Value= articulo.Precio});
                parametros.Add(new SqlParameter{ParameterName = "@pUsuarioActualiza",SqlDbType= SqlDbType.Int,Value= articulo.Usuario});
                DataSet ds = dac.Fill("sp_InsertArticulos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetArticulosModel
                        {
                            Descripcion = row["Descripcion"].ToString(),
                            UM = int.Parse(row["UnidadMedida"].ToString()),
                            Costo = row["Costo"].ToString(),
                            Precio = row["Precio"].ToString(),
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

        public int UpdateArticulos(UpdateArticulosModel articulo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetArticulosModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pId",SqlDbType= SqlDbType.VarChar,Value= articulo.Id});
                parametros.Add(new SqlParameter{ParameterName = "@pCodigo",SqlDbType= SqlDbType.VarChar,Value= articulo.Codigo});
                parametros.Add(new SqlParameter{ParameterName = "@pDescripcion",SqlDbType= SqlDbType.VarChar,Value= articulo.Descripcion});
                parametros.Add(new SqlParameter{ParameterName = "@pUnidadMedida",SqlDbType= SqlDbType.Int,Value= articulo.UM});
                parametros.Add(new SqlParameter{ParameterName = "@pCosto",SqlDbType= SqlDbType.Decimal,Value= articulo.Costo});
                parametros.Add(new SqlParameter{ParameterName = "@pPrecio",SqlDbType= SqlDbType.Decimal,Value= articulo.Precio});
                parametros.Add(new SqlParameter{ParameterName = "@pUsuarioActualiza",SqlDbType= SqlDbType.Int,Value= articulo.Usuario});
                DataSet ds = dac.Fill("sp_UpdateArticulos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetArticulosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Codigo = row["Codigo"].ToString(),
                            Descripcion = row["Descripcion"].ToString(),
                            UM = int.Parse(row["UnidadMedida"].ToString()),
                            Costo = row["Costo"].ToString(),
                            Precio = row["Precio"].ToString(),
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

        public int DeleteArticulos(DeleteArticulosModel Articulo)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetArticulosModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pId",SqlDbType = SqlDbType.Int, Value = Articulo.Id});
                DataSet ds =dac.Fill("sp_DeleteArticulos",parametros);
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetArticulosModel
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
