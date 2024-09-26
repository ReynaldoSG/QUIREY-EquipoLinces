using System;
using System.Collections;
using System.Collections.Generic;
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

        public List<CategoriasModulos> ListaModulosPerfil(int idPerfil){
            var categorias = this.GetCatPerfil(idPerfil);
            List<CategoriasModulos> Modulos = new List<CategoriasModulos>();
            foreach (var categoria in categorias){
                var modulos = this.GetModCat(categoria.Id);
                Modulos.Add(new CategoriasModulos{
                    Categoria = categoria,
                    Modulos = modulos
                });
            }
            return Modulos;

        }

        public List<GetCatPerfil> GetCatPerfil(int perfil)
        {
            ArrayList parametros = new ArrayList();
            List<GetCatPerfil> usuario = new List<GetCatPerfil>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                
                parametros.Add(new SqlParameter { ParameterName = "@pPerfil", SqlDbType = SqlDbType.VarChar, Value = perfil });
                DataSet ds = dac.Fill("sp_GetCategoriaConPerfil", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        
                        usuario.Add(new GetCatPerfil{
                           Id = int.Parse(row["Id"].ToString()),
                           Categoria = row["Categoria"].ToString()
                        });
                    
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GetModCat> GetModCat(int categoria)
        {
            List<GetModCat> usuario = new List<GetModCat>();
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
                       usuario.Add(new GetModCat{
                        Id = int.Parse(row["Id"].ToString()),
                        Modulo = row["Modulo"].ToString(),
                        Categoria = row["Categoria"].ToString()
                       });
                    
                    };
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
