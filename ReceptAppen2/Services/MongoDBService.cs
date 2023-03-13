namespace ReceptAppen2.Services
{
    public class MongoDBService
    {
        public static IMongoCollection<Models.RecipeDb> GetDbCollection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Admin:7Porqnv3ZIU5xFjF@receptspara.4cg3c5m.mongodb.net/test");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("ReceptSpara");
            var myCollection = database.GetCollection<Models.RecipeDb>("MyRecipesCollection");
            return myCollection;
        }
    }
}
