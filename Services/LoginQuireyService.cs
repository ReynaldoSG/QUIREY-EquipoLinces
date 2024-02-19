using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;

namespace marcatel_api.Services
{
    public class LoginQuireyService
    {
        private  string connection;
        public LoginQuireyService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public GetCatPerfil GetCatPerfil(int perfil)
        {
            GetCatPerfil usuario = new GetCatPerfil();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@pPerfil", SqlDbType = SqlDbType.VarChar, Value = perfil });
                DataSet ds = dac.Fill("sp_GetCategoriaConPerfil", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        usuario.Id = int.Parse(row["Id"].ToString());
                        usuario.Categoria = row["Categoria"].ToString();
                    
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetModCat GetModCat(int categoria)
        {
            GetModCat usuario = new GetModCat();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@pCategoria", SqlDbType = SqlDbType.Int, Value = categoria });
                DataSet ds = dac.Fill("sp_GetModuloConCategoria", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        usuario.Id = int.Parse(row["Id"].ToString());
                        usuario.Modulo = row["Modulo"].ToString();
                        usuario.Categoria = row["Categoria"].ToString();
                    
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
    }
}
