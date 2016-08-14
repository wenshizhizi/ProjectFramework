using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Framework.DTO;

namespace Framework.MapperConfig
{
    public class MapConfiguration
    {
        /// <summary>
        /// 初始化automapper配置
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //TODO:配置对象的映射，如下
                cfg.CreateMap<Account, EHECD_AccountDTO>();
                cfg.CreateMap<EHECD_AccountDTO, Account>();
            });
        }
    }
}
