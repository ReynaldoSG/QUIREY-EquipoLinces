using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class DetallePerfilService
    {
        private  string connection;
        public DetallePerfilService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }
                public List<GetDetallePerfilModel> GetDetallePerfil()
                {
                    ArrayList parametros = new ArrayList();
                    ConexionDataAccess dac = new ConexionDataAccess(connection);
                    var lista = new List<GetDetallePerfilModel>();
                    try
                    {
                        DataSet ds = dac.Fill("sp_GetDetallePerfil", parametros);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                lista.Add(new GetDetallePerfilModel
                                {
                                    Id = int.Parse(row["Id"].ToString()),
                                    nombreModulo = row["Nombre Modulo"].ToString(),
                                    Rol = row["Rol"].ToString(),
                                    acceso = int.Parse(row["acceso"].ToString()),
                                    fechaRegistro = DateTime.Parse(row["fechaRegistro"].ToString()),
                                    fechaActualiza = DateTime.Parse(row["fechaActualiza"].ToString()),
                                    Estatus = row["Estatus"].ToString(),
                                    UsuarioActualiza = row["Usuario Actualiza"].ToString()
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

        public int InsertDetallePerfil(InsertDetallePerfilModel detallePerfil)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertDetallePerfilModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pidPerfil", SqlDbType = SqlDbType.Int, Value = detallePerfil.idPerfil });
                parametros.Add(new SqlParameter { ParameterName = "@pidModulo", SqlDbType = SqlDbType.Int, Value = detallePerfil.idModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pacceso", SqlDbType = SqlDbType.Bit, Value = detallePerfil.acceso });
                parametros.Add(new SqlParameter { ParameterName = "@pusuarioActualiza", SqlDbType = SqlDbType.Decimal, Value = detallePerfil.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_InsertDetallePerfil", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new InsertDetallePerfilModel
                        {
                            idPerfil = int.Parse(row["idPerfil"].ToString()),
                            idModulo = int.Parse(row["idModulo"].ToString()),
                            acceso = int.Parse(row["acceso"].ToString()),
                            UsuarioActualiza = int.Parse(row["usuarioActualiza"].ToString())
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

        public int UpdateDetallePerfil(UpdateDetallePerfilModel detallePerfil)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetallePerfilModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pid", SqlDbType = SqlDbType.Int, Value = detallePerfil.id });
                parametros.Add(new SqlParameter { ParameterName = "@pidPerfil", SqlDbType = SqlDbType.Int, Value = detallePerfil.idPerfil });
                parametros.Add(new SqlParameter { ParameterName = "@pidModulo", SqlDbType = SqlDbType.Int, Value = detallePerfil.idModulo });
                parametros.Add(new SqlParameter { ParameterName = "@pacceso", SqlDbType = SqlDbType.Bit, Value = detallePerfil.acceso });
                parametros.Add(new SqlParameter { ParameterName = "@pusuarioActualiza", SqlDbType = SqlDbType.Int, Value = detallePerfil.UsuarioActualiza });
                parametros.Add(new SqlParameter { ParameterName = "@pestatus", SqlDbType = SqlDbType.Int, Value = detallePerfil.estatus });
                DataSet ds = dac.Fill("sp_UpdateDetallePerfil", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetallePerfilModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            nombreModulo = row["Nombre Modulo"].ToString(),
                            Rol = row["Rol"].ToString(),
                            acceso = int.Parse(row["acceso"].ToString()),
                            fechaRegistro = DateTime.Parse(row["fechaRegistro"].ToString()),
                            fechaActualiza = DateTime.Parse(row["fechaActualiza"].ToString()),
                            Estatus = row["Estatus"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString()
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

        public int DeleteDetallePerfil(DeleteDetallePerfilModel detallePerfil)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDetallePerfilModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = detallePerfil.Id });
                DataSet ds = dac.Fill("sp_DeleteDetallePerfil", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDetallePerfilModel
                        {
                            Id = int.Parse(row["Id"].ToString())
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
