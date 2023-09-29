using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veterinary.API.DATA;
using veterinary.shared.Entities;

namespace veterinary.API.Controllers
{

    [ApiController]
    [Route("api/owners")]
    public class OwnersController : ControllerBase
    {
        private readonly DataContext _context;



        public OwnersController(DataContext context)
        {
            _context = context;
        }

        //el get es como una busqueda
        //GET POR LISTA
        // select * from owners
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Owners.ToListAsync());
        }

        //GET POR PARAMETRO
        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {
           var owner = await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);

            if (owner == null) {
                return NotFound();
            }

            return Ok(owner);
        }

        //el post es como un insert, inserta un registro.
        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            _context.Add(owner);
            await _context.SaveChangesAsync();  
           
            return Ok(owner);
        }
    }
}
