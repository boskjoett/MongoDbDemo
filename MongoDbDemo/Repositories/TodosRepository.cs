using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbDemo.Models;

namespace MongoDbDemo.Repositories
{
    public class TodosRepository : ITodosRepository
    {
        private readonly IMongoCollection<TodoItem> _todosCollection;

        public TodosRepository(IOptions<TodoDatabaseSettings> todoDatabaseSettings)
        {
            var mongoClient = new MongoClient(todoDatabaseSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(todoDatabaseSettings.Value.DatabaseName);
            _todosCollection = mongoDatabase.GetCollection<TodoItem>(todoDatabaseSettings.Value.TodosCollectionName);
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _todosCollection.Find(_ => true).ToListAsync();
        }

        public async Task<TodoItem?> GetAsync(string id)
        {
            return await _todosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TodoItem newTodo)
        {
            await _todosCollection.InsertOneAsync(newTodo);
        }

        public async Task UpdateAsync(string id, TodoItem updatedTodo)
        {
            await _todosCollection.ReplaceOneAsync(x => x.Id == id, updatedTodo);
        }

        public async Task DeleteAsync(string id)
        {
            await _todosCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
