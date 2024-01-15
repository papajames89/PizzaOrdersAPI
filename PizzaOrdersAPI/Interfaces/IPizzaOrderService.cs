using PizzaOrdersAPI.Models;

namespace PizzaOrdersAPI.Interfaces
{
    public interface IPizzaOrderService
    {
        List<PizzaOrder> Get();
        List<PizzaOrder> Get(DateTime dateTime);
        PizzaOrder Get(string id);
        PizzaOrder Create(PizzaOrder pizzaOrder);
        PizzaOrder Update(string id, PizzaOrder pizzaOrder);
        void Remove(string id);
    }
}