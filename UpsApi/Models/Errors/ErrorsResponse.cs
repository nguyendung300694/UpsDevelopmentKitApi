using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpsApi.Models.Errors
{
    public class ErrorsResponse
    {
        public List<Error> errors { get; set; }
    }

    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}