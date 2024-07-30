using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class DetalleTicketService
    {
        private string connection;
        public DetalleTicketService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<GetDetalleTicketModel> GetDetalleTicket(GetDetalleTicketSearchModel detalleticket)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleTicketModel>();
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdTicket", SqlDbType = SqlDbType.Int, Value = detalleticket.idTicket });

                DataSet ds = dac.Fill("sp_GetDetalleTicket", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetalleTicketModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdTicket = int.Parse(row["IdTicket"].ToString()),
                            Codigo = row["Codigo"].ToString(),
                            Articulo = row["Descripcion_Articulo"].ToString(),
                            Cantidad = decimal.Parse(row["Cantidad"].ToString()),
                            PrecioVenta = decimal.Parse(row["PrecioVenta"].ToString()),
                            Total = decimal.Parse(row["Total"].ToString()),
                            TotalTicket = decimal.Parse(row["TotalTicket"].ToString()),
                            Estatus = row["Estatus"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString()
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

        public string InsertDetalleTicket(InsertDetalleTicketModel detalleticket)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleTicketModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdTicket", SqlDbType = SqlDbType.Int, Value = detalleticket.IdTicket });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = detalleticket.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = detalleticket.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pPrecioVenta", SqlDbType = SqlDbType.Decimal, Value = detalleticket.PrecioVenta });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = detalleticket.Usuario });

                DataSet ds = dac.Fill("sp_InsertDetalleTicket", parametros);

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

        public string UpdateDetalleTicket(UpdateDetalleTicketModel detalleticket)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleTicketModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = detalleticket.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = detalleticket.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.Decimal, Value = detalleticket.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pPrecioventa", SqlDbType = SqlDbType.Decimal, Value = detalleticket.PrecioVenta });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = detalleticket.Estatus });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = detalleticket.Usuario });
                DataSet ds = dac.Fill("sp_UpdateDetalleTicket", parametros);
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

        public string DeleteDetalleTicket(DeleteDetalleTicketModel detalleticket)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetalleTicketModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = detalleticket.Id });
                DataSet ds = dac.Fill("sp_DeleteDetalleTicket", parametros);
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

        public int AutorizarTickets(AutorizarTicketModel autorizarticket)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdTicket", SqlDbType = SqlDbType.Int, Value = autorizarticket.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.VarChar, Value = autorizarticket.Estatus });

                DataSet ds = dac.Fill("sp_AutorizarTicket", parametros);

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
