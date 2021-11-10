using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Sample.Models
{
    public class ItemModel
    {
        public string Id { get; set; }
        public string Describe { get; set; }
        public string Note { get; set; }
    }
}
