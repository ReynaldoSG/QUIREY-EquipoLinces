using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class VendedoresService
    {
        private  string connection;
        public VendedoresService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }


    public List<GetVendedoresModel> GetVendedores()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetVendedoresModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetVendedores", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetVendedoresModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            NombreVendedor = row["Vendedor"].ToString(),
                            Sucursal = row["Sucursal"].ToString(),
                            Estatus = row["Estatus"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString(),
                            FechaRegistro = DateTime.Parse(row["FechaRegistro"].ToString()),
                            FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString())

                        });
                    }
                }
                return lista;
                
            }
            catch (Exception ex)
            {
                throw ex; // Opcional: lanzar la excepción para mantener el flujo
            }
            
            
        }
    }
}