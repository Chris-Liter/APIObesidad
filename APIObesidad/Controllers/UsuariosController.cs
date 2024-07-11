using APIObesidad.Contexts;
using APIObesidad.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIObesidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        // GET: UsuariosController
        private readonly ConexionPostgreSQL _conexionPostgreSQL;

        public UsuariosController(ConexionPostgreSQL _conexionPostgreSQL)
        {
            this._conexionPostgreSQL = _conexionPostgreSQL;
        }
        public ActionResult Index()
        {
            return View();
        }


        // GET: UsuariosController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<usuarios>> GetUsuario(int id)
        {
            var turno = await _conexionPostgreSQL.Usuario.FindAsync(id);
            if (turno == null)
                return NotFound();
            return Ok(turno);
        }

        // GET: UsuariosController
        [HttpGet]
        public IEnumerable<usuarios> Create()
        {
            return _conexionPostgreSQL.Usuario.ToList();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        public async Task<ActionResult<turnos>> Create(usuarios usuario)
        {
            try
            {
                _conexionPostgreSQL.Usuario.Add(usuario);
                await _conexionPostgreSQL.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id }, usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST: UsuariosController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] usuarios usuario)
        {
            if (id != usuario.id)
            {
                return BadRequest();
            }

            _conexionPostgreSQL.Entry(usuario).State = EntityState.Modified;

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

            return Ok(usuario);
        }

        // GET: UsuariosController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _conexionPostgreSQL.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _conexionPostgreSQL.Usuario.Remove(usuario);
            await _conexionPostgreSQL.SaveChangesAsync();
            return NoContent();
        }
    }
}
