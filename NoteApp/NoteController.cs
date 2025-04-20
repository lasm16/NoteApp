using BLL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [ApiController]
    [Route("Note")]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(string text)
        {
            await noteService.CreateAsync(text);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNoteAsync([FromRoute] int id)
        {
            var retsult = await noteService.GetByIdAsync(id);
            return Ok(retsult);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, string newText)
        {
            await noteService.UpdateAsync(id, newText);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await noteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
