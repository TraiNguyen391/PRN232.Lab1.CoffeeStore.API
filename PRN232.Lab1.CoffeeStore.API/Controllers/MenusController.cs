using Microsoft.AspNetCore.Mvc;
using PRN232.Lab1.CoffeeStore.Repository.Models;
using PRN232.Lab1.CoffeeStore.Repository.UnitOfWork;
using PRN232.Lab1.CoffeeStore.Service.Interface;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;
using PRN232.Lab1.CoffeeStore.Service.Model.ResponseModel;
using PRN232.Lab1.CoffeeStore.Service.ServiceProviders;

namespace PRN232.Lab1.CoffeeStore.API.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IServiceProviders _serviceProviders;
        private readonly IUnitOfWork _unitOfWork;

        public MenusController(IServiceProviders serviceProviders, IUnitOfWork unitOfWork)
        {
            _serviceProviders = serviceProviders;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Menu>>> GetAllMenu()
        {
            var result = await _serviceProviders.MenuService.GetAllAsync();
            return Ok(result);
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<MenuResponseModel>> GetMenuById(int id)
        {
            var menu = await _serviceProviders.MenuService.GetByIdAsync(id);

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
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody]MenuRequestModel menu)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _serviceProviders.MenuService.UpdateAsync(id, menu);

            _unitOfWork.SaveChange();

            var result = await _serviceProviders.MenuService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateMenu([FromBody] MenuRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var menu = await _serviceProviders.MenuService.CreateAsync(model);

            _unitOfWork.SaveChange();

            return CreatedAtAction("GetMenuById", new { id = menu.MenuId }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _serviceProviders.MenuService.GetByIdAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            await _serviceProviders.MenuService.DeleteAsync(id);

            _unitOfWork.SaveChange();

            return NoContent();
        }

    }
}
