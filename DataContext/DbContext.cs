using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace marcatel_api.DataContext
{
    public class ConexionDataAccess
    {
     
        SqlConnection SqlCon;
        string Configuration;
        public ConexionDataAccess(string source)
        {
            SqlCon = new SqlConnection();
            Configuration = source;
           
        }
        public SqlConnection GetConnection()
        {
         ;

            SqlConnection connection = new SqlConnection(Configuration);

            return connection;
        }

        public void ExecuteNonQuery(string procedimiento, ArrayList parametros)
        {
            try
            {
                this.SqlCon = this.GetConnection();
                this.SqlCon.Open();

                SqlCommand mComando = new SqlCommand(procedimiento, SqlCon);
                mComando.CommandType =  System.Data.CommandType.StoredProcedure;

                foreach (SqlParameter param in parametros)
                {
                    mComando.Parameters.Add(param);
                }
                mComando.CommandTimeout = 10000;
                mComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                SqlCon.Close();
                throw ex;

            }
            finally
            {
                SqlCon.Close();
            }
        }
        public DataSet Fill(string procedimiento, ArrayList parametros)
        {
            DataSet mDataSet = new DataSet();

            try
            {
                this.SqlCon = this.GetConnection();
                this.SqlCon.Open();


                SqlCommand mComando = new SqlCommand(procedimiento, SqlCon);
                SqlDataAdapter mDataAdapter = new SqlDataAdapter(mComando);

                mComando.CommandType = CommandType.StoredProcedure;
                mComando.CommandTimeout = 600;

                foreach (SqlParameter param in parametros)
                {
                    mComando.Parameters.Add(param);
                }

                mDataAdapter.Fill(mDataSet);
                return mDataSet;
            }
            catch (Exception ex)
            {
                this.SqlCon.Close();
                throw ex;
               
            }
            finally
            {
            this.SqlCon.Close();
            }
        }
        public DataSet Fill(string procedimiento)
        {
            DataSet mDataSet = new DataSet();

            try
            {
                this.SqlCon = this.GetConnection();
                this.SqlCon.Open();


                SqlCommand mComando = new SqlCommand(procedimiento, SqlCon);
                SqlDataAdapter mDataAdapter = new SqlDataAdapter(mComando);

                mComando.CommandType = CommandType.StoredProcedure;
                mComando.CommandTimeout = 600;

            

                mDataAdapter.Fill(mDataSet);
                return mDataSet;
            }
            catch (Exception ex)
            {
                this.SqlCon.Close();
                throw ex;

            }
            finally
            {
                this.SqlCon.Close();
            }
        }
    }
}


