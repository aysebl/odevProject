using AutoMapper;
using MongoDB.Bson;
using Odev.Business.Model;
using Odev.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<ProductViewModel, ProductLookedUp>();
            CreateMap<ProductLookedUp, ProductViewModel>();
        }

        //public MappingProfile()
        //{
        //    CreateUserMappings();
        //    CreateProductMappings();
        //    CreateCategoryMappings();

        //    CreateMap<string, ObjectId?>().ConvertUsing(s => StringToObjectTypeConverter(s));
        //}

        //public ObjectId? StringToObjectTypeConverter(string source)
        //{
        //    if (string.IsNullOrEmpty(source))
        //    {
        //        return null;
        //    }
        //    return ObjectId.Parse(source);
        //}

        //public void CreateUserMappings()
        //{
        //    CreateMap<UserModel, User>().ReverseMap();
        //}

        //public void CreateProductMappings()
        //{
        //    CreateMap<ProductModel, Product>().ReverseMap();
        //}

        //public void CreateCategoryMappings()
        //{
        //    CreateMap<CategoryModel, Category>();
        //    CreateMap<Category, CategoryModel>().ReverseMap();
        //}

    }
}
