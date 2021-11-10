using MongoDB.Driver;
using MongoDB.Sample.Configurations;
using MongoDB.Sample.Models;

namespace MongoDB.Sample.Services
{
    public class ItemService : IItemService
    {
        private readonly IMongoCollection<ItemModel> _item;
        public ItemService(IDatabaseSettings settings)
        {
            var settingMongoDB = MongoClientSettings.FromConnectionString(settings.ConnectionString);
            settingMongoDB.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settingMongoDB);
            var database = client.GetDatabase(settings.DatabaseName);
            _item = database.GetCollection<ItemModel>(settings.MongoDBCollectionName);
        }

        public ItemModel Create(ItemModel item)
        {
            _item.InsertOne(item);
            return item;
        }

        public List<ItemModel> Create(List<ItemModel> items)
        {
            _item.InsertMany(items);
            return items;
        }

        public void DeleteItem(string id) => _item.DeleteOneAsync(item => item.Id == id);

        public void DeleteItems() => _item.DeleteManyAsync(Builders<ItemModel>.Filter.Empty);

        public ItemModel GetItem(string id) => _item.Find<ItemModel>(item => item.Id == id).FirstOrDefault();

        public List<ItemModel> GetItems() => _item.Find(item => true).ToList();
        public void UpdateItem(ItemModel item) => _item.ReplaceOne(ite => ite.Id == item.Id, item);
    }
    public interface IItemService
    {
        ItemModel GetItem(string id);
        List<ItemModel> GetItems();
        void DeleteItem(string id);
        void DeleteItems();
        ItemModel Create(ItemModel item);
        List<ItemModel> Create(List<ItemModel> items);
        void UpdateItem(ItemModel item);
    }
}
