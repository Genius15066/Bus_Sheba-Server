using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoExample.Models;
public class Userlist
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string name { get; set; } = null!;
    public int mobile { get; set; } =0!;
    public string email { get; set; } = null!;
    public string password { get; set; } = null!;
    public string city { get; set; } = null!;

}
