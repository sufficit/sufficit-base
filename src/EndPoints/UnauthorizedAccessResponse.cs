using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.EndPoints
{
    public class UnauthorizedAccessResponse : EndPointResponse
    {
        public new UnauthorizedAccessData Data { get => (UnauthorizedAccessData)base.Data!; set => base.Data = value; }
    }    
}
