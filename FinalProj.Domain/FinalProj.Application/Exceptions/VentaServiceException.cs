using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Application.Exceptions
{
    public class VentaServiceException : Exception
    {
        public VentaServiceException(string message) : base(message)
        {
            // realizar x logica //
        }
    }
}
