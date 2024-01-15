namespace PizzaOrdersAPI.Interfaces.Implementations
{
    public class PizzaOrdersDatabaseSettings : IPizzaOrdersDatabaseSettings
    {
        public string PizzaOrdersCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}