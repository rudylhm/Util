using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Util.MongoDB
{
    public class Helper
    {
        /// <summary>
        /// 生成MongoClient
        /// </summary>
        /// <param name="connectStr">连接串</param>
        /// <returns></returns>
        public static MongoClient GetClient(string connectStr)
        {
            return new MongoClient(connectStr);
        }

        public static IMongoDatabase GetDatabase(MongoClient client, string databaseName)
        {
            return client.GetDatabase(databaseName);
        }

        public static GridFSBucket GetFSBucket(IMongoDatabase db)
        {
            return new GridFSBucket(db);
        }

        public static IMongoDatabase GetDataBaseDirect(string connectStr, string databaseName)
        {
            var client = GetClient(connectStr);
            return GetDatabase(client, databaseName);
        }

        public static GridFSBucket GetBucketDirect(string connectStr, string databaseName)
        {
            var client = GetClient(connectStr);
            var db = GetDatabase(client, databaseName);
            return GetFSBucket(db);
        }
    }
}
