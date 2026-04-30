namespace Orders.Infrastructure.Persistense
{
    public class MongoDbOptions
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
    }
}
