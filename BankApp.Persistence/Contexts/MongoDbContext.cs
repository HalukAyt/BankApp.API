using BankApp.Domain.Entities;
using BankApp.Persistence.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BankApp.Persistence.Contexts
{
    public class MongoDbContext 
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
        public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("Accounts");
        public IMongoCollection<Transaction> Transactions => _database.GetCollection<Transaction>("Transactions");
    }
}
