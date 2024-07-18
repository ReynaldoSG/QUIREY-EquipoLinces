using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class PuestosService
    {
        private string connection;
        public PuestosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<GetPuestosModel> GetPuestos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetPuestosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetPuestos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetPuestosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            nombre = row["nombre"].ToString(),
                            descripcion = row["descripcion"].ToString(),
                            salario = decimal.Parse(row["salario"].ToString()),
                            usuarioActualiza = row["UsuarioActualiza"].ToString(),
                            fechaRegistro = DateTime.Parse(row["fechaRegistro"].ToString()),
                            fechaActualiza = DateTime.Parse(row["fechaActualiza"].ToString())
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


        public string InsertPuestos(InsertPuestoModel puesto)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetPuestosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = puesto.nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = puesto.descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pSalario", SqlDbType = SqlDbType.Decimal, Value = puesto.salario });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioAct", SqlDbType = SqlDbType.Decimal, Value = puesto.usuarioActualiza });

                DataSet ds = dac.Fill("sp_InsertPuesto", parametros);
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

        public string UpdatePuestos(UpdatePuestoModel puesto)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetPuestosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = puesto.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = puesto.nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = puesto.descripcion });
                parametros.Add(new SqlParameter { ParameterName = "@pSalario", SqlDbType = SqlDbType.Decimal, Value = puesto.salario });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioAct", SqlDbType = SqlDbType.Decimal, Value = puesto.usuarioActualiza });
                DataSet ds = dac.Fill("sp_UpdatePuesto", parametros);

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

        public string DeletePuesto(DeletePuestoModel puesto)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetPuestosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = puesto.Id });
                DataSet ds = dac.Fill("sp_DeletePuesto", parametros);
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
