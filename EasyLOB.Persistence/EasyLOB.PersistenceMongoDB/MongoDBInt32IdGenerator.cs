using EasyLOB.Data;
using EasyLOB.Library;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

/*
Mapping Classes
http://mongodb.github.io/mongo-csharp-driver/2.0/reference/bson/mapping

When you Insert a document, the driver checks to see if the Id member has been assigned a value and, if not, generates a new unique value for it.
Since the Id member can be of any type, the driver requires the help of an IIdGenerator to check whether the Id has a value assigned to it and to generate a new value if necessary.

BsonObjectIdGenerator
CombGuidGenerator
GuidGenerator
NullIdChecker
ObjectIdGenerator
StringObjectIdGenerator
ZeroIdChecker<T>
 */

// <add key = "MongoDB.Sequence.Url" value="mongodb://localhost" />
// <add key = "MongoDB.Sequence.Database" value="Chinook" />

namespace EasyLOB.Persistence
{
    public class MongoDBInt32IdGenerator : IIdGenerator // ???
    {
        #region Properties

        public static MongoDBInt32IdGenerator Instance { get { return new MongoDBInt32IdGenerator(); } }

        //private static IMongoDatabase _sequenceDatabase;

        //private static IMongoDatabase SequenceDatabase
        //{
        //    get
        //    {
        //        if (_sequenceDatabase == null)
        //        {
        //            string url = ConfigurationHelper.AppSettings<string>("MongoDB.Sequence.Url");
        //            string databaseName = ConfigurationHelper.AppSettings<string>("MongoDB.Sequence.Database");
        //            _sequenceDatabase = (new MongoClient(url)).GetDatabase(databaseName);
        //        }

        //        return _sequenceDatabase;
        //    }
        //}

        #endregion Properties

        #region Methods

        //private static int GetSequence(string name)
        //{
        //    int result = LibraryDefaults.Default_Int32;

        //    var collection = SequenceDatabase.GetCollection<BsonDocument>(typeof(MongoDBSequence).Name);
        //    var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
        //    var update = new BsonDocument("$inc", new BsonDocument { { "Value", 1 } });
        //    var document = collection.FindOneAndUpdateAsync(filter, update).Result;
        //    if (document != null)
        //    {
        //        MongoDBSequence mongoDBSequence = BsonSerializer.Deserialize<MongoDBSequence>(document);
        //        result = mongoDBSequence.Value;
        //    }
        //    else
        //    {
        //        result = 1;
        //        collection.InsertOne(new BsonDocument { { "Name", name }, { "Value", result + 1 } });
        //    }

        //    return result;
        //}

        #endregion Methods

        #region Methods IIdGenerator

        public object GenerateId(object container, object document)
        {
            int id = LibraryDefaults.Default_Int32;

            if (document is ZDataBase)
            {
                //id = GetSequence(document.GetType().Name);
            }

            return id;
        }

        public bool IsEmpty(object id)
        {
            return id == null || id.ToString() == "0";
        }

        #endregion Methods IIdGenerator
    }
}