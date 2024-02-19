using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class ModUsuarioService
    {
        private  string connection;
        public ModUsuarioService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertModUser(InsertModUserModel modUser)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetModUserModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdModulo", SqlDbType = SqlDbType.Int, Value = modUser.IdModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.Int, Value = modUser.IdUsuario });
                DataSet ds = dac.Fill("sp_InsertModuloUsuario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetModUserModel
                        {
                            Modulo = row["Modulo"].ToString(),
                            Usuario = row["Usuario"].ToString()
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

        public List<GetModUserModel> GetModUser()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetModUserModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetModuloUsuario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetModUserModel
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            Modulo = row["Modulo"].ToString(),
                            Usuario = row["Usuario"].ToString(),
                            FechaRegistro = DateTime.Parse(row["FechaRegistro"].ToString()),
                            FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString()),

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

        public int UpdateModUser(UpdateModUserModel modUser)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateModUserModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = modUser.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdModulo", SqlDbType = SqlDbType.Int, Value = modUser.IdModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.Int, Value = modUser.IdUsuario });
            
                DataSet ds = dac.Fill("sp_UpdateModuloUsuario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new UpdateModUserModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdModulo = int.Parse(row["Modulo"].ToString()),
                            IdUsuario = int.Parse(row["Usuario"].ToString())
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

        public int DeleteModUser(DeleteModUserModel moduser)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteModUserModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = moduser.Id });
                DataSet ds = dac.Fill("sp_DeleteModuloUsuario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new DeleteModUserModel
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
