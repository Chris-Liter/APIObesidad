using APIObesidad.Contexts;
using APIObesidad.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace APIObesidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : Controller
    {
        // GET: TurnosController
        private readonly ConexionPostgreSQL _conexionPostgreSQL;

        public TurnosController(ConexionPostgreSQL _conexionPostgreSQL)
        {
            this._conexionPostgreSQL = _conexionPostgreSQL;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: TurnosController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<turnos>> GetTurno(int id)
        {
            var turno = await _conexionPostgreSQL.Turnos.FindAsync(id);
            if (turno == null)
                return NotFound();
            return Ok(turno);
        }

        // GET: TurnosController
        [HttpGet]
        public IEnumerable<turnos> Create()
        {
            return _conexionPostgreSQL.Turnos.ToList();
        }

        // POST: TurnosController/Create
        [HttpPost]
        public async Task<ActionResult<turnos>> Create(turnos turno)
        {
            try
            {
                _conexionPostgreSQL.Turnos.Add(turno);
                await _conexionPostgreSQL.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTurno), new { id = turno.id }, turno);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST: TurnosController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] turnos turno)
        {
            if (id != turno.id)
            {
                return BadRequest();
            }

            _conexionPostgreSQL.Entry(turno).State = EntityState.Modified;

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

            return Ok(turno);
        }

        // GET: TurnosController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var turno = await _conexionPostgreSQL.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }

            _conexionPostgreSQL.Turnos.Remove(turno);
            await _conexionPostgreSQL.SaveChangesAsync();
            return NoContent();
        }

        // POST: TurnosController/Delete/5


    }
}
