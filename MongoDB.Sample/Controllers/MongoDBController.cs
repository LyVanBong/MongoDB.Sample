using Microsoft.AspNetCore.Mvc;
using MongoDB.Sample.Models;
using MongoDB.Sample.Services;

namespace MongoDB.Sample.Controllers
{
    [Route("api/v1/MongoDB")]
    [ApiController]
    public class MongoDBController : ControllerBase
    {
        private readonly IItemService _itemService;
        public MongoDBController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public ActionResult<List<ItemModel>> Get() => _itemService.GetItems();
        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<ItemModel> Get(string id)
        {
            var res = _itemService.GetItem(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpPost]
        public ActionResult<ItemModel> Create(ItemModel item)
        {
            _itemService.Create(item);
            return Ok(item);
        }
        //[HttpPost]
        //public ActionResult<List<ItemModel>> Adds(List<ItemModel> items) => _itemService.Create(items);
        [HttpPut]
        public ActionResult Update(ItemModel item)
        {
            var ite = _itemService.GetItem(item.Id);
            if (ite == null) return NotFound();
            _itemService.UpdateItem(item);
            return Ok(ite);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(string id)
        {
            var res = _itemService.GetItem(id);
            if (res == null) return NotFound();
            _itemService.DeleteItem(id);
            return Ok("Xao thanh cong");
        }
        [HttpDelete]
        public ActionResult DeleteAll()
        {
            _itemService.DeleteItems();
            return Ok("Xoa thanh cong");
        }
    }
}
