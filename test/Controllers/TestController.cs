using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MongoDbContext _db;

        public TestController(MongoDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> PostMongo(Test test)
        {
            //test._id = ObjectId.GenerateNewId();
            test._id = Guid.NewGuid().ToString();
            await _db.Test.AddAsync(test);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetMongo()
        {
            // Hämta samlingen "Test" från MongoDbContext
            var collection = await _db.Test.AsNoTracking().ToListAsync();

            // Returnera dokumenten som JSON
            return Ok(collection);
        }
        [Route("hej")]
        [HttpGet]
        public async Task<IActionResult> GetSearhMongo(string n)
        {
            // Hämta samlingen "Test" från MongoDbContext
            var collection = _db.Test.AsNoTracking().Where(s => s.name.Contains(n));

            // Returnera dokumenten som JSON
            return Ok(collection);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMongo(string id)
        {
            var user = await _db.Test.FirstOrDefaultAsync(u => u._id == id);
           _db.Test.Remove(user!);
            await _db.SaveChangesAsync();
            return Ok("User Deleted");
        }
        //[HttpPut]
        //public async Task<IActionResult> UpdateMongo(Test test)
        //{
        //   var userTuUpdate = await _db.Test.FirstOrDefaultAsync(

        //    if (selectedIngredient == null)
        //        return false;

        //    // Uppdatera namnet på ingrediensen direkt
        //    selectedIngredient.Name = newIngrident;

        //    // Markera entiteten som modifierad
        //    _context.Entry(selectedIngredient).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return Ok("User updated");
        //}

    }
}
