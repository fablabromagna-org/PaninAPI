using System.Collections.Generic;

namespace PaninApi.WebApi.Options
{
    public class JwtAuthoritiesOption
    {
        public IDictionary<string, JwtAuthorityOption> Authorities { get; set; }
    }
}