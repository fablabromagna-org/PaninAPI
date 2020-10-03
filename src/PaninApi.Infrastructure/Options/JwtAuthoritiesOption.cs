using System.Collections.Generic;

namespace PaninApi.Infrastructure.Options
{
    public class JwtAuthoritiesOption
    {
        public IDictionary<string, JwtAuthorityOption> Authorities { get; set; }
    }
}