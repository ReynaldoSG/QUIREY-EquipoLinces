using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class EstadosService
    {
        private  string connection;
        public EstadosService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }


                public List<GetEstadosModel> GetEstados()
                {
                    ArrayList parametros = new ArrayList();
                    ConexionDataAccess dac = new ConexionDataAccess(connection);
                    var lista = new List<GetEstadosModel>();
                    try
                    {
                        DataSet ds = dac.Fill("sp_GetEstados",parametros);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                lista.Add(new GetEstadosModel
                                {
                                    Id = int.Parse(row["Id"].ToString()),
                                    NombreEstado = row["NombreEstado"].ToString()
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

        public int InsertEstados(InsertEstadosModel estados)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEstadosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pEstado", SqlDbType = SqlDbType.VarChar, Value = estados.NombreEstado });

                DataSet ds = dac.Fill("sp_InsertEstados", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetEstadosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NombreEstado = row["NombreEstado"].ToString()
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

        public int UpdateEstados(UpdateEstadosModel Estados)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEstadosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = Estados.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pEstado", SqlDbType = SqlDbType.VarChar, Value = Estados.NombreEstado });
                DataSet ds = dac.Fill("sp_UpdateEstados", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetEstadosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NombreEstado = row["Codigo"].ToString()
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
    }}
