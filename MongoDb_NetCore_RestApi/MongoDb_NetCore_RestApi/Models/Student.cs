using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_NetCore_RestApi.Models
{
    [BsonIgnoreExtraElements] // eşleşen ekstra alanlar varsa onları alma (bizim class'ta olan property'lerle eşleşen property'leri al, eşleşmeyen, mongodb'de bulunup bizim class'ımızda karşılığı bulunmayan alanları alma)
    public class Student
    {
        [BsonId] // id olduğunu belirtir
        [BsonRepresentation(BsonType.ObjectId)]  // mongo data type'ını .net data type'ına dönüştürür ve vice versa (bizim aşağıdaki Id string tipinde. Ama mongodb'deki int tipinde, o yüzden BsonType.ObjectId yazdık. Ama tek sebebi bu değil. ID olduğunu belirtmek için de BsonType.ObjectId yazdık)
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }

        [BsonElement("courses")]
        public string[]? Courses { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }
    }
}
