namespace mcq_backend.Helper.AppHelper
{
    public class AppSettingsOptions
    {
        public const string AppSettings = "AppSettings";
        
        public string JwtSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string JwtEmailEncryption { get; set; }
    }
}