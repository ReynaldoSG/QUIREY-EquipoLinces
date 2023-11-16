using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class MovInventarioService
    {
        private  string connection;
        public MovInventarioService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }


    public List<GetMovInventarioModels> GetMovInventario()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetMovInventarioModels>();
            try
            {
                DataSet ds = dac.Fill("sp_GetMovimientosInv", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetMovInventarioModels
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            IdTipoMov = row["TipoMovimiento"].ToString(),
                            IdAlmacen = row["Almacen"].ToString(),
                            fechaMovimiento = DateTime.Parse(row["FechaMovimiento"].ToString()),
                            Estatus = row["Estatus"].ToString(),
                            Usuario = row["UsuarioActualiza"].ToString(),
                            FechaActualiza = DateTime.Parse(row["FechaActualiza"].ToString())
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
