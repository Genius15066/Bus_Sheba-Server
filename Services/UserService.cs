using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoExample.Services;
public class UserService{
    private readonly IMongoCollection<Userlist> _userlistCollection;
    public UserService(IOptions<MongoDBSettings>mongoDBsettings){

        MongoClient client = new MongoClient(mongoDBsettings.Value.ConnectionURI);

        IMongoDatabase database = client.GetDatabase(mongoDBsettings.Value.DatabaseName);

        _userlistCollection = database.GetCollection<Userlist>("userlist");

    }

    public async Task CreateAsync(Userlist userlist){
        await _userlistCollection.InsertOneAsync(userlist);
        return ;
    }

    public async Task<List<Userlist>> GetAsync(){
        return await _userlistCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateAsync(string id, Userlist updateuser){
       await _userlistCollection.ReplaceOneAsync(x=>x.Id==id,updateuser);
    }

    public async Task DeleteAsync(string id){
        FilterDefinition<Userlist> filter = Builders<Userlist>.Filter.Eq("Id", id);
        await _userlistCollection.DeleteOneAsync(filter);
        return;
    }
}
