using MongoDB.Bson.Serialization.Attributes;

namespace PizzaOrdersAPI.Models
{
    public class User
    {
        [BsonElement("username")]
        public string? Username { get; set; }
        
        [BsonElement("email")]
        public string? Email { get; set; }
        
        [BsonElement("phone_number")]
        public string? PhoneNumber { get; set; }
        
        [BsonElement("registration_date")]
        public DateTime RegistrationDate { get; set; }
    }
}