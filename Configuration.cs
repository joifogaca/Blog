namespace Blog
{
    public static class Configuration
    {
        //TOKEN - JWT - Jason Web Token
        public static string JwtKey { get; set; } = "NGY4ZWQ3OGQtMjAzZS00MWRkLWFjYzgtZjg1ODkxMjdlOGEy"; //Chave para desencriptografat

        public static string ApiKeyName = "api_key";

        public static string ApiKey = "curso_api_04552726-1885-45a5-98c6-6959451bf4b2";

        public static SmtpConfiguration Smtp = new ();

        public class SmtpConfiguration 
        {
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string UserName { get; set; }

            public string Password { get; set; }
        }
    }
}
