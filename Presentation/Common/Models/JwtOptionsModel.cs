using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Common.Models
{
    public class JwtOptionsModel
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public double JwtExpireMinutes { get; set; }
        public double JwtExpireDays { get; set; }
    }
}
