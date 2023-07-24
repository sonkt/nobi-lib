namespace Nobi.Jwt
{
    public class JwtOptions
    {
        #region Properties

        public bool Enabled { get; set; }

        public int ExpiredMinutes { get; set; }

        public string Issuer { get; set; }

        public string SecretKey { get; set; }

        public string InternalTokenKey { get; set; }

        public bool ValidateAudience { get; set; }

        public bool ValidateLifetime { get; set; }

        public string ValidAudience { get; set; }

        #endregion Properties
    }
}
