using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class UsuariosService
    {
        private string connection;
        public UsuariosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int InsertUsuarios(InsertUsuariosModel usuarios)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertUsuariosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = usuarios.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pContrasena", SqlDbType = SqlDbType.VarChar, Value = usuarios.Contrasena });
                parametros.Add(new SqlParameter { ParameterName = "@pRol", SqlDbType = SqlDbType.Int, Value = usuarios.Rol });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = usuarios.Usuario });

                DataSet ds = dac.Fill("sp_InsertUsuario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new InsertUsuariosModel
                        {
                            Nombre = row["Nombre"].ToString(),
                            Contrasena = row["Contrasena"].ToString(),
                            Rol = int.Parse(row["Rol"].ToString()),
                            Usuario = int.Parse(row["UsuarioActualiza"].ToString())
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

        public List<GetUsuariosModel> GetUsuarios()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetUsuariosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetUsuario", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetUsuariosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Contrasena = row["Contrasena"].ToString(),
                            Rol = row["Rol"].ToString(),
                            Usuario = row["Usuario"].ToString(),
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

        public int UpdateUsuarios(UpdateUsuariosModel usuarios)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateUsuariosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = usuarios.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = usuarios.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pContrasena", SqlDbType = SqlDbType.VarChar, Value = usuarios.Contrasena });
                parametros.Add(new SqlParameter { ParameterName = "@pRol", SqlDbType = SqlDbType.Int, Value = usuarios.Rol });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = usuarios.Usuario });
                DataSet ds = dac.Fill("sp_UpdateUsuarios", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new UpdateUsuariosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Contrasena = row["Contrasena"].ToString(),
                            Rol = int.Parse(row["Rol"].ToString()),
                            Usuario = int.Parse(row["UsuarioActualiza"].ToString())
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

        public int DeleteUsuarios(DeleteUsuariosModel usuarios)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteUsuariosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = usuarios.Id });
                DataSet ds = dac.Fill("sp_DeleteUsuarios", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new DeleteUsuariosModel
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

        public List<GetLoginUserModel> GetLogin(GetLoginUserModel usuarios)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetLoginUserModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.VarChar, Value = usuarios.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pContrasena", SqlDbType = SqlDbType.VarChar, Value = usuarios.Contrasena });
                DataSet ds = dac.Fill("sp_GetLogin", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetLoginUserModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Perfil = row["Perfil"].ToString(),
                            Nombre = row["Nombre"].ToString(),
                        });
                    }

                    return lista;
                }
                else
                {
                    return lista;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return lista;
            }


        }


    }
}
