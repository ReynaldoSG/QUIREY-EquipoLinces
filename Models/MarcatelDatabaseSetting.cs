using System;
namespace marcatel_api.Models
{
    public class MarcatelDatabaseSetting:IMarcatelDatabaseSetting
    {
       
       
        public string ConnectionString { get; set; }

     



    }
    public interface IMarcatelDatabaseSetting
    {
     
        string ConnectionString { get; set; }
    


    }
}
