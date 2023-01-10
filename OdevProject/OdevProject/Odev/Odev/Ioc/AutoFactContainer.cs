using Autofac;
using AutoMapper;
using Odev.Business.Interfcae;
using Odev.Business.Services;
using Odev.DAL.MongoDbSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev.Ioc
{
    public class AutoFactContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<MongoDbSettings>().As<IMongoDbSettings>().InstancePerLifetimeScope();
            builder.RegisterType<RedisService>().As<IRedisService>().InstancePerLifetimeScope();
            builder.RegisterType<ShoppingCartService>().As<IShoppingCartService>().InstancePerLifetimeScope();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
