using HomeFinance.DTO;
using HomeFinance.Services;
using HomeFinance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeFinance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoneyCategoryController : Controller
    {
        private readonly MoneyCategoryService _category;
        private readonly ILogger<MoneyCategoryController> _logger;

        public MoneyCategoryController(MoneyCategoryService category, ILogger<MoneyCategoryController> logger)
        {
            _category = category;
            _logger = logger;
        }

        // GET: api/MoneyCategory/
        [HttpGet]
        public async Task<IEnumerable<MoneyCategoryViewModel>> Get()
        {
            return await _category.GetAllCategoriesAsync();
        }
        // GET: api/MoneyCategory/5
        [HttpGet("id")]
        public async Task<ActionResult<MoneyCategoryUpadateDto>> GetMoneyCategory([FromQuery] int id)
        {
            var category = await _category.GetMoneyCategoryByID(id);
            if (category == null)
                return NotFound();

            return category;
        }
        // POST: api/MoneyCategory/<string>
        [HttpPost]
        public async Task<ActionResult<MoneyCategoryViewModel>> PostMoneyCategory([FromBody] MoneyCategoryCreateDto mc)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!_category.TypeMoneyCategoryExists(mc.TypeCategoryId))
                return NotFound();

            var createdCategory = await _category.CreateMoneyCategoryAsync(mc);
            if (createdCategory == null)
                return BadRequest();

            return createdCategory;
        }
        // PUT api/MoneyCategory/5
        [HttpPut]
        public async Task<ActionResult<MoneyCategoryViewModel>> Put([FromBody] MoneyCategoryUpadateDto mc)
        {
            _logger.LogInformation(mc.Description, " in method PUT");

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_category.MoneyCategoryExists(mc.Id) || !_category.TypeMoneyCategoryExists(mc.TypeId))
                return NotFound();

            var updatedCategory = await _category.UpadateMoneyCategoryAsync(mc);
            if (updatedCategory == null)
                return NoContent();

            return updatedCategory;
        }
        // DELETE api/MoneyCategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            if (!_category.MoneyCategoryExists(id))
                return NotFound();

            if (_category.TransactionsByСategoryExists(id))
                return BadRequest();

            var deletedCategory = await _category.DeleteMoneyCategoryAsync(id);
            if (deletedCategory == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
