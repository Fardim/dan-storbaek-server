namespace dan_storbaek_server.Domains
{
    public class DanTestDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UsersCollectionName { get; set; } = null!;
        public string ProductsCollectionName { get; set; } = null!;
    }
}
