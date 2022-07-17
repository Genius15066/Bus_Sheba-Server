using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoExample.Services;
public class BusService{
    private readonly IMongoCollection<Buslist> _buslistCollection;
    public BusService(IOptions<MongoDBSettings>mongoDBsettings){

        MongoClient client = new MongoClient(mongoDBsettings.Value.ConnectionURI);

        IMongoDatabase database = client.GetDatabase(mongoDBsettings.Value.DatabaseName);

        _buslistCollection = database.GetCollection<Buslist>("buslist");

    }

    public async Task CreateAsync(Buslist buslist){
        await _buslistCollection.InsertOneAsync(buslist);
        return ;
    }

    public async Task<List<Buslist>> GetAsync(){
        return await _buslistCollection.Find(new BsonDocument()).ToListAsync();
    }

    // public async Task AddToBuslistAsync(string id, string movieId){
    //     FilterDefinition<Buslist> filter = Builders<Buslist>.Filter.Eq("Id", id);
    //     UpdateDefinition<Buslist> update = Builders<Buslist>.Update.AddToSet<string>("items", movieId);
    //     await _buslistCollection.UpdateOneAsync(filter, update);
    //     return;
    // }

    public async Task DeleteAsync(string id){
        FilterDefinition<Buslist> filter = Builders<Buslist>.Filter.Eq("Id", id);
        await _buslistCollection.DeleteOneAsync(filter);
        return;
    }
}
