using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media.Api.Core.Exceptions
{
    public class GuardBaseException : Exception
    {
        public GuardBaseException(string msg) : base(msg)
        {

        }
    }
}
