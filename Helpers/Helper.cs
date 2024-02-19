using System;
using marcatel_api.Models;

namespace marcatel_api.Helpers
{
    public class Helper
    {
        public Helper()
        {
        }
        // Returns structure for Json Response
        public static DataResponse GetStructResponse()
        {
            return new DataResponse
            {
                StatusCode=0,
                success = false,
                message = "",
              
                response = new { data = "" }

            };
        }
    }
}
