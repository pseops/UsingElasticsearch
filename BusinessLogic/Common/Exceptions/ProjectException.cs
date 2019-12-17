﻿using System;

namespace BusinessLogic.Common.Exceptions
{
    public class ProjectException : Exception
    {
        public int StatusCode { get; set; }

        public ProjectException(string message) : base(message)
        {
        }

        public ProjectException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public ProjectException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
