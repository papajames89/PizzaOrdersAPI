namespace PizzaOrdersAPI.Interfaces
{
    public interface IPizzaOrdersDatabaseSettings
    {
        string PizzaOrdersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}