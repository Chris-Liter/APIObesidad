using APIObesidad.Contexts;
using APIObesidad.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIObesidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : Controller
    {
        private readonly ConexionPostgreSQL _conexionPostgreSQL;

        public MedicosController(ConexionPostgreSQL _conexionPostgreSQL)
        {
            this._conexionPostgreSQL = _conexionPostgreSQL;
        }
        // GET: MedicosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuariosController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<medicos>> GetMedico(int id)
        {
            var medico = await _conexionPostgreSQL.Medico.FindAsync(id);
            if (medico == null)
                return NotFound();
            return Ok(medico);
        }

        // GET: UsuariosController
        [HttpGet]
        public IEnumerable<medicos> Create()
        {
            return _conexionPostgreSQL.Medico.ToList();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        public async Task<ActionResult<medicos>> Create(medicos medico)
        {
            try
            {
                _conexionPostgreSQL.Medico.Add(medico);
                await _conexionPostgreSQL.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMedico), new { id = medico.id }, medico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST: UsuariosController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] medicos medico)
        {
            if (id != medico.id)
            {
                return BadRequest();
            }

            _conexionPostgreSQL.Entry(medico).State = EntityState.Modified;

            try
            {
                await _conexionPostgreSQL.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                //if (!ProductoExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                return BadRequest(e.Message);
            }

            return Ok(medico);
        }

        // GET: UsuariosController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var medico = await _conexionPostgreSQL.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _conexionPostgreSQL.Medico.Remove(medico);
            await _conexionPostgreSQL.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("login/{nombre}/{password}")]
        public async Task<ActionResult<medicos>> Login(string nombre, string password)
        {
            var usuario = await _conexionPostgreSQL.Medico.FirstOrDefaultAsync(opt => opt.nombre == nombre && opt.pass == password);
            if (usuario == null)
                return NotFound("Contraseña o Usuario incorrecto");
            return Ok(usuario);
        }
    }
}
