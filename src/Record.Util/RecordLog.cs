using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Record.Util
{
    public class RecordLogger
    {

        private static Logger log;

        private static Logger Log
        {
            get
            {
                if (log == null)
                {
                    log = LogManager.GetCurrentClassLogger();
                }

                return log;
            }
        }

        public static void LogError(Exception ex) {
            SaveExceptionLog(ex, ex.Message);
        }

        private static void SaveExceptionLog(Exception e, string message = null)
        {
            SaveExceptionLog(e, true, message);
        }

        private static void SaveExceptionLog(Exception e, bool first, string message = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                log.Info(message);
            }

            log.Error(e.Message);
            if (e.InnerException != null)
            {
                SaveExceptionLog(e.InnerException, false);
            }

            if (first)
            {
                log.Error(e.StackTrace);
            }
        }

        public static void LogInfo(string message)
        {
            Log.Info(message);
        }

    }
 }
