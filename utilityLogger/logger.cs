using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace utilityLogger
{
    public class logger
    {
        // logging every error to a file
        public void logError(Exception _errorToWrite)
        {
            // date and time
            string message = string.Format("Time: {0}", DateTime.Now.ToString(""));
            message += Environment.NewLine;
            message += "-------------------------------";
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", _errorToWrite.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Message: {0}", _errorToWrite.Message);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", _errorToWrite.TargetSite);
            message += Environment.NewLine;
            message += "-------------------------------";
            // accessing the file to write error message
            string name = new FileInfo(AppDomain.CurrentDomain.BaseDirectory.ToString()).Directory.Parent.FullName;
            using (StreamWriter _writer = new StreamWriter(Path.Combine(name,"utilityLogger\\workoutLog.txt"), true))
            {
                // writes message to the file
                _writer.WriteLine(message);
            }
        }
    }
}
