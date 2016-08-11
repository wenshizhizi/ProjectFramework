using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DI
{
    /// <summary>
    /// 依赖注入对象
    /// </summary>
    public class DIEntity
    {
        ///// <summary>
        ///// 注入配置对象
        ///// </summary>
        //private UnityConfigurationSection configuration =
        //   ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;

        //注入容器
        private UnityContainer container = null;

        /// <summary>
        /// 获取注入容器
        /// </summary>
        public UnityContainer Container
        {
            get
            {
                return container;
            }
        }

        /// <summary>
        /// 单例
        /// </summary>
        static DIEntity instance = new DIEntity();

        /// <summary>
        /// 构造函数
        /// </summary>
        private DIEntity()
        {
            container = new UnityContainer();
            
            //container.RegisterType(typeof(IRepository), typeof(FileRepository));
            //var repository = myContainer.Resolve<IRepository>();
            //初始化容器
            //configuration.Configure(container, "defaultContainer");
        }

        /// <summary>
        /// 获取注入对象实例
        /// </summary>
        /// <returns>注入对象</returns>
        public static DIEntity GetInstance()
        {
            return instance;
        }
    }
}
