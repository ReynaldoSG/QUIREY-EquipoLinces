using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ClientesService
    {
        private  string connection;
        public ClientesService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }


    public List<GetClientesModel> GetClientes()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetClientesModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetClientes", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetClientesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Direccion = row["Direccion"].ToString(),
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


        public int InsertClientes(InsertClientesModel cliente)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetClientesModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pNombre",SqlDbType= SqlDbType.VarChar,Value= cliente.Nombre});
                parametros.Add(new SqlParameter{ParameterName = "@pDireccion",SqlDbType= SqlDbType.VarChar,Value= cliente.Direccion});
                parametros.Add(new SqlParameter{ParameterName = "@pUsuarioActualiza",SqlDbType= SqlDbType.Int,Value= cliente.Usuario});
                DataSet ds = dac.Fill("sp_InsertClientes", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetClientesModel
                        {
                            Nombre = row["Nombre"].ToString(),
                            Direccion = row["Direccion"].ToString(),
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

        public int UpdateClientes(UpdateClientesModel cliente)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetClientesModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pId",SqlDbType= SqlDbType.VarChar,Value= cliente.Id});
                parametros.Add(new SqlParameter{ParameterName = "@pNombre",SqlDbType= SqlDbType.VarChar,Value= cliente.Nombre});
                parametros.Add(new SqlParameter{ParameterName = "@pDireccion",SqlDbType= SqlDbType.VarChar,Value= cliente.Direccion});
                parametros.Add(new SqlParameter{ParameterName = "@pUsuarioActualiza",SqlDbType= SqlDbType.Int,Value= cliente.Usuario});
                DataSet ds = dac.Fill("sp_UpdateClientes", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetClientesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Direccion = row["Direccion"].ToString(),
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

        public int DeleteClientes(DeleteClientesModel cliente)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetClientesModel>();

            try
            {
                parametros.Add(new SqlParameter{ParameterName = "@pId",SqlDbType = SqlDbType.Int, Value = cliente.Id});
                DataSet ds =dac.Fill("sp_DeleteClientes",parametros);
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetClientesModel
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
