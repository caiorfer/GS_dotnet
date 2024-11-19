using Microsoft.AspNetCore.Mvc;
using SustainableEnergyAPI.DTO;
using SustainableEnergyAPI.Models;
using SustainableEnergyAPI.Services;

namespace SustainableEnergyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnergyProcessController : ControllerBase
    {
        private readonly EnergyProcessService _energyProcessService;

        public EnergyProcessController(EnergyProcessService energyProcessService)
        {
            _energyProcessService = energyProcessService;
        }

        /// <summary>
        /// Lista todos os processos de energia.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllEnergyProcesses()
        {
            var processes = _energyProcessService.GetAll();
            return Ok(processes);
        }

        /// <summary>
        /// Recupera um processo de energia específico pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetEnergyProcessById(string id)
        {
            var process = _energyProcessService.GetById(id);
            if (process == null)
            {
                return NotFound();
            }
            return Ok(process);
        }

        /// <summary>
        /// Cria um novo processo de energia.
        /// </summary>
        [HttpPost]
        public IActionResult CreateEnergyProcess([FromBody] EnergyProcessDTO processDTO)
        {
            if (processDTO == null)
            {
                return BadRequest("Process data is null.");
            }

            var process = _energyProcessService.Create(processDTO);
            return CreatedAtAction(nameof(GetEnergyProcessById), new { id = process.Id }, process);
        }

        /// <summary>
        /// Atualiza um processo de energia existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateEnergyProcess(string id, [FromBody] EnergyProcessDTO processDTO)
        {
            if (processDTO == null)
            {
                return BadRequest("Process data is null.");
            }

            var updatedProcess = _energyProcessService.Update(id, processDTO);
            if (updatedProcess == null)
            {
                return NotFound();
            }

            return Ok(updatedProcess);
        }

        /// <summary>
        /// Atualiza parcialmente um processo de energia existente.
        /// </summary>
        [HttpPatch("{id}")]
        public IActionResult PatchEnergyProcess(string id, [FromBody] EnergyProcessDTO partialUpdate)
        {
            if (partialUpdate == null)
            {
                return BadRequest("Partial update data is null.");
            }

            var patchedProcess = _energyProcessService.Patch(id, partialUpdate);
            if (patchedProcess == null)
            {
                return NotFound();
            }

            return Ok(patchedProcess);
        }

        /// <summary>
        /// Remove um processo de energia pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteEnergyProcess(string id)
        {
            var deleted = _energyProcessService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
