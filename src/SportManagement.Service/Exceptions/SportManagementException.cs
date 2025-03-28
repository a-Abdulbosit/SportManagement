using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManagement.Service.Exceptions;

public class SportManagementException : Exception
{
    public int StatusCode { get; set; }

    public SportManagementException(int code, string message) : base(message)
    {
        this.StatusCode = code;
    }
}
