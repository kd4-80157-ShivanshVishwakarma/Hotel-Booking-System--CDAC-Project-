using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelsLib
{
    public class ErrorLogs
    {
        private int _id;
        private String? _source;
        private String? _method;
        private DateTime _errorOn;
        private String? _message;
        private String? _stackTrace;

        public String StackTrace
        {
            get { return _stackTrace; }
            set { _stackTrace = value; }
        }


        public String Message
        {
            get { return _message; }
            set { _message = value; }
        }


        public DateTime ErrorOn
        {
            get { return _errorOn; }
            set { _errorOn = value; }
        }


        public String Method
        {
            get { return _method; }
            set { _method = value; }
        }

        public String Source
        {
            get { return _source; }
            set { _source = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string? ToString()
        {
            return String.Format("Id:{0}, Source:{1}, Method:{2}, ErrorOn:{3}, Message:{4}, Stacktrace:{5}", _id, _source, _method, _errorOn, _message, _stackTrace);
        }
    }
}
