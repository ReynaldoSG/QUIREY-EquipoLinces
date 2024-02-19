using System;
using System.Collections.Generic;
using System.Data;
using marcatel_api.Models;
using marcatel_api.DataContext;
using System.Collections;
using System.Data.SqlClient;



namespace marcatel_api.Services
{
    public class MapeosService
    {
        private  string connection;
        public MapeosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public List<InvAreaModel>GetAreasInv()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InvAreaModel>();
            try
            {
                DataSet ds = dac.Fill("sp_get_areas", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new InvAreaModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),

                        });
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public int InsertMapeo(InsertMapeo mapeo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            int folio = 0;
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdArea", SqlDbType = SqlDbType.VarChar, Value = mapeo.IdArea });
                parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = mapeo.IdSucursal });
                parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = mapeo.IdUsuario });
                parametros.Add(new SqlParameter { ParameterName = "@pMueble", SqlDbType = SqlDbType.VarChar, Value = mapeo.Mueble });
                parametros.Add(new SqlParameter { ParameterName = "@pZona", SqlDbType = SqlDbType.VarChar, Value = mapeo.Zona });
                parametros.Add(new SqlParameter { ParameterName = "@pCara", SqlDbType = SqlDbType.VarChar, Value = mapeo.Cara });
             //   parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = SqlDbType.VarChar, Value = mapeo.Tipo });
                DataSet ds = dac.Fill("sp_insert_mapeo", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        folio = int.Parse(dr["Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
            return folio;

        }

        public List<MapeoModel>GetMapeosImpresion(int id_sucursal, int impresion, int id_usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<MapeoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pImpreso", SqlDbType = SqlDbType.VarChar, Value = impresion });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = id_usuario });
            try
            {
                DataSet ds = dac.Fill("sp_get_mapeos_impresion", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            IdArea = 1,
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            Estado = dr["Estado"].ToString()
                           
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                throw;
            }
            return lista;
        }

        public int InsertDetalleMapeo(RenglonMapeoModel renglon)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            int valor = 0;
            parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = renglon.IdMapeo });
            parametros.Add(new SqlParameter { ParameterName = "@pEstante", SqlDbType = SqlDbType.VarChar, Value = renglon.Estante });
            parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = renglon.Codigo });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = renglon.IdUsuario });
            parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = SqlDbType.VarChar, Value = renglon.Tipo });
            parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.VarChar, Value = renglon.CantidadDirecto });

            try
            {
                DataSet ds = dac.Fill("sp_insert_detalle_mapeo", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        valor = int.Parse(dr["Id"].ToString());
                    }

                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return valor;

        }

        public int CongelarInventario(int sucursal, string fecha, string fecha_inicial, string fecha_final)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            int valor = 0;
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = fecha });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });

            try
            {
                DataSet ds = dac.Fill("INV_CongelarInventario", parametros);
                if (ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        valor = int.Parse(dr["Id"].ToString());
                    }

                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return valor;

        }

        public List<RenglonMapeoModel>GetDetalleMapeo(int id, int tipo)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            
            var lista = new List<RenglonMapeoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = id });
            parametros.Add(new SqlParameter { ParameterName = "@pTipo", SqlDbType = SqlDbType.VarChar, Value = tipo });
            try
            {
                DataSet ds = dac.Fill("sp_get_detalle_mapeo", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new RenglonMapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Consecutivo = int.Parse(dr["ConsecutivoMueble"].ToString()),
                            Estante = int.Parse(dr["Estante"].ToString()),
                            DescripcionArticulo = dr["ARTC_DESCRIPCION"].ToString(),
                            Codigo = dr["CodigoProducto"].ToString(),
                            IdMapeo = int.Parse(dr["IdMapeo"].ToString()),
                            CantidadCaptura = float.Parse(dr["Captura"].ToString())
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public List<MapeoModel>GetMapeosCapturar(int id_sucursal, int id_usuario)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<MapeoModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = id_usuario });
            parametros.Add(new SqlParameter { ParameterName = "@pImpreso", SqlDbType = SqlDbType.VarChar, Value = 0 });
            try
            {
                DataSet ds = dac.Fill("sp_get_mapeos_captura", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            NombreUsuario = dr["nombre_usuario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Fecha = dr["Fecha"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                
            }
            return list;
        }

        public List<MapeoModel>GetMapeosCapturados(int id_sucursal, int id_usuario)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<MapeoModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = id_usuario });
            parametros.Add(new SqlParameter { ParameterName = "@pImpreso", SqlDbType = SqlDbType.VarChar, Value = 0 });
            try
            {
                DataSet ds = dac.Fill("MAP_GetMapeosCapturados", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            NombreUsuario = dr["nombre_usuario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Fecha = dr["Fecha"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                
            }
            return list;
        }

        public List<CantidadesCapturadasModel>GetCantidadesCapturadas(int id_sucursal, string fecha)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<CantidadesCapturadasModel>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = fecha });
            try
            {
                DataSet ds = dac.Fill("INV_GetCapturaFecha", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new CantidadesCapturadasModel
                        {
                            Codigo = dr["CodigoProducto"].ToString(),
                            Cantidad = decimal.Parse(dr["Cantidad"].ToString()),
                            Descripcion = dr["ARTC_DESCRIPCION"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return list;
        }

        public List<GetDiferenciasInventarios>GetDiferenciasInventarios(int id_sucursal, string fecha, int idDepto)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var list = new List<GetDiferenciasInventarios>();

            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = fecha });
            parametros.Add(new SqlParameter { ParameterName = "@pIdDepartamento", SqlDbType = SqlDbType.VarChar, Value = idDepto });
            try
            {
                DataSet ds = dac.Fill("INV_GetDiferenciasInventarios", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new GetDiferenciasInventarios
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Capturado = decimal.Parse(dr["Capturado"].ToString()),
                            Congelado = decimal.Parse(dr["Cantidad"].ToString()),
                            Descripcion =  dr["ARTC_DESCRIPCION"].ToString(),
                            Diferencia = decimal.Parse(dr["TeoricoCalculado"].ToString()) - decimal.Parse(dr["Capturado"].ToString()),
                            SalidaVenta = decimal.Parse(dr["salidaVenta"].ToString()),
                            SalidaPConsumo = decimal.Parse(dr["SalidaPConsumo"].ToString()) ,
                            SalidaConversion = decimal.Parse(dr["SalidaPConversion"].ToString()),
                            SalidaPmerma = decimal.Parse(dr["SalidaPmerma"].ToString()) ,
                            SalidaTransferencia  = decimal.Parse(dr["salidaPTransfer"].ToString()),
                            EntradaPTraspaso  = decimal.Parse(dr["EntradaPTraspaso"].ToString()),
                            EntradaPConversion = decimal.Parse(dr["EntradaPConversion"].ToString()),
                            EntradaSOrden = decimal.Parse(dr["EntradaSOrden"].ToString()),
                            EntradaDevolucion  = decimal.Parse(dr["EntradaDevolucion"].ToString()),
                            Teorico  =  decimal.Parse(dr["TeoricoCalculado"].ToString()),

                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return list;
        }

        public void FinalizarMapeo(int id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = id });
            try
            {
                dac.ExecuteNonQuery("sp_finalizar_mapeo", parametros);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
        }

        public MapeoModel GetDatosMapeo(int id)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = id });
                DataSet ds = dac.Fill("sp_get_datos_mapeo", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        mapeo.Zona = dr["Zona"].ToString();
                        mapeo.Mueble = dr["Mueble"].ToString();
                        mapeo.Cara = dr["Cara"].ToString();
                        mapeo.Id = int.Parse(dr["Id"].ToString());
                        mapeo.Fecha = dr["Fecha"].ToString();
                        mapeo.Area = dr["Area"].ToString();
                        mapeo.IdArea = int.Parse(dr["IdArea"].ToString());
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return mapeo;
        }

        public List<MapeoModel>GetMapeos(int id_sucursal)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<MapeoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = 1 });
            try
            {
                
                DataSet ds = dac.Fill("sp_get_mapeos", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new MapeoModel
                        {
                            Id = int.Parse(dr["Id"].ToString()),
                            IdArea = int.Parse(dr["IdArea"].ToString()),
                            Area = dr["Area"].ToString(),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString(),
                            NombreUsuario = dr["nombre_usuario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Fecha = dr["Fecha"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public int InsertCaptura(CapturaModel captura)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdDetalle", SqlDbType = SqlDbType.VarChar, Value = captura.IdRenglon });
                parametros.Add(new SqlParameter { ParameterName = "@pCodigo", SqlDbType = SqlDbType.VarChar, Value = captura.Codigo });
                parametros.Add(new SqlParameter { ParameterName = "@pCantidad", SqlDbType = SqlDbType.VarChar, Value = captura.Cantidad });
                parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = captura.IdUsuario });
                parametros.Add(new SqlParameter { ParameterName = "@pFecha", SqlDbType = SqlDbType.VarChar, Value = captura.Fecha });
                dac.ExecuteNonQuery("sp_insert_captura", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
                
            }
        }

        public int FinalizarCaptura(int id, int usuario)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            int numero = 0;
            parametros.Add(new SqlParameter { ParameterName = "@pIdMapeo", SqlDbType = SqlDbType.VarChar, Value = id });
            parametros.Add(new SqlParameter { ParameterName = "@pIdUsuario", SqlDbType = SqlDbType.VarChar, Value = usuario });
            try
            {
                dac.ExecuteNonQuery("sp_finalizar_captura", parametros);
                numero = 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return numero;
        }

        public List<CostoInventarioModel>GetReporteValorInventario(string fecha_inicial, string fehca_final)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<CostoInventarioModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fehca_final });
            try
            {
                
                DataSet ds = dac.Fill("INV_ReprteCostoInventario", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new CostoInventarioModel
                        {
                            IdFamilia = int.Parse(dr["Id"].ToString()),
                            NombreFamilia = dr["nombre"].ToString(),
                            NombreDepartamento = dr["Departamento"].ToString(),
                            Ventas =  decimal.Parse(dr["Ventas"].ToString()),
                            Compras =  decimal.Parse(dr["Compras"].ToString()),
                            Devoluciones =  decimal.Parse(dr["DevolVentas"].ToString()),
                            Ajustes =  decimal.Parse(dr["Ajuste"].ToString()),
                            Mermas =  decimal.Parse(dr["Mermas"].ToString()),
                            TransferEntradas =  decimal.Parse(dr["Transf_Entradas"].ToString()),
                            TransferSalidas =  decimal.Parse(dr["Sal_transferencia"].ToString()),
                            NotasCargo =  decimal.Parse(dr["notasCargo"].ToString()),
                            InvInicial = decimal.Parse(dr["InvInicial"].ToString())
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public List<KardexArticuloModel>GetKardexArticulos(string fecha_inicial, string fecha_final, int sucursal)
        {
            var mapeo = new MapeoModel();
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            var lista = new List<KardexArticuloModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pFechaInicial", SqlDbType = SqlDbType.VarChar, Value = fecha_inicial });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.VarChar, Value = fecha_final });
            parametros.Add(new SqlParameter { ParameterName = "@pSucursal", SqlDbType = SqlDbType.VarChar, Value = sucursal });
            try
            {
                
                DataSet ds = dac.Fill("INV_GetKardexArticulos", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new KardexArticuloModel
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Cantidad = decimal.Parse( dr["cantidad"].ToString()),
                            SalidaVentas = decimal.Parse( dr["salidaVenta"].ToString()),
                            SalidaConsumo = decimal.Parse( dr["SalidaPConsumo"].ToString()),
                            SalidaMerma = decimal.Parse( dr["SalidaPmerma"].ToString()),
                            SalidaTransferencia = decimal.Parse( dr["salidaPTransfer"].ToString()),
                            SalidaConversion = decimal.Parse( dr["SalidaPConversion"].ToString()),
                            EntradaTraspaso = decimal.Parse( dr["EntradaPTraspaso"].ToString()),
                            EntradasConversion = decimal.Parse( dr["EntradaPConversion"].ToString()),
                            EntradasDevolucion = decimal.Parse( dr["EntradaDevolucion"].ToString()),
                            EntradasSinOrden = decimal.Parse( dr["EntradaSOrden"].ToString()),
                            Teorico = decimal.Parse(dr["Teorico"].ToString())
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }

        public List<MapeosCodigoModel>GetMapeosCodigo(string codigo, string fecha, int id_sucursal)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            
            var lista = new List<MapeosCodigoModel>();
            parametros.Add(new SqlParameter { ParameterName = "@pArticulo", SqlDbType = SqlDbType.VarChar, Value = codigo });
            parametros.Add(new SqlParameter { ParameterName = "@pFechaConteo", SqlDbType = SqlDbType.VarChar, Value = fecha });
            parametros.Add(new SqlParameter { ParameterName = "@pIdSucursal", SqlDbType = SqlDbType.VarChar, Value = id_sucursal });
            try
            {
                DataSet ds = dac.Fill("INV_GetMapeosArticulo", parametros);
                if(ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        lista.Add(new MapeosCodigoModel
                        {
                            IdDetalleMapeo = int.Parse(dr["IdDetalleMapeo"].ToString()),
                            Descripcion = dr["ARTC_DESCRIPCION"].ToString(),
                            Codigo = dr["CodigoProducto"].ToString(),
                            IdMapeo = int.Parse(dr["IdMapeo"].ToString()),
                            Cantidad = decimal.Parse(dr["Cantidad"].ToString()),
                            Zona = dr["Zona"].ToString(),
                            Mueble = dr["Mueble"].ToString(),
                            Cara = dr["Cara"].ToString()
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
            }
            return lista;
        }
    }

    
}