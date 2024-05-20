using MongoDB.Driver;
using Pets.Server.Data;
using Pets.Server.Entities;

namespace Pets.Server.Services
{

    public class PetService
    {
        private readonly IMongoCollection<Pet> _pets;

        public PetService(MongoDBContext mongoDBContext)
        {
            _pets = mongoDBContext.Database.GetCollection<Pet>(mongoDBContext.PetsCollectionName);
        }

        public async Task<IEnumerable<Pet>> GetAsync() =>
        await _pets.Find(FilterDefinition<Pet>.Empty).ToListAsync();

        public async Task<Pet> CreateAsync(string name, string created_at, string type, string color, int age)
        {



            var pet = new Pet
            {
                Name = name,
                CreatedAt = created_at,
                Type = type,
                Color = color,
                Age = age
            };

            await _pets.InsertOneAsync(pet);
            return pet;
        }

        public async Task<Pet?> GetByIdAsync(string id) =>
           await _pets.Find(x => x.Id == id).FirstOrDefaultAsync();

    }






}
