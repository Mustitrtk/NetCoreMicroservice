using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreMicroservice.Catalog.API.Repository
{
    public class BaseEntity
    {
        [BsonElement("_id")] 
        public Guid Id { get; set; }
    }
}
