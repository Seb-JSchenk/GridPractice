using GridPractice.Models;
namespace GridPractice.Services
{
    public class ThingsService
    {

        private static readonly string[] Names = new[]
        {
            "Jeff", "bob" , "Jack", "Seb"
        };

        private List<Things> _things { get; set; }

        public Task<List<Things>> ThingsTask() 
        { 
            if(_things == null)
            {
                var rng = new Random();
                _things = Enumerable.Range(1, 100).Select(i => new Things
                {
                    Id = i,
                    Name = Names[rng.Next(0, 4)],
                    Stars = rng.Next(0, 6)
                }).ToList();
            }

            List<Things> things = new List<Things>(_things);
            return Task.FromResult(things);
        }

        public async Task UpdateThingAsync(Things thingToUpdate)
        {
            //implement proper error handling here, and then actual data source operations
            if (_things == null)
            {
                return;
            }

            var index = _things.FindIndex(i => i.Id == thingToUpdate.Id);
            if (index != -1)
            {
                _things[index] = thingToUpdate;
            }
        }

        public async Task DeleteThingAsync(Things thingToRemove)
        {
            if (_things == null) return;
            //implement proper error handling here, and then actual data source operations

            _things.Remove(thingToRemove);
        }

        public async Task InsertThingAsync(Things thingToInsert)
        {
            //implement proper error handling here, and then actual data source operations
            if (_things == null)
            {
                return;
            }

            Things insertedThing = new Things()
            {
                Id = _things.Count + 2,
                Name = thingToInsert.Name,
                Stars = thingToInsert.Stars,
                
            };

            _things.Insert(0, insertedThing);
        }

    }
}
