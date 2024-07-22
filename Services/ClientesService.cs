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
        private string connection;
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
                            FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString()),
                            Telefono = row["Telefono"].ToString(),
                            RFC = row["RFC"].ToString(),
                            CURP = row["CURP"].ToString(),
                            Email = row["EMail"].ToString(),
                            Coordenadas = row["Coordenadas"].ToString()
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


        public string InsertClientes(InsertClientesModel cliente)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = cliente.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = cliente.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = cliente.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@pTelefono", SqlDbType = SqlDbType.VarChar, Value = cliente.Telefono });
                parametros.Add(new SqlParameter { ParameterName = "@pRFC", SqlDbType = SqlDbType.VarChar, Value = cliente.RFC });
                parametros.Add(new SqlParameter { ParameterName = "@pCURP", SqlDbType = SqlDbType.VarChar, Value = cliente.CURP });
                parametros.Add(new SqlParameter { ParameterName = "@pEmail", SqlDbType = SqlDbType.VarChar, Value = cliente.Email });
                parametros.Add(new SqlParameter { ParameterName = "@pCoordenadas", SqlDbType = SqlDbType.VarChar, Value = cliente.Coordenadas });
                DataSet ds = dac.Fill("sp_InsertClientes", parametros);
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

        public string UpdateClientes(UpdateClientesModel cliente)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = cliente.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = cliente.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = cliente.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = cliente.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@pTelefono", SqlDbType = SqlDbType.VarChar, Value = cliente.Telefono });
                parametros.Add(new SqlParameter { ParameterName = "@pRFC", SqlDbType = SqlDbType.VarChar, Value = cliente.RFC });
                parametros.Add(new SqlParameter { ParameterName = "@pCURP", SqlDbType = SqlDbType.VarChar, Value = cliente.CURP });
                parametros.Add(new SqlParameter { ParameterName = "@pEmail", SqlDbType = SqlDbType.VarChar, Value = cliente.Email });
                parametros.Add(new SqlParameter { ParameterName = "@pCoordenadas", SqlDbType = SqlDbType.VarChar, Value = cliente.Coordenadas });
                DataSet ds = dac.Fill("sp_UpdateClientes", parametros);
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

        public string DeleteClientes(DeleteClientesModel cliente)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = cliente.Id });
                DataSet ds = dac.Fill("sp_DeleteClientes", parametros);
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
