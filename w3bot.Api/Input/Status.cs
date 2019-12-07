using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3bot.Input
{
    public static class Status
    {
        public static string Log(string text)
        {
            return Core.Core.AppendTextToLog(text, Color.Black);
        }

        public static string Log(Object obj)
        {
            return Core.Core.AppendTextToLog(obj == null ? "null" : obj.ToString(), Color.Black);
        }

        public static string Warning(string text)
        {
            return Core.Core.AppendTextToLog(text, Color.Red);
        }

        public static string Warning(Object obj)
        {
            return Core.Core.AppendTextToLog(obj == null ? "null" : obj.ToString(), Color.Red);
        }

        public static string HandleException(Action codeToHandle)
        {
            string result = null;
            try
            {
                codeToHandle();
            }
            catch (Exception e)
            {
                result = Warning(e);
            }
            return result;
        }
    }
}
