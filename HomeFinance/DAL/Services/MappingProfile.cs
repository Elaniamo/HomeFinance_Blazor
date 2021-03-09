using AutoMapper;
using HomeFinance.DTO;
using HomeFinance.Model;
using HomeFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinance.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MoneyCategory, MoneyCategoryViewModel>();
            CreateMap<MoneyCategory, MoneyCategoryUpadateDto>();
            CreateMap<Transaction, TransactionViewModel>();
        }
    }
}
