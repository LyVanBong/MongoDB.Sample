using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Sample.Models;

namespace MongoDB.Sample.Controllers
{
    [Route("api/v2/MongoDB")]
    [ApiController]
    public class MongoDBController : ControllerBase
    {
        private string _connectionString = "mongodb://localhost:27017";
        private string _databaseName = "MongoDB";
        private IMongoClient _mongoClient;
        private IMongoDatabase _database;
        private IMongoCollection<ItemModel> _collectionItem;
        public MongoDBController()
        {
            var settings = MongoClientSettings.FromConnectionString(_connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _mongoClient = new MongoClient(settings);
            _database = _mongoClient.GetDatabase(_databaseName);
            _collectionItem = _database.GetCollection<ItemModel>(_databaseName);
        }
        /// <summary>
        /// Thêm 1 item vào database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ItemModel PostItem1( ItemModel item)
        {
            _collectionItem.InsertOne(item);
            return item;
        }
        ///// <summary>
        ///// Thêm n item vào database
        ///// </summary>
        ///// <param name="items"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public List<ItemModel> PostItem2(List<ItemModel> items)
        //{
        //    _collectionItem.InsertMany(items);
        //    return items;
        //}
        ///// <summary>
        ///// Lấy 1 item theo id của nó
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        [HttpGet("{id}")]
        public ItemModel GetItem1(int id)
        {
            var data = _collectionItem.Find(Builders<ItemModel>.Filter.Eq("Id", id)).FirstOrDefault();
            return data;
        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu trong database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ItemModel> GetItem2()
        {
            var data = _collectionItem.Find(new BsonDocument()).ToList();
            return data;
        }
        /// <summary>
        /// Cập nhật 1 item trong database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        public ItemModel PutItem(ItemModel item)
        {
            var filter = Builders<ItemModel>.Filter.Eq("Id", item.Id);
            _collectionItem.ReplaceOne(filter, item);
            return item;
        }
        /// <summary>
        /// Xóa 1 item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public string DeleteItem1(int id)
        {
            _collectionItem.DeleteOne(Builders<ItemModel>.Filter.Eq("Id", id));
            return "Xóa thành công";
        }
        /// <summary>
        /// Xoa all table
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public string DeleteItem2()
        {
            _collectionItem.DeleteOne(Builders<ItemModel>.Filter.Empty);
            return "Xóa thành công";
        }
    }
}
