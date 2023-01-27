using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Runtime.InteropServices;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IitemRepository itemRepository;
        private readonly IMapper mapper;
        public ItemController(IitemRepository itemRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllitemAsync()
        {
            var items = await itemRepository.GetAllAsync();




            // var itemssDTO = mapper.Map<List<Models.DTO.item>>(items);

            var itemDTO = mapper.Map<List<Models.DTO.item>>(items);

            return Ok(itemDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetItemAsync")]
        public async Task<IActionResult> GetItemAsync(Guid id)
        {
            {
                var item = await itemRepository.GetAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                var regionDTO = mapper.Map<Models.DTO.item>(item);
                return Ok(regionDTO);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync(Models.DTO.AddItemRequest addItemRequest)
        {
            //request to domain model
            var item = new Models.Domain.Item()
            {
                name = addItemRequest.name,
                price = addItemRequest.price

            };

            //pass details to repository

            item = await itemRepository.AddAsync(item);
            //Convert back to DTO

            var itemDTO = new Models.DTO.item
            {
                itemId = item.itemId,
                name = item.name,
                price = item.price

            };

            return CreatedAtAction(nameof(GetItemAsync), new { itemId = itemDTO.itemId }, itemDTO);
        }
    }
}
