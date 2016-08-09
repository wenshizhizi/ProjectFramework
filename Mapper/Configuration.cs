using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Framework.DTO;
using Framework.Domain;

namespace Framework.MapperConfig
{
    public class Configuration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<OrderGoodDTO, OrderGood>();
                cfg.CreateMap<RecevierAddressDTO, RecevierAddress>();
            });
        }
    }
}
