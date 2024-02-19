using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class EmpleadosService
    {
        private  string connection;
        public EmpleadosService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }


                public List<GetEmpleadosModel> GetEmpleados()
                {
                    ArrayList parametros = new ArrayList();
                    ConexionDataAccess dac = new ConexionDataAccess(connection);
                    var lista = new List<GetEmpleadosModel>();
                    try
                    {
                        

                        DataSet ds = dac.Fill("sp_GetEmpleado", parametros);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                lista.Add(new GetEmpleadosModel
                                {
                                    Id = int.Parse(row["Id"].ToString()),
                                    Persona = row["Persona"].ToString(),
                                    Sucursal = row["Sucursal"].ToString(),
                                    Puesto = row["Puesto"].ToString(),
                                    usuarioActualiza = row["usuarioActualiza"].ToString(),
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
                public int InsertEmpleado(InsertEmpleadosModel empleadosModel)
            {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEmpleadosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdPersona", SqlDbType = SqlDbType.Int, Value = empleadosModel.IdPersona });
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.Int, Value = empleadosModel.IdSucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pIdPuesto", SqlDbType = SqlDbType.Int, Value = empleadosModel.IdPuesto });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioAct", SqlDbType = SqlDbType.Int, Value = empleadosModel.usuarioActualiza });
              

                DataSet ds = dac.Fill("sp_InsertEmpleado", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                         lista.Add(new GetEmpleadosModel
                                {
                                  Persona = row["Persona"].ToString(),
                                  Sucursal = row["Sucursal"].ToString(),
                                  Puesto = row["Puesto"].ToString(),
                                  fechaRegistro = DateTime.Parse(row["fechaRegistro"].ToString()),
                                  fechaActualiza = DateTime.Parse(row["fechaActualiza"].ToString()),
                                  usuarioActualiza = row["UsuarioActualiza"].ToString()
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
           public int UpdateEmpleados(UpdateEmpleadosModel empleadosModel)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEmpleadosModel>();

            try
            {
                parametros.Add(new SqlParameter {ParameterName="@pId", SqlDbType = SqlDbType.Int, Value= empleadosModel.Id});
                parametros.Add(new SqlParameter { ParameterName = "@pIdPersona", SqlDbType = SqlDbType.Int, Value = empleadosModel.IdPersona });
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.Int, Value = empleadosModel.IdSucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pIdPuesto", SqlDbType = SqlDbType.Int, Value = empleadosModel.IdPuesto });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioAct", SqlDbType = SqlDbType.Int, Value = empleadosModel.usuarioActualiza });
                DataSet ds = dac.Fill("sp_UpdateEmpleados", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetEmpleadosModel
                        {
                          Id = int.Parse(row["Id"].ToString()), 
                          Persona = row["Persona"].ToString(),
                          Sucursal = row["Sucursal"].ToString(),
                          Puesto = row["Puesto"].ToString(),
                          fechaRegistro = DateTime.Parse(row["fechaRegistro"].ToString()),
                          fechaActualiza = DateTime.Parse(row["fechaActualiza"].ToString()),
                          usuarioActualiza = row["UsuarioActualiza"].ToString()

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

        public int DeleteEmpleados(DeleteEmpleadosModel empleadosModel)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEmpleadosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = empleadosModel.Id });
                DataSet ds = dac.Fill("sp_DeleteEmpleados", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetEmpleadosModel
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



    }
}
