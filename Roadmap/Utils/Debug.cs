using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roadmap.Utils
{
    public static class Debug
    {
        public static void LogError(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);

            if (ex.InnerException != null)
            {
                LogError(ex.InnerException);
            }
        }

        public static string GetDefaultErrorMessage()
        {
            return "Во время выполнения операции произошла ошибка";
        }
    }
}