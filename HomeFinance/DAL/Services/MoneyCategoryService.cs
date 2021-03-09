using AutoMapper;
using HomeFinance.DTO;
using HomeFinance.Infrastructure;
using HomeFinance.Model;
using HomeFinance.Services.Base;
using HomeFinance.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.Services
{
    public class MoneyCategoryService : BaseService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public MoneyCategoryService(MyDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MoneyCategoryViewModel>> GetAllCategoriesAsync()
        {
            var Category = await _context.MoneyCategories.ToListAsync();
            return _mapper.Map<IEnumerable<MoneyCategory>, IEnumerable<MoneyCategoryViewModel>>(Category);
        }
        public async Task<MoneyCategoryUpadateDto> GetMoneyCategoryByID(int id)
        {
            var Category = await _context.MoneyCategories.FindAsync(id);
            return _mapper.Map<MoneyCategory, MoneyCategoryUpadateDto>(Category);
        }
        public async Task<MoneyCategoryViewModel> CreateMoneyCategoryAsync(MoneyCategoryCreateDto mc)
        {
            MoneyCategory newCategory = new MoneyCategory { Description = mc.NewName, TypeId = mc.TypeCategoryId};
            _context.MoneyCategories.Add(newCategory);

            return await GetSavedModelAsync(newCategory);
        }
        public async Task<MoneyCategoryViewModel> UpadateMoneyCategoryAsync(MoneyCategoryUpadateDto mc)
        {
            MoneyCategory Category = _context.MoneyCategories.Find(mc.Id);
            Category.Description = mc.Description;
            Category.TypeId = mc.TypeId;

            return await GetSavedModelAsync(Category);
        }
        public async Task<MoneyCategoryViewModel> DeleteMoneyCategoryAsync(int id)
        {
            MoneyCategory Category = _context.MoneyCategories.Find(id);
            _context.MoneyCategories.Remove(Category);

            return await GetSavedModelAsync(Category);
        }

        private MoneyCategoryViewModel GetMappedModel(MoneyCategory Category)
        {
            return _mapper.Map<MoneyCategory, MoneyCategoryViewModel>(Category);
        }
        private async Task<MoneyCategoryViewModel> GetSavedModelAsync(MoneyCategory Category)
        {
            try
            {
                await this._context.SaveChangesAsync();
                return GetMappedModel(Category);
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }
    }
}
