using Examination.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Examination.Domain.AggregateModels.CategoryAggregate
{
    [BsonIgnoreExtraElements]
    public class Category : Entity, IAggregateRoot
    {
        public Category(string id, string name, string urlPath) => (Id, Name, UrlPath) = (id, name, urlPath);

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("urlPath")]
        public string UrlPath { set; get; } //domain/exam-category-1/
    }
}