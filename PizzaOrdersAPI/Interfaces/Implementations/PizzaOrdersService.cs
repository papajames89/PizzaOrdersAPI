using MongoDB.Driver;
using PizzaOrdersAPI.Models;

namespace PizzaOrdersAPI.Interfaces.Implementations
{
    public class PizzaOrdersService : IPizzaOrderService
    {
        private readonly IMongoCollection<PizzaOrder> _pizzaOrders;
        public PizzaOrdersService(IPizzaOrdersDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _pizzaOrders = database.GetCollection<PizzaOrder>(settings.PizzaOrdersCollectionName);
        }


        public List<PizzaOrder> Get()
        {
            return _pizzaOrders.Find(pizzaOrder => true).ToList();
        }

        public List<PizzaOrder> Get(DateTime dateTime)
        {
            return _pizzaOrders.Find(pizzaOrder => pizzaOrder.OrderDate == dateTime).ToList();
        }

        public PizzaOrder Get(string id)
        {
            return _pizzaOrders.Find(pizzaOrder => pizzaOrder.Id == id).FirstOrDefault();
        }

        public PizzaOrder Create(PizzaOrder pizzaOrder)
        {
            _pizzaOrders.InsertOne(pizzaOrder);
            return pizzaOrder;
        }

        public PizzaOrder Update(string id, PizzaOrder newPizzaOrder)
        {
            _pizzaOrders.ReplaceOne(pizzaOrder => pizzaOrder.Id == id, newPizzaOrder);
            return _pizzaOrders.Find(_pizzaOrders => _pizzaOrders.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _pizzaOrders.DeleteOne(pizzaOrder => pizzaOrder.Id == id);
        }
    }
}