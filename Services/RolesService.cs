using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class RolesService
    {
        private  string connection;
        public RolesService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }
        public List<GetRolesModel> GetRoles()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetRolesModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetRoles", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetRolesModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Rol = row["Rol"].ToString()
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
    }
}
