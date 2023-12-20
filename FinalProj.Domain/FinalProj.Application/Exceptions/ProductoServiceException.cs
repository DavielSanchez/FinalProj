using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProj.Application.Exceptions
{
    public class ProductoServiceException : Exception
    {
        public VentaServiceException(string message) : base(message)
        {

        }
    }
}
