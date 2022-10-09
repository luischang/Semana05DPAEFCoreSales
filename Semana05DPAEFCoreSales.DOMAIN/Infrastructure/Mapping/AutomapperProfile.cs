using AutoMapper;
using Semana05DPAEFCoreSales.DOMAIN.Core.DTOs;
using Semana05DPAEFCoreSales.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana05DPAEFCoreSales.DOMAIN.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {

        public AutomapperProfile()
        {

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerCountryDTO>();
            CreateMap<CustomerCountryDTO, Customer>();

            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<Customer, CustomerCreateDTO>();

            CreateMap<Customer, CustomerOrderDTO>();
            CreateMap<CustomerOrderDTO, Customer>();
            CreateMap<Order, OrderNumberAmountDTO>();
            CreateMap<OrderNumberAmountDTO, Order>();

        }



    }
}
