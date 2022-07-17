using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoExample.Models;
public class Buslist
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string busnumber { get; set; } = null!;
    public string busname { get; set; } = null!;
    public string bustype { get; set; } = null!;
    public string origin { get; set; } = null!;
    public string destination { get; set; } = null!;
    public string time { get; set; } = null!;
    public int num_of_row { get; set; } = 0;
    public int num_of_col { get; set; } = 0;

}
