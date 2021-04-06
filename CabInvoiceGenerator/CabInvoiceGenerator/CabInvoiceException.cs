﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class CabInvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
        }
        ExceptionType type;
        public CabInvoiceException(ExceptionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
   
}