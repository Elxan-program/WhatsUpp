using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsUpp.Errors
{
    public class WrongSelectedFileError : Exception
    {
        public WrongSelectedFileError(string msg) : base(msg)
        {

        }
    }
}
