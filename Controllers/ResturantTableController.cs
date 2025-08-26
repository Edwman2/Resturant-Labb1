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
    public class ResturantTableController : ControllerBase
    {
        private readonly IResturantTableService _resturantTableService;

        public ResturantTableController(IResturantTableService resturantTableService)
        {
            _resturantTableService = resturantTableService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableDTO>>> GetAllResturantTablesAsync()
        {
            var tables = _resturantTableService.GetAllResturantTablesAsync();
            return Ok(tables);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TableDTO>> GetResturantTablesByIdAsync(int id)
        {
            var tables = await _resturantTableService.GetResturantTablesById(id);
            if(tables == null)
            {
                return NotFound($"Resturant table with id {id} can not be found");
            }
            return Ok(tables);


        }

        [HttpPost]
        public async Task<ActionResult<TableDTO>> CreateResturantTableAsync(TableDTO tableDTO)
        {
            var createdTable = await _resturantTableService.CreateResturantTableAsync(tableDTO);
            return CreatedAtAction(nameof(GetResturantTablesByIdAsync), new { id = createdTable.TableId }, createdTable);
        }
    }
}
