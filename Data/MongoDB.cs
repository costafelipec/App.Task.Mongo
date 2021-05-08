using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using task.Data.Collections;

namespace task.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB {get;}

        public MongoDB(IConfiguration config){
            try{
                var settings = MongoClientSettings.FromUrl(new MongoUrl(config["ConnectionStrings"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(config["DataBaseName"]);                

            }catch(Exception ex){
                throw new MongoException($"Erro ao conectar no banco {ex.Message.ToString()}");
            }
        }
        private void MapClasses(){
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Tarefas)))
            {
                BsonClassMap.RegisterClassMap<Tarefas>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
        
    }
}