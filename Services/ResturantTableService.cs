using Microsoft.AspNetCore.Http.HttpResults;
using Resturant_Labb1.DTOs.RequestDTOs;
using Resturant_Labb1.DTOs.ResponseDTOs;
using Resturant_Labb1.Models;
using Resturant_Labb1.Repositories.IRepository;
using Resturant_Labb1.Services.IServices;
using System.Runtime.InteropServices;

namespace Resturant_Labb1.Services
{
    public class ResturantTableService : IResturantTableService
    {
        private readonly IResturantTableRepository _resturantTableRepo;

        public ResturantTableService(IResturantTableRepository resturantTableRepository)
        {
            _resturantTableRepo = resturantTableRepository;
        }

        public async Task<TableDTO> CreateResturantTableAsync(TableDTO tableDTO)
        {
            var resturantTable = new ResturantTable
            {
                TableNumber = tableDTO.TableNumber,
                Seats = tableDTO.Seats

            };

            var newResturantTable = await _resturantTableRepo.AddResturantTableAsync(resturantTable);

            return new TableDTO
            {
                TableNumber = resturantTable.TableNumber,
                Seats = resturantTable.Seats
            };

            
        }

        public async Task<bool> DeleteResturantTableAsync(int TableId)
        {
           return await _resturantTableRepo.DeleteResturantTableAsync(TableId);
            
        }

        public async Task<List<TableDTO>> GetAllResturantTablesAsync()
        {
            var tables = await _resturantTableRepo.GetAllResturantTablesAsync();
            var tableDTO = tables.Select(t => new TableDTO
            {
                TableId = t.TableId,
                TableNumber = t.TableNumber,
                Seats = t.Seats
            }).ToList();

            return tableDTO;
        }

        public async Task<TableDTO> GetResturantTablesById(int TableId)
        {
            var tables = await _resturantTableRepo.GetResturantTablesById(TableId);

            if(tables == null)
            {
                return null;
            }

            var resturantTableDTO = new TableDTO
            {
                TableId = tables.TableId,
                TableNumber = tables.TableNumber,
                Seats = tables.Seats

            };

            return resturantTableDTO;
        }

        public async Task<bool> UpdateResturantTableAsync(int id, CreateTableDTO createTableDTO)
        {
            var resturantTable = await _resturantTableRepo.GetResturantTablesById(id);
            if(resturantTable == null)
            {
                return false;
            }
            resturantTable.TableNumber = createTableDTO.TableNumber;
            resturantTable.Seats = createTableDTO.Seats;

            await _resturantTableRepo.SaveChangesAsync();

            return true;


        }
    }
}
