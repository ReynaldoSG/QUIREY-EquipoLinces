using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class TicketsService
    {
        private  string connection;
        public TicketsService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public List<GetTicketsModel> GetTickets()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTicketsModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetTickets", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTicketsModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Sucursal = row["Sucursal"].ToString(),
                            Cliente = row["Cliente"].ToString(),
                            Vendedor = row["Vendedor"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString(),
                            Fecha = DateTime.Parse(row["FechaVenta"].ToString()),
                            Estatus = row["Estatus"].ToString()
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

        public int InsertTickets(InsertTicketsModel ticket)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTicketsModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = ticket.IdSucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pIdCliente", SqlDbType = SqlDbType.VarChar, Value = ticket.IdCliente });
                parametros.Add(new SqlParameter { ParameterName = "@pIdVendedor", SqlDbType = SqlDbType.Int, Value = ticket.IdVendedor });
                parametros.Add(new SqlParameter {ParameterName = "@pUsuarioActualiza",SqlDbType= SqlDbType.Int,Value= ticket.Usuario});
                DataSet ds = dac.Fill("sp_InsertTickets", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTicketsModel
                        {
                            Sucursal = row["IdSucursal"].ToString(),
                            Cliente = row["IdCliente"].ToString(),
                            Vendedor = row["IdVendedor"].ToString(),
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

        public int UpdateTickets(UpdateTicketsModel ticket)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTicketsModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = ticket.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = ticket.Estatus });
                DataSet ds = dac.Fill("sp_UpdateTickets", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTicketsModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Estatus = row["Estatus"].ToString()

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

        public int DeleteTickets(DeleteTicketsModel ticket)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTicketsModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = ticket.Id });
                DataSet ds = dac.Fill("sp_DeleteTickets", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTicketsModel
                        {
                            Sucursal = row["IdSucursal"].ToString(),
                            Cliente = row["IdCliente"].ToString(),
                            Vendedor = row["IdVendedor"].ToString(),
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
