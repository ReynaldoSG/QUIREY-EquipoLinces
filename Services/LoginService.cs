using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;

namespace marcatel_api.Services
{
    public class LoginService
    {
        private string connection;
        public LoginService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public UsuarioModel Login(string user, string pass)
        {
            UsuarioModel usuario = new UsuarioModel();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
      try
{
    ArrayList parametros = new ArrayList();
    parametros.Add(new SqlParameter { ParameterName = "@pUsuario", SqlDbType = SqlDbType.VarChar, Value = user });
    parametros.Add(new SqlParameter { ParameterName = "@pPass", SqlDbType = SqlDbType.VarChar, Value = pass });
    DataSet ds = dac.Fill("sp_login_pv", parametros);
    if (ds.Tables[0].Rows.Count > 0)
    {
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            usuario.NombreUsuario = row["NombreUsuario"].ToString();
            usuario.NombrePersona = row["NombrePersona"].ToString();
            usuario.IdSucursal = int.Parse(row["IdSucursal"].ToString());
            usuario.NombreSucursal = row["NombreSucursal"].ToString();
            usuario.Id = int.Parse(row["Id"].ToString());
            usuario.IdPerfil = int.Parse(row["Id"].ToString());
            usuario.Rol = row["Rol"].ToString();
            usuario.IdRol = int.Parse(row["IdRol"].ToString());
        }
    }
    else
    {
        // Log this case: No records found
        Console.WriteLine("No records found for user: " + user);
        Console.WriteLine("No records found for user: " + pass);
    }
    return usuario;
}
catch (Exception ex)
{
    // Log the exception
    Console.WriteLine("An error occurred: " + ex.Message);
    throw ex;
}

        }


    }
}