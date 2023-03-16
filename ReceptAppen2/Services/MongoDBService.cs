namespace ReceptAppen2.Services
{
    public class MongoDBService
    {
        public static IMongoCollection<Models.RecipeDb> GetDbCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://Admin:7Porqnv3ZIU5xFjF@ac-vxpq7fj-shard-00-00.4cg3c5m.mongodb.net:27017,ac-vxpq7fj-shard-00-01.4cg3c5m.mongodb.net:27017,ac-vxpq7fj-shard-00-02.4cg3c5m.mongodb.net:27017/?ssl=true&replicaSet=atlas-eofm93-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("ReceptSpara");
            var myCollection = database.GetCollection<Models.RecipeDb>("MyRecipesCollection");
            return myCollection;
        }
    }
}
