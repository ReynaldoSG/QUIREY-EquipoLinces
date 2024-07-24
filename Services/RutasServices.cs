using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class RutasService
    {
        private string connection;
        public RutasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }
        public List<GetRutasModel> GetRutas()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRutasModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetRutas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetRutasModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString()),
                            FechaRegristro = DateTime.Parse(row["FechaRegistro"].ToString()),
                            Usuario = row["UsuarioActualiza"].ToString(),
                            Matricula = row["Matricula"].ToString(),
                            Conductor = row["NombreConductor"].ToString(),
                            NoLicencia = row["NumeroLicencia"].ToString(),
                            NoSeguro = row["NoSeguro"].ToString()
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

        public string InsertRutas(InsertRutasModel InsertRutas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRutasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = InsertRutas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = InsertRutas.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = SqlDbType.VarChar, Value = InsertRutas.Matricula });
                parametros.Add(new SqlParameter { ParameterName = "@pNombreConductor", SqlDbType = SqlDbType.VarChar, Value = InsertRutas.Conductor });
                parametros.Add(new SqlParameter { ParameterName = "@pNumLicencia", SqlDbType = SqlDbType.VarChar, Value = InsertRutas.NoLicencia });
                parametros.Add(new SqlParameter { ParameterName = "@pNumSeguro", SqlDbType = SqlDbType.VarChar, Value = InsertRutas.NoSeguro });
                DataSet ds = dac.Fill("sp_InsertRutas", parametros);
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

        public string UpdateRutas(UpdateRutasModel UpdateRutas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRutasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = UpdateRutas.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = UpdateRutas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = UpdateRutas.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = SqlDbType.VarChar, Value = UpdateRutas.Matricula });
                parametros.Add(new SqlParameter { ParameterName = "@pNombreConductor", SqlDbType = SqlDbType.VarChar, Value = UpdateRutas.Conductor });
                parametros.Add(new SqlParameter { ParameterName = "@pNumLicencia", SqlDbType = SqlDbType.VarChar, Value = UpdateRutas.NoLicencia });
                parametros.Add(new SqlParameter { ParameterName = "@pNumSeguro", SqlDbType = SqlDbType.VarChar, Value = UpdateRutas.NoSeguro });
                DataSet ds = dac.Fill("sp_UpdateRutas", parametros);
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

        public string DeleteRutas(DeleteRutasModel DeleteRutas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRutasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = DeleteRutas.Id });
                DataSet ds = dac.Fill("sp_DeleteRutas", parametros);
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
