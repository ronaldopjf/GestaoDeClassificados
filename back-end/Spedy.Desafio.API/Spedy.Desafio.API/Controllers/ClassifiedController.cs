using Microsoft.AspNetCore.Mvc;
using Spedy.Desafio.API.Interfaces.Services;
using Spedy.Desafio.API.Models.DTOs;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Spedy.Desafio.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassifiedController : ControllerBase
    {
        private readonly IClassifiedService _classifiedService;

        public ClassifiedController(IClassifiedService classifiedService)
        {
            _classifiedService = classifiedService;
        }

        // GET: <ClassifiedController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _classifiedService.Get();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        // GET <ClassifiedController>/1
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _classifiedService.Get(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        // GET <ClassifiedController>
        [HttpGet("title/{title}")]
        public IActionResult Activate([FromRoute] string title)
        {
            var result = _classifiedService.Get(title);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        // POST <ClassifiedController>
        [HttpPost]
        public IActionResult Post([FromBody] ClassifiedForCreateDto classifiedForCreateDto)
        {
            var result = _classifiedService.Post(classifiedForCreateDto);
            if (result.Success)
            {
                return Created("/classified", result.Object);
            }

            if (result.Message != null)
            {
                return BadRequest(new { error = result.Message });
            }

            return StatusCode(500);
        }

        // PUT <ClassifiedController>
        [HttpPut]
        public IActionResult Put([FromBody] ClassifiedForUpdateDto classifiedForUpdateDto)
        {
            var result = _classifiedService.Put(classifiedForUpdateDto);
            if (result.Success)
            {
                return Ok(result.Object);
            }

            if (!string.IsNullOrEmpty(result.Message))
            {
                return BadRequest(new { error = result.Message });
            }

            return StatusCode(500);
        }

        // DELETE <ClassifiedController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _classifiedService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Object);
            }

            if (!string.IsNullOrEmpty(result.Message))
            {
                return BadRequest(new { error = result.Message });
            }

            return StatusCode(500);
        }

        // POST <ClassifiedController>/delete
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] IEnumerable<ClassifiedForReadDto> classifieds)
        {
            var result = _classifiedService.Delete(classifieds);
            if (result.Success)
            {
                return Ok(result.Object);
            }

            if (!string.IsNullOrEmpty(result.Message))
            {
                return BadRequest(new { error = result.Message });
            }

            return StatusCode(500);
        }
    }
}
