using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Common.Errors
{
    public class ErrorKeys : IErrorOr
    {
        
        public string? _Code { get; set; } 
        public string? _description { get; set; }
        public ErrorKeys(string? code, string? Description)
        {
            _Code = code;
            _description = Description;
        }

        public List<Error>? Errors => throw new NotImplementedException();

        public bool IsError => throw new NotImplementedException();
    }
}
