using Microsoft.AspNetCore.Mvc;
using Coloviu.Models;
using Coloviu.Services;
using System.Threading.Tasks;

namespace Coloviu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoviuController : ControllerBase
    {
        private readonly ProfesorService _profesorService;
        private readonly MaterieService _materieService;
        private readonly AsignareMaterieService _asignareMaterieService;

        public ColoviuController(ProfesorService profesorService, MaterieService materieService, AsignareMaterieService asignareMaterieService)
        {
            _profesorService = profesorService;
            _materieService = materieService;
            _asignareMaterieService = asignareMaterieService;
        }

        // Profesor endpoints
        // ... (aici adăugați metodele pentru Profesor, similar cu cele de mai jos pentru Materie și AsignareMaterie)
        [HttpGet("profesori")]
        public async Task<IActionResult> GetAllProfesori()
        {
            var profesori = await _profesorService.GetAllProfesoriAsync();
            return Ok(profesori);
        }

        [HttpGet("profesori/{id}")]
        public async Task<IActionResult> GetProfesorById(int id)
        {
            var profesor = await _profesorService.GetProfesorByIdAsync(id);
            if (profesor == null)
                return NotFound();

            return Ok(profesor);
        }

        [HttpPost("profesori")]
        public async Task<IActionResult> AddProfesor([FromBody] Profesor profesor)
        {
            await _profesorService.AddProfesorAsync(profesor);
            return CreatedAtAction(nameof(GetProfesorById), new { id = profesor.ProfesorId }, profesor);
        }

        [HttpPut("profesori/{id}")]
        public async Task<IActionResult> UpdateProfesor(int id, [FromBody] Profesor profesor)
        {
            if (id != profesor.ProfesorId)
                return BadRequest();

            await _profesorService.UpdateProfesorAsync(profesor);
            return NoContent();
        }

        [HttpDelete("profesori/{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            await _profesorService.DeleteProfesorAsync(id);
            return NoContent();
        }
        // Materie endpoints
        [HttpGet("materii")]
        public async Task<IActionResult> GetAllMaterii()
        {
            var materii = await _materieService.GetAllMateriiAsync();
            return Ok(materii);
        }

        [HttpGet("materii/{id}")]
        public async Task<IActionResult> GetMaterieById(int id)
        {
            var materie = await _materieService.GetMaterieByIdAsync(id);
            if (materie == null)
                return NotFound();

            return Ok(materie);
        }

        [HttpPost("materii")]
        public async Task<IActionResult> AddMaterie([FromBody] Materie materie)
        {
            await _materieService.AddMaterieAsync(materie);
            return CreatedAtAction(nameof(GetMaterieById), new { id = materie.MaterieId }, materie);
        }

        [HttpPut("materii/{id}")]
        public async Task<IActionResult> UpdateMaterie(int id, [FromBody] Materie materie)
        {
            if (id != materie.MaterieId)
                return BadRequest();

            await _materieService.UpdateMaterieAsync(materie);
            return NoContent();
        }

        [HttpDelete("materii/{id}")]
        public async Task<IActionResult> DeleteMaterie(int id)
        {
            await _materieService.DeleteMaterieAsync(id);
            return NoContent();
        }

        // AsignareMaterie endpoints
        [HttpPost("asignari")]
        public async Task<IActionResult> AsignareMaterieLaProfesor([FromBody] AsignareMaterie asignare)
        {
            await _asignareMaterieService.AsignareMaterieLaProfesorAsync(asignare.ProfesorId, asignare.MaterieId);
            return Ok();
        }


        // Aici puteți adăuga mai multe metode pentru AsignareMaterie, dacă este necesar
    }
}
