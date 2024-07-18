using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class AlmacenesService
    {
        private string connection;
        public AlmacenesService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int InsertAlmacenes(InsertAlmacenesModel almacen)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetAlmacenesModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = almacen.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = almacen.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pEncargado", SqlDbType = SqlDbType.Int, Value = almacen.Encargado });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = almacen.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@pEncargado", SqlDbType = SqlDbType.Int, Value = almacen.Encargado });
                DataSet ds = dac.Fill("sp_InsertAlmacenes", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetAlmacenesModel
                        {
                            Nombre = row["Nombre"].ToString(),
                            Direccion = row["Direccion"].ToString(),
                            Encargado = row["Encargado"].ToString(),
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

        public List<GetAlmacenesModel> GetAlmacenes()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetAlmacenesModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetAlmacenes", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetAlmacenesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Direccion = row["Direccion"].ToString(),
                            Encargado = row["Encargado"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString(),
                            FechaReg = DateTime.Parse(row["FechaRegistro"].ToString()),
                            FechaAct = DateTime.Parse(row["FechaActualiza"].ToString()),
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

        public int UpdateAlmacenes(UpdateAlmacenesModel almacen)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetAlmacenesModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = almacen.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = almacen.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = almacen.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pEncargado", SqlDbType = SqlDbType.Int, Value = almacen.Encargado });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = almacen.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@pEncargado", SqlDbType = SqlDbType.Int, Value = almacen.Encargado });
                DataSet ds = dac.Fill("sp_UpdateAlmacenes", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetAlmacenesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Direccion = row["Direccion"].ToString(),
                            Encargado = row["Encargado"].ToString(),
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

        public int DeleteAlmacenes(DeleteAlmacenesModel almacen)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetAlmacenesModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = almacen.Id });
                DataSet ds = dac.Fill("sp_DeleteAlmacenes", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetAlmacenesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Direccion = row["Direccion"].ToString(),
                            Encargado = row["Encargado"].ToString(),
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


    }
}
