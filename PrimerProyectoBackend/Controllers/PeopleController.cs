using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimerProyectoBackend.Services;

namespace PrimerProyectoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService; 
        }

        [HttpGet("all")]
        public List<People> GetPeoples() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id){
             var people = Repository.People.FirstOrDefault(p => p.Id == id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }
        [HttpGet("search/{search}")]
        public List<People> Get (string search) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People people) {

            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);

            return NoContent();
        }
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People(){
                Id = 1, Name = "Pedro", Birthdate = new DateTime(1998,12,3)
            },
            new People(){
                Id = 2, Name = "Jose", Birthdate = new DateTime(1998,02,22)
            },
            new People(){
                Id = 3, Name = "Juan", Birthdate = new DateTime(1997,07,12)
            }
        };
    }

    public class People
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }

}
