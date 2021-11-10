# MongoDB

[Database MongoDB](https://downloads.mongodb.com/windows/mongodb-windows-x86_64-enterprise-5.0.3-signed.msi)

[Thư viện kết nối MongoDB với .Net](https://www.nuget.org/packages/MongoDB.Driver)

Tài liệu
- [Tài liệu 1](https://docs.mongodb.com/manual/crud/)
- [Tài liệu 2](https://www.mongodb.com/developer/quickstart/csharp-crud-tutorial/)
- [Tài liệu 3](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio#add-a-crud-operations-service)

[Image Docker MongoDB](https://hub.docker.com/_/mongo/)

Khởi tạo kết nỗi với MongoDB
```C#
/// <summary>
/// Chuỗi connectionstring
/// </summary>
private string _connectionString = "mongodb://localhost:27017";
/// <summary>
/// Db Name
/// </summary>
private string _databaseName = "MongoDB";
private string _collectionName = "MongoDB";
private IMongoClient _mongoClient;
private IMongoDatabase _database;
private IMongoCollection<ItemModel> _collectionItem;
public MongoDBController()
{
    var settings = MongoClientSettings.FromConnectionString(_connectionString);
    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
    _mongoClient = new MongoClient(settings);
    _database = _mongoClient.GetDatabase(_databaseName);
    _collectionItem = _database.GetCollection<ItemModel>(_collectionName);
}
```

Thêm 1 dòng dữ liệu vào database
```C#
_collectionItem.InsertOne(item);
```

Lấy 1 dòng dữ liệu theo id
```C#
var data = _collectionItem.Find(Builders<ItemModel>.Filter.Eq("Id", id)).FirstOrDefault();
```

Lấy toàn bộ dữ liệu trong bảng
```C#
 var data = _collectionItem.Find(new BsonDocument()).ToList();
```

Cập nhật 1 dòng dữ liệu
```C#
_collectionItem.ReplaceOne(Builders<ItemModel>.Filter.Eq("Id", item.Id), item);
```

Xóa 1 dòng dữ liệu
```C#
_collectionItem.DeleteOne(Builders<ItemModel>.Filter.Eq("Id", id));
```

Xóa toàn bộ dữ liệu trong bảng
```C#
_collectionItem.DeleteMany(Builders<ItemModel>.Filter.Empty);
```
