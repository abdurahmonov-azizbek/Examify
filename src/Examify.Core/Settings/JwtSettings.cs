using System;

namespace Examify.Core.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public int Expires { get; set; }
}
