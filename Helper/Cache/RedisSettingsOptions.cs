namespace mcq_backend.Helper.Cache
{
    public class RedisSettingsOptions
    {
        public const string RedisSettings = "RedisSettings";
        public bool Enabled { get; set; }
        public string ConnectionString { get; set; }
    }
}