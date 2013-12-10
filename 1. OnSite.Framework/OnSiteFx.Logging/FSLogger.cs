using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using mkFx.Logging;

namespace OnSiteFx.Logging
{
    public class FSLogger : ILogger
    {
        public FSLogger()
        {

            System.IO.File.AppendAllText(@"C:\FSLogger.log", "FSLogger 생성자 호출" + Environment.NewLine);
        }

        public void Write(string message)
        {
            System.IO.File.AppendAllText(@"C:\FSLogger.log", message + Environment.NewLine);
        }
    } 
}
