namespace GbLib.Jwt
{
    public static class JwtClaimsTypes
    {
        #region Fields

        public static string JwtId = "jid";

        public static string IssuedAt = "iat";

        public static string Issuer = "iss";

        public static string Permissions = "pers";

        public static string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        public static string UserName = "una";

        public static string UserId = "uid";

        public static string UserType = "utype";

        public static string Configs = "confs";

        public static string OrgnizationId = "orgid";
        #endregion Fields
    }
}