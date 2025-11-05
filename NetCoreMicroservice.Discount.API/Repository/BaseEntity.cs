using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreMicroservice.Discount.API.Repository
{
    public class BaseEntity
    {
        [BsonElement("_id")] 
        public Guid Id { get; set; }
    }
}
