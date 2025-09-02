using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Repositories.IRepository;
using Resturant_Labb1.Services.IServices;

namespace Resturant_Labb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IResturantTableService _resturantTableService;

        public TableController(IResturantTableService resturantTableService)
        {
            _resturantTableService = resturantTableService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<TableDTO>>> GetAllResturantTablesAsync()
        {
            var tables = await _resturantTableService.GetAllResturantTablesAsync();
            return Ok(tables);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TableDTO>> GetResturantTablesById(int id)
        {
            var tables = await _resturantTableService.GetResturantTablesByIdAsync(id);
            if(tables == null)
            {
                return NotFound($"Resturant table with id {id} can not be found");
            }
            return Ok(tables);


        }

        [HttpPost]
        public async Task<ActionResult<TableDTO>> CreateResturantTableAsync(CreateTableDTO tableDTO)
        {
            var createdTable = await _resturantTableService.CreateResturantTableAsync(tableDTO);

            return CreatedAtAction(nameof(GetResturantTablesById), new { id = createdTable.TableId }, createdTable);
        }
        [HttpDelete]
        public async Task<ActionResult<TableDTO>> DeleteResturantTableAsync(int id)
        {
            var deleteTable = await _resturantTableService.DeleteResturantTableAsync(id);

            if(deleteTable == null)
            {
                NotFound("can't find a table with matching id");
            }

            return Ok("Deleted");
        }
    }
}
