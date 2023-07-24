namespace Nobi.Jwt
{
    public class JsonWebTokenPayload
    {
        #region Properties

        public IDictionary<string, string> Claims { get; set; }

        public DateTime Expires { get; set; }

        public string[] Roles { get; set; }

        public string Subject { get; set; }

        #endregion Properties
    }
}
