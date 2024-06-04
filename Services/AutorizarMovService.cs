using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class AutorizarMovService
    {
        private string connection;
        public AutorizarMovService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int AutorizarMovInv(AutorizarMovModel autorizarmov)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = autorizarmov.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.VarChar, Value = autorizarmov.Estatus });

                DataSet ds = dac.Fill("sp_AutorizarMov", parametros);

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
