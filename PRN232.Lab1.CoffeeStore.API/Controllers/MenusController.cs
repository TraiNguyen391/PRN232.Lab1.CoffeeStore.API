using Microsoft.AspNetCore.Mvc;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Service.Implementation;
using PRN232.Lab1.CoffeeStore.Service.Interface;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;
using PRN232.Lab1.CoffeeStore.Service.Model.ResponseModel;

namespace PRN232.Lab1.CoffeeStore.API.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _context;

        public MenusController(IMenuService context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Menu>>> GetAllMenu()
        {
            var result = await _context.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MenuResponseModel>> GetMenuById(int id)
        {
            var menu = await _context.GetByIdAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody]MenuRequestModel menu)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _context.UpdateAsync(id, menu);

            var result = await _context.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMenu([FromBody] MenuRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var menu = await _context.CreateAsync(model);
            return Ok(new { Message = "Tạo menu thành công", menu });
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.GetByIdAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            await _context.DeleteAsync(id);

            return NoContent();
        }

    }
}
