using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class PersonasService
    {
        private string connection;
        public PersonasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertPersonas(InsertPersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = personas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = personas.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = personas.Usuario });




                DataSet ds = dac.Fill("sp_InsertPersonas", parametros);
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

        public List<GetPersonasModel> GetPersonas()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetPersonasModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetPersonas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetPersonasModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            ApPaterno = row["ApPaterno"].ToString(),
                            ApMaterno = row["ApMaterno"].ToString(),
                            Direccion = row["Direccion"].ToString(),
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

        public string UpdatePersonas(UpdatePersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = personas.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = personas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = personas.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.Int, Value = personas.Usuario });

                DataSet ds = dac.Fill("sp_UpdatePersonas", parametros);
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

        public string DeletePersonas(DeletePersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = personas.Id });
                DataSet ds = dac.Fill("sp_DeletePersonas", parametros);
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
