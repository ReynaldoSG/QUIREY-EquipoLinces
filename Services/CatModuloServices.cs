using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class CatModuloService
    {
        private string connection;
        public CatModuloService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<GetCatModuloModel> GetCatModulo()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetCatModuloModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetCategoriaModulo", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetCatModuloModel
                        {
                            Id = int.Parse(row["id"].ToString()),
                            Nombre = row["nombre"].ToString(),
                            Descripcion = row["descripcion"].ToString(),
                            FechaRegistro = DateTime.Parse(row["fechaRegristro"].ToString()),
                            FechaActualiza = DateTime.Parse(row["fechaActualiza"].ToString()),
                            Usuario = row["usuarioActualiza"].ToString(),
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


        public string InsertCatModulo(InsertCatModuloModel catModulo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetCatModuloModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = catModulo.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = catModulo.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = catModulo.Usuario });
                DataSet ds = dac.Fill("sp_InsertCategoriaModulo", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public string UpdateCatModulo(UpdateCatModuloModel catModulo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetCatModuloModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = catModulo.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = catModulo.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = catModulo.Descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = catModulo.Usuario });
                DataSet ds = dac.Fill("sp_UpdateCategoriaModulo", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public string DeleteCatModulo(DeleteCatModuloModel catModulo)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetCatModuloModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = catModulo.Id });
                DataSet ds = dac.Fill("sp_DeleteCategoriaModulo", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }

        }


    }
}
