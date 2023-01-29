using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Runtime.InteropServices;
using WebApplication1.Models.DTO;
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
                var itemDTO = mapper.Map<Models.DTO.item>(item);
                return Ok(itemDTO);
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
            return Ok(itemDTO);

            //return CreatedAtAction(nameof(GetItemAsync), new { itemId = itemDTO.itemId }, itemDTO);
        }

        [HttpDelete]
        [Route("{itemId:guid}")]
        public async Task<IActionResult> DeleteItemAsymc(Guid itemId)
        {
            // Get item from database
            var item = await itemRepository.DeleteAsync(itemId);


            // If null NotFound
            if (itemId == null)
            {
                return NotFound();
            }


            // Convert response back to DTO

            var itemDTO = new Models.DTO.item
            {
                itemId = item.itemId,
                name = item.name,
                price = item.price

            };


            // return Ok response
            return Ok(itemDTO);

        }

        [HttpPut]
        [Route("{itemId:guid}")]
        public async Task<IActionResult> UpdateItem([FromRoute]Guid itemId, [FromBody] Models.DTO.UpdateItemRequest updateItem)
        {
            // convert DTO to Domain model

            var item = new Models.Domain.Item()
            {
                name = updateItem.name,
                price = updateItem.price

            };

            //Update Item using repository

              item= await itemRepository.UpdateAsync(itemId, item);


            //if null then notfound
            if (item == null)
            {
                return NotFound();
            }

            //convert domain back to DTO
            var itemDTO = new Models.DTO.item
            {
                itemId = item.itemId,
                name = item.name,
                price = item.price

            };

            //return ok responce
            return Ok(itemDTO);


        }

    }
}
