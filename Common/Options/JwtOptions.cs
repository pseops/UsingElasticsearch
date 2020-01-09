namespace Common.Options
{
    public class JwtOptions
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public double JwtExpireMinutes { get; set; }
        public double JwtExpireDays { get; set; }
    }
}
