using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaOrdersAPI.Models
{
    public class PizzaOrder
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; } = string.Empty;
        
        [BsonElement("pizza_name")]
        public string? PizzaName { get; set; }
        
        [BsonElement("ingredients")]
        public List<string>? Ingredients { get; set; }
        
        [BsonElement("order_date")]
        public DateTime OrderDate { get; set; }
        
        [BsonElement("user")]
        public User? User { get; set; }
    }
}